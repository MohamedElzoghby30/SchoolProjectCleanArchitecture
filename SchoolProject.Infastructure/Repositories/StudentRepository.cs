using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infastructure.Abstracts;
using SchoolProject.Infastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {

        #region Fields 
        private readonly ApplicationDbContext _applicationDbContext;
        #endregion

        #region Constractor
        public StudentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        #endregion
        #region Handeler Functions
        public async Task<List<Student>> GetStudentsListAsync()
        {
           return await _applicationDbContext.Students.Include(x=>x.Department).ToListAsync();
        }
        #endregion
    }
}
