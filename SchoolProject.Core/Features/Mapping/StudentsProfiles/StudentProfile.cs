using AutoMapper;
using SchoolProject.Core.Features.Students.Queries.Resluts;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Mapping.StudentsProfiles
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentListMapping();
            AddStudentMapping();
            EditStudentMapping();

        }
    }
}
