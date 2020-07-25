using Automobile_repair_shop.Models;
using Automobile_repair_shop.Models.Repository;
using Automobile_repair_shop.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Web.ModelBinding;

namespace Automobile_repair_shop.Pages
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkoutForm.Visible = true;
            checkoutMessage.Visible = false;

            if(IsPostBack)
            {
                Order order = new Order();
                if(TryUpdateModel(order, new FormValueProvider(ModelBindingExecutionContext)))
                {
                    order.OrderLines = new List<OrderLine>();

                    Cart cart = SessionHelper.GetCart(Session);

                    foreach (CartLine line in cart.Lines)
                    {
                        order.OrderLines.Add(new OrderLine()
                        {
                            Order = order,
                            Service = line.Service,
                            Quantity = line.Quantity
                        });
                    }

                    new Repository().SaveOrder(order);
                    cart.Clear();

                    checkoutForm.Visible = false;
                    checkoutMessage.Visible = true;
                }
            }
        }
    }
}