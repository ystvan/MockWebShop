using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ProductManager.Data;

namespace ProductManager.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Pizza",
                        Description = "A real home-made, traditional Italian masterpiece of the kitchen",
                        Category = "Food",
                        Price = 10.45m
                    },
                    new Product
                    {
                        Name = "Pickles",
                        Description = "The best sliders one can have on a juicy beef patty",
                        Category = "Food",
                        Price = 2.58m
                    },
                    new Product
                    {
                        Name = "Ketchup",
                        Description = "Fresh breeze of pure south Italian tomato, pressured and served out of 57 varietes",
                        Category = "Food",
                        Price = 9.38m
                    },
                    new Product
                    {
                        Name = "Cheese",
                        Description = "Greate mature cheddar from Scotland. The older the better, this is probably the number one",
                        Category = "Food",
                        Price = 1.54m
                    },
                    new Product
                    {
                        Name = "Surface-Laptop",
                        Description = "Flat and thin, with the new Intel Pentium 2 processor",
                        Category = "Electronics",
                        Price = 1999.99m
                    },
                    new Product
                    {
                        Name = "Walkman",
                        Description = "Magneto magic, no need for Electric-Shock-Protection any more",
                        Category = "Electronics",
                        Price = 299.55m
                    },
                    new Product
                    {
                        Name = "Philips Turntable",
                        Description = "Feels like the 90\'s again, be like JDilla and Magic Mike, scratch & loop that tune",
                        Category = "Electronics",
                        Price = 400.78m
                    },
                    new Product
                    {
                        Name = "Hi-Fi station",
                        Description = "Built-in VHS and CD/DVD player, the gadget you can\'t afford not to have in the future",
                        Category = "Electronics",
                        Price = 375.88m
                    },
                    new Product
                    {
                        Name = "Trousers",
                        Description = "One can not simply go out without a good pair of these. Don\'t be naked out there",
                        Category = "Clothing",
                        Price = 17
                    },
                    new Product
                    {
                        Name = "T-Shirt",
                        Description = "Simple and elegant, hand made from the notorious antitrust sweatshops of South-Asia",
                        Category = "Clothing",
                        Price = 0.09m
                    },
                    new Product
                    {
                        Name = "V-Shirt",
                        Description = "Made in Mexico, but the assembly line is from the USA. No more walls between the two nation",
                        Category = "Clothing",
                        Price = 36.88m
                    },
                    new Product
                    {
                        Name = "Necklace",
                        Description = "Pure 42 carat diamond with silver-gold chains. Anti-robbery feature: netto weight 200 kg",
                        Category = "Clothing",
                        Price = 100000
                    });
                context.SaveChanges();
            }
        }
    }
}
