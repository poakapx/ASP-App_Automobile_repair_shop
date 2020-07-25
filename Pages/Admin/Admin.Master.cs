using System;
using System.Web.Routing;

namespace Automobile_repair_shop.Pages.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private string GenerateUrl(string routeName) => RouteTable.Routes.GetVirtualPath(null, routeName, null).VirtualPath;

        public string OrdersUrl
        {
            get { return GenerateUrl("admin_orders"); }
        }
        public string ServicesUrl
        {
            get { return GenerateUrl("admin_services"); }
        }
    }
}