using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_OnlineShop.Models.Exceptions;

namespace MVC_OnlineShop.Models
{
    public class Cart
    {
        public List<Product> Products
        {
            get
            { 
                return Products;
            }
        }

        public void Add(Product product)
        {
            Products.Add(product);
        }

        public void Delete(Product product)
        {
            try
            {
                Products.Remove(product);
            }
            catch
            {
                throw new ProductNotFoundException();
            }
        }
    }
}

// To Be Deleted....
public class Product { }