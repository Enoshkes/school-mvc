using Microsoft.AspNetCore.Mvc;
using school.Models;
using school.Service;
using school.ViewModel;

namespace school.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index() => 
            View(await _studentService.GetStudentsAsync());

        public IActionResult Create() => View(new StudentVM());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentVM student)
        {
            try
            {
                var model = await _studentService.CreateStudentAsync(student);
                return View("Details", model);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Details(int studentId)
        {
            StudentModel? student = await _studentService
                .FindStudentByIdAsync(studentId);
            if (student == null) { return RedirectToAction("Index"); }
            return View(student);
        }
    }
}
