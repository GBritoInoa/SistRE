using SistRE.AccessControl;
using System.Net;
using System.Web.Mvc;
using SistRE.Models;
using SistRE.AccesControl;
using BusinessControl;
using SistRE.Comun;
using System;
using System.Collections.Generic;
using BeEntity;
using Newtonsoft.Json;
using System.Data;

namespace SistRE.Controllers
{
    public class HomeController : Controller
    {
        public string _IpAddress { get; set; }
        [Autorizar(AllowAllProfiles = true)]

        public class BeREsultado
        {
            public int Novedad { get; set; }
            public string Provincia { get; set; }
        }

        public ActionResult Index()
        {

            var TipoNovedadId = 0;
            var FechaDesde = DateTime.Now;
            var FechaHasta = DateTime.Now;

            List<BeResultadoNovedad> ListNovedades = new List<BeResultadoNovedad>();
            List<BeResultadoNovedad> PoncentajeNovedades = new List<BeResultadoNovedad>();

            ListNovedades = BcReporteNovedades.GetAll(TipoNovedadId, FechaDesde, FechaHasta);
            PoncentajeNovedades = BcReporteNovedades.PorcientoNovedad();
            BeResultadoNovedad Protestas = PoncentajeNovedades.Find(a => a.Novedad.Equals("Protesta"));
            BeResultadoNovedad Repatriaciones = PoncentajeNovedades.Find(a => a.Novedad.Equals("Repatriación"));
            BeResultadoNovedad Apresamientos = PoncentajeNovedades.Find(a => a.Novedad.Equals("Apresamientos"));
            BeResultadoNovedad Incautaciones = PoncentajeNovedades.Find(a => a.Novedad.Equals("Protesta"));

            ViewBag.Protestas = Protestas.PorcientoNovedad.Substring(0, 2);
            ViewBag.Repatriaciones = Repatriaciones.PorcientoNovedad.Substring(0, 2);
            ViewBag.Apresamientos = Apresamientos.PorcientoNovedad.Substring(0, 2);
            ViewBag.Incautaciones = Incautaciones.PorcientoNovedad.Substring(0, 2);
            var CantidadProtestas = ListNovedades.Find(a => a.Novedad.Equals("Protesta"));

            string listados = "";
            List<string> Novedad = new List<string>();
           
            foreach (var item in ListNovedades) {
                Novedad.Add($"['{item.Provincia}' , {item.CantidadNovedad}]");
          
            }
            listados += String.Join(",",Novedad);
            listados += "";
            ViewBag.Novedades = listados;
            //string emcabezado ;
            //DataTable data = new DataTable();

            //data.Columns.Add(new DataColumn("Provincia", typeof(string)));
            //data.Columns.Add(new DataColumn("CantidadNovedad", typeof(int)));
            //foreach (var item in ListNovedades)
            //{
            //    data.Rows.Add(new Object[] { item.Provincia, item.CantidadNovedad });
            //}

            //emcabezado = "[['Novedades', 'Por Provincia'],";
            //foreach (DataRow item in data.Rows)
            //{
            //    emcabezado = emcabezado + "[";
            //    emcabezado = emcabezado +"'"+item[0]+"'" + ","+item[1];
            //    emcabezado = emcabezado + "],";
            //}

            //  emcabezado = emcabezado + "]";

            //ViewBag.Novedades = resultado;
            //string dataNovedades = "[['Prueba','probando nuevamente']";


            //List<string> itemsAnyos = new List<string>();

            //List<string> itemsCantidad = new List<string>();


            //foreach (var item in ListNovedades)
            //{

            //    //dataNovedades
            //    itemsAnyos.Add($"'[{item.Novedad} , {item.CantidadNovedad}]'");


            //}              


            //CantidadPorAnyos += String.Join(",", itemsAnyos);

            //CantidadPorAnyos += "";

            //ViewBag.cantidadPorAnios =

            //ViewBag.CantidadProtestas = JsonConvert.SerializeObject(itemsAnyos);


            //TempData["info"] = "Prueeeebaaaaaa";
            //TempData["warn"] = "Hum! Cuidao!";
            //TempData["success"] = "Siiiii!";
            //TempData["error"] = "Oh noooo!";
            //TempData["mensaje"] = "Oh noooo!";
            List<string> result = new List<string>();

            //var prue = string.Format("'{0}'" + ListNovedades[0].Provincia);
            //result.Add("'" +ListNovedades[0].Provincia+"'");    
            ViewBag.Cantidad = TipoNovedadId;
            ViewBag.Provincia = "Probando";
            return View();
        }




        /// <summary>
        /// Acceso al Sistema
        /// </summary>
        /// <returns></returns>
          public ActionResult Login()
        {
            return View();

        }
      
        [HttpPost]
        public ActionResult Login(BeEntity.BeCredencials model)
        {
            if (!ModelState.IsValid)
                return View(model);

            DalcMembresia MB = new DalcMembresia();
            var loginResult = MB.Login(model);

            if (!loginResult.Success)
            {
                ModelState.AddModelError("password", loginResult.Message);
                return View(model);
            }

            SessionData.SetSesion(loginResult.User.UserName, loginResult.User.Perfil.ToString(), loginResult.User.PerfilID, loginResult.User.NombreCompleto, loginResult.User.Rango);

            return RedirectToAction("Index");

        }
        public ActionResult LogOff()
        {
            SessionData.ClearSession();
            return RedirectToAction("Login");
        }

        /// <summary>
        /// User not Autorized
        /// </summary>
        /// <returns></returns>
        public ActionResult NotAutorized()
        {
            TempData["error"] = "Usted no tiene permisos para acceder a esta opcion!";
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}