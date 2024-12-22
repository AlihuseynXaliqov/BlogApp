using AutoMapper;
using BlogApp.API.DTOs.Product;
using BlogApp.DAL.Context;
using BlogApp.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly BlogDbContext dbContext;
        private readonly IMapper mapper;

        public ProductController(BlogDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var product =dbContext.products.FirstOrDefault(p => p.Id == id);
            if (product == null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK, product);
        }

        [HttpPost]
        public IActionResult Create(CreateProductDto product)
        {
            if (product == null) return StatusCode(StatusCodes.Status404NotFound);
            var newProduct=mapper.Map<Product>(product);
            dbContext.products.Add(newProduct);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, newProduct);
        }

        [HttpPut("{id}")]
        public IActionResult Update(UpdateProductDto product)
        {
            if (product == null) return StatusCode(StatusCodes.Status404NotFound);
            var oldProduct=dbContext.products.FirstOrDefault(x=>x.Id==product.Id);
            mapper.Map<Product>(product);
            dbContext.Update(oldProduct);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status202Accepted,product);

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
        
            var product=dbContext.products.FirstOrDefault(x=>x.Id==id);
            if (product == null) return StatusCode(StatusCodes.Status404NotFound);
            dbContext.products.Remove(product);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
