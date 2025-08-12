using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Subjects.Queries.Models;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubjectController(IMediator mediator)
        {
          _mediator = mediator;
        }
        [HttpGet("/Subjects/list")]
        public async Task<IActionResult> GetAllSubjects()
        {

            var Res = await _mediator.Send(new GetAllSubjectQuery() );
            return Ok( Res );
        }


    }
}
