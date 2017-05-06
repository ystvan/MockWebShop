using System;
using System.Collections.Generic;
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