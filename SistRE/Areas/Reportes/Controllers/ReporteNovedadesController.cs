using BeEntity;
using BusinessControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace SistRE.Areas.Reportes.Controllers
{
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


        //public ActionResult Index()
        //{

        //    var TipoNovedadId = 0;
        //    var FechaDesde = DateTime.Now;
        //    var FechaHasta = DateTime.Now;

        //    List<BeResultadoNovedad> ListNovedades = new List<BeResultadoNovedad>();
        //    List<BeResultadoNovedad> PoncentajeNovedades = new List<BeResultadoNovedad>();
        //    ListNovedades = BcReporteNovedades.GetAll(TipoNovedadId, FechaDesde, FechaHasta);
   
        //    IEnumerable<BeResultadoNovedad> ListProtestas = from p in ListNovedades where p.Novedad.Equals("Protesta") select p;
        //    IEnumerable<BeResultadoNovedad> ListApresados = from a in ListNovedades where a.Novedad.Equals("Apresamientos") select a;


        //    //////////////////Protestas//////////////////
        //    string listados = "";
        //    List<string> Novedad = new List<string>();

        //    foreach (var item in ListProtestas)
        //    {
        //        Novedad.Add($"['{item.Provincia}' , {item.CantidadNovedad}]");

        //    }
        //    listados += String.Join(",", Novedad);
        //    listados += "";
        //    ViewBag.Novedades = listados;

        //    ////////////////////////////////////////////////////////

        //    //////////////////Apresados//////////////////
        //    string listadosApresados = "";
        //    List<string> Novedadapresados = new List<string>();

        //    foreach (var item in ListApresados)
        //    {
        //        Novedadapresados.Add($"['{item.Provincia}' , {item.CantidadNovedad}]");

        //    }
        //    listadosApresados += String.Join(",", Novedadapresados);
        //    listadosApresados += "";
        //    ViewBag.NovedadesApresados = listadosApresados;
        //    ////////////////////////////////////////////////////////

        //    return View();
        //}



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


        [DisplayName("Estadisticas")]
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
                    TempData["info"] = "No EXISTEN REGISTROS PARA ESTA CONSULTA";
                    GetTypeNovedad();
                    return View();
                }

                else
                {

                    if (TipoNovedadId == 0)
                    {

                        NombreArchivo = "Todas las Novedades" + " " + "Desde" + " " + FechaDesde.ToShortDateString() + " " + "Hasta" + " " + FechaHasta.ToShortDateString();
                        ViewBag.NombreArchivo = "Todas las Novedades";

                    }
                    else
                    {
                        NombreArchivo = ListNovedades[0].Novedad.ToString() + " " + "Desde" + " " + FechaDesde.ToShortDateString() + " " + "Hasta" + " " + FechaHasta.ToShortDateString();
                        ViewBag.NombreArchivo = ListNovedades[0].Novedad.ToString();
                    }
              
                    IEnumerable<BeResultadoNovedad> ListadeNovedades = from p in ListNovedades where p.TipoNoveddID == TipoNovedadId select p;
                  
                    //////////////////Protestas//////////////////
                    string listados = "";
                    List<string> Novedad = new List<string>();

                    foreach (var item in ListNovedades)
                    {
                        Novedad.Add($"['{item.Provincia}' , {item.CantidadNovedad}]");

                    }
                    listados += String.Join(",", Novedad);
                    listados += "";
                    ViewBag.Novedades = listados;
                    GetTypeNovedad();
                    var stream = new MemoryStream();
                    var serialicer = new XmlSerializer(typeof(List<BeResultadoNovedad>));

                    //Lo transformo en un XML y lo guardo en memoria
                    serialicer.Serialize(stream, ListNovedades);
                    stream.Position = 0;
0;
                    //devuelvo el XML de la memoria como un fichero.xls
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheet", "Reporte Estiadísticas" + " " + NombreArchivo + ".xls");


                }

            }
            

            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al generar Gráficos Estadísticos");
                throw new Exception(ex.Message);
            }
                     

        }

     

   
    }
}