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
        [HttpGet("/Student/PagnatedStudents")]
        public async Task<IActionResult> PagnatedStudents([FromQuery] GetStudentPaginatedListQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("/Student/Get/{id}")]
        public async Task<IActionResult> GetStudentsByIdAsync( [FromRoute]int id)
        {
            var result = await Mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(result);
        }
        [HttpPost("/Student/Create")]
        public async Task<IActionResult> CreateStudentAsync([FromBody] AddStudentCommand addStudentCommand)
        {
            var result = await Mediator.Send(addStudentCommand);
            return NewResult(result);
        }
        [HttpPut("/Student/Update")]
        public async Task<IActionResult> UpdateStudentsByIdAsync([FromBody] EditStudentCommand EditStudentCommand)
        {
            var result = await Mediator.Send(EditStudentCommand);
            return NewResult(result);
        }
        [HttpDelete("/Student/Delete/{id}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] int id)
        {
            var result = await Mediator.Send(new DeleteStudentCommand(id));
            return NewResult(result);
        }
    }
}
