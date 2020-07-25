using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Automobile_repair_shop.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Service service, int quantity)
        {
            CartLine cartLine = lineCollection.Where(p => p.Service.ServiceId == service.ServiceId).FirstOrDefault();
            if (cartLine == null)
            {
                lineCollection.Add(new CartLine() { Service = service, Quantity = quantity });
            }
            else
            {
                cartLine.Quantity += quantity;
            }
        }
        public void RemoveLine(Service service)
        {
            lineCollection.RemoveAll(l => l.Service.ServiceId == service.ServiceId);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
        public decimal ComputeTotalPrice()
        {
            return lineCollection.Sum(e => e.Service.Price * e.Quantity);
        }
        public IEnumerable<CartLine> Lines
        { get{ return lineCollection; } }
    }

    public class CartLine
    {
        public Service Service { get; set; }
        public int Quantity { get; set; }
    }
}