using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockyAPI.Models;

namespace MockyAPI.Repository
{
    public interface IProductsRepository
    {
        void Add(Product product);
        IEnumerable<Product> GetAllProducts();
        Product Find(Guid id);
        void Remove(Guid id);
        void Update(Product product);
    }
}
