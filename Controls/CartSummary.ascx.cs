using Automobile_repair_shop.Models;
using Automobile_repair_shop.Pages.Helpers;
using System;
using System.Linq;
using System.Web.Routing;

namespace Automobile_repair_shop.Controls
{
    public partial class CartSummary : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cart cart = SessionHelper.GetCart(Session);
            csQuantity.InnerText = cart.Lines.Sum(x => x.Quantity).ToString();
            csTotal.InnerText = cart.ComputeTotalPrice().ToString("c");
            csLink.HRef = RouteTable.Routes.GetVirtualPath(null, "cart", null).VirtualPath;
        }
    }
}