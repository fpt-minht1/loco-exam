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
        Product[] products = new Product[]
        {
            new Product { Id = "PRODUCT001", Price = 10.90, Weight = 11.2 },
            new Product { Id = "PRODUCT002", Price = 20, Weight = 9},
            new Product { Id = "PRODUCT003", Price = 21, Weight = 10 }
        };

        public IEnumerable<Product> GetAll()
        {
            //return JsonConvert.SerializeObject(products);
            return products.ToList();
        }     

    }
}