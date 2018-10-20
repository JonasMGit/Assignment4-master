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

        [HttpGet]
        public IActionResult GetProducts()
        {
            var data = _dataService.GetCategory();

            return Ok(data);
        }
    }
}