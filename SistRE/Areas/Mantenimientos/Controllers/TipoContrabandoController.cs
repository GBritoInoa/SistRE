﻿using BeEntity;
using BusinessControl;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SistRE.Areas.Mantenimientos.Controllers
{
    public class TipoContrabandoController : Controller
    {
        // GET: Tipo_Novedad
        public ActionResult Index()
        {
            try
            {

                var TipoContrabando = BcTipoContrabando.GetAll().ToList();
                return View(TipoContrabando);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);

            }
        }

        /// <summary>
        /// GetProducto
        /// </summary>
        public void GetProducto()
        {

            try
            {
                var Producto = BcProductos.GetAll().ToList().OrderBy(a => a.Nombre);
                ViewBag.ProductoID = new SelectList(Producto, "ID", "Nombre");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }

        }


        /// <summary>
        /// GetTipoProducto
        /// </summary>
        public void GetTipoProducto()
        {

            try
            {
                var Producto = BcTipoProducto.GetAll().ToList().OrderBy(a => a.Nombre);
                ViewBag.TipoProductoID = new SelectList(Producto, "TipoProductoID", "Nombre");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error");
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
                var TipoContrabando = BcTipoContrabando.Find(id);
                if (TipoContrabando == null)
                {
                    return HttpNotFound();
                }
                return View(TipoContrabando);


            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);

            }
        }



        [HttpGet]
        // GET: Tipo_Novedad/Create
        public ActionResult Create()
        {
            try
            {
                GetProducto();
                GetTipoProducto();
                GetEstatus();
                return View();

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Tipo_Novedad/Create
        public ActionResult Create(BeTipoContrabando item)
        {


            if (!ModelState.IsValid)
            {
                GetEstatus();
                return View(item);
            }

            try
            {

                BcTipoContrabando.Create(item);
                TempData["success"] = "Tipo Contrabando creado Satisfactoriamente!";
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
                var TipoContrabando = BcTipoContrabando.Find(id);

                if (TipoContrabando == null)
                {
                    return HttpNotFound();
                }
                GetEstatus();
                return View(TipoContrabando);

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
        public ActionResult Edit(BeTipoContrabando item)
        {

            if (!ModelState.IsValid)
            {
                GetEstatus();
                return View(item);

            }

            try
            {
                BcTipoContrabando.Edit(item);
                TempData["success"] = "Tipo Contrabando actualizdo Satisfactoriamente!";
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al crear Tipo Contrabando");
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
