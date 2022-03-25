using System;
using System.Collections.Generic;
using System.Linq;
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


        private void Perfil()
        {

            try
            {

            }
            catch (Exception)
            {

                throw;
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

            //model.CambioClave = true;
            //model.CompaniaID = 116;
            //model.EstatusID = 1;
            //model.Email = "pruebaemail@gmail.com";
            //model.Password = "prueba";
            //model.Salt = "prueba";
            //model.ApellidosNombre = model.Apellidos + " " + model.Nombres;
            //model.UserId = 10;
            //model.ID = 11;
            //model.AuditoriaID = 1;
            //model.Institucion = "prueba";
            //model.Rango = "prueba";
            //model.FechaActualizo = DateTime.Now;
            //model.UsuarioActualizo = "prueba";
            //model.UsuarioCreo = "prueba";
            //model.FechaCreo = DateTime.Now;
            //model.Brigada = "prueba";
            //model.Perfil = "prueba";
            //model.UserName = "prueba";
            //model.UserLogueado = "prueba";
                 

            if(ModelState.IsValid)
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
                TempData["success"] = "Tipo Ausencia creada Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al CREAR Usuario");
                throw new Exception(ex.Message);
            }

        }
    }
}