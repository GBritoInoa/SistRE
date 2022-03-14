using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeEntity;
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


        /// <summary>
        /// Trae los datos Miembro ERD
        /// </summary>
        public void GetMiembroERD( int user)
        {
            try
            {
                var miembro = BcComun.GetMemberERD(user);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }



        /// <summary>
        /// Create User
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al CREAR Usuario");
                throw new Exception(ex.Message);
            }



        }


        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeUser model)
        {
            try
            {

                return View(model);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al CREAR Usuario");
                throw new Exception(ex.Message);
            }



        }
    }
}