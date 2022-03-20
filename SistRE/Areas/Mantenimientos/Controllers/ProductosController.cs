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
    public class ProductosController : Controller
    {
        
        /// <summary>
        /// GetTipoProducto
        /// </summary>
        public void GetTipoProducto()
        {

            try
            {
                var Producto = BcTipoProducto.GetAll().ToList().OrderBy(a=>a.Nombre); 
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

        // GET: Mantenimientos/Productos
        public ActionResult Index()
        {
            try
            {
                var producto = BcProductos.GetAll().ToList();
                  return View(producto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            try
            {
                var producto = BcProductos.Find(id);
                if (producto == null)
                {

                    return HttpNotFound();
                }

                GetEstatus();
                GetTipoProducto();
                return View(producto);

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);            }

        }

        // GET: Mantenimientos/Productos/Create
        public ActionResult Create()
        {
            try
            {
                GetTipoProducto();
                GetEstatus();
                var producto = new BeProductos();
                 return View(producto);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al generar Vista Producto");
                throw new Exception(ex.Message);
            }
           
        }

        // POST: Mantenimientos/Productos/Create
        [HttpPost]
        public ActionResult Create(BeProductos model)
        {

            if(!ModelState.IsValid)
            {

                GetTipoProducto();
                GetEstatus();
                return View(model);
            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); ///Usuario Loguedo
                BcProductos.Create(model);
                TempData["success"] = "Producto CREADO Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al CREAR Producto");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            try
            {
                var producto = BcProductos.Find(id);
                if (producto == null)
                {

                    return HttpNotFound();
                }

                GetEstatus();
                GetTipoProducto();
                return View(producto);

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }

        }

        // POST: Mantenimientos/Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeProductos model)
        {

            if (!ModelState.IsValid)
            {
                GetTipoProducto();
                GetEstatus();
                return View(model);

            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); ///Usuario Loguedo
                BcProductos.Edit(model);
                TempData["success"] = "Producto ACTUALIZADO Satisfactoriamente!!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al EDITAR Producto");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/Productos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mantenimientos/Productos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                {
                    ModelState.AddModelError(ex.Message, "Error");
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
