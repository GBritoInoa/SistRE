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
    public class CategoriaProtestaController : Controller
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

        // GET: Mantenimientos/Categoria Protesta
        public ActionResult Index()
        {

            try
            {

                var CategoriaProtesta = BcCategoriaProtesta.GetAll().ToList();
                return View(CategoriaProtesta);

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al obtener listado de Categoria Protesta");
                throw new Exception(ex.Message);
            }

        }

        // GET: Mantenimientos/CategoriaProtesta/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var CategoriaProtesta = BcCategoriaProtesta.Find(id);
                if (CategoriaProtesta == null)
                {
                    return HttpNotFound();
                }

                return View(CategoriaProtesta);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/CategoriaProtesta/Create
        public ActionResult Create()
        {
            try
            {
                GetEstatus();
                return View();
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al generar la vista Categoría Protesta");
                throw new Exception(ex.Message);
            }

        }

        // POST: Mantenimientos/CategoriaProtesta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeCategoriaProtesta model)
        {

            if (!ModelState.IsValid)
            {
                GetEstatus();
                return View(model);
            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); ///Guarda User Logueado
                BcCategoriaProtesta.Create(model);
                TempData["success"] = "Categoría Protesta CREADA Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al crear CategoriaProtesta");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/CategoriaProtesta/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var CategoriaProtesta = BcCategoriaProtesta.Find(id);
                if (CategoriaProtesta == null)
                {
                    return HttpNotFound();

                }
                GetEstatus();
                return View(CategoriaProtesta);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al encontrar CategoriaProtesta");
                throw new Exception(ex.Message);
            }
        }

        // POST: Mantenimientos/CategoriaProtesta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeCategoriaProtesta model)
        {

            if (!ModelState.IsValid)
            {
                GetEstatus();
                return View(model);

            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); ///Guarda User Logueado
                BcCategoriaProtesta.Edit(model);
                TempData["success"] = "Categoría Protesta ACTUALIZADA Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/CategoriaProtesta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //// POST: Mantenimientos/CategoriaProtesta/Delete/5
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
