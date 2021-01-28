using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_OnlineShop.Models
{
    public class Product
    {
        public string name;
        public float price;
        public int quantity;
        public string image_url;
        public string type;

        public Product(string name, float price, int quantity, string image, string type)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.image_url = image;
            this.type = type;
        }
    }
}