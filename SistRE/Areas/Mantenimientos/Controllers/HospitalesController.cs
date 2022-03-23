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
    public class HospitalesController : Controller
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

        // GET: Mantenimientos/Hospitales
        public ActionResult Index()
        {

            try
            {

                var Hospitales = BcHospitales.GetAll().ToList();
                return View(Hospitales);

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al obtener listado de Hospitaleses");
                throw new Exception(ex.Message);
            }

        }

        // GET: Mantenimientos/Hospitales/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var Hospitales = BcHospitales.Find(id);
                if (Hospitales == null)
                {
                    return HttpNotFound();
                }

                return View(Hospitales);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/Hospitales/Create
        public ActionResult Create()
        {
            try
            {
                GetEstatus();
                return View();
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al generar Vista Hospital");
                throw new Exception(ex.Message);
            }

        }

        // POST: Mantenimientos/Hospitales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeHospitales model)
        {

            if (!ModelState.IsValid)
            {
                GetEstatus();
                return View(model);
            }
            try
            {

                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString();
                BcHospitales.Create(model);
                TempData["success"] = "Hospital CREADO Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al crear Hospitales");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/Hospitales/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var Hospitales = BcHospitales.Find(id);
                if (Hospitales == null)
                {
                    return HttpNotFound();

                }
                GetEstatus();
                return View(Hospitales);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al encontrar Hospitales");
                throw new Exception(ex.Message);
            }
        }

        // POST: Mantenimientos/Hospitales/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeHospitales model)
        {

            if (!ModelState.IsValid)
            {
                GetEstatus();
                return View(model);

            }
            try
            {

                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString();
                BcHospitales.Edit(model);
                TempData["success"] = "Hospital ACTUALIZADO Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/Hospitales/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //// POST: Mantenimientos/Hospitales/Delete/5
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
