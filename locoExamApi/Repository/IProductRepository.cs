using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using locoExamApi.Models;

namespace locoExamApi.Repository
{
    public interface IProductRepository
    {
        void Add(Product item);
        IEnumerable<Product> GetAll();
        Product Find(string key);
        void Remove(string Id);
    }
}
