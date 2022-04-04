using BeEntity;
using BusinessControl;
using DataLogic;
using SistRE.AccesControl;
using SistRE.AccessControl;
using SistRE.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistRE.Areas.Mantenimientos.Controllers
{
    [Autorizar(Profiles = new EnumPerfiles.Perfiles[] { EnumPerfiles.Perfiles.Administrador })]
    public class EnfermedadesController : Controller
    {


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

                throw new Exception(ex.Message);
            }


        }

        // GET: Mantenimientos/Enfermedades
        public ActionResult Index()
        {

            try
            {

                var Enfermedades = BcEnfermedades.GetAll().ToList();
                return View(Enfermedades);

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al obtener listado de Enfermedadeses");
                throw new Exception(ex.Message);
            }

        }

        // GET: Mantenimientos/Enfermedades/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var Enfermedades = BcEnfermedades.Find(id);
                if (Enfermedades == null)
                {
                    return HttpNotFound();
                }

                return View(Enfermedades);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/Enfermedades/Create
        public ActionResult Create()
        {
            try
            {
                GetEstatus();
                return View();
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al generar la vista Institucion Protestante");
                throw new Exception(ex.Message);
            }

        }

        // POST: Mantenimientos/Enfermedades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeEnfermedades model)
        {

            if (!ModelState.IsValid)
            {
                GetEstatus();
                return View(model);
            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); ///Usuario Logueado
                BcEnfermedades.Create(model);
                TempData["success"] = "Institucion Protestante CREADA Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al crear Enfermedades");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/Enfermedades/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var Enfermedades = BcEnfermedades.Find(id);
                if (Enfermedades == null)
                {
                    return HttpNotFound();

                }
                GetEstatus();
                return View(Enfermedades);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al encontrar Enfermedades");
                throw new Exception(ex.Message);
            }
        }

        // POST: Mantenimientos/Enfermedades/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeEnfermedades model)
        {

            if (!ModelState.IsValid)
            {
                GetEstatus();
                return View(model);

            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); ///Usuario Logueado
                BcEnfermedades.Edit(model);
                TempData["success"] = "Enfermedades ACTUALIZADA Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/Enfermedades/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //// POST: Mantenimientos/Enfermedades/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
