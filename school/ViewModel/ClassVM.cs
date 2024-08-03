using Microsoft.AspNetCore.Mvc.Rendering;
using school.Models;
using System.ComponentModel.DataAnnotations;

namespace school.ViewModel
{
    public class ClassVM
    {
        [Required, StringLength(50, MinimumLength = 4)]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Teacher")]
        public int? SelectedTeacherId { get; set; }

        public List<SelectListItem> AvailableTeachers { get; set; } = [];
        public List<StudentModel> Students { get; set; } = [];
    }
}
