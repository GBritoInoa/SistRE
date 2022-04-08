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

            if (PoncentajeNovedades.Count > 0)
            {
                BeResultadoNovedad Protestas = PoncentajeNovedades.Find(a => a.Novedad.Contains("Protestas"));
                BeResultadoNovedad Repatriaciones = PoncentajeNovedades.Find(a => a.Novedad.Contains("Repatriaciones"));
                BeResultadoNovedad Apresamientos = PoncentajeNovedades.Find(a => a.Novedad.Contains("Apresamientos"));
                BeResultadoNovedad Incautaciones = PoncentajeNovedades.Find(a => a.Novedad.Contains("Incautaciones"));

                //////////////////Validando si hay Protestas//////////////////
                if (Protestas != null)
                    {
                    ViewBag.Protestas = Protestas.PorcientoNovedad.Substring(0, 3);
        
                    IEnumerable<BeResultadoNovedad> ListProtestas = from p in ListNovedades where p.Novedad.Equals("Protestas") select p;
                    string listadoProtrestas = "";
                    List<string> Novedad = new List<string>(); 

                    foreach (var item in ListProtestas)
                    {
                        Novedad.Add($"['{item.Provincia}' , {item.Cantidad}]");

                    }
                    listadoProtrestas += String.Join(",", Novedad);
                    listadoProtrestas += "";
                    ViewBag.NovedadProtestas = listadoProtrestas;
                }
                else
                {
                    ViewBag.Protestas = 0.00;

                }

                //////////////////Validando si hay Apresamientos//////////////////
                if (Apresamientos != null)
                {
                    ViewBag.Apresamientos = Apresamientos.PorcientoNovedad.Substring(0, 3);

                    IEnumerable<BeResultadoNovedad> ListApresamientos = from a in ListNovedades where a.Novedad.Contains("Apresamientos") select a;
                    string listadoApresamientos = "";
                    List<string> Novedad = new List<string>();

                    foreach (var item in ListApresamientos)
                    {
                        Novedad.Add($"['{item.Provincia}' , {item.Cantidad}]");

                    }
                    listadoApresamientos += String.Join(",", Novedad);
                    listadoApresamientos += "";
                    ViewBag.NovedadApresamientos= listadoApresamientos;
                }
                else
                {
                    ViewBag.Apresamientos = 0.00;

                }

                //////////////////Validando si hay Repatriaciones//////////////////
                if (Repatriaciones != null)
                {
                    ViewBag.Repatriaciones = Repatriaciones.PorcientoNovedad.Substring(0, 3);

                    IEnumerable<BeResultadoNovedad> ListRepatriaciones = from a in ListNovedades where a.Novedad.Contains("Repatriaciones") select a;
                    string listadoRepatriaciones = "";
                    List<string> Novedad = new List<string>();

                    foreach (var item in ListRepatriaciones)
                    {
                        Novedad.Add($"['{item.Provincia}' , {item.Cantidad}]");

                    }
                    listadoRepatriaciones += String.Join(",", Novedad);
                    listadoRepatriaciones += "";
                    ViewBag.NovedadRepatriaciones = listadoRepatriaciones;
                }
                else
                {
                    ViewBag.Repatriaciones = 0.00;

                }

                //////////////////Validando si hay Incautaciones//////////////////
                if (Incautaciones != null)
                {
                    ViewBag.Incautaciones = Incautaciones.PorcientoNovedad.Substring(0, 3);

                    IEnumerable<BeResultadoNovedad> ListIncautaciones = from a in ListNovedades where a.Novedad.Contains("Incautaciones") select a;
                    string listadoIncautaciones = "";
                    List<string> Novedad = new List<string>();

                    foreach (var item in ListIncautaciones)
                    {
                        Novedad.Add($"['{item.Provincia}' , {item.Cantidad}]");

                    }
                    listadoIncautaciones += String.Join(",", Novedad);
                    listadoIncautaciones += "";
                    ViewBag.NovedadIncautaciones = listadoIncautaciones;
                }
                else
                {
                    ViewBag.Incautaciones = 0.00;

                }


   
            }
            else
            {

                ViewBag.Protestas = 0.00;
                ViewBag.Incautaciones = 0.00;
                ViewBag.Apresamientos = 0.00;
                ViewBag.Repatriaciones = 0.00;

            }

  
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
            TempData["error"] = "Usted no tiene PERMISOS para acceder a esta opcion!";
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