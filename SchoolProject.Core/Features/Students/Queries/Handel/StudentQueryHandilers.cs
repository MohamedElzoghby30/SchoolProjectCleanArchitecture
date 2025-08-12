using AutoMapper;
using MediatR;
using SchoolProject.Core.Basic;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Resluts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Queries.Handel
{
    public class StudentQueryHandilers: ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetStudentResponse>>>
                                                        , IRequestHandler<GetStudentByIdQuery, Response<GetStudentResponse>>
    {
        #region Fildes
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion
        #region Constractor
        public StudentQueryHandilers(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion
        #region Handeler Functions
        public async Task<Response<List<GetStudentResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var StudentsList= await _studentService.GetStudentsListAsync();
            var  StudentsResponse = _mapper.Map<List<GetStudentResponse>>(StudentsList);
            return Success(StudentsResponse);
        }

        public async Task<Response<GetStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            if (student == null) 
               return NotFound<GetStudentResponse>();
            var StudentResponse = _mapper.Map<GetStudentResponse>(student);
            return Success(StudentResponse);

        }
        #endregion
    }
}
