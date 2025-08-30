using AutoMapper;
using MediatR;
using SchoolProject.Core.Basic;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Resluts;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Students.Queries.Handel
{
    public class StudentQueryHandilers: ResponseHandler , IRequestHandler<GetStudentListQuery, Response<List<GetStudentResponse>>>
                                                        , IRequestHandler<GetStudentByIdQuery, Response<GetStudentResponse>>
                                                        , IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
    
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

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudID,e.Name,e.Address,e.Department.DName);
            var Filter = _studentService.FilterStudentsPagnatedQuerable(request.Search);
            var pagnated = await Filter.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return pagnated;
        }
        #endregion
    }
}
