using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using locoExamApi.Models;
using locoExamApi.Controllers;
using locoExamApi.Repository;

namespace locoExamApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ApiController
    {
        public IProductRepository ProductRepo { get; set; }
        
        public ProductController(IProductRepository _repo)
        {
            ProductRepo = _repo;
            var _product = new Product();
            _product.Id = "1";
            _product.Price = 10.90;
            _product.Weight = 10.5;
            ProductRepo.Add(_product);
        }

        [Route("api/product")]
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return ProductRepo.GetAll();
        }
        
        //[Route("api/prodcut/{productId}")]
        //[HttpGet]
        //public IActionResult GetById(string id)
        //{
        //    var item = ProductRepo.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return new ObjectResult(item);
        //}

        //[HttpPost]
        //public IActionResult Create([FromBody] Product item)
        //{
        //    if (item == null)
        //    {
        //        return BadRequest();
        //    }
        //    ProductRepo.Add(item);
        //    return CreatedAtRoute("GetProduct", new { Controller = "Product", id = item.Id }, item);
        //}
        
    }
}