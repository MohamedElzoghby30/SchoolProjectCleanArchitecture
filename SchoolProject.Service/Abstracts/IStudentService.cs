using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsListAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<Student> GetByIdAsync(int id);
        public Task<string> AddStudentAsync(Student student);
        public Task<string> UpdateStudentAsync(Student student);
        public Task<bool> IsExsitAsync(string Name);
        public Task<string> DeleteAsync(Student student);
    }
}
