using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Mapping.StudentsProfiles
{
    public partial class StudentProfile
    {
        public void EditStudentMapping()
        {

            CreateMap<EditStudentCommand, Student>()
               .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DID))
               .ForMember(dest=>dest.StudID, opt => opt.MapFrom(src => src.StudID));

        }
    }
}
