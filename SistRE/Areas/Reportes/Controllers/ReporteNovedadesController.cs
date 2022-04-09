using BeEntity;
using BusinessControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace SistRE.Areas.Reportes.Controllers
{

    /// <summary>
    /// Reporte Novedades
    /// </summary>
    public class ReporteNovedadesController : Controller
    {
        string NombreArchivo;


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


        /// <summary>
        ///  Descargar Excel
        /// </summary>
        /// <param name="TipoNovedadId"></param>
        /// <returns></returns>
        [HttpGet]
        public   ActionResult Download(int TipoNovedadID, DateTime FechaDesde, DateTime FechaHasta)
        {

            
            if (TipoNovedadID == 0)
                {
                TipoNovedadID = 0;
                }
                List<BeResultadoNovedad> ListNovedades = new List<BeResultadoNovedad>();
                ListNovedades = BcReporteNovedades.GetAll(TipoNovedadID, FechaDesde, FechaHasta).OrderBy(a => a.Novedad).ToList();
                try
                {

                    if (ListNovedades.Count == 0)
                    {
                    TempData["success"] = "!No EXISTEN registros para esta consulta!";
                    GetTypeNovedad();
                    RedirectToAction("ReporteNovedades");
                    }

                    else
                    {

                        if (TipoNovedadID == 0)
                        {

                            NombreArchivo = "Todas las Novedades" + " " + "Desde" + " " + FechaDesde.ToShortDateString() + " " + "Hasta" + " " + FechaHasta.ToShortDateString();
                            ViewBag.NombreArchivo = "Todas las Novedades";

                        }
                        else
                        {
                            NombreArchivo = ListNovedades[0].Novedad.ToString() + " " + "Desde" + " " + FechaDesde.ToShortDateString() + " " + "Hasta" + " " + FechaHasta.ToShortDateString();
                            ViewBag.NombreArchivo = ListNovedades[0].Novedad.ToString();
                        }

                  
                    }
                var stream = new MemoryStream();
                var serialicer = new XmlSerializer(typeof(List<BeResultadoNovedad>));
                
                //Lo transformo en un XML y lo guardo en memoria
                serialicer.Serialize(stream, ListNovedades);
                stream.Position = 0;
              

                //devuelvo el XML de la memoria como un fichero.xls
                return  File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheet", "Reporte Estiadísticas" + " " + NombreArchivo + ".xls");

            }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "Error al generar Gráficos Estadísticos");
                    throw new Exception(ex.Message);
                }         


            }


        [DisplayName("Estadisticas")]
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



        [Route("Estadísticas")]
        [HttpPost]
        /// <summary>
        /// 
        /// Descargar archivo en formato excel
        /// </summary>
        /// <returns></returns>
        public ActionResult ReporteNovedades(int TipoNovedadId, DateTime FechaDesde, DateTime FechaHasta)
        {
            if(TipoNovedadId == 0)
            {
                TipoNovedadId = 0;
            }

        
            List<BeResultadoNovedad> ListNovedades = new List<BeResultadoNovedad>();
            ListNovedades = BcReporteNovedades.GetAll(TipoNovedadId, FechaDesde, FechaHasta).OrderBy(a => a.Novedad).ToList();
            try
            {

                if (ListNovedades.Count == 0)
                {
                    TempData["success"] = "!No EXISTEN registros para esta consulta!";
               
                    GetTypeNovedad();
                    return View();
                
                }

                  
                    string listados = "";
                    List<string> Novedad = new List<string>();

                    foreach (var item in ListNovedades)
                    {
                        Novedad.Add($"['{item.Provincia}' , {item.Cantidad}]");

                    }
                    listados += String.Join(",", Novedad);
                    listados += "";
                    ViewBag.Novedades = listados;
                

                ViewBag.TNId = TipoNovedadId;
                ViewBag.FechaDesde = FechaDesde;
                ViewBag.FechaHasta = FechaHasta;
                GetTypeNovedad();
                return View(); 
                          
            }            

            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al generar Gráficos Estadísticos");
                throw new Exception(ex.Message);
            }
                     

        }

        private ActionResult RedirectToActionPermanent(string v, int tipoNovedadId, DateTime fechaDesde, DateTime fechaHasta)
        {
            throw new NotImplementedException();
        }
    }
}