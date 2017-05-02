using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MockyAPI.Models;

namespace MockyAPI.Contexts
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options) { }

        //default constructor
        public ProductsContext() { }

        public DbSet<Product> Products { get; set; } 
    }
}
