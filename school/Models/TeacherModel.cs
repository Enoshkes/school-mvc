using System.ComponentModel.DataAnnotations;

namespace school.Models
{
    public class TeacherModel
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public required string FirstName { get; set; }
        [Required, StringLength(100)]
        public required string LastName { get; set; }
        public List<ClassModel> Classes { get; set; } = [];
    }
}
