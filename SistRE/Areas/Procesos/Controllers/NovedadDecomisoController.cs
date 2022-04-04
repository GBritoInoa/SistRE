using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeEntity;
using BusinessControl;
using SistRE.AccesControl;
using SistRE.AccessControl;
using SistRE.Comun;

namespace SistRE.Areas.Procesos.Controllers
{
    [Autorizar(Profiles = new EnumPerfiles.Perfiles[] { EnumPerfiles.Perfiles.Administrador, EnumPerfiles.Perfiles.Digitador })]
    public class NovedadDecomisoController : Controller
    {



        /// <summary>
        /// GetProvincias
        /// </summary>
        private void GetProvincias()
        {

            try
            {
                List<BeProvincias> Provincias = BcComun.GetProvincias().ToList();
                ViewBag.ProvinciaID = new SelectList(Provincias.OrderBy(p => p.Nombre), "ProvinciaID", "Nombre");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al obtener Listado Provincias");
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Tipo Medidas
        /// </summary>
        /// <param name="ProductoId"></param>
        /// <returns></returns>
        public JsonResult GetTipoMedidas(int ProductoID)
        {

            try
            {

                //var p = BcProductos.GetAll().Where(a => a.ID == ProductoID).FirstOrDefault();
                var tp = BcTipoProducto.GetAll().Where(y => y.TipoProductoID == ProductoID).FirstOrDefault();
                var TipoMedidaID = BcTipoMedidas.GetAll().Where(x => x.TipoProductoID == ProductoID).ToList();
                return Json(TipoMedidaID, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// JsonResult Productos
        /// </summary>
        /// <param name="TipoProductoID"></param>
        /// <returns></returns>
        public JsonResult GetProducts(int TipoProductoID)
        {

            try
            {

                var tipoInc = BcTipoDecomiso.GetAll().Where(a => a.ID == TipoProductoID).FirstOrDefault();
                var tipoproducto = BcTipoProducto.GetAll().Where(y => y.TipoProductoID == tipoInc.TipoProductoID).FirstOrDefault();
                var productos = BcProductos.GetAll().Where(x => x.TipoProductoID == tipoproducto.TipoProductoID).ToList();

                return Json(productos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Get Tipo Decomiso
        /// </summary>
        private void GetTipoDecomiso()
        {
            try
            {
                List<BeTipoDecomiso> TipoDecomiso = BcTipos.GetTipoDecomisos().ToList();
                ViewBag.TipoDecomisoID = new SelectList(TipoDecomiso.OrderBy(td => td.Nombre), "ID", "Nombre");
                ViewBag.TipoNovedadID = new SelectList(TipoDecomiso.OrderBy(c => c.TipoNovedadID), "TipoNovedadID", "Nombre");

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al obtener Listado Provincias");
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Tipo Drogas
        /// </summary>
        private void GetTipoDrogas()
        {
            try
            {
                List<BeTipoDroga> TipoDroga = BcTipos.GetTipoDrogas().ToList();
                ViewBag.TipoDrogaID = new SelectList(TipoDroga.OrderBy(td => td.Nombre), "TipoDrogaID", "Nombre");
            }
            catch (Exception ex)
            {


                ModelState.AddModelError(ex.Message, "Error al obtener Listado Tipo Drogas");
                throw new Exception(ex.Message);
            }


        }



        /// <summary>
        /// List Productos
        /// </summary>
        private void GetProductos()
        {
            try
            {
                List<BeProductos> productos = BcTipos.GetProductos().ToList();
                ViewBag.ProductoID = new SelectList(productos.OrderBy(p => p.Nombre), "ID", "Nombre");


            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al obtener LISTADO Productos");
                throw new Exception(ex.Message);
            }


        }

        /// <summary>
        /// Get Brigadas
        /// </summary>
        private void GetBrigadas()
        {

            try
            {
                List<BeBrigada> Brigadas = BcComun.GetBrigadas().ToList();
                ViewBag.BrigadaID = new SelectList(Brigadas.OrderBy(b => b.UnidadID), "UnidadID", "Nombre");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al obtener List Provincias");
                throw new Exception(ex.Message);
            }
        }


        // GET: Procesos/Decomisos/Create
        [HttpGet]
        public ActionResult Create()
        {
            try
            {

                GetProductos();
                GetBrigadas();
                GetTipoDecomiso();
                GetTipoDrogas();
                GetProvincias();
            }
            catch (Exception ex )
            {


                ModelState.AddModelError(ex.Message, "Error al mostrar la Vista Novedad Decomisos");
                throw new Exception(ex.Message);
            }
            return View();
        }

        // POST: Procesos/Decomisos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeNovedadDecomiso model)
        { 

            if(!ModelState.IsValid)
            {
                GetProductos();
                GetTipoDecomiso();
                GetTipoDrogas();
                 GetProvincias();
                return View(model);

            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); //Usuario Logueado
                BcNovedadDecomiso.Create(model);
                TempData["success"] = "Decomiso REGISTRADO Satisfactoriamente!";
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al Crear Novedad Decomiso");
                throw new Exception(ex.Message);
            }
        }

        // GET: Procesos/Decomisos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Procesos/Decomisos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

  
    }
}
