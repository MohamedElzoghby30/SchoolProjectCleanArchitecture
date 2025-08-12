using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _medatior;

        public StudentController(IMediator medatior)
        {
            _medatior = medatior;
        }

        [HttpGet("/Student/AllStudent")]
        public async Task<IActionResult> GetStudentsListAsync()
        {
            var result = await _medatior.Send(new GetStudentListQuery());
            return Ok(result);
        }
        [HttpGet("/Student/{id}/")]
        public async Task<IActionResult> GetStudentsByIdAsync( [FromRoute]int id)
        {
            var result = await _medatior.Send(new GetStudentByIdQuery(id));
            return Ok(result);
        }
        [HttpPost("/Student/Create/")]
        public async Task<IActionResult> CreateStudentAsync([FromBody] AddStudentCommand addStudentCommand)
        {
            var result = await _medatior.Send(addStudentCommand);
            return Ok(result);
        }
    }
}
