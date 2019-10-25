using ElVegetarianoFurio.Models;
using ElVegetarianoFurio.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;


namespace ElVegetarianoFurio.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _repository;
        private readonly string _path;

        public CategoriesController(ICategoryRepository repository, IWebHostEnvironment env)
        {
            _repository = repository;
            _path = Path.Combine(env.ContentRootPath, "data", "images", "categories");
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _repository.GetCategories();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _repository.GetCategoryById(id);
            if(category == null)
            {
                return NotFound();
            }
        
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _repository.CreateCategory(category);
            return CreatedAtAction("Get", new { id = category.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            if(id != category.Id)
            {
                return BadRequest();
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(_repository.GetCategoryById(id) == null)
            {
                return NotFound();
            }

            var result = _repository.UpdateCategory(category);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(_repository.GetCategoryById(id) == null)
            {
                return NotFound();
            }
            _repository.DeleteCategory(id);
            return NoContent();
        }

        [HttpGet("{id}/image")]
        public IActionResult Image(int id)
        {
            var file = Path.Combine(_path, $"{id}.jpg");
            if(System.IO.File.Exists(file))
            {
                var bytes = System.IO.File.ReadAllBytes(file);
                return File(bytes, "image/jpeg");
            }
            return NotFound();
        }
    }
}
