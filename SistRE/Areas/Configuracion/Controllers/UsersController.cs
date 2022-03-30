using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BeEntity;
using BusinessControl;
using SistRE.AccesControl;
using SistRE.Comun;

namespace SistRE.Areas.Configuracion.Controllers
{

   
    public class UsersController : Controller
    {
        // GET: Configuracion/Users
        public ActionResult Index()
        {
            try
            {
                var users = BcUsers.GetAll().OrderBy(u=> u.NombreCompleto).ToList();
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
        public JsonResult ValidaCarnet(int? carnet)
        {

        try
            {

                var miembro = BcComun.GetMemberERD(carnet);

                //if(miembro == null)
                //{
                //    //RedirectToAction("Create");
                //    //TempData["error"] = "No se encontro Miembro ERD con este numero de Carnet !";
                //    //RedirectToAction("Create");

                //}

                              
                    return Json(miembro??null);
              
               
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Get Type Novedad
        /// </summary>
        private void GetPerfiles()
        {

            try
            {
                List<BePerfil> Perfiles = BcComun.GetPerfiles().ToList();
                ViewBag.PerfilID = new SelectList(Perfiles.OrderBy(c => c.Nombre), "PerfilID", "Nombre");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al obtener Tipo Novedad");
                throw new Exception(ex.Message);
            }



        }

        /// <summary>
        /// All Estatus
        /// </summary>
        public void GetEstatus()
        {

            try
            {
                var Estados = BcEstatus.GetAll().ToList();
                ViewBag.EstatusID = new SelectList(Estados, "EstatusID", "Nombre");
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
                GetEstatus();
                GetPerfiles();
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

                   

            if (ModelState.IsValid)
            {
                GetEstatus();
                GetPerfiles();
                return View(model);

            }


            try
            {
                model.Salt = BcCriptografia.ComputeSha256Hash($"{model.NumCarnet}");
                model.Password = BcCriptografia.ComputeSha256Hash($"{model.NumCarnet}");
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); ///Usuario Loguedo
                BcUsers.Create(model);
                TempData["success"] = "Usuario CREADO Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al CREAR Usuario");
                throw new Exception(ex.Message);
            }

        }


        // GET: Mantenimientos/Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            try
            {
                BeUser user = BcUsers.GetAll().Where(a => a.UserId == id).FirstOrDefault();
                if (user == null)
                {

                    return HttpNotFound();
                }

                GetEstatus();
                GetPerfiles();
                return View(user);

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }

        }

        // POST: Configuration/User/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeUser model)
        {

            if (!ModelState.IsValid)
            {

                GetPerfiles();
                GetEstatus();
                return View(model);

            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); ///Usuario Loguedo
                BcUsers.Edit(model);
                TempData["success"] = "Usuario ACTUALIZADO Satisfactoriamente!!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al EDITAR Usuario");
                throw new Exception(ex.Message);
            }
        }


       /// <summary>
       /// Details User
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            try
            {
                var user = BcUsers.GetAll().Where(a => a.UserId == id).FirstOrDefault();
                if (user == null)
                {
                    return HttpNotFound();

                }
                return View(user);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }



    }
}