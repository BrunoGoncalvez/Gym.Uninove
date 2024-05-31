using Gym.Uninove.Core.Entities.Users;
using Gym.Uninove.Core.Interfaces.Repository;
using Gym.Uninove.Web.Models;
using Gym.Uninove.Web.Models.ViewModels;
using Gym.Uninove.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gym.Uninove.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Index()
        {
            return View(await this._userRepository.GetAll());
        }


        public ActionResult Details(int id)
        {
            return View();
        }

        [AuthenticatedUserRedirectFilter]
        public ActionResult Authentication()
        {
            return View();
        }

        [HttpPost]
        [AuthenticatedUserRedirectFilter]
        public async Task<IActionResult> Authentication(UserLoginViewModel login)
        {

            if (login == null) return View(login);

            if(!ModelState.IsValid) return View(login);

            try
            {
                login.Password = EncryptService.HashPassword(login.Password);
                var users = await this._userRepository.GetAll();
                var user = users.Where(u => u.Email == login.Email && u.Password == login.Password).FirstOrDefault();

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "E-mail ou senha incorretos.");
                    return View(login);
                }

                var token = TokenService.GenerateTokens(user);

                var userSession = new UserSession { Email = user.Email, Name = user.Name, Role = ((int)user.Role).ToString() };

                HttpContext.Session.SetString("CurrentUser", JsonConvert.SerializeObject(userSession));

                // Armazene o token em um cookie ou retorne como resposta
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddHours(2)
                };

                Response.Cookies.Append("jwt", token, cookieOptions);
                return RedirectToAction(nameof(Index), "Home");

            }
            catch (Exception)
            {
                throw;
            }
        }

        [AuthenticatedUserRedirectFilter]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthenticatedUserRedirectFilter]
        public async Task<IActionResult> Create(UserViewModel user)
        {
            // TODO: Adicionar Profile
            // TODO: Ajustar Membership
            if(!ModelState.IsValid) return View(user);


            try
            {
                // Verifica se o e-mail já existe no banco de dados
                var users = await this._userRepository.GetAll();

                if (users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Este e-mail já está em uso.");
                    return View(user);
                }

                if (!user.AcceptTerms)
                {
                    ModelState.AddModelError("AcceptTerms", "Você deve aceitar os termos.");
                    return View(user);
                }

                user.Password = EncryptService.HashPassword(user.Password);
                user.Role = Core.Enums.TypeUser.Default;
                var newUser = this.ConvertUser(user);

                await this._userRepository.Add(newUser);
                await this._userRepository.SaveChangesAsync();
                TempData["CadastroSucesso"] = true;

                return RedirectToAction(nameof(Authentication));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro ao realizar o cadastro. Tente mais tarde.");
                return View(user);
            }

        }


        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            TempData["AccessDenied"] = "Acesso Negado";
            return View();
        }

        public IActionResult Logout()
        {
            // Limpa o cookie "jwt" no lado do cliente
            Response.Cookies.Delete("jwt");

            // Limpa a session "CurrentUser" no lado do servidor
            HttpContext.Session.Remove("CurrentUser");

            // Redireciona para a página de login ou outra página de sua escolha
            return RedirectToAction(nameof(Index), "Home");
        }


        private User ConvertUser(UserViewModel model)
        {
            return new User
            {
                Email = model.Email,
                Password = model.Password,
                Role = model.Role,
                Name = model.Name,
            };
        }

    }
}
