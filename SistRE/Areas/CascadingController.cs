using BeEntity;
using BusinessControl;
using DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistRE.Areas
{
    public class CascadingController : Controller
    {
        // GET: Cascading
        public ActionResult Create()
        {

           //var _tipoIncautacion = new List<BeTipoIncautacion>() { new BeTipoIncautacion { ID = 0, Nombre = "----Seleccione Tipo Incautación----" } };
            List<BeTipoIncautacion> _tipoIncautacion = BcTipoIncautacion.GetAll().OrderBy(o => o.Nombre).ToList();
            ViewBag.Incautaciones = new SelectList(_tipoIncautacion, "ID", "Nombre");
            return View();
        }


        /// <summary>
        /// Get Productos
        /// </summary>
        /// <param name="idTipoProducto"></param>
        /// <returns></returns>
        public ActionResult Products(int Cid)
        {

            var tipoInc = BcTipoIncautacion.GetAll().Where(a => a.ID == Cid).FirstOrDefault();
            var tipoproducto = BcTipoProducto.GetAll().Where(y => y.TipoProductoID == tipoInc.TipoProductoID).FirstOrDefault();
            var productos = BcProductos.GetAll().Where(x => x.TipoProductoID == tipoproducto.TipoProductoID).ToList();
            return View("Create");
        }


        /// <summary>
        /// Get Tipo Medidas
        /// </summary>
        /// <param name="idProducto"></param>
        /// <returns></returns>
        public ActionResult Medidas(int idProducto)
        {

            var p = BcProductos.GetAll().Where(a => a.ID == idProducto).FirstOrDefault();
            var tp = BcTipoProducto.GetAll().Where(y => y.TipoProductoID == p.ID).FirstOrDefault();
            var tipomedidas = BcTipoMedidas.GetAll().Where(x => x.TipoProductoID == tp.TipoProductoID).ToList();
            return View("Create");
        }

    }
}