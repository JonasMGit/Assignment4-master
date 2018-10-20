﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment4;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            var data = _dataService.GetProducts();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var cat = _dataService.GetCategory(id);
            if (cat == null) return NotFound();
            return Ok(cat);
        }
        /*
        [HttpPost]
        public IActionResult AddCategory(CategoryPostAndPutModel category)
        {
            _dataService.CreateCategory(category.Name);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, CategoryPostAndPutModel category)
        {
            var cat = _dataService.UpdateCategory(id, category.Name);
            if (cat == null) return NotFound();
            return Ok(cat);
        }
        */
    }
}
