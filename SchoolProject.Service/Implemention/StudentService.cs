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
           var StudentReslut=await _studentRepository
                .GetTableNoTracking()
                .Where(x=>x.Name==student.Name)
                .FirstOrDefaultAsync();
            if (StudentReslut != null) return "Not Exist";
            else {

              await _studentRepository.AddAsync(student);
                return "Success";
            }
               

        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetTableNoTracking()
                .Where(x => x.StudID.Equals(id))
                .Include(x => x.Department)
                .FirstOrDefaultAsync();
            return student;
        }
        #endregion
    }
}
