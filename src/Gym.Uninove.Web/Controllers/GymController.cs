using Gym.Uninove.Core.Entities;
using Gym.Uninove.Core.Interfaces.Repository;
using Gym.Uninove.Web.Models;
using Gym.Uninove.Web.Models.ViewModels;
using Gym.Uninove.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace Gym.Uninove.Web.Controllers
{
    public class GymController : Controller
    {

        private readonly IGymBranchRepository _gymRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ImageUploadService _imageUploadService;
        private readonly int PageSize = 9; // Número de itens por página

        public GymController(IGymBranchRepository gymRepository, IAddressRepository addressRepository, ImageUploadService imageUploadService)
        {
            this._gymRepository = gymRepository;
            this._addressRepository = addressRepository;
            this._imageUploadService = imageUploadService;
        }

        public async Task<IActionResult> Index(int? page)
        {

            var userSession = HttpContext.Session.GetString("CurrentUser");
            UserSession userCurrent = null;

            // Desserializa a string JSON para um objeto UserSession
            if (!string.IsNullOrEmpty(userSession))
            {
                userCurrent = JsonConvert.DeserializeObject<UserSession>(userSession);
                TempData["Admin"] = userCurrent.Role == "2" ? true : false;
            }


            var pageNumber = page ?? 1; // Número da página atual
            var gyms = await _gymRepository.GetAll(); // Obtenha todos os registros (gym)

            // Converta a tarefa para a lista real de gyms
            var gymList = gyms.ToList();

            // Use o método ToPagedList() para paginar a lista
            var pagedList = gymList.ToPagedList(pageNumber, PageSize);

            return View(pagedList);

            //return View(await this._gymRepository.GetAll());
        }


        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GymBranchViewModel gymViewModel)
        {
            if(!ModelState.IsValid) { return View(gymViewModel); }

            try
            {

                var newGym = new GymBranch
                {
                    Name = gymViewModel.GymBranch.Name,
                    UnitNumber = gymViewModel.GymBranch.UnitNumber,
                    Phone = gymViewModel.GymBranch.Phone
                };

                if (!await this.IsGymBranchUniqueAsync(newGym)) 
                {
                    ModelState.AddModelError(string.Empty, "UnitNumber, Phone, or Name must be unique");
                    return View(gymViewModel);
                }

                if (gymViewModel.ImageFile != null && gymViewModel.ImageFile.Length > 0)
                {
                    var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images/gym");
                    var imagePath = await _imageUploadService.UploadImageAsync(gymViewModel.ImageFile, uploadFolder);
                    gymViewModel.GymBranch.ImagePath = imagePath;

                    newGym.ImagePath = gymViewModel.GymBranch.ImagePath;
                }
                else
                {
                    newGym.ImagePath = "/images/gym/default-gym-image.jpg";
                }

                await this._gymRepository.Add(newGym);
                await this._gymRepository.SaveChangesAsync();

                int gymId = newGym.Id;

                newGym = await this._gymRepository.GetById(gymId);

                var newAddress = new Address
                {
                    Street = gymViewModel.Address.Street,
                    Number = gymViewModel.Address.Number,
                    City = gymViewModel.Address.City,
                    State = gymViewModel.Address.State,
                    Neighborhood = gymViewModel.Address.Neighborhood,
                    Complement = gymViewModel.Address.Complement,
                    ZipCode = gymViewModel.Address.ZipCode,
                    GymId = gymId  // Set the GymId to the Id of the new GymBranch
                };

                newGym.Address = newAddress;

                await this._addressRepository.Add(newAddress);
                await this._addressRepository.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Um erro ocorreu ao adicionar Gym. Tente mais tarde.");
                return View(gymViewModel);
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            var gym = await this._gymRepository.GetGymWithAddress(id);
            var gymViewModel = new GymBranchViewModel
            {
                Address = gym.Address,
                GymBranch = gym
            };

            return View(gymViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GymBranchViewModel gym)
        {
            try
            {
                var oldGym = await this._gymRepository.GetGymWithAddress(id);
                if(oldGym == null) return View(gym);

                oldGym.Name = gym.GymBranch.Name;
                oldGym.Phone = gym.GymBranch.Phone;
                oldGym.UnitNumber = gym.GymBranch.UnitNumber;

                oldGym.Address.Street = gym.Address.Street;
                oldGym.Address.Number = gym.Address.Number;
                oldGym.Address.Neighborhood = gym.Address.Neighborhood;
                oldGym.Address.ZipCode = gym.Address.ZipCode;
                oldGym.Address.City = gym.Address.City;
                oldGym.Address.State = gym.Address.State;
                oldGym.Address.Complement = gym.Address.Complement;

                await this._gymRepository.Update(oldGym);
                await this._gymRepository.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro ao alterar a academia. Por favor, tente novamente mais tarde.");
                return View(gym);
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            var gym = await this._gymRepository.GetGymWithAddress(id);
            if (gym == null) 
            {
                ModelState.AddModelError(string.Empty, "Gym não encontrada.");
                return RedirectToAction(nameof(Index));
            }

            return View(gym);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var gym = await this._gymRepository.GetGymWithAddress(id);
                if (gym == null)
                {
                    ModelState.AddModelError(string.Empty, "Gym não encontrada.");
                    return View(gym);
                }

                await this._gymRepository.Delete(id);
                await this._gymRepository.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Erro ao remover Gym. Tente mais tarde.");
                return View();
            }

        }


        // Method Check Properties
        public async Task<bool> IsGymBranchUniqueAsync(GymBranch gymBranch)
        {
            var gyms = await _gymRepository.GetAll();
            return !gyms.Any(g =>
                g.UnitNumber == gymBranch.UnitNumber ||
                g.Phone == gymBranch.Phone ||
                g.Name == gymBranch.Name);
        }

    }
}
