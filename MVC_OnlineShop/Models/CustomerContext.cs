using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_OnlineShop.Models {
    public class CustomerContext : DbContext {
        public CustomerContext() : base("SqlConnection") { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}