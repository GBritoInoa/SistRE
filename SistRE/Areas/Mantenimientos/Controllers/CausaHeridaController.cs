using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeEntity;
using BusinessControl;

namespace SistRE.Areas.Mantenimientos.Controllers
{
    public class CausaHeridaController : Controller
    {

        #region Variable u Objetos

        #endregion

        // GET: CausaHerida
        public ActionResult Index()
        {

            try
            {
                var CausaH = BcTipoHerido.GetAll();
                return View(CausaH);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
      
        }


        /// <summary>
        /// All Estatus
        /// </summary>
        public void AllEstados()
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

        /// <summary>
        /// Details Causa Herida
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: CausaHerida/Details/5
        public ActionResult Details(int? id)
        {

            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            try
            {
                var causaherida = BcTipoHerido.Find(id);
                if(causaherida ==null)
                {
                    return HttpNotFound();

                }
                return View(causaherida);

   
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
     
        }

        /// <summary>
        /// Create  Cause Herida
        /// </summary>
        /// <returns></returns>
        // GET: CausaHerida/Create
        public ActionResult Create()
        {
            try
            {
                AllEstados();
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Create Tipo Causa Herida
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        // POST: CausaHerida/Create
        [HttpPost]
        public ActionResult Create(BeTipoHerido item)
        {

            if (item == null)
            {
                AllEstados();
                return View(item);
            }
            try
            {
                BcTipoHerido.Create(item);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        /// <summary>
        /// Edit Causa Herida
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: CausaHerida/Edit/5
        public ActionResult Edit(int? id)
        {

            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            try
            {
                var causaherida = BcTipoHerido.Find(id);
                AllEstados();
                if(causaherida==null)
                {
                    return HttpNotFound();

                }

                return View(causaherida);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
   
        }

        // POST: CausaHerida/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeTipoHerido item)
        {
            if (item == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                BcTipoHerido.Edit(item);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        // GET: CausaHerida/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CausaHerida/Delete/5
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
