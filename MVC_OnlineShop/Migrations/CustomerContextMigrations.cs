using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_OnlineShop.Models;

namespace MVC_OnlineShop.Migrations
{
    public class CustomerContextMigrations
    {
        public static void Migrations()
        {
            using (var context = new CustomerContext())
            {
                //Laptops
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Acer',150,1000,'google.com','laptop')");
                context.Products.Add(new Product { Name = "Acer", Price = 150, Quantity = 1000, Type = ProductType.Laptop });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Dell',200,1000,'google.com','laptop')");
                context.Products.Add(new Product { Name = "Dell", Price = 200, Quantity = 1000, Type = ProductType.Laptop });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Mac',300,1000,'google.com','laptop')");
                context.Products.Add(new Product { Name = "Mac", Price = 300, Quantity = 1000, Type = ProductType.Laptop });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Chromebook',100,1000,'google.com','laptop')");
                context.Products.Add(new Product { Name = "Chromebook", Price = 100, Quantity = 1000, Type = ProductType.Laptop });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Lenovo',400,1000,'google.com','laptop')");
                context.Products.Add(new Product { Name = "Lenovo", Price = 400, Quantity = 1000, Type = ProductType.Laptop });

                //Mobiles
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Samsung',400,1000,'google.com','mobile')");
                context.Products.Add(new Product { Name = "Samsung", Price = 400, Quantity = 1000, Type = ProductType.Mobile });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('IPhone',1000,1000,'google.com','mobile')");
                context.Products.Add(new Product { Name = "iPhone", Price = 1000, Quantity = 1000, Type = ProductType.Mobile });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Tracfone',100,100,'google.com','mobile')");
                context.Products.Add(new Product { Name = "Tracfone", Price = 100, Quantity = 1000, Type = ProductType.Mobile });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Nokia',300,1000,'google.com','mobile')");
                context.Products.Add(new Product { Name = "Nokia", Price = 300, Quantity = 1000, Type = ProductType.Mobile });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Motorola',350,999,'google.com','mobile')");
                context.Products.Add(new Product { Name = "Motorola", Price = 350, Quantity = 999, Type = ProductType.Mobile });

                //Tvs
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Vizio',100,1000,'google.com','tv')");
                context.Products.Add(new Product { Name = "Vizio", Price = 100, Quantity = 1000, Type = ProductType.TV});
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Samsung',200,200,'google.com','tv')");
                context.Products.Add(new Product { Name = "Samsung", Price = 200, Quantity = 200, Type = ProductType.TV });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Sony',300,10,'google.com','tv')");
                context.Products.Add(new Product { Name = "Sony", Price = 300, Quantity = 10, Type = ProductType.TV });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Toshiba',400,9999,'google.com','tv')");
                context.Products.Add(new Product { Name = "Toshiba", Price = 400, Quantity = 9999, Type = ProductType.TV });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('JVC',500,999,'google.com','tv')");
                context.Products.Add(new Product { Name = "JVC", Price = 500, Quantity = 999, Type = ProductType.TV });

                //aliens
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Niblonians',400000,10000,'google.com','alien')");
                context.Products.Add(new Product { Name = "Niblonians", Price = 400000, Quantity = 10000, Type = ProductType.Alien });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Ewoks',1000,1000000,'google.com','alien')");
                context.Products.Add(new Product { Name = "Ewoks", Price = 1000, Quantity = 1000000, Type = ProductType.Alien });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Tralfamadorians',100000,100,'google.com','alien')");
                context.Products.Add(new Product { Name = "Tralfamadorians", Price = 100000, Quantity = 100, Type = ProductType.Alien});
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Martians',300,1000,'google.com','alien')");
                context.Products.Add(new Product { Name = "Martians", Price = 300, Quantity = 1000, Type = ProductType.Alien });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Spiders from Mars',350000,999,'google.com','alien')");
                context.Products.Add(new Product { Name = "Spiders from Mars", Price = 350000, Quantity = 99, Type = ProductType.Alien });

                context.SecurityQuestions.Add(new SecurityQuestion { Question = "What is your mother's maiden name?" });
                context.SaveChanges();
            }
        }
    }
}