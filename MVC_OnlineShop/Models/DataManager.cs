using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_OnlineShop.Models {
    public static class DataManager {

        public static List<Product> GetProducts(int BlockNumber, int BlockSize) {
            /*int startIndex = (BlockNumber - 1) * BlockSize;*/
            int startIndex = (BlockNumber - 1) * BlockSize;
            using (var context = new CustomerContext()) {
                var productList = context.Products.Select(p => p);
                return productList.OrderBy(p => p.Id).Skip(startIndex).Take(BlockSize).ToList();
            }
        }

        public static List<Product> GetProductTypes(int BlockNumber, int BlockSize, string productType) {
            int startIndex = (BlockNumber - 1) * BlockSize;
            using (var context = new CustomerContext()) {
                var products = context.Products
                                        .Select(type => type)
                                        .Where(p => p.stringType == productType);
                return products.OrderBy(p => p.Id).Skip(startIndex).Take(BlockSize).ToList();
            }
        }
    }
}