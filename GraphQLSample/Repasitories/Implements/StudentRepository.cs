using GraphQLSample.Data;
using GraphQLSample.Model.Entities;
using GraphQLSample.Model.Enums;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSample.Repasitories.Implements
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolAppDbContext _context;
        public StudentRepository(SchoolAppDbContext context)
            => _context = context;

        // Get all students
        public async Task<List<Student>> GetAllStudentsAsync()
          => await _context.Students.Include(x => x.School).ToListAsync();


        // Get student by Id
        public async Task<Student> GetStudentByIdAsync(int id)
          => await _context.Students.Include(x => x.School).FirstOrDefaultAsync(s => s.StudentId == id);


        // Add a new student
        public async Task<Student> AddStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        // Update an existing student
        public async Task<Student> UpdateStudentAsync(int id, Student student)
        {
            var existingStudent = await _context.Students.FindAsync(id);
            if (existingStudent == null) return null;

            // Update fields
            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.GradeLevel = student.GradeLevel;
            existingStudent.Major = student.Major;
            existingStudent.School = student.School;


            await _context.SaveChangesAsync();
            return existingStudent;
        }

        // Delete a student
        public async Task<Student> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return null;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }

    }
}
