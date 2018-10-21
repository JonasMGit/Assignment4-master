using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment4;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers

{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : Controller
    {
        DataService _dataService;

        public ProductsController(DataService dataService)
        {
            _dataService = dataService;
        }

        //Not working
        /*
        [HttpGet]
        public IActionResult GetProducts()
        {
            var data = _dataService.GetProduct();
            
            return Ok(data);
        }
        */

        //Not working
            /*
        [HttpGet("/{id}")]
        public IActionResult GetProductValidId(int id)
        {
            var data = _dataService.GetProduct(id);
            if (data == null ) return NotFound();
            return Ok(data);
        }*/
        

            //Works good for ApiProducts_CategoryInvalid_EmptyListNotFound
        [HttpGet("category/{id}")]
        public IActionResult GetProductsByInvalidId(int id)
        {
            var data = _dataService.GetProductByCategory(id);
            if (data.Count == 0) return NotFound(data);
            return Ok(data);
        } 

        /*
       [HttpGet("category/{id}")]
        public IActionResult GetProductById(int id)
        {
            var data = _dataService.GetProductByCategory(id);
            if (data.Count == 0) return NotFound();
            return Ok(data);
        }*/
        

            //Works good and Passed for two test
            //ApiProducts_NameContained... and ApiProductNameNotContained...
        [HttpGet("name/{name}")]
        public IActionResult GetProductsByName(string name)
        {
            var data = _dataService.GetProductByName(name);
            if (data.Count == 0) return NotFound(data);
            return Ok(data);
        }
    }
}