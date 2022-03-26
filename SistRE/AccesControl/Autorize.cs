using SistRE.AccesControl;
using SistRE.Comun;
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
        public EnumPerfiles.Perfiles[] Profiles { get; set; }
        public bool AllowAllProfiles { get; set; }


        /// <summary>
        /// AuthorizeCore
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Profiles = Profiles ?? new EnumPerfiles.Perfiles[] { };
            //Si la sesion esta iniciada pasa si no se redireciona al "Login" para su autenticacion
            if (SessionData.IsOnline())
            {
                var sesionInfo = SessionData.GetOnlineUserInfo();

                //Si el usuario tiene el id del modulo solicitado se le da acceso
                if (Profiles.Contains((EnumPerfiles.Perfiles)sesionInfo.idProfile) || AllowAllProfiles)
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
                    area = ""
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