using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_OnlineShop.Models
{
    public class Product
    {
        public int _id;
        public string _name;
        public float _price;
        public int _quantity;
        public string _image_url;
        public string _type;

        public Product(int id, string name, float price, int quantity, string image, string type)
        {
            _id = id;
            _name = name;
            _price = price;
            _quantity = quantity;
            _image_url = image;
            _type = type;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string Image_Url { get; set; }
        public string Type { get; set; }



    }
}