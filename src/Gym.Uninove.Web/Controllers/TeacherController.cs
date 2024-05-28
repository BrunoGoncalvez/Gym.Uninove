using Gym.Uninove.Core.Entities;
using Gym.Uninove.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Uninove.Web.Controllers
{
    public class TeacherController : Controller
    {

        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            this._teacherRepository = teacherRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this._teacherRepository.GetAll());
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
        public async Task<IActionResult> Create(Teacher teacher)
        {
            try
            {
                if (!ModelState.IsValid) return View(teacher);

                await this._teacherRepository.Add(teacher);
                await this._teacherRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro ao adicionar Instrutor. Tente mais tarde.");
                return View(teacher);
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            var teacher = await this._teacherRepository.GetById(id);
            return View(teacher);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Teacher newTeacher)
        {
            try
            {
                if (!ModelState.IsValid) return View(newTeacher);
                var oldTeacher = await this._teacherRepository.GetById(id);

                oldTeacher.Name = newTeacher.Name;
                oldTeacher.Description = newTeacher.Description;

                await this._teacherRepository.Update(oldTeacher);
                await this._teacherRepository.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro ao alterar Instrutor. Tente mais tarde.");
                return View(newTeacher);
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await this._teacherRepository.GetById(id);
            if (teacher == null)
            {
                ModelState.AddModelError(string.Empty, "Instrutor não encontrada.");
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, Teacher teacher)
        {
            try
            {
                var oldTeacher = await this._teacherRepository.GetById(id);
                if (teacher.Id != oldTeacher.Id)
                {
                    ModelState.AddModelError(string.Empty, "Instrutor não encontrado.");
                    return View(teacher);
                }

                await this._teacherRepository.Delete(teacher.Id);
                await this._teacherRepository.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro ao Remover Instrutor");
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
