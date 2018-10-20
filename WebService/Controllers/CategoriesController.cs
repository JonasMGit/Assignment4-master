using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment4;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebService.Model;
//using WebService.Models;

namespace WebService.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : Controller
    {
        DataService _dataService;

        public CategoriesController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var data = _dataService.GetCategory();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var cat = _dataService.GetCategory(id);
            if (cat == null) return NotFound(cat);
            return Ok(cat);
        }
        
        [HttpPost]
        public IActionResult CreateCategory([FromBody]Category category)
        {
            _dataService.CreateCategory(category.Name, category.Description);

            return Created($"api/categories/{category}", category);
        }

        

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(Category category)
        {
            var cat = _dataService.UpdateCategory(category.Id, category.Name, category.Description);
            if (!cat) return NotFound(cat);
            return Ok(cat);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var del = _dataService.DeleteCategory(id);

            if (!del)
            {
                return NotFound();
            }
            return Ok(del);
        }

    }
}
