﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Commy;
using Commy.Model;
using Microsoft.AspNetCore.Cors;

namespace Commy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowOrigin")]
    public class CategoriesController : Controller
    {
        private readonly CommyDBContext _context;

        public CategoriesController(CommyDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }
        [HttpPost]
        public async Task<ActionResult> CreateCategory(string name, string description)
        {
            var newCategory = new Category
            {
                Name = name,
                Description = description
            };
            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();

            return Ok("");
        }
    }
}
