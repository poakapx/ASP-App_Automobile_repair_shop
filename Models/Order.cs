using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Automobile_repair_shop.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Введите имя!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите хоть адрес 1!")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required(ErrorMessage = "Введите город для получения!")]
        public string City { get; set; }
        public bool GiftWrap { get; set; }
        public bool Dispatched { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
    }

    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public Order Order { get; set; }
        public Service Service { get; set; }
        public int Quantity { get; set; }
    }
}