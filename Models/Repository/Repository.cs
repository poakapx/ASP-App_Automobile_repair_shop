using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Automobile_repair_shop.Models.Repository
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Service> Services { get { return context.Services; } }
        public IEnumerable<Order> Orders
        {
            get
            {
                return context.Orders.Include(c => c.OrderLines.Select(ol => ol.Service));
            }
        }
        public void SaveOrder(Order order)
        {
            if (order.OrderId == 0)
            {
                order = context.Orders.Add(order);
                foreach (OrderLine line in order.OrderLines)
                {
                    context.Entry(line.Service).State = EntityState.Modified;
                }
            }
            else
            {
                Order dbOrder = context.Orders.Find(order.OrderId);
                if (dbOrder != null)
                {
                    dbOrder.Name = order.Name;
                    dbOrder.Line1 = order.Line1;
                    dbOrder.Line2 = order.Line2;
                    dbOrder.Line3 = order.Line3;
                    dbOrder.City = order.City;
                    dbOrder.GiftWrap = order.GiftWrap;
                    dbOrder.Dispatched = order.Dispatched;
                }
            }
            context.SaveChanges();
        }
        public void SaveService(Service service)
        {
            if (service.ServiceId == 0)
            {
                service = context.Services.Add(service);
            }
            else
            {
                Service dbService = context.Services.Find(service.ServiceId);
                if (dbService != null)
                {
                    dbService.Name = service.Name;
                    dbService.Price = service.Price;
                    dbService.Category = service.Category;
                    dbService.Description = service.Description;
                }
            }
            context.SaveChanges();
        }
        public void DeleteService(Service service)
        {
            IEnumerable<Order> orders = context.Orders.
                Include(
                    o => o.OrderLines.Select(
                        ol => ol.Service))
                    .Where(
                        o => o.OrderLines.Count(
                            ol => ol.Service.ServiceId == service.ServiceId) > 0
                           ).ToArray();
            foreach (Order order in orders)
            {
                context.Orders.Remove(order);
            }
            context.Services.Remove(service);
            context.SaveChanges();
        }
    }
}