using Microsoft.EntityFrameworkCore;
using MockyAPI.Models;

namespace MockyAPI.Contexts
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //default constructor
        public ProductsContext()
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}