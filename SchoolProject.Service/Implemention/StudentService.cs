using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infastructure.Abstracts;
using SchoolProject.Infastructure.Data;
using SchoolProject.Infastructure.Repositories;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Implemention
{
    public class StudentService : IStudentService
    {
        #region Fields 
        private readonly IStudentRepository _studentRepository;
        #endregion

        #region Constractor
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

      
        #endregion
        #region Handeler Functions
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetStudentsListAsync();
        }
        public async Task<string> AddStudentAsync(Student student)
        {
              await _studentRepository.AddAsync(student);
                return "Success";
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetTableNoTracking()
                .Where(x => x.StudID.Equals(id))
                .Include(x => x.Department)
                .FirstOrDefaultAsync();
            return student;
        }

        public async Task<bool> IsExsitAsync(string Name)
        {
            var StudentReslut = await _studentRepository
               .GetTableNoTracking()
               .Where(x => x.Name == Name)
               .FirstOrDefaultAsync();
            if (StudentReslut == null) return false;
            return true;
        }

        public async Task<string> UpdateStudentAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";

        }

        public async Task<string> DeleteAsync(Student student)
        {
            var Trans = _studentRepository.BeginTransaction();
            try
            {
               await _studentRepository.DeleteAsync(student);
                Trans.Commit();
                return "Success";
            }
            catch (Exception)
            {

               Trans.Rollback();
                return "Faild";
            }
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetTableNoTracking()
                .Where(x => x.StudID.Equals(id))
                .FirstOrDefaultAsync();
            return student;
        }

        #endregion
    }
}
