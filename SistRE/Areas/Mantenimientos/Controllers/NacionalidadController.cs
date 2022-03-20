using BeEntity;
using BusinessControl;
using SistRE.AccesControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistRE.Areas.Mantenimientos.Controllers
{
    public class NacionalidadController : Controller
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

        // GET: Mantenimientos/Nacionalidad
        public ActionResult Index()
        {

            try
            {
              
                var nacionalidad = BcNacionalidad.GetAll().ToList();
                return View(nacionalidad);

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al obtener listado de Nacionalidades");
                throw new Exception(ex.Message);
            }
           
        }

        // GET: Mantenimientos/Nacionalidad/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var nacionalidad = BcNacionalidad.Find(id);
                if (nacionalidad == null)
                {
                    return HttpNotFound();
                }

                return View(nacionalidad);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/Nacionalidad/Create
        public ActionResult Create()
        {
            try
            {
                GetEstatus();
                return View();
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al generar la vista Naciolidad");
                throw new Exception(ex.Message);
            }
    
        }

        // POST: Mantenimientos/Nacionalidad/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeNacionalidad model)
        {

            if(!ModelState.IsValid)
            {
                GetEstatus();
                return View(model);
            }
            try
            {

                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString();
                BcNacionalidad.Create(model);
                TempData["success"] = "Nacionalidad creada Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al crear Nacionalidad");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/Nacionalidad/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var nacionalidad = BcNacionalidad.Find(id);
                if (nacionalidad == null)
                {
                    return HttpNotFound();

                }
                GetEstatus();
                return View(nacionalidad);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al encontrar Nacionalidad");
                throw new Exception(ex.Message);
            }
        }

        // POST: Mantenimientos/Nacionalidad/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeNacionalidad model)
        {

            if(!ModelState.IsValid)
            {
                GetEstatus();
                return View(model);

            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString();
                BcNacionalidad.Edit(model);
                TempData["success"] = "Nacionalidad actualizada Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/Nacionalidad/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //// POST: Mantenimientos/Nacionalidad/Delete/5
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
