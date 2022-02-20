﻿using BeEntity;
using BusinessControl;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SistRE.Areas.Mantenimientos.Controllers
{
    public class TipoNovedadController : Controller
    {
          // GET: Tipo_Novedad
        public ActionResult Index()
        {
            try
            {

                var tiponovedad = BcTipoNovedad.GetAll().ToList();
                return View(tiponovedad);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al MOSTRAR Listdo Tipo Novedades");
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
                ModelState.AddModelError(ex.Message, "Error MOSTRAR Listado Estatus");
                throw new Exception(ex.Message);
            }


        }

        /// <summary>
        /// Details Tipo Novedad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Tipo_Novedad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
            try
            {
                var tiponovedad = BcTipoNovedad.Find(id);
                if (tiponovedad == null)
                {
                    return HttpNotFound();
                }
                return View(tiponovedad);


            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al mostrar el DETALLE Tipo Novedad");
                throw new Exception(ex.Message );
               
            }
        }

        [HttpGet]
        // GET: Tipo_Novedad/Create
        public ActionResult Create( )
        {
            try
            {
               GetEstatus();
                return View();

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al MOSTRAR Vista Tipo Novedades");
                throw new Exception(ex.Message);
            }
         
         
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Tipo_Novedad/Create
        public ActionResult Create(BeTipoNovedad model)
        {
                

            if (!ModelState.IsValid)
            {
                GetEstatus();
                return View(model);
            }
          
           try
            {

                BcTipoNovedad.Create(model);
                TempData["success"] = "Tipo Novedad creada Satisfactoriamente!";
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);

            }
        }


        /// <summary>
        /// Editar Novedad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Tipo_Novedad/Edit/
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            try
            {
                var tiponovedad = BcTipoNovedad.Find(id);
            
                if (tiponovedad == null)
                {
                    return HttpNotFound();
                }
                GetEstatus();
                return View(tiponovedad);

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }

        }

        // POST: Tipo_Novedad/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeTipoNovedad model)
        {

            if (!ModelState.IsValid)
            {
                GetEstatus();
                return View(model);

            }

            try 
            {
                BcTipoNovedad.Edit(model);
                TempData["success"] = "Tipo Novedad actualizada Satisfactoriamente!";
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al crear Tipo Novedad");
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
