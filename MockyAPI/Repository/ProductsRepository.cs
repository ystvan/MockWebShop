using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockyAPI.Models;

namespace MockyAPI.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private static List<Product> _productsList = new List<Product>();

        public void Add(Product product)
        {
            _productsList.Add(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productsList;
        }

        public Product Find(Guid id)
        {
            return _productsList.SingleOrDefault(p => p.Id == id);

        }

        public void Remove(Guid id)
        {
            var productToRemove = _productsList.SingleOrDefault(p => p.Id == id);
            if (productToRemove != null)
            {
                _productsList.Remove(productToRemove);
            }
        }

        public void Update(Product product)
        {
            var productToUpdate = _productsList.FirstOrDefault(p => p.Id == product.Id);
            if (productToUpdate != null)
            {
                productToUpdate.Id = product.Id;
                productToUpdate.Name = product.Name;
                productToUpdate.Description = product.Description;
                productToUpdate.Price = product.Price;
                productToUpdate.Category = product.Category;
                productToUpdate.IsAvailable = product.IsAvailable;
            }
        }
    }
}
