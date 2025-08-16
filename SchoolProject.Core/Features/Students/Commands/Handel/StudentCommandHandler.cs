using AutoMapper;
using MediatR;
using SchoolProject.Core.Basic;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Handel
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
                                                        , IRequestHandler<EditStudentCommand, Response<string>>


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
           if (Reslut == "Success")
              return Success<string>("Added Done");
            else 
                return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            //check Id is exsit 
            var studentDB = await _studentService.GetStudentByIdAsync(request.StudID);
            if (studentDB == null)
                return NotFound<string>("Student Not Found");
            // Map
             var StudentMapping = _mapper.Map<Student>(request);
             var Reslut = await _studentService.UpdateStudentAsync(StudentMapping);
       
            if (Reslut == "Success")
                return Success<string>($"Update Succees for StudentId {studentDB.StudID}");
            else
                return BadRequest<string>();
        }
    }
}
