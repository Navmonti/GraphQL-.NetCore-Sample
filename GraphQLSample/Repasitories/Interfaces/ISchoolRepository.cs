using GraphQLSample.Model.Entities;

namespace GraphQLSample.Repasitories.Implements
{
    public interface ISchoolRepository
    {
        Task<List<School>> GetAllSchoolsAsync();
        Task<School> GetSchoolByIdAsync(int id);
        Task<School> AddSchoolAsync(School school);
        Task<School> UpdateSchoolAsync(int id, School school);
        Task<School> DeleteSchoolAsync(int id);
    }
}
