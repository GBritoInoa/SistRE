using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessControl;
using BeEntity;
using Microsoft.Reporting.WebForms;
using System.IO;


namespace SistRE.Areas.Reportes.Controllers
{
    public class ReportsController : Controller
    {



        /// <summary>
        /// Reorte Decomisos
        /// </summary>
        /// <returns></returns>
        public ActionResult Decomisos()
        {

            try
            {

                string DirectoryRelative = "~/";
                string urlArchivo = string.Format("{0}.{1}", "MiReporte", "rdlc");

                string FullPathReporte = string.Format("{0}.{1}", this.HttpContext.Server.MapPath(DirectoryRelative), urlArchivo);
                    
                ReportViewer rpte = new ReportViewer();
                rpte.Reset();
                rpte.LocalReport.ReportPath = FullPathReporte;
                ReportDataSource datasource = new ReportDataSource("", "mi data");
                   rpte.LocalReport.DataSources.Add(datasource);
                rpte.LocalReport.Refresh();
                byte[] file = rpte.LocalReport.Render("PDF");
                return File(new MemoryStream(file).ToArray(),
                System.Net.Mime.MediaTypeNames.Application.Octet,
                string.Format("{0}{1}","ArchivoPrueba.","PDF"));
                    
        
            }
            catch (Exception)
            {

                throw;
            }
        }
     
    }
}
