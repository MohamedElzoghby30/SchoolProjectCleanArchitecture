using AutoMapper;
using MediatR;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Resluts;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Handel
{
    public class StudentHandilers:IRequestHandler<GetStudentListQuery, List<GetStudentListResponse>>
    {
        #region Fildes
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion
        #region Constractor
        public StudentHandilers(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion
        #region Handeler Functions
        public async Task<List<GetStudentListResponse>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var StudentsList= await _studentService.GetStudentsListAsync();
            var  StudentsResponse = _mapper.Map<List<GetStudentListResponse>>(StudentsList);
            return StudentsResponse;
        }
        #endregion
    }
}
