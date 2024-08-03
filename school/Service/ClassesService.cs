using Microsoft.EntityFrameworkCore;
using school.Data;
using school.Models;
using school.ViewModel;

namespace school.Service
{
    public class ClassesService : IClassesService
    {
        private readonly ApplicationDbContext _context;

        public ClassesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ClassModel> AddTeacherToClassAsync(int classId, TeacherModel model)
        {
            ClassModel? byId = await FindClassByIdAsync(classId);
            if (byId == null)
            {
                throw new Exception($"Class by the Id {classId} doesnt found");
            }
            byId.Teahcher = model;
            await _context.SaveChangesAsync();
            return byId;
        }

        public async Task<ClassModel> CreateClassAsync(ClassVM vm)
        {
            var teacher = await _context.Teachers.FindAsync(vm.SelectedTeacherId);
            if (teacher == null)
            {
                throw new Exception($"Teacher by the id {vm.SelectedTeacherId} does not exists");
            }
            ClassModel model = new () { Name = vm.Name, Teahcher = teacher };
            await _context.Classes.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<ClassModel?> FindClassByIdAsync(int id) => 
            await _context.Classes
            .Include(c => c.Teahcher)
            .Include(c => c.Students)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<ClassModel>> GetClassesAsync() =>
            await _context.Classes.ToListAsync();
    }
}
