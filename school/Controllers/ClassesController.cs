using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using school.Models;
using school.Service;
using school.ViewModel;

namespace school.Controllers
{
    public class ClassesController : Controller
    {
        private IClassesService _classesService;
        private readonly ITeacherService _teacherService;

        public ClassesController(IClassesService classesService, ITeacherService teacherService)
        {
            _classesService = classesService;
            _teacherService = teacherService;
        }
        public async Task<IActionResult> Index() =>
            View(await _classesService.GetClassesAsync());

        public async Task<IActionResult> Create()
        {
            var teachers = await _teacherService.GetTeachersAsync();
            var availableTeachers = _teacherService.ToSelectedItemsAsync(teachers);
            var viewModel = new ClassVM() { AvailableTeachers = availableTeachers };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassVM classVM)
        {
            try
            {
                var model = await _classesService.CreateClassAsync(classVM);
                return View("Details", model);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Details(int classId)
        {
            ClassModel? classModel = await _classesService
                .FindClassByIdAsync(classId);
            if (classModel == null) { return RedirectToAction("Index"); }
            return View(classModel);
        }

    }
}
