using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_OnlineShop.Models
{
    public class Bill
    {
        public bool Paid {get; set;}
        public double getTotal(Cart cart)
        {
            double total = 0;

            foreach (var p in cart.Products)
            {
                total += p.Price;
            }

            return total;
        }

        public override string ToString()
        {
            return "TO DO.. maybe?";
        }
    }
}