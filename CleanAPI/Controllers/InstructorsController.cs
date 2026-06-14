using Clean.Core.Entities;
using Clean.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clean.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorsService _instructorsService;

        public InstructorsController(IInstructorsService instructorsService)
        {
            _instructorsService = instructorsService;
        }

        [HttpGet]
        public ActionResult<List<Instructors>> Get()
        {
            return Ok(_instructorsService.GetList());
        }

        [HttpGet("{id}")]
        public ActionResult<Instructors> GetById(int id)
        {
            var instructors = _instructorsService.GetById(id);

            if (instructors == null)
                return NotFound();

            return Ok(instructors);
        }

        [HttpPost]
        public ActionResult<Instructors> Post([FromBody] Instructors instructors)
        {
            var newInstructor = _instructorsService.Add(instructors);

            if (newInstructor == null)
                return BadRequest("Related item was not found");

            return Ok(newInstructor);
        }

        [HttpPut("{id}")]
        public ActionResult<Instructors> Put(int id, [FromBody] Instructors instructors)
        {
            var updatedInstructor = _instructorsService.Update(id, instructors);

            if (updatedInstructor == null)
                return NotFound();

            return Ok(updatedInstructor);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _instructorsService.Delete(id);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}
