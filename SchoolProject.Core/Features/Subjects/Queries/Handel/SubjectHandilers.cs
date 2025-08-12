using MediatR;
using SchoolProject.Core.Features.Subjects.Queries.Models;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Subjects.Queries.Handel
{
    public class SubjectHandilers : IRequestHandler<GetAllSubjectQuery, List<Data.Entities.Subjects>>
    {
        private readonly ISubjectService _subjectService;

        public SubjectHandilers(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        public async Task<List<Data.Entities.Subjects>> Handle(GetAllSubjectQuery request, CancellationToken cancellationToken)
        {
            return await _subjectService.GetSubjectsAsync();
        }
    }
}
