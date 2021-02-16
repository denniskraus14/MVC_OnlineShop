using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_OnlineShop.Models {
    public class SiteContext : DbContext {

        /// <summary>
        /// Used for connecting to database
        /// </summary>
        public SiteContext() : base("name=SqlConnection") { }

        /// <summary>
        /// Creates Cx database tables 
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Creates Roels database tables
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Creates product database tables
        /// </summary>
        public DbSet<Product> Products { get; set;}

        /// <summary>
        /// Creates security questinos into the database with each question having its own identifier
        /// </summary>
        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }

        /// <summary>
        /// Creates default information into the tables for testing.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            // Drops the database and creates a new one with pre-defined options/settings
            Database.SetInitializer<SiteContext>(new DropCreateDatabaseAlways<SiteContext>()); 

            // Utilizes exisiting database with its content
            //Database.SetInitializer<CustomerContext>(new CreateDatabaseIfNotExists<CustomerContext>());

            //
            //Database.SetInitializer<CustomerContext>(new DropCreateDatabaseIfModelChanges<CustomerContext>());
            base.OnModelCreating(modelBuilder);
        }

    }
}