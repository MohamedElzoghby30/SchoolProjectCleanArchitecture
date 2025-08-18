using MediatR;
using SchoolProject.Core.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommand :IRequest<Response<string>>
    {
        public int ID { get; set; }
        public DeleteStudentCommand(int id)
        {
            ID=id;
        }
    }
}
