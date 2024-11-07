using GraphQLSample.Model.Entities;

namespace GraphQLSample.Servcies.Interfaces
{
    public interface ISchoolService
    {
        Task<List<School>> GetAllSchoolsAsync();
        Task<School> GetSchoolByIdAsync(int id);
        Task<School> AddSchoolAsync(School school);
        Task<School> UpdateSchoolAsync(int id, School school);
        Task<School> DeleteSchoolAsync(int id);
    }
}
