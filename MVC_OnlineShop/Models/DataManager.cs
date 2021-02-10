using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_OnlineShop.Models {
    public static class DataManager {

        public static List<Product> GetProducts(int BlockNumber, int BlockSize) {
            int startIndex = (BlockNumber - 1) * BlockSize;
            using(var context = new CustomerContext()) {
                var productList = context.Products.Select(p => p);
                return productList.OrderBy(p => p.Id).Skip(startIndex).Take(BlockSize).ToList();
            }
        }
    }
}