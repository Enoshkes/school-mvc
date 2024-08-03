using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace school.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class StudentModel
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public required string FirstName { get; set; }
        
        [Required, StringLength(100)]
        public required string LastName { get; set; }

        [Required, StringLength(255)]
        public required string Email { get; set; }

        public List<ClassModel> Classes { get; set; } = [];
    }
}
