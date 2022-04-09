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
    public class TipoMuertesController : Controller
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

        // GET: Mantenimientos/TipoMuertes
        public ActionResult Index()
        {

            try
            {

                var TipoMuertes = BcTipoMuertes.GetAll().ToList();
                return View(TipoMuertes);

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al obtener listado de Tipo Muertes");
                throw new Exception(ex.Message);
            }

        }

        // GET: Mantenimientos/TipoMuertes/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var TipoMuertes = BcTipoMuertes.Find(id);
                if (TipoMuertes == null)
                {
                    return HttpNotFound();
                }

                return View(TipoMuertes);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/TipoMuertes/Create
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

        // POST: Mantenimientos/TipoMuertes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeTipoMuertes model)
        {

            if (!ModelState.IsValid)
            {
                GetEstatus();
                return View(model);
            }
            try
            {

                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString();
                BcTipoMuertes.Create(model);
                TempData["success"] = "Tipo Defuncion CREADA Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al crear TipoMuertes");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/TipoMuertes/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var TipoMuertes = BcTipoMuertes.Find(id);
                if (TipoMuertes == null)
                {
                    return HttpNotFound();

                }
                GetEstatus();
                return View(TipoMuertes);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al ENCONTRAR Tipo Defunción");
                throw new Exception(ex.Message);
            }
        }

        // POST: Mantenimientos/TipoMuertes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeTipoMuertes model)
        {

            if (!ModelState.IsValid)
            {
                GetEstatus();
                return View(model);

            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString();
                BcTipoMuertes.Edit(model);
                TempData["success"] = "Tipo Defuncion ACTUALIZADA Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/TipoMuertes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //// POST: Mantenimientos/TipoMuertes/Delete/5
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
