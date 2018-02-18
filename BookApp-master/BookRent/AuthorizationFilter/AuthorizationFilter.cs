using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookRent.AuthorizationFilter
{
    public class AuthorizationFilter : FilterAttribute,IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var username = filterContext.Controller.TempData["UserName"];
            if(username==null)
            {
                
                filterContext.HttpContext.Response.Redirect("http://localhost:3847/Admin/Index");
            }
        }
    }
}