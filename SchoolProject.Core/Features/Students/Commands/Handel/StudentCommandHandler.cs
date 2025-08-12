using AutoMapper;
using MediatR;
using SchoolProject.Core.Basic;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System.ComponentModel.Design;

namespace SchoolProject.Core.Features.Students.Commands.Handel
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
    { 
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentCommandHandler(IMapper mapper , IStudentService studentService)
        {
            _mapper = mapper;
            _studentService = studentService;
        }

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var StudentMapping = _mapper.Map<Student>(request);
            var Reslut= await _studentService.AddStudentAsync(StudentMapping);
            if (Reslut == "Not Exist")
                return UnprocessableEntity<string>("this element not exsit");
            else if (Reslut == "Success")
              return Success<string>("Added Done");
            else 
                return BadRequest<string>();
        }
    }
}
