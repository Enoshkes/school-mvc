using System.ComponentModel.DataAnnotations;

namespace school.Models
{
    public class ClassModel
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public required string Name { get; set; }
        public List<StudentModel> Students { get; set; } = [];
        public TeacherModel? Teahcher { get; set; }
        public int TeacherId { get; set; }

    }
}
