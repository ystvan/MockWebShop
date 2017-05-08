using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManager.Data;

namespace ProductManager.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext _context;
        public EFOrderRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IEnumerable<Order> Orders => _context.Orders.Include(o => o.Lines).ThenInclude(l => l.Product);
        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                _context.Orders.Add(order);
            }
            _context.SaveChanges();
        }
    }
}
