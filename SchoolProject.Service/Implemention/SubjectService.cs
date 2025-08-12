using SchoolProject.Data.Entities;
using SchoolProject.Infastructure.Abstracts;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Implemention
{
    public class SubjectService : ISubjectService
    {

        #region Fields
        private readonly ISubjectRepository _subjectRepository;
        #endregion
        #region Constractor
        public SubjectService(ISubjectRepository subjectRepository)
        {
           _subjectRepository = subjectRepository;
        }
        #endregion
        #region Handeler Functions
        public async Task<List<Subjects>> GetSubjectsAsync()
        {
           return await _subjectRepository.GetAllSubjectAsync();
        }
        #endregion
    }
}
