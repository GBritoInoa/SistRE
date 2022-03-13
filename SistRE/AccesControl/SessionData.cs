using SistRE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistRE.AccesControl
{
    public static class SessionData
    {
        public static bool IsOnline()
        {
            var isOnline = HttpContext.Current.Session["SI"];
            return (isOnline == null ? false : true);
        }
        public static void SetSesion(string userName, string profile, int idProfile)
        {
            HttpContext.Current.Session["SI"] = true;
            HttpContext.Current.Session["userName"] = userName;
            HttpContext.Current.Session["profile"] = profile;
            HttpContext.Current.Session["idProfile"] = idProfile;
        }
        public static UserInfo GetOnlineUserInfo()
        {
            return new UserInfo((string)HttpContext.Current.Session["userName"], (string)HttpContext.Current.Session["profile"], (int)HttpContext.Current.Session["idProfile"]);
        }
        public static void ClearSession()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
}