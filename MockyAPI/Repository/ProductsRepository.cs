using System;
using System.Collections.Generic;
using System.Linq;
using MockyAPI.Contexts;
using MockyAPI.Models;

namespace MockyAPI.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        //private static List<Product> _productsList = new List<Product>();

        private readonly ProductsContext _context;

        public ProductsRepository(ProductsContext context)
        {
            _context = context;
        }


        public void Add(Product product)
        {
            //_productsList.Add(product);
            product.Id = Guid.NewGuid();
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            //return _productsList;
            return _context.Products.ToList();
        }

        public Product Find(Guid id)
        {
            //return _productsList.SingleOrDefault(p => p.Id == id);
            return _context.Products.SingleOrDefault(p => p.Id == id);
        }

        public void Remove(Guid id)
        {
            //var productToRemove = _productsList.SingleOrDefault(p => p.Id == id);
            //if (productToRemove != null)
            //{
            //    _productsList.Remove(productToRemove);
            //}

            var productToRemove = _context.Products.SingleOrDefault(p => p.Id == id);
            if (productToRemove != null)
                _context.Products.Remove(productToRemove);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            //var productToUpdate = _productsList.FirstOrDefault(p => p.Id == product.Id);
            //if (productToUpdate != null)
            //{
            //    productToUpdate.Id = Guid.NewGuid();;
            //    productToUpdate.Name = product.Name;
            //    productToUpdate.Description = product.Description;
            //    productToUpdate.Price = product.Price;
            //    productToUpdate.Category = product.Category;
            //    productToUpdate.IsAvailable = product.IsAvailable;
            //}

            var productToUpdate = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (productToUpdate != null)
            {
                productToUpdate.Id = Guid.NewGuid();
                productToUpdate.Name = product.Name;
                productToUpdate.Description = product.Description;
                productToUpdate.Price = product.Price;
                productToUpdate.Category = product.Category;
                productToUpdate.IsAvailable = product.IsAvailable;
            }
            _context.SaveChanges();
        }
    }
}