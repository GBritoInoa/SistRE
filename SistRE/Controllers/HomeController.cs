using SistRE.AccessControl;
using System.Net;
using System.Web.Mvc;
using SistRE.Models;
using SistRE.AccesControl;
using BusinessControl;

namespace SistRE.Controllers
{
    public class HomeController : Controller
    {
        public string _IpAddress { get; set; }
        [Autorizar(AllowAllModules = true)]
        public ActionResult Index()
        {

            //TempData["info"] = "Prueeeebaaaaaa";
            //TempData["warn"] = "Hum! Cuidao!";
            //TempData["success"] = "Siiiii!";
            //TempData["error"] = "Oh noooo!";
            //TempData["mensaje"] = "Oh noooo!";
            return View();
        }




        /// <summary>
        /// Acceso al Sistema
        /// </summary>
        /// <returns></returns>
          public ActionResult Login()
        {
            return View();

        }
      
        [HttpPost]
        public ActionResult Login(BeEntity.BeCredencials model)
        {
            if (!ModelState.IsValid)
                return View(model);

            DalcMembresia MB = new DalcMembresia();
            var loginResult = MB.Login(model);

            if (!loginResult.Success)
            {
                ModelState.AddModelError("password", loginResult.Message);
                return View(model);
            }

            SessionData.SetSesion(loginResult.User.UserName, loginResult.User.PerfilID.ToString(), loginResult.User.PerfilID);

            return RedirectToAction("Index");

        }
        public ActionResult LogOff()
        {
            SessionData.ClearSession();
            return RedirectToAction("Login");
        }

        /// <summary>
        /// User not Autorized
        /// </summary>
        /// <returns></returns>
        public ActionResult NotAutorized()
        {
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}