using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using locoExamApi.Controllers;
using locoExamApi.Models;
using System.Web.Http.Results;

namespace locoExamApi.Tests
{
    [TestFixture] 
    public class TestProductController
    {
        ProductController pController;
        int count;

        [SetUp]
        public void Setup()
        {
            pController = new ProductController();
            count = pController.GetAll().ToArray().Length;
        }

        [Test]
        public void GetAll()
        {
            Assert.IsTrue(count > 0);
        }

        [Test]
        public void GetProduct()
        {
            var response = pController.GetProduct("PRODUCT001");
            var contentResult = response as OkNegotiatedContentResult<Product>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("PRODUCT001", contentResult.Content.Id);
        }

        [Test]
        public void Add()
        {            
            Product product = new Product { Id = "PRODUCT100", Price = 30.02, Weight = 51 };
            pController.AddProduct(product);
            var response = pController.GetProduct("PRODUCT100");
            var contentResult = response as OkNegotiatedContentResult<Product>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("PRODUCT100", contentResult.Content.Id);
        }

        [Test]
        public void Delete()
        {            
            pController.DeleteProduct("PRODUCT100");
            var response = pController.GetProduct("PRODUCT100");
            var contentResult = response as OkNegotiatedContentResult<Product>;

            Assert.IsNull(contentResult);
        }
    }    
}
