using GraphQLSample.Data;
using GraphQLSample.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSample.Repasitories.Implements
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SchoolAppDbContext _context;
        public SchoolRepository(SchoolAppDbContext context)
            => _context = context;

        // Get all schools
        public async Task<List<School>> GetAllSchoolsAsync()
          => await _context.Schools.ToListAsync();


        // Get school by Id
        public async Task<School> GetSchoolByIdAsync(int id)
          => await _context.Schools.FirstOrDefaultAsync(s => s.SchoolId == id);


        // Add a new school
        public async Task<School> AddSchoolAsync(School school)
        {
            _context.Schools.Add(school);
            await _context.SaveChangesAsync();
            return school;
        }

        // Update an existing school
        public async Task<School> UpdateSchoolAsync(int id, School school)
        {
            var existingSchool = await _context.Schools.FindAsync(id);
            if (existingSchool == null) return null;

            // Update fields
            existingSchool.Name = school.Name;
            existingSchool.City = school.City;


            await _context.SaveChangesAsync();
            return existingSchool;
        }

        // Delete a school
        public async Task<School> DeleteSchoolAsync(int id)
        {
            var school = await _context.Schools.FindAsync(id);
            if (school == null) return null;

            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();
            return school;
        }
    }
}
