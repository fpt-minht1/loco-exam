using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using locoExamApi.Models;

namespace locoExamApi.Repository
{
    public class ProductRepository
    {
        static List<Product> ProductList = new List<Product>();

        public void Add(Product item)
        {
            ProductList.Add(item);    
        }

        public Product Find(string key)
        {
            return ProductList
                .Where(e => e.Id.Equals(key))
                .SingleOrDefault();
        }

        public IEnumerable<Product> GetAll()
        {
            return ProductList;
        }
        public void Remove(string Id)
        {
            var itemToRemove = ProductList.SingleOrDefault(r => r.Id == Id);
            if (itemToRemove != null)
            {
                ProductList.Remove(itemToRemove);
            }
        }
    }
}