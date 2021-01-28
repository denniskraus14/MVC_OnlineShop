﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_OnlineShop.Models {
    public class CustomerContext : DbContext {

        public CustomerContext() : base("name=SqlConnection") { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Product> Products { get; set;}
    }
}