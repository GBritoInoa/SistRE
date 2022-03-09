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
    public class TipoDecomisoController : Controller
    {
        // GET: Mantenimientos/TipoDecomiso
        public ActionResult Index()
        {
            try
            {

                var tipodecomiso = BcTipoDecomiso.GetAll().ToList();
                return View(tipodecomiso);
            }
            catch (Exception ex)
            {
         
                ModelState.AddModelError(ex.Message, "Error al MOSTRAR LISTADO Tipo Decomiso");
                throw new Exception(ex.Message);

            }

        }

        // GET: Mantenimientos/TipoDecomiso/Details/5
        public ActionResult Details(int? id)
        {

            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            try
            {
                var tipodecomido = BcTipoDecomiso.Find(id);
                if(tipodecomido == null)
                {

                    return HttpNotFound();
                }

                
                return View(tipodecomido);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al mostrar DETALLE Tipo Decomiso");
                throw new Exception(ex.Message);
            }
           
        }

        // GET: Mantenimientos/TipoDecomiso/Create
        public ActionResult Create()
        {

            try
            {
                GetTypeNovedad();
                GetEstatus();
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        
        }

        // POST: Mantenimientos/TipoDecomiso/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeTipoDecomiso model)
        {

            if(!ModelState.IsValid)
            {
                GetTypeNovedad();
                GetEstatus();
                return View(model);
            }
            try
            {
                BcTipoDecomiso.Create(model);
                TempData["success"] = "Tipo Decomiso CREADO Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al REGISTRAR Tipo Decomiso");
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
                var tiponovedad = BcTipoNovedad.GetAll().Where(a => a.Nombre.Equals("Contrabando")).ToList();
                ViewBag.TipoNovedadID = new SelectList(tiponovedad.OrderBy(c => c.TipoNovedadID), "TipoNovedadID", "Nombre");

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
                var Producto = BcTipoProducto.GetAll().ToList();
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
                ModelState.AddModelError(ex.Message, "Error MOSTRAR  Estatus");
                throw new Exception(ex.Message);
            }


        }

        // GET: Mantenimientos/TipoDecomiso/Edit/5
        public ActionResult Edit(int? id)
        {

            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            try
            {
                var tipodecomiso = BcTipoDecomiso.Find(id);
                if(tipodecomiso==null)
                {
                    return HttpNotFound();
                }

                GetTypeNovedad();
                GetEstatus();
                return View(tipodecomiso);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al BUSCAR Tipo Decomiso");
                throw new Exception(ex.Message);
            }
        }

        // POST: Mantenimientos/TipoDecomiso/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeTipoDecomiso model)
        {

            if(!ModelState.IsValid)
            {
                GetTypeNovedad();
                GetEstatus();
                return View(model);

            }

            try
            {

                BcTipoDecomiso.Edit(model);
                TempData["success"] = "Tipo Decomiso ACTUALIZADO Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al EDITAR Tipo Decomiso");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/TipoDecomiso/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mantenimientos/TipoDecomiso/Delete/5
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
