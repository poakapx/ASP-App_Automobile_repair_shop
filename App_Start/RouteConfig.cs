using System.Web.Routing;

//namespace Automobile_repair_shop.App_Start
namespace Automobile_repair_shop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(null, "", "~/Pages/Listing.aspx");
            routes.MapPageRoute(null, "list", "~/Pages/Listing.aspx");
            routes.MapPageRoute(null, "list/{page}", "~/Pages/Listing.aspx");
            routes.MapPageRoute(null, "list/{category}/{page}", "~/Pages/Listing.aspx");

            routes.MapPageRoute("cart", "cart", "~/Pages/CartView.aspx");

            routes.MapPageRoute("checkout", "checkout", "~/Pages/Checkout.aspx");

            routes.MapPageRoute("admin_orders", "admin/orders", "~/Pages/Admin/Orders.aspx");
            routes.MapPageRoute("admin_services", "admin/services", "~/Pages/Admin/Services.aspx");
        }
    }
}