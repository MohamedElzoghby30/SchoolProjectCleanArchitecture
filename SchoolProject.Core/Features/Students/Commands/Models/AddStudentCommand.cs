using Azure;
using MediatR;
using SchoolProject.Core.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand : IRequest<Basic.Response<string>>
    {
        public AddStudentCommand( )
        {
            
        }
        [Required]
        public int StudID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int DID { get; set; }
    }
}
