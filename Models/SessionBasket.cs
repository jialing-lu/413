using System;
using System.Text.Json.Serialization;
using _413.Infrastrusture;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace _413.Models
{
    public class SessionBasket : Basket
    {
        public static Basket GetBasket (IServiceProvider services)
        {
            //Pull in information from the session
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //If there is new infor then create a session basket
            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            //Update the session
            basket.Session = session;

            return basket;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        //override related to virtual
        public override void AddItem(Books books, int qty)
        {
            base.AddItem(books, qty);
            Session.SetJson("Basket", this);
        }

        public override void RemoveItem(Books books)
        {
            base.RemoveItem(books);
            Session.SetJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }
    }
}
