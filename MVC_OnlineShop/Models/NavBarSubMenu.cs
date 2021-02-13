using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_OnlineShop.Models {
    public class NavBarSubMenu {

        public static IEnumerable<Product> ShopDropDown() {
            using (var context = new CustomerContext()) {
                return context.Products.ToList();
            }
        }
    }
}