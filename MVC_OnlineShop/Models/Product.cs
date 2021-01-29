using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_OnlineShop.Models
{
    public class Product
    {
        /* public int _id;
        public string _name;
        public float _price;
        public int _quantity;
        public string _image_url;
        public string _type; */

        public Product() { }

        /*public Product(int id, string name, float price, int quantity, string image_url, string type)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            Image_Url = image_url;
            Type = type;
        } */

        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Image_Url { get; set; }
        public ProductType Type { get; set; }



    }
}