using GreenfinchTest.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GreenfinchTest.Controllers
{
    public class GreenFinchController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (HttpContext != null && HttpContext.Session["sessionId"] != null)
            {
                LoginInformation info = (LoginInformation)SessionContainer.LoginSessions[HttpContext.Session["sessionId"].ToString()];
                ViewBag.UserInfo = info;
            }
        }

    }
}