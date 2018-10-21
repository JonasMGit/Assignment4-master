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

        //Not working
        /*
        [HttpGet]
        public IActionResult GetCategories()
        {
            var data = _dataService.GetCategory();

            return Ok(data);
        }*/
        
        //Works good for ApiCategories_GetWithValidCategoryId_OkAndCategory

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var cat = _dataService.GetCategory(id);
            if (cat == null) return NotFound(cat);
            return Ok(cat);
        }
        
        
        //Works good for ApiCategories_PostWithCategory_Created

        [HttpPost]
        public IActionResult CreateCategory([FromBody]Category category)
        {
            _dataService.CreateCategory(category.Name, category.Description);

            return Created($"api/categories/{category}", category);
        }
        
        /*
        //This code is not working
        [HttpPut("{id}")]
        public IActionResult UpdateCategory([FromBody]Category category)
        {
            var cat = _dataService.UpdateCategory(category.Id, category.Name, category.Description);
            if (!cat) return NotFound(cat);
            return Ok(cat);
        }
        */
        
            //works good for ApiCategories_DeleteWithValid_Ok

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
