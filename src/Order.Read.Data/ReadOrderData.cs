using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Order.Read.Domain;

namespace Order.Read.Data
{
 public class ReadOrderData
 {
   private OrderReadContext _context;
   public ReadOrderData(OrderReadContext context)
   {
     _context = context;
   }

   public SalesOrder GetOrderWithDetails(Guid orderId)
   {
     return _context.Orders.Include(o => o.LineItems)
        .SingleOrDefault(o=>o.Id==orderId);
   }

   public async Task<List<SalesOrder>> GetOrdersForCustomerAsync(int custId)
   {
     return await _context.Orders.Where(o=>o.CustomerId==custId).ToListAsync();

   }

 }
}
