using Clean.Core.Entities;
using Clean.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clean.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpGet]
        public ActionResult<List<Students>> Get()
        {
            return Ok(_studentsService.GetList());
        }

        [HttpGet("{id}")]
        public ActionResult<Students> GetById(int id)
        {
            var students = _studentsService.GetById(id);

            if (students == null)
                return NotFound();

            return Ok(students);
        }

        [HttpPost]
        public ActionResult<Students> Post([FromBody] Students students)
        {
            var newStudent = _studentsService.Add(students);

            if (newStudent == null)
                return BadRequest("Related item was not found");

            return Ok(newStudent);
        }

        [HttpPut("{id}")]
        public ActionResult<Students> Put(int id, [FromBody] Students students)
        {
            var updatedStudent = _studentsService.Update(id, students);

            if (updatedStudent == null)
                return NotFound();

            return Ok(updatedStudent);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _studentsService.Delete(id);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}
