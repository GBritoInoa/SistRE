using BeEntity;
using BusinessControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace SistRE.Areas.Reportes.Controllers
{
    public class ReporteNovedadesController : Controller
    {



        /// <summary>
        /// Get TypeNovedad
        /// </summary>
        public void GetTypeNovedad()
        {

            try
            {
                var tiponovedad = BcTipoNovedad.GetAll().ToList();
                tiponovedad.Add(new BeTipoNovedad() { TipoNovedadID = 0, Nombre = "Todas las Novedades" });              
                ViewBag.TipoNovedadID = new SelectList(tiponovedad.OrderBy(c => c.TipoNovedadID), "TipoNovedadID", "Nombre");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }


        }

        // GET: Reportes/ReporteNovedades
        public ActionResult Index()
        {


          

            return View();
        }



        [HttpGet]
        /// <summary>
        /// Reporte Novedades
        /// </summary>
        /// <returns></returns>
        public ActionResult ReporteNovedades()
        {

            try
            {
                GetTypeNovedad();
                return View();
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }


        }


        [HttpPost]
        /// <summary>
        /// 
        /// Descargar archivo en formato excel
        /// </summary>
        /// <returns></returns>
        public ActionResult ReporteNovedades(int TipoNovedadId, DateTime FechaDesde, DateTime FechaHasta)
        {
            List<BeResultadoNovedad> ListNovedades = new List<BeResultadoNovedad>();
            try
            {
                ListNovedades = BcReporteNovedades.GetAll(TipoNovedadId, FechaDesde, FechaHasta).OrderBy(a => a.Novedad).ToList();
            


                

                var stream = new MemoryStream();
                var serialicer = new XmlSerializer(typeof(List<BeResultadoNovedad>));
                
                ////Lo transformo en un XML y lo guardo en memoria
                serialicer.Serialize(stream, ListNovedades);
                stream.Position = 0;

                ////devuelvo el XML de la memoria como un fichero .xls
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheet", "Listado" + ListNovedades[0].Novedad+".xls");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tiponovedadid"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="Fechahasta"></param>
        /// <returns></returns>
        public ActionResult Reporte_Novedades(int TipoNovedadID, DateTime FechaDesde , DateTime Fechahasta)
        {

            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}