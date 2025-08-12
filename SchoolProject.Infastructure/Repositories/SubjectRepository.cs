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
    public class SubjectRepository : ISubjectRepository
    {
        #region Fields 
        private readonly ApplicationDbContext _applicationDbContext;
        #endregion
        #region Constractor
        public SubjectRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        #endregion
        #region Handeler Functions
        public async Task<List<Subjects>> GetAllSubjectAsync()
        {
           return await _applicationDbContext.Subjects.ToListAsync();
        }
        #endregion
    }
}
