using Gym.Uninove.Core.Entities;
using Gym.Uninove.Core.Interfaces.Repository;
using Gym.Uninove.Web.Models;
using Gym.Uninove.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gym.Uninove.Web.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class EquipmentController : Controller
    {

        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentController(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var userSession = HttpContext.Session.GetString("CurrentUser");
            UserSession userCurrent = null;

            // Desserializa a string JSON para um objeto UserSession
            if (!string.IsNullOrEmpty(userSession))
            {
                userCurrent = JsonConvert.DeserializeObject<UserSession>(userSession);
                TempData["Admin"] = userCurrent.Role == "2" ? true : false;
            }

            return View(await this._equipmentRepository.GetAll());
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
        public async Task<IActionResult> Create(EquipmentViewModel model)
        {

            if(!ModelState.IsValid) return View(model);

            try
            {

                var equipment = new Equipment
                {
                    Name = model.Name,
                    StatusPurchase = model.StatusPurchase,
                    DatePurchase = model.DatePurchase,
                    UsageTime = DateTime.Now
                };

                await this._equipmentRepository.Add(equipment);
                await this._equipmentRepository.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var quipment = await this._equipmentRepository.GetById(id);
            return View(quipment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Equipment equipment)
        {

            if(!ModelState.IsValid) return View(equipment);
            if(id != equipment.Id) return View(equipment);

            try
            {
                await this._equipmentRepository.Update(equipment);
                await _equipmentRepository.SaveChangesAsync();
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
    }
}
