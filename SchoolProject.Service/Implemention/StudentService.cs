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
        #endregion
    }
}
