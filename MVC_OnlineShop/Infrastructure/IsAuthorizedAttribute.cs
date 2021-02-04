using MVC_OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_OnlineShop.Infrastructure {
    public class IsAuthorizedAttribute : AuthorizeAttribute {
        private readonly string[ ] _allowedRoles;

        public IsAuthorizedAttribute(params string[] roles) {
            _allowedRoles = roles;
        }

        /*
         * Check if the associated roles of an action is in a controller with
         * the assigned role of the given user. If no role is found that matches,
         * this method will return "false" and the authorization will fail.
         */
        protected override bool AuthorizeCore(HttpContextBase httpContext) {
            bool authorize = false;
            var userId = Convert.ToString(httpContext.Session[ "UserId" ]);
            if (!string.IsNullOrEmpty(userId)) {
                using (var context = new CustomerContext()) {
                    var userRole = (from c in context.Customers
                                    join r in context.Roles on c.RoleId equals r.Id
                                    where c.UserId == userId
                                    select new {
                                        r.Name
                                    }).FirstOrDefault();

                    foreach (var role in _allowedRoles) {
                        if (role == userRole.Name) return true;
                    }
                }
            }

            return authorize;
        }

        /*
         * If the authorization fails, this method will be executed. The page will be
         * redirected to a specific Action that is located in the given Controller.
         *  Controller: Home
         *  Action: UnAuthorized
         */
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                { "controller", "Shop" },
                { "action", "UnAuthorized" }
            });
        }




    }
}