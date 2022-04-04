using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeEntity;
using BusinessControl;
using SistRE.AccesControl;
using SistRE.AccessControl;
using SistRE.Comun;

namespace SistRE.Areas.Mantenimientos.Controllers
{
    [Autorizar(Profiles = new EnumPerfiles.Perfiles[] { EnumPerfiles.Perfiles.Administrador })]
    public class TipoMedidasController : Controller
    {

        /// <summary>
        ///  GetTypeProducts
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
        /// List GetTypeMedidas
        /// </summary>
        /// <returns></returns>
        // GET: Mantenimientos/TipoMedidas
        public ActionResult Index()
        {
            try
            {
                var tipomedida = BcTipoMedidas.GetAll().ToList();
                return View(tipomedida);
            }
            catch (Exception ex)
            {


                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }

        }

        // GET: Mantenimientos/TipoMedidas/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var typeMedida = BcTipoMedidas.Find(id);
                if (typeMedida == null)
                {
                    return HttpNotFound();

                }
                GetEstatus();
                GetTipoProducto();
                return View(typeMedida);
            }
            catch (Exception ex)
            {


                ModelState.AddModelError(ex.Message, "ERROR al mostrar Detalle Tipo Medida");
                throw new Exception(ex.Message);
            }
      
        }


        /// <summary>
        /// Registro Tipo Medida
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // GET: Mantenimientos/TipoMedidas/Create
        public ActionResult Create()
        {
           
            try
            {
                GetTipoProducto();
                GetEstatus();
                var tipomedida = new BeTipoMedidas();
                return View(tipomedida);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al generar Vista Tipo Medida");
                throw new Exception(ex.Message);
            }
       
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST: Mantenimientos/TipoMedidas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeTipoMedidas model)
        {
            if (!ModelState.IsValid)
            {
                GetTipoProducto();
                GetEstatus();
                return View(model);
            }
            try
            {

                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString();
                BcTipoMedidas.Create(model);
                TempData["success"] = "Tipo Medida CREADA Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al CREAR Producto");
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Find type Measure
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Mantenimientos/TipoMedidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var typeMedida = BcTipoMedidas.Find(id);
                if(typeMedida ==null)
                {
                    return HttpNotFound();

                }
                GetEstatus();
                GetTipoProducto();
                return View(typeMedida);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "ERROR el ENCONTRAR Tipo Medida");
                throw new Exception(ex.Message);
            }
        
        }

        // POST: Mantenimientos/TipoMedidas/Edit/5
        [HttpPost]
        public ActionResult Edit(BeTipoMedidas model)
        {
            if (!ModelState.IsValid)
            {
                GetTipoProducto();
                GetEstatus();
                return View(model);

            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString();
                BcTipoMedidas.Edit(model);
                TempData["success"] = "TIpo Medida ACTUALIZADA Satisfactoriamente!!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al ACTUALIZAR Tipo Medida");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/TipoMedidas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mantenimientos/TipoMedidas/Delete/5
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
