using GraphQLSample.Model.Entities;
using GraphQLSample.Repasitories.Implements;
using GraphQLSample.Servcies.Interfaces;

namespace GraphQLSample.Servcies.Implements
{
    public class StudentService: IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
            => _studentRepository = studentRepository;

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            try
            {
                return await _studentRepository.GetAllStudentsAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while fetching students.", ex);
            }
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            try
            {
                return await _studentRepository.GetStudentByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while fetching the student with ID {id}.", ex);
            }
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            try
            {
                return await _studentRepository.AddStudentAsync(student);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding the student.", ex);
            }
        }

        public async Task<Student> UpdateStudentAsync(int id, Student student)
        {
            try
            {
                return await _studentRepository.UpdateStudentAsync(id, student);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while updating the student with ID {id}.", ex);
            }
        }

        public async Task<Student> DeleteStudentAsync(int id)
        {
            try
            {
                return await _studentRepository.DeleteStudentAsync(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while deleting the student with ID {id}.", ex);
            }
        }
    }
}
