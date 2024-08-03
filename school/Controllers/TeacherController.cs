using Microsoft.AspNetCore.Mvc;
using school.Models;
using school.Service;
using school.ViewModel;

namespace school.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        public async Task<IActionResult> Index() =>
            View(await _teacherService.GetTeachersAsync());

        public IActionResult Create() => View(new TeacherVM());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherVM model)
        {
            await _teacherService.AddTeacherAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int teacherId)
        {
            TeacherModel? teacher = await _teacherService.FindTeacherByIdAsync(teacherId);
            if (teacher == null) { return RedirectToAction("Index"); }
            return View(teacher);
        }

        public async Task<IActionResult> Edit(int teacherId)
        {
            var teacher = await _teacherService.FindTeacherByIdAsync(teacherId);
            if (teacher == null) 
            {
                return RedirectToAction("Index");
            }
            return View(new TeacherVM
            {
                Id = teacherId,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TeacherVM teacherVM)
        {
            try
            {
                var model = await _teacherService.UpdateTeacherAsync(teacherVM);
                return RedirectToAction("Details", new { teacherId = model.Id });
            }
            catch
            {
               return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Delete(int teacherId)
        {
            try
            {
                await _teacherService.DeleteTeacherAsync(teacherId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("deleteError",ex.Message);
                return View("Index", await _teacherService.GetTeachersAsync());
            }
        } 
    }
}
