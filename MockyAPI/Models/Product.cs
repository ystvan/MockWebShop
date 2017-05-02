using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockyAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public decimal Price { get; set; }
        public String Category { get; set; }
        public bool IsAvailable { get; set; }

    }
}
