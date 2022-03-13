using SistRE.AccesControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SistRE.AccessControl
{
    public class Autorizar : AuthorizeAttribute
    {
        private int statusCode = 200;
        private string destinationAction;
        public string codModule { get; set; }
        public bool AllowAllModules { get; set; }


        /// <summary>
        /// AuthorizeCore
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //Si la sesion esta iniciada pasa si no se redireciona al "Login" para su autenticacion
            if (SessionData.IsOnline())
            {
                //Si el usuario tiene el id del modulo solicitado se le da acceso
                if (ModulesControl.CanAccessModule(codModule) || AllowAllModules)
                    return true;
                //De lo contrario es un error 403 (no esta autorizado el acceso para el usuario)
                else
                {
                    destinationAction = "NotAutorized";
                    statusCode = 403;
                    return false;
                }
            }
            else
            {
                destinationAction = "Login";
                statusCode = 401;
                return false;
            }
        }

        /// <summary>
        /// HandleUnauthorizedRequest
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            RedirectToRouteResult routeData = null;
            routeData = new RedirectToRouteResult
                (new RouteValueDictionary
                (new
                {
                    controller = "Home",
                    action = destinationAction,
                }
                ));

            filterContext.Result = routeData;
            //If HttpRequest is Ajax we just response a 401 or 403 code (front end will manage those codes)
            if (new HttpRequestWrapper(HttpContext.Current.Request).IsAjaxRequest())
            {
                HttpContext.Current.Response.StatusCode = statusCode;
                HttpContext.Current.Response.End();
            }
        }
    }
}