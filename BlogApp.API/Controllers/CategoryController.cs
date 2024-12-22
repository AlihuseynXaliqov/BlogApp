using System;
using AutoMapper;
using BlogApp.API.DTOs.Category;
using BlogApp.DAL.Context;
using BlogApp.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly BlogDbContext dbContext;
        private readonly IMapper mapper;

        public CategoryController(BlogDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDtos create)
        {
            var category = mapper.Map<Category>(create);
            dbContext.Add(category);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var category = dbContext.categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK, category);

        }

        [HttpPut]
        public IActionResult Update(UpdateCategoryDtos update)
        {
            var category = dbContext.categories.AsNoTracking().FirstOrDefault(x => x.Id == update.Id);
            if (category == null) return StatusCode(StatusCodes.Status404NotFound);
            mapper.Map<Category>(update);
            dbContext.Update(category);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status202Accepted, category);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category= dbContext.categories.FirstOrDefault(x => x.Id == id);
            if (category == null) return StatusCode(StatusCodes.Status404NotFound);
            dbContext.categories.Remove(category);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }

    }
}