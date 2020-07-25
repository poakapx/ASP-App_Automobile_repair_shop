using Automobile_repair_shop.Models;
using Automobile_repair_shop.Models.Repository;
using Automobile_repair_shop.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;

namespace Automobile_repair_shop.Pages
{
    public partial class CartView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Repository repository = new Repository();
                int serviceID;
                if(int.TryParse(Request.Form["remove"], out serviceID))
                {
                    Service serviceToRemove = repository.Services.Where(g => g.ServiceId == serviceID).FirstOrDefault();
                    if(serviceID != null)
                    {
                        SessionHelper.GetCart(Session).RemoveLine(serviceToRemove);
                    }
                }
            }
        }

        public IEnumerable<Automobile_repair_shop.Models.CartLine> GetCartLines()
        {
            return SessionHelper.GetCart(Session).Lines;
        }

        public decimal CartTotal { get { return SessionHelper.GetCart(Session).ComputeTotalPrice(); } }

        public string ReturnUrl { get { return SessionHelper.Get<string>(Session, SessionKey.RETURN_URL); } }
        public string CheckoutUrl { get { return RouteTable.Routes.GetVirtualPath(null, "checkout", null).VirtualPath; } }
    }
}