using GreenfinchTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenfinchTest.Filter
{
    public class LoginInformation
    {
        public DateTime LoginDate { get; set; }
        public string UserName { get; set; }

    }
    public static class SessionContainer
    {
        public static CacheDictionary LoginSessions { get; set; }
        static SessionContainer()
        {
            LoginSessions = new CacheDictionary();
        }
    }
    public class GreenFinchAuthorizationFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.RequestContext.HttpContext.Session["sessionId"] != null)
            {
                var sessionId = filterContext.RequestContext.HttpContext.Session["sessionId"].ToString();
                if (!SessionContainer.LoginSessions.ContainsKey(sessionId))
                {
                    filterContext.Result = new ViewResult
                    {
                        ViewName = "Login",
                    };
                }
            }
            else
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "Login"
                };
            }

        }
    }
}