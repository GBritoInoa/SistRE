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
using System.Linq;

namespace SistRE.Controllers
{
    public class HomeController : Controller
    {
        public string _IpAddress { get; set; }
        [Autorizar(AllowAllProfiles = true)]

 

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

           IEnumerable<BeResultadoNovedad> ListProtestas = from p in ListNovedades where p.Novedad.Equals("Protesta") select p;
            IEnumerable<BeResultadoNovedad> ListApresados = from a in ListNovedades where a.Novedad.Equals("Apresamientos") select a;



            //////////////////Protestas//////////////////
            string listados = "";
            List<string> Novedad = new List<string>();
           
            foreach (var item in ListProtestas) {
                Novedad.Add($"['{item.Provincia}' , {item.CantidadNovedad}]");
          
            }
            listados += String.Join(",",Novedad);
            listados += "";
            ViewBag.Novedades = listados;

            ////////////////////////////////////////////////////////

            //////////////////Apresados//////////////////
            string listadosApresados = "";
            List<string> Novedadapresados = new List<string>();

            foreach (var item in ListApresados)
            {
                Novedadapresados.Add($"['{item.Provincia}' , {item.CantidadNovedad}]");

            }
            listadosApresados += String.Join(",", Novedadapresados);
            listadosApresados += "";
            ViewBag.NovedadesApresados = listadosApresados;
            ////////////////////////////////////////////////////////

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