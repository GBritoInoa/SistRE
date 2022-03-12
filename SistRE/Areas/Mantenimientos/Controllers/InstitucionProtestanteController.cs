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
    public class InstitucionProtestanteController : Controller
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

        // GET: Mantenimientos/InstitucionProtestante
        public ActionResult Index()
        {

            try
            {

                var InstitucionProtestante = BcInstitucionProtestante.GetAll().ToList();
                return View(InstitucionProtestante);

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al obtener listado de InstitucionProtestantees");
                throw new Exception(ex.Message);
            }

        }

        // GET: Mantenimientos/InstitucionProtestante/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var InstitucionProtestante = BcInstitucionProtestante.Find(id);
                if (InstitucionProtestante == null)
                {
                    return HttpNotFound();
                }

                return View(InstitucionProtestante);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/InstitucionProtestante/Create
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

        // POST: Mantenimientos/InstitucionProtestante/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeInstitucionProtestante item)
        {

            if (!ModelState.IsValid)
            {
                GetEstatus();
                return View(item);
            }
            try
            {
                BcInstitucionProtestante.Create(item);
                TempData["success"] = "Institucion Protestante creada Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al crear InstitucionProtestante");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/InstitucionProtestante/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var InstitucionProtestante = BcInstitucionProtestante.Find(id);
                if (InstitucionProtestante == null)
                {
                    return HttpNotFound();

                }
                GetEstatus();
                return View(InstitucionProtestante);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al encontrar InstitucionProtestante");
                throw new Exception(ex.Message);
            }
        }

        // POST: Mantenimientos/InstitucionProtestante/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeInstitucionProtestante item)
        {

            if (!ModelState.IsValid)
            {
                GetEstatus();
                return View(item);

            }
            try
            {
                BcInstitucionProtestante.Edit(item);
                TempData["success"] = "InstitucionProtestante actualizada Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/InstitucionProtestante/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //// POST: Mantenimientos/InstitucionProtestante/Delete/5
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
