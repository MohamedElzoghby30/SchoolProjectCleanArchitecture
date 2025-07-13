using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
