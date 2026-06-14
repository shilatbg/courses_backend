using Clean.Core.Entities;
using Clean.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clean.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesService _coursesService;

        public CoursesController(ICoursesService coursesService)
        {
            _coursesService = coursesService;
        }

        [HttpGet]
        public ActionResult<List<Courses>> Get()
        {
            return Ok(_coursesService.GetList());
        }

        [HttpGet("{id}")]
        public ActionResult<Courses> GetById(int id)
        {
            var courses = _coursesService.GetById(id);

            if (courses == null)
                return NotFound();

            return Ok(courses);
        }

        [HttpPost]
        public ActionResult<Courses> Post([FromBody] Courses courses)
        {
            var newCourse = _coursesService.Add(courses);

            if (newCourse == null)
                return BadRequest("Related item was not found");

            return Ok(newCourse);
        }

        [HttpPut("{id}")]
        public ActionResult<Courses> Put(int id, [FromBody] Courses courses)
        {
            var updatedCourse = _coursesService.Update(id, courses);

            if (updatedCourse == null)
                return NotFound();

            return Ok(updatedCourse);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _coursesService.Delete(id);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}
