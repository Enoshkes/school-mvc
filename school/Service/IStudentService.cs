using school.Models;
using school.ViewModel;

namespace school.Service
{
    public interface IStudentService
    {
        Task<List<StudentModel>> GetStudentsAsync();

        Task<StudentModel?> CreateStudentAsync(StudentVM student);

        Task<StudentModel?> FindStudentByIdAsync(int id);

        Task<StudentModel?> FindStudentByEmailAsync(string email);
    }
}
