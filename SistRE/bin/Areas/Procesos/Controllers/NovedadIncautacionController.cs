using BeEntity;
using BusinessControl;
using SistRE.AccesControl;
using SistRE.AccessControl;
using SistRE.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SistRE.Areas.Procesos.Controllers
{
    [Autorizar(Profiles = new EnumPerfiles.Perfiles[] { EnumPerfiles.Perfiles.Administrador, EnumPerfiles.Perfiles.Digitador })]
    public class NovedadIncautacionController : Controller
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

                var tipoInc = BcTipoIncautacion.GetAll().Where(a=>a.ID == TipoProductoID).FirstOrDefault();
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
        /// Tipo Medidas
        /// </summary>
        /// <param name="ProductoId"></param>
        /// <returns></returns>
        public JsonResult  GetTipoMedidas (int ProductoID)
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


        ///// <summary>
        ///// Get TipoCombustible and TipoMedidaCombustible
        ///// </summary>
        //private void GetTipoCombustible()

        //{
        //    try
        //    {

        //        List<BeProductos> TipoCombustible = BcTipos.GetProductos().Where(p => p.TipoProductoID == 12).ToList();
        //        ViewBag.TipoCombustibleID = new SelectList(TipoCombustible, "ID", "Nombre");
        //        List<BeTipoMedidaCombustible> TipoMedidaCombustible = BcTipos.GetTipoMedidaCombustible().OrderBy(o => o.Medida).ToList();
        //        ViewBag.TipoMedidaCombustibleID = new SelectList(TipoMedidaCombustible, "TipoMedidaCombustibleID", "Medida");
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }

        //}

        /// <summary>
        /// GetTipoIncautacion
        /// </summary>
        private void GetTipoIncautacion()
        {

            try
            {

                List<BeTipoIncautacion> TipoIncautacion = BcTipoIncautacion.GetAll().OrderBy(r => r.ID).ToList();
                ViewBag.TipoIncautacionID = new SelectList(TipoIncautacion.OrderBy(c => c.Nombre), "ID", "Nombre");
                ViewBag.TipoNovedadID = new SelectList(TipoIncautacion.OrderBy(c => c.TipoNovedadID), "TipoNovedadID", "Nombre");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Ausencia");
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
        /// GetNacionalidades
        /// </summary>
        private void GetNacionalidades()
        {

            try
            {
                List<BeNacionalidad> Nacionalidades = BcNacionalidad.GetAll().ToList();
                ViewBag.NacionalidadID = new SelectList(Nacionalidades.OrderBy(p => p.Nombre), "NacionalidadID", "Nombre");
                ViewBag.NacionalidadID1 = new SelectList(Nacionalidades.OrderBy(p => p.Nombre), "NacionalidadID", "Nombre");
                ViewBag.NacionalidadID2 = new SelectList(Nacionalidades.OrderBy(p => p.Nombre), "NacionalidadID", "Nombre");
                //return Json(Nacionalidades, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al obtener List Nacionalidades");
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
                GetNacionalidades();
                GetProductos();
                GetTipoIncautacion();
                GetBrigadas();
                GetProvincias();
                return View();
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al MOSTRAR Vista Novedad Incautación");
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
        public ActionResult Create(BeNovedadIncautacion model)
        {
         
           model.EstatusID = (int)EstatusRegistro.Estatus.Activo;
            if(!ModelState.IsValid)
            {
                GetNacionalidades();
                GetProductos();
                GetTipoIncautacion();
                GetBrigadas();
                GetProvincias();
                return View(model);

            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); //Usuario Logueado
                BcNovedadIncautacion.Create(model);
                TempData["success"] = "Incautacion REGISTRADA Satisfactoriamente!";
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al REGISTRAR Novedad Incautación");
                throw new Exception(ex.Message);
            }

        }


        public ActionResult _Nacionalidades()
        {

            try
            {
                List<BeNacionalidad> Nacionalidades = BcNacionalidad.GetAll().ToList();
                ViewBag.NacionalidadID = new SelectList(Nacionalidades.OrderBy(p => p.Nombre), "NacionalidadID", "Nombre");
                ViewBag.NacionalidadID1 = new SelectList(Nacionalidades.OrderBy(p => p.Nombre), "NacionalidadID", "Nombre");
                ViewBag.NacionalidadID2 = new SelectList(Nacionalidades.OrderBy(p => p.Nombre), "NacionalidadID", "Nombre");
                //return Json(Nacionalidades, JsonRequestBehavior.AllowGet);
                return PartialView(Nacionalidades);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al obtener List Nacionalidades");
                throw new Exception(ex.Message);
            }



        }
    }
}