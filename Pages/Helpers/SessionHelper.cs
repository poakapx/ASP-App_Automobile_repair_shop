using Automobile_repair_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Automobile_repair_shop.Pages.Helpers
{
    public enum SessionKey
    {
        CART,
        RETURN_URL
    }
    public static class SessionHelper
    {
        public static void Set(HttpSessionState session, SessionKey key, object value)
        {
            session[Enum.GetName(typeof(SessionKey), key)] = value;
        }
        public static Cart GetCart(HttpSessionState session)
        {
            Cart cart = Get<Cart>(session, SessionKey.CART);
            if(cart == null)
            {
                cart = new Cart();
                Set(session, SessionKey.CART, cart);
            }
            return cart;
        }

        public static T Get<T>(HttpSessionState session, SessionKey key)
        {
            object dataValue = session[Enum.GetName(typeof(SessionKey), key)];
            if (dataValue != null && dataValue is T)
            {
                return (T)dataValue;
            }
            else
            {
                return default(T);
            }
        }
    }
}