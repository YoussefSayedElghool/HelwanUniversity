using HelwanUniversity.Core.Helpers;
using HelwanUniversity.Core.Models;
using HelwanUniversity.Infrastructure.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelwanUniversity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public StudentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<Student>>>> GetStudents()
        {
            var result = await mediator.Send(new GetAllStudentsQuery());
            if (!result.IsSuccess)
                return StatusCode(result.Message.StatusCode, result);

            return Ok(result);
        }        
        
        
        [HttpPost]
        public async Task<ActionResult<Response<IEnumerable<Student>>>> AddStudent(Student student)
        {
            var result = await mediator.Send(new AddStudentCommand(student));

            if (!result.IsSuccess)
                return StatusCode(result.Message.StatusCode, result);

            return Ok(result);

        }
   
    }
}
