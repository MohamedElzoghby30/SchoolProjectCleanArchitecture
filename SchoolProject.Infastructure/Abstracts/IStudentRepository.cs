using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infastructure.Abstracts
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsListAsync();
    }
}
