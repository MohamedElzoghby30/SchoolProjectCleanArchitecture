using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : AppControllerBase
    {
  

        [HttpGet("/Student/AllStudent")]
        public async Task<IActionResult> GetStudentsListAsync()
        {
            var result = await Mediator.Send(new GetStudentListQuery());
            return NewResult(result);
        }
        [HttpGet("/Student/{id}/")]
        public async Task<IActionResult> GetStudentsByIdAsync( [FromRoute]int id)
        {
            var result = await Mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(result);
        }
        [HttpPost("/Student/Create/")]
        public async Task<IActionResult> CreateStudentAsync([FromBody] AddStudentCommand addStudentCommand)
        {
            var result = await Mediator.Send(addStudentCommand);
            return NewResult(result);
        }
    }
}
