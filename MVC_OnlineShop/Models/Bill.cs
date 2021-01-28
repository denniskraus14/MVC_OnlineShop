using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_OnlineShop.Models
{
    public class Bill
    {
        public bool Paid {get; set;}
        public void getTotal(Cart cart)
        {
            foreach (var p in cart.Products)
            {
                // TO DO
            }
        }

        public override string ToString()
        {
            return "TO DO";
        }
    }
}