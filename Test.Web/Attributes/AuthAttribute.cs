using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test.Web.Attributes
{
    public class AuthAttribute : Attribute, IAuthorizationFilter
    {
        private string _controller;
        private string _action;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isValid = false;

            _controller = "Login";
            _action = "Login";

            string cookie = context.HttpContext.Request.Cookies["test"];
            if (!string.IsNullOrEmpty(cookie))
            {
                isValid = true;
            }
            if (!isValid)
                context.Result = new RedirectToActionResult(_action, _controller, null);
        }
    }
}
