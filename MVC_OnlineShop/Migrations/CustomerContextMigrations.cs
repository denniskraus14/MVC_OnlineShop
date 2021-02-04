using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_OnlineShop.Models;
using MVC_OnlineShop.Models.Enums;

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
                context.Products.Add(new Product { Name = "Acer", Price = 150, Quantity = 1000, Type = ProductType.Laptop, Image_Url= "https://images-na.ssl-images-amazon.com/images/I/71sesDsw95L._AC_SL1500_.jpg" });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Dell',200,1000,'google.com','laptop')");
                context.Products.Add(new Product { Name = "Dell", Price = 200, Quantity = 1000, Type = ProductType.Laptop, Image_Url= "https://specials-images.forbesimg.com/imageserve/5d609f0668cb0a0008c045d2/960x0.jpg?cropX1=0&cropX2=1500&cropY1=327&cropY2=1171" });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Mac',300,1000,'google.com','laptop')");
                context.Products.Add(new Product { Name = "Mac", Price = 300, Quantity = 1000, Type = ProductType.Laptop, Image_Url= "https://www.apple.com/newsroom/images/product/os/macos/standard/Apple_macOS-catalina-available-today_100719_big.jpg.large.jpg" });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Chromebook',100,1000,'google.com','laptop')");
                context.Products.Add(new Product { Name = "Chromebook", Price = 100, Quantity = 1000, Type = ProductType.Laptop, Image_Url= "https://images-na.ssl-images-amazon.com/images/I/81mX-4s%2BguL._AC_SL1500_.jpg" });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Lenovo',400,1000,'google.com','laptop')");
                context.Products.Add(new Product { Name = "Lenovo", Price = 400, Quantity = 1000, Type = ProductType.Laptop, Image_Url= "https://i.pcmag.com/imagery/roundups/01WVjMAdwpsB2gomJXcqpNl-10.1574817850.fit_lim.size_1200x630.jpg" });

                //Mobiles
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Samsung',400,1000,'google.com','mobile')");
                context.Products.Add(new Product { Name = "Samsung", Price = 400, Quantity = 1000, Type = ProductType.Mobile, Image_Url= "https://fdn2.gsmarena.com/vv/pics/samsung/samsung-galaxy-s10-1.jpg" });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('IPhone',1000,1000,'google.com','mobile')");
                context.Products.Add(new Product { Name = "iPhone", Price = 1000, Quantity = 1000, Type = ProductType.Mobile, Image_Url= "https://images.macrumors.com/article-new/2017/09/iphonexdesign-800x669.jpg" });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Tracfone',100,100,'google.com','mobile')");
                context.Products.Add(new Product { Name = "Tracfone", Price = 100, Quantity = 1000, Type = ProductType.Mobile, Image_Url= "https://images-na.ssl-images-amazon.com/images/I/71jxzmP6QxL._AC_SL1500_.jpg" });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Nokia',300,1000,'google.com','mobile')");
                context.Products.Add(new Product { Name = "Nokia", Price = 300, Quantity = 1000, Type = ProductType.Mobile, Image_Url= "https://media.wired.com/photos/5f4e82925c49dd59083f89a3/125:94/w_2375,h_1786,c_limit/Gear-Nokia-90739547.jpg" });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Motorola',350,999,'google.com','mobile')");
                context.Products.Add(new Product { Name = "Motorola", Price = 350, Quantity = 999, Type = ProductType.Mobile, Image_Url= "https://www.gizmochina.com/wp-content/uploads/2019/05/Motorola-Moto-E6.jpg" });

                //Tvs
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Vizio',100,1000,'google.com','tv')");
                context.Products.Add(new Product { Name = "Vizio", Price = 100, Quantity = 1000, Type = ProductType.TV, Image_Url= "https://images-na.ssl-images-amazon.com/images/I/81IB1NYH9qL._AC_SY355_.jpg" });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Samsung',200,200,'google.com','tv')");
                context.Products.Add(new Product { Name = "Samsung", Price = 200, Quantity = 200, Type = ProductType.TV, Image_Url= "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6360/6360291_rd.jpg" });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Sony',300,10,'google.com','tv')");
                context.Products.Add(new Product { Name = "Sony", Price = 300, Quantity = 10, Type = ProductType.TV, Image_Url= "https://images-na.ssl-images-amazon.com/images/I/71VC9cPNy6L._AC_SL1080_.jpg" });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Toshiba',400,9999,'google.com','tv')");
                context.Products.Add(new Product { Name = "Toshiba", Price = 400, Quantity = 9999, Type = ProductType.TV, Image_Url= "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/9868/9868051le.jpg" });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('JVC',500,999,'google.com','tv')");
                context.Products.Add(new Product { Name = "JVC", Price = 500, Quantity = 999, Type = ProductType.TV, Image_Url= "https://acimg.auctivacommerce.com/imgdata/0/3/2/0/1/8/webimg/9062621.jpg" });

                //aliens
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Niblonians',400000,10000,'google.com','alien')");
                context.Products.Add(new Product { Name = "Niblonians", Price = 400000, Quantity = 10000, Type = ProductType.Alien, Image_Url= "https://theinfosphere.org/images/thumb/7/7e/Nibblonian_ships.jpg/300px-Nibblonian_ships.jpg" });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Ewoks',1000,1000000,'google.com','alien')");
                context.Products.Add(new Product { Name = "Ewoks", Price = 1000, Quantity = 1000000, Type = ProductType.Alien, Image_Url= "https://www.thathashtagshow.com/wp-content/uploads/2019/03/ewoks.jpg" });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Tralfamadorians',100000,100,'google.com','alien')");
                context.Products.Add(new Product { Name = "Tralfamadorians", Price = 100000, Quantity = 100, Type = ProductType.Alien, Image_Url= "https://i.pinimg.com/originals/7c/e6/32/7ce632615f7cdbee31dda411b18df9c1.jpg" });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Martians',300,1000,'google.com','alien')");
                context.Products.Add(new Product { Name = "Martians", Price = 300, Quantity = 1000, Type = ProductType.Alien, Image_Url= "https://bcdbimages.s3.amazonaws.com/warner/marvin.jpg" });
                //Sql("Insert into Products(name,price,quantity,image_url,type) values ('Spiders from Mars',350000,999,'google.com','alien')");
                context.Products.Add(new Product { Name = "Spiders from Mars", Price = 350000, Quantity = 99, Type = ProductType.Alien,Image_Url= "https://render.fineartamerica.com/images/images-profile-flow/400/images-medium-large-5/spiders-from-mars-carl-salonen.jpg" });

                context.Roles.Add(new Role { Name = "Normal" });

                context.SecurityQuestions.Add(new SecurityQuestion { Question = "What is your mother's maiden name?" });

                context.SaveChanges();
            }
        }
    }
}