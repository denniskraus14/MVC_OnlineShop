using System;
using MVC_OnlineShop.Infrastructure;
using MVC_OnlineShop.Models;

namespace MVC_OnlineShop.Migrations {
    public class CustomerContextMigrations {
        public static void Migrations() {
            using (var context = new SiteContext()) {
                //Laptops
                /*
                context.Products.Add(new Product { Name = "Acer", Description = "This is a sample description", Price = 150, Quantity = 1000, stringType = "Laptop", Image_Url= "https://images-na.ssl-images-amazon.com/images/I/71sesDsw95L._AC_SL1500_.jpg" });
                context.Products.Add(new Product { Name = "Dell", Description = "This is a sample description", Price = 200, Quantity = 1000, stringType = "Laptop", Image_Url= "https://specials-images.forbesimg.com/imageserve/5d609f0668cb0a0008c045d2/960x0.jpg?cropX1=0&cropX2=1500&cropY1=327&cropY2=1171" });
                context.Products.Add(new Product { Name = "Mac", Description = "This is a sample description", Price = 300, Quantity = 1000, stringType = "Laptop", Image_Url= "https://www.apple.com/newsroom/images/product/os/macos/standard/Apple_macOS-catalina-available-today_100719_big.jpg.large.jpg" });
                context.Products.Add(new Product { Name = "Chromebook", Description = "This is a sample description", Price = 100, Quantity = 1000, stringType = "Laptop", Image_Url= "https://images-na.ssl-images-amazon.com/images/I/81mX-4s%2BguL._AC_SL1500_.jpg" });
                context.Products.Add(new Product { Name = "Lenovo", Description = "This is a sample description", Price = 400, Quantity = 1000, stringType = "Laptop", Image_Url = "https://i.pcmag.com/imagery/roundups/01WVjMAdwpsB2gomJXcqpNl-10.1574817850.fit_lim.size_1200x630.jpg" });
                
                //Mobiles
                context.Products.Add(new Product { Name = "Samsung", Description = "This is a sample description", Price = 400, Quantity = 1000, stringType = "Mobile", Image_Url= "https://fdn2.gsmarena.com/vv/pics/samsung/samsung-galaxy-s10-1.jpg" });
                context.Products.Add(new Product { Name = "iPhone", Description = "This is a sample description", Price = 1000, Quantity = 1000, stringType = "Mobile", Image_Url= "https://images.macrumors.com/article-new/2017/09/iphonexdesign-800x669.jpg" });
                context.Products.Add(new Product { Name = "Tracfone", Description = "This is a sample description", Price = 100, Quantity = 1000, stringType = "Mobile", Image_Url= "https://images-na.ssl-images-amazon.com/images/I/71jxzmP6QxL._AC_SL1500_.jpg" });
                context.Products.Add(new Product { Name = "Nokia", Description = "This is a sample description", Price = 300, Quantity = 1000, stringType = "Mobile", Image_Url= "https://media.wired.com/photos/5f4e82925c49dd59083f89a3/125:94/w_2375,h_1786,c_limit/Gear-Nokia-90739547.jpg" });
                context.Products.Add(new Product { Name = "Motorola", Description = "This is a sample description", Price = 350, Quantity = 999, stringType = "Mobile", Image_Url = "https://www.gizmochina.com/wp-content/uploads/2019/05/Motorola-Moto-E6.jpg" });

                //Tvs
                context.Products.Add(new Product { Name = "Vizio", Description = "This is a sample description", Price = 100, Quantity = 1000, stringType = "TV", Image_Url= "https://images-na.ssl-images-amazon.com/images/I/81IB1NYH9qL._AC_SY355_.jpg" });
                context.Products.Add(new Product { Name = "Samsung", Description = "This is a sample description", Price = 200, Quantity = 200, stringType = "TV", Image_Url= "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6360/6360291_rd.jpg" });
                context.Products.Add(new Product { Name = "Sony", Description = "This is a sample description", Price = 300, Quantity = 10, stringType = "TV", Image_Url= "https://images-na.ssl-images-amazon.com/images/I/71VC9cPNy6L._AC_SL1080_.jpg" });
                context.Products.Add(new Product { Name = "Toshiba", Description = "This is a sample description", Price = 400, Quantity = 9999, stringType = "TV", Image_Url= "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/9868/9868051le.jpg" });
                context.Products.Add(new Product { Name = "JVC", Description = "This is a sample description", Price = 500, Quantity = 999, stringType = "TV", Image_Url = "https://acimg.auctivacommerce.com/imgdata/0/3/2/0/1/8/webimg/9062621.jpg" });

                //aliens
                context.Products.Add(new Product { Name = "Niblonians", Description = "This is a sample description", Price = 400000, Quantity = 10000, stringType = "Alien", Image_Url= "https://theinfosphere.org/images/thumb/7/7e/Nibblonian_ships.jpg/300px-Nibblonian_ships.jpg" });
                context.Products.Add(new Product { Name = "Ewoks", Description = "This is a sample description", Price = 1000, Quantity = 1000000, stringType = "Alien", Image_Url= "https://www.thathashtagshow.com/wp-content/uploads/2019/03/ewoks.jpg" });
                context.Products.Add(new Product { Name = "Tralfamadorians", Description = "This is a sample description", Price = 100000, Quantity = 100, stringType = "Alien", Image_Url= "https://i.pinimg.com/originals/7c/e6/32/7ce632615f7cdbee31dda411b18df9c1.jpg" });
                context.Products.Add(new Product { Name = "Martians", Description = "This is a sample description", Price = 300, Quantity = 1000, stringType = "Alien", Image_Url = "https://bcdbimages.s3.amazonaws.com/warner/marvin.jpg" });
                context.Products.Add(new Product { Name = "Spiders from Mars", Description = "This is a sample description", Price = 350000, Quantity = 99, stringType = "Alien", Image_Url = "https://render.fineartamerica.com/images/images-profile-flow/400/images-medium-large-5/spiders-from-mars-carl-salonen.jpg" });
                context.Products.Add(new Product { Name = "Spiders from Mars (copy)", Description = "This is a sample description (copy)", Price = 950000, Quantity = 99, stringType = "Alien", Image_Url = "https://render.fineartamerica.com/images/images-profile-flow/400/images-medium-large-5/spiders-from-mars-carl-salonen.jpg" });

                context.Roles.Add(new Role { Name = "Administrator" }); // Role ID = 1
                context.Roles.Add(new Role { Name = "Moderator" }); // Role ID = 2
                context.Roles.Add(new Role { Name = "Normal" }); // Role ID = 3

                AES obj = new AES();

                string def = obj.Encryption("password");

                context.Customers.Add(new Customer
                {
                    UserId = 1,
                    FirstName = "Bob",
                    LastName = "Smith",
                    UserName = "admin",
                    Password = def,
                    ConfirmPassword = def,
                    Email = "admin@yahoo.com",
                    SecurityQuestion = 1,
                    QuestionAnswer = "admin",
                    RoleId = 1,
                    CreatedDate = DateTime.Today,
                    LastLoginDate = DateTime.Today,
                    File = new byte[] { }
                });

                context.Customers.Add(new Customer
                {
                    UserId = 2,
                    FirstName = "Rob",
                    LastName = "Smith",
                    UserName = "a",
                    Password = def,
                    ConfirmPassword = def,
                    Email = "a@yahoo.com",
                    SecurityQuestion = 1,
                    QuestionAnswer = "Smith",
                    RoleId = 3,
                    CreatedDate = DateTime.Today,
                    LastLoginDate = DateTime.Today,
                    File = new byte[] { }
                });

                context.SecurityQuestions.Add(new SecurityQuestion { Question = "What is your mother's maiden name?" });
                context.SecurityQuestions.Add(new SecurityQuestion { Question = "What city was you born in?" });
                context.SecurityQuestions.Add(new SecurityQuestion { Question = "What is your favorite hobby?" });
                context.SecurityQuestions.Add(new SecurityQuestion { Question = "What is your first pet name?" });

                context.SaveChanges();
                */
            }


        }
    }
}