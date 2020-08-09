using Automobile_repair_shop.Models;
using Automobile_repair_shop.Models.Repository;
using Automobile_repair_shop.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Web.ModelBinding;

namespace Automobile_repair_shop.Pages
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkoutForm.Visible = true;
            checkoutMessage.Visible = false;

            if (IsPostBack)
            {
                Order order = new Order();
                if (TryUpdateModel(order, new FormValueProvider(ModelBindingExecutionContext)))
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

                    #region Почта/Mail:Доделать потом надо будет
                    var fromAddress = new MailAddress("Test@gmail.com", "From Test");
                    var toAddress = new MailAddress("pavelocheretyany2001@gmail.com", "To Pavlo");
                    const string fromPassword = "Rjhybqxer1";
                    const string subject = "Покупка деталей на СТО";

                    string body = "Вы оплатиле следующие товары: на сумму...";

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }
                    #endregion
                }
            }
        }
    }
}