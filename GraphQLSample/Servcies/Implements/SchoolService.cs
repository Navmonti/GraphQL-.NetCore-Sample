using GraphQLSample.Model.Entities;
using GraphQLSample.Repasitories.Implements;
using GraphQLSample.Servcies.Interfaces;

namespace GraphQLSample.Servcies.Implements
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolService(ISchoolRepository schoolRepository)
            => _schoolRepository = schoolRepository;

        public async Task<List<School>> GetAllSchoolsAsync()
        {
            try
            {
                return await _schoolRepository.GetAllSchoolsAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                throw new ApplicationException("An error occurred while fetching cities.", ex);
            }
        }

        public async Task<School> GetSchoolByIdAsync(int id)
        {
            try
            {
                return await _schoolRepository.GetSchoolByIdAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                throw new ApplicationException($"An error occurred while fetching the school with ID {id}.", ex);
            }
        }

        public async Task<School> AddSchoolAsync(School school)
        {
            try
            {
                return await _schoolRepository.AddSchoolAsync(school);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                throw new ApplicationException("An error occurred while adding the school.", ex);
            }
        }

        public async Task<School> UpdateSchoolAsync(int id, School school)
        {
            try
            {
                return await _schoolRepository.UpdateSchoolAsync(id, school);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                throw new ApplicationException($"An error occurred while updating the school with ID {id}.", ex);
            }
        }

        public async Task<School> DeleteSchoolAsync(int id)
        {
            try
            {
                return await _schoolRepository.DeleteSchoolAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                throw new ApplicationException($"An error occurred while deleting the school with ID {id}.", ex);
            }
        }
    }
}
