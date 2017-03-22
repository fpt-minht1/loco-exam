using locoExamApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace locoExamApi.Controllers
{

    public class ProductController : ApiController
    {
        public static List<Product> products = new List<Product>
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
        public IHttpActionResult AddProduct([FromBody]Product product) {
			if (product != null)
			{
				products.Add(product);				
			}
			return Ok(products);
        }

        [HttpDelete]
        public IHttpActionResult DeleteProduct([FromUri]string id) {
            var dProduct = products.FirstOrDefault((p) => p.Id == id);
			if (dProduct !=null)
			{
				products.Remove(dProduct);
			}
			return Ok(products);
        }
    }
}