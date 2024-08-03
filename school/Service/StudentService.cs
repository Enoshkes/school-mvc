using Microsoft.EntityFrameworkCore;
using school.Data;
using school.Models;
using school.ViewModel;

namespace school.Service
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;
        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StudentModel?> CreateStudentAsync(StudentVM student)
        {
            StudentModel? byEmail = await FindStudentByEmailAsync(student.Email);
            if (byEmail != null) { 
                throw new Exception($"Student by the email {student.Email} is already exists"); 
            }
            StudentModel model = new()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
            };
            await _context.Students.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<StudentModel?> FindStudentByEmailAsync(string email) =>
            await _context.Students.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<StudentModel?> FindStudentByIdAsync(int id) =>
            await _context.Students.FindAsync(id);

        public async Task<List<StudentModel>> GetStudentsAsync() =>
            await _context.Students.ToListAsync();
    }
}
