using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MockyAPI.Models;
using MockyAPI.Repository;

namespace MockyAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        public IProductsRepository ProductsRepo { get; set; }

        public ProductsController(IProductsRepository _repo)
        {
            ProductsRepo = _repo;
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return ProductsRepo.GetAllProducts();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var product = ProductsRepo.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return new ObjectResult(product);
        }

        [HttpPut("{id}")]
        public IActionResult Create([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            ProductsRepo.Add(product);
            return CreatedAtRoute("GetProducts", new {Controller = "Products", id = product.Id}, product);
        }

        [HttpPut]
        public IActionResult Update(Guid id, [FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            var productToUpdate = ProductsRepo.Find(id);
            if (productToUpdate == null)
            {
                return NotFound();
            }
            ProductsRepo.Update(product);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            ProductsRepo.Remove(id);
        }
    }
}
