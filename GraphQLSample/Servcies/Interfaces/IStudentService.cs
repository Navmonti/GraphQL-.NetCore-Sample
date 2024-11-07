using GraphQLSample.Model.Entities;

namespace GraphQLSample.Servcies.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> AddStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(int id, Student student);
        Task<Student> DeleteStudentAsync(int id);
    }
}
