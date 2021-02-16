using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_OnlineShop.Models {

    public class JsonModel {
        /// <summary>
        /// Get the products details and convert them into string format for reading as
        /// JSON.
        /// </summary>
        public string HTMLString { get; set; }

        /// <summary>
        /// Checks for additional products in the database. If no products are found,
        /// will return false.
        /// </summary>
        public bool NoMoreData { get; set; }
    }
}