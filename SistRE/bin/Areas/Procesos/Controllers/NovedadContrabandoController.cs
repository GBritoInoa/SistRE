using BeEntity;
using BusinessControl;
using SistRE.AccesControl;
using SistRE.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SistRE.Areas.Procesos.Controllers
{
    public class NovedadContrabandoController : Controller
    {
             

        // GET: Procesos/NovedadIncautacion
        public ActionResult Index()
        {
            return View();
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
                var tipoC = BcTipoContrabando.GetAll().Where(a=>a.ID == TipoProductoID).FirstOrDefault();
                var tipoproducto = BcTipoProducto.GetAll().Where(y => y.TipoProductoID == tipoC.TipoProductoID).FirstOrDefault();
                var productos = BcProductos.GetAll().Where(x => x.TipoProductoID == 2).ToList();
                 
                return Json(productos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
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

                var p = BcProductos.GetAll().Where(a => a.ID == ProductoID).FirstOrDefault();
                var tp = BcTipoProducto.GetAll().Where(y => y.TipoProductoID == p.ID).FirstOrDefault();
                var TipoMedidaID = BcTipoMedidas.GetAll().Where(x => x.TipoProductoID == tp.TipoProductoID).ToList();
                return Json(TipoMedidaID, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Tipo Contrabando
        /// </summary>
        private void GetTipoContrabando()
        {

            try
            {

                List<BeTipoContrabando> TipoContrabando = BcTipoContrabando.GetAll().OrderBy(r => r.ID).ToList();
                ViewBag.TipoContrabandoID = new SelectList(TipoContrabando.OrderBy(c => c.ID), "ID", "Nombre");
                ViewBag.TipoNovedadID = new SelectList(TipoContrabando, "TipoNovedadID", "Nombre");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error generar Listado Contrabando");
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
                ModelState.AddModelError(ex.Message, "Error al obtener List Provincias");
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// List Productos
        /// </summary>
        private void GetProductos( )
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
        /// Get Tipo Producto
        /// </summary>
        private void GetTipoProducto()
        {
            try
            {
                List<BeTipoProducto> tipoproductos = BcTipos.GetTipoProducto().ToList();
                ViewBag.regionsItems = new SelectList(tipoproductos.OrderBy(p => p.Nombre), "TipoProductoID", "Nombre");

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al obtener LISTADO Productos");
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {

            try
            {
                                
                GetProductos();
                GetTipoContrabando();
                GetBrigadas();
                GetProvincias();
                return View();
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al MOSTRAR Vista Novedad Contrabando");
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Registro Novedad Incautación
        /// <param name="model"></param>
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeNovedadContrabando model)
        {
         
           model.EstatusID = (int)EstatusRegistro.Estatus.Activo;
            if(!ModelState.IsValid)
            {
                GetProductos();
                GetTipoContrabando(); 
                GetBrigadas();
                GetProvincias();
                return View(model);
            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName;
                BcNovedadContrabando.Create(model);
                TempData["success"] = "Contrabando REGISTRADO Satisfactoriamente!";
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al REGISTRAR Novedad Contrabando");
                throw new Exception(ex.Message);
            }

        }
    }
}