using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeEntity;
using BusinessControl;
using SistRE.AccesControl;

namespace SistRE.Areas.Mantenimientos.Controllers
{
    public class TipoIncautacionController : Controller
    {
        #region Variable u Objetos

        #endregion

        // GET: TipoIncautacion
        public ActionResult Index()
        {
           
            try
            {
                var tipoincautacion = BcTipoIncautacion.GetAll().ToList();
                 return View(tipoincautacion);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
               

        /// <summary>
        /// Get TypeNovedad
        /// </summary>
        public void GetTypeNovedad()
        {

            try
            {
                var tiponovedad = BcTipoNovedad.GetAll().Where(a=> a.Nombre.Equals("Incautación")).ToList();
                ViewBag.TipoNovedadID = new SelectList(tiponovedad.OrderBy(c=> c.TipoNovedadID), "TipoNovedadID", "Nombre");
             
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
      

        // GET: TipoIncautacion/Details/5
        public ActionResult Details(int? id)
        {

            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            try
            {
                var tipoIncacutacion = BcTipoIncautacion.Find(id);
                if(tipoIncacutacion==null)
                    {

                    return HttpNotFound();
                }
                return View(tipoIncacutacion);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
          
        }

        // GET: TipoIncautacion/Create
        public ActionResult Create()
        {
            try
            {
                AllEstados();
                GetTypeNovedad();
                GetTipoProducto();
               return View();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
       
        }

        // POST: TipoIncautacion/Create
        [HttpPost]
        public ActionResult Create(BeTipoIncautacion model)
        {

            if(model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString();
                BcTipoIncautacion.Create(model);
                TempData["success"] = "Tipo Incautacion creada Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoIncautacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            try
            {
                var tipoIncacutacion = BcTipoIncautacion.Find(id);
                if (tipoIncacutacion == null)
                {

                    return HttpNotFound();
                }


                GetTipoProducto();           
                GetTypeNovedad();
                AllEstados();
               // ViewBag.AuditoriaID = tipoIncacutacion.AuditoriaID;
                return View(tipoIncacutacion);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // POST: TipoIncautacion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeTipoIncautacion model)
        {

            if(model == null)
                {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                }

            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString();
                BcTipoIncautacion.Edit(model);
                TempData["success"] = "Tipo Incautacion ACTUALIZADA Satisfactoriamente!";
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //// GET: TipoIncautacion/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: TipoIncautacion/Delete/5
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
