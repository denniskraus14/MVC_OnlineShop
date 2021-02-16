using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_OnlineShop.Models {
    public class SecurityQuestion {

        /// <summary>
        /// Identifier for determining what question to use
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Question to be displayed
        /// </summary>
        public string Question { get; set; }
    }
}