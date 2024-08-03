using school.Models;
using school.ViewModel;

namespace school.Service
{
    public interface IClassesService
    {
        Task<List<ClassModel>> GetClassesAsync();
        Task<ClassModel?> FindClassByIdAsync(int id);
        Task<ClassModel> AddTeacherToClassAsync(int classId, TeacherModel model);
        Task<ClassModel> CreateClassAsync(ClassVM vm);
    }
}
