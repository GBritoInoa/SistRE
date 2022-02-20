using BeEntity;
using BusinessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistRE.Areas.Mantenimientos.Controllers
{
    public class TipoApresamientoController : Controller
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

        // GET: Mantenimientos/TipoApresamiento
        public ActionResult Index()
        {
            try
            {
                var tipoApresamiento = BcTipoApresamiento.GetAll().ToList();
                return View(tipoApresamiento);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al mostrar listado Tipo Apresamientos");
                throw new Exception(ex.Message);
            }
       
        }

        // GET: Mantenimientos/TipoApresamiento/Details/5
        public ActionResult Details(int? id)
        {

            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


            }
            try
            {
                var tipoapresamiento = BcTipoApresamiento.Find(id);
                if(tipoapresamiento ==null)
                {
                    return HttpNotFound();
                }
                return View(tipoapresamiento);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        
        }

        // GET: Mantenimientos/TipoApresamiento/Create
        public ActionResult Create()
        {
            try
            {
                GetEstatus();
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        
        }

        // POST: Mantenimientos/TipoApresamiento/Create
        [HttpPost]
        public ActionResult Create(BeTipoApresamiento item)
        {
            if(!ModelState.IsValid)
            {
                GetEstatus();
                return View(item);

            }
            try
            {
                BcTipoApresamiento.Create(item);
                TempData["success"] = "Tipo Apresamiento creado Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al crear tipo Apresamiento");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/TipoApresamiento/Edit/5
        public ActionResult Edit(int? id)
        {

            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            try
            {
                var tipoapresamiento = BcTipoApresamiento.Find(id);
                if(tipoapresamiento==null)
                {
                    HttpNotFound();

                }
                GetEstatus();
                return View(tipoapresamiento);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Encontrar tipo Apresamiento");
                throw new Exception(ex.Message);
            }
          
        }

        // POST: Mantenimientos/TipoApresamiento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeTipoApresamiento item)
        {

            if(!ModelState.IsValid)
            {
                GetEstatus();
                return View(item);

            }
            try
            {
                BcTipoApresamiento.Edit(item);
                TempData["success"] = "Tipo Apresamiento actualiado Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al crear Novedad Tipo Apresamiento");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/TipoApresamiento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mantenimientos/TipoApresamiento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
