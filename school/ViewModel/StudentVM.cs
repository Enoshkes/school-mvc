using System.ComponentModel.DataAnnotations;

namespace school.ViewModel
{
    public class StudentVM
    {
        public int Id { get; set; }
        [Required, StringLength(100, MinimumLength = 3)]
        public string FirstName { get; set; } = string.Empty;
        [Required, StringLength(100, MinimumLength = 3)]
        public string LastName { get; set; } = string.Empty;
        [Required, StringLength(255), EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; } = string.Empty;
    }
}