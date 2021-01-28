namespace MVC_OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastLoginDate = c.DateTime(),
                        RememberMe = c.Boolean(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.String(),
                        Quantity = c.String(),
                        Image_Url = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            //Laptops
            Sql("Insert into Products(name,price,quantity,image_url,type) values ('Acer',150,1000,'google.com','laptop')");
            Sql("Insert into Products(name,price,quantity,image_url,type) values ('Dell',200,1000,'google.com','laptop')");
            Sql("Insert into Products(name,price,quantity,image_url,type) values ('Mac',300,1000,'google.com','laptop')");
            Sql("Insert into Products(name,price,quantity,image_url,type) values ('Chromebook',100,1000,'google.com','laptop')");
            Sql("Insert into Products(name,price,quantity,image_url,type) values ('Lenovo',400,1000,'google.com','laptop')");
            
            //Mobiles
            Sql("Insert into Products(name,price,quantity,image,type) values ('Samsung',400,1000,'google.com','mobile')");
            Sql("Insert into Products(name,price,quantity,image,type) values ('IPhone',1000,1000,'google.com','mobile')");
            Sql("Insert into Products(name,price,quantity,image,type) values ('Tracfone',100,100,'google.com','mobile')");
            Sql("Insert into Products(name,price,quantity,image,type) values ('Nokia',300,1000,'google.com','mobile')");
            Sql("Insert into Products(name,price,quantity,image,type) values ('Motorola',350,999,'google.com','mobile')");

            //Tvs
            Sql("Insert into Products(name,price,quantity,image,type) values ('Vizio',100,1000,'google.com','tv')");
            Sql("Insert into Products(name,price,quantity,image,type) values ('Samsung',200,200,'google.com','tv')");
            Sql("Insert into Products(name,price,quantity,image,type) values ('Sony',300,10,'google.com','tv')");
            Sql("Insert into Products(name,price,quantity,image,type) values ('Toshiba',400,9999,'google.com','tv')");
            Sql("Insert into Products(name,price,quantity,image,type) values ('JVC',500,999,'google.com','tv')");

            //aliens
            Sql("Insert into Products(name,price,quantity,image,type) values ('Niblonians',400000,10000,'google.com','alien')");
            Sql("Insert into Products(name,price,quantity,image,type) values ('Ewoks',1000,1000000,'google.com','alien')");
            Sql("Insert into Products(name,price,quantity,image,type) values ('Tralfamadorians',100000,100,'google.com','alien')");
            Sql("Insert into Products(name,price,quantity,image,type) values ('Martians',300,1000,'google.com','alien')");
            Sql("Insert into Products(name,price,quantity,image,type) values ('Spiders from Mars',350000,999,'google.com','alien')");


        }
        
        public override void Down()
        {
            DropTable("dbo.Roles");
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
        }
    }
}
