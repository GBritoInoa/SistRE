using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessControl;

namespace SistRE.Areas.Configuracion.Controllers
{
    public class UsersController : Controller
    {
        // GET: Configuracion/Users
        public ActionResult Index()
        {
            try
            {
                var users = BcUsers.GetAll().ToList();
                return View(users);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al mostrar Usuarios");
                throw new Exception(ex.Message);
            }
        }
    }
}