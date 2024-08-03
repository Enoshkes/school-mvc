using Microsoft.AspNetCore.Mvc.Rendering;
using school.Models;
using school.ViewModel;

namespace school.Service
{
    public interface ITeacherService
    {
        Task<List<TeacherModel>> GetTeachersAsync();

        Task<TeacherModel?> FindTeacherByIdAsync(int id);

        Task<TeacherModel> UpdateTeacherAsync(TeacherVM model);

        Task<TeacherModel> DeleteTeacherAsync(int id);

        Task<TeacherModel> AddTeacherAsync(TeacherVM teacherVM);
        List<SelectListItem> ToSelectedItemsAsync(IEnumerable<TeacherModel> teachers);
    }
}
