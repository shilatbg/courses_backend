using Clean.Core.Entities;
using Clean.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clean.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public ActionResult<List<Categories>> Get()
        {
            return Ok(_categoriesService.GetList());
        }

        [HttpGet("{id}")]
        public ActionResult<Categories> GetById(int id)
        {
            var categories = _categoriesService.GetById(id);

            if (categories == null)
                return NotFound();

            return Ok(categories);
        }

        [HttpPost]
        public ActionResult<Categories> Post([FromBody] Categories categories)
        {
            var newCategorie = _categoriesService.Add(categories);

            if (newCategorie == null)
                return BadRequest("Related item was not found");

            return Ok(newCategorie);
        }

        [HttpPut("{id}")]
        public ActionResult<Categories> Put(int id, [FromBody] Categories categories)
        {
            var updatedCategorie = _categoriesService.Update(id, categories);

            if (updatedCategorie == null)
                return NotFound();

            return Ok(updatedCategorie);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _categoriesService.Delete(id);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}
