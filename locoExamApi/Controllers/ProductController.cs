using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using locoExamApi.Models;
using Newtonsoft.Json;

namespace locoExamApi.Controllers
{

    public class ProductController : ApiController
    {
        public static Product[] products = new Product[]
        {
            new Product { Id = "PRODUCT001", Price = 10.90, Weight = 11.2 },
            new Product { Id = "PRODUCT002", Price = 20, Weight = 9},
            new Product { Id = "PRODUCT003", Price = 21, Weight = 10 }
        }; 


        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        [HttpGet]
        public IHttpActionResult GetProduct(string id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public void AddProduct([FromBody]Product product) {
            List<Product> listProduct = new List<Product>();
            for (int j = 0; j < products.Length; j++)
            {
                listProduct.Add(products[j]);
            }
            listProduct.Add(product);
            products = listProduct.ToArray();
        }

        [HttpDelete]
        public void DeleteProduct([FromBody]string id) {
            var itemDelete = products.FirstOrDefault((p) => p.Id == id);
            products = products.Where(val => val != itemDelete).ToArray();
        }
    }
}