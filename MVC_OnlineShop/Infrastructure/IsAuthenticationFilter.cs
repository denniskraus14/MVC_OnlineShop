using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace MVC_OnlineShop.Infrastructure {
    public class IsAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter {
        /*
         * Check if the session value "UserName" is empty or not. If the value is empty, it will throw
         * the result "HttpUnauthorizedResult".
         */
        public void OnAuthentication(AuthenticationContext filterContext) {
            if(string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["UserName"]))) {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        /*
         * Then method will be executed if the "HttpUnAuthorizedResult" is thrown, which will redirect the
         * request to a specific action and controller. 
         *  Redirect: Login View
         *  Action: Account Controller
         */
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext) {
            if(filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult) {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    { "controller", "UserManagement" },
                    { "action", "Login" }
                });

            }
        }


    }
}