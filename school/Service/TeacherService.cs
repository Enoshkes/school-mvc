using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using school.Data;
using school.Models;
using school.ViewModel;

namespace school.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly ApplicationDbContext _context;

        public TeacherService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TeacherModel> AddTeacherAsync(TeacherVM teacherVM)
        {
            TeacherModel model = new()
            {
                FirstName = teacherVM.FirstName,
                LastName = teacherVM.LastName
            };
            await _context.Teachers.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<TeacherModel> DeleteTeacherAsync(int id)
        {
            TeacherModel? model = await FindTeacherByIdAsync(id);
            if (model == null)
            {
                throw new Exception($"Teacher by the id {id} does not exists");
            }
            _context.Teachers.Remove(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<TeacherModel?> FindTeacherByIdAsync(int id) =>
            await _context.Teachers.FindAsync(id);

        public async Task<List<TeacherModel>> GetTeachersAsync() =>
             await _context.Teachers.ToListAsync();

        public List<SelectListItem> ToSelectedItemsAsync(IEnumerable<TeacherModel> teachers) =>
            teachers.Select(t => new SelectListItem
            {
                Text = $"{t.FirstName} {t.LastName}",
                Value = $"{t.Id}"
            })
                .ToList();


        public async Task<TeacherModel> UpdateTeacherAsync(TeacherVM model)
        {
            TeacherModel? byId = await FindTeacherByIdAsync(model.Id);
            if (byId == null)
            {
                throw new Exception($"Teacher by the id {model.Id} does not exists");
            }
            byId.FirstName = model.FirstName;
            byId.LastName = model.LastName;
            await _context.SaveChangesAsync();
            return byId;
        }
    }
}
