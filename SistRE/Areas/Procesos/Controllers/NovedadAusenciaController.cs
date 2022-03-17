using BeEntity;
using BusinessControl;
using DataLogic;
using SistRE.AccesControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistRE.Areas.Procesos.Controllers
{
    public class NovedadAusenciaController : Controller
    {

        /// <summary>
        /// Rangos
        /// </summary>
        public void  GetRangos()
        {
            try
            {
           
                List<BeRangos> Rango = BcComun.GetRangos().OrderBy(r=> r.RangoID).ToList();
                ViewBag.RangoID = new SelectList(Rango.OrderBy(r=>r.RangoID), "RangoID", "Rango");
            }
            catch (Exception ex)   
            {

                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Ausencia");
                throw new Exception(ex.Message);
            }
           
        }

        /// <summary>
        /// Companías
        /// </summary>
        public void GetCompanias()
        {

            try
            {
                List<BeCompania> Compania = new List<BeCompania>();
                 Compania = BcComun.GetCompania().OrderBy(r => r.CompaniaID).ToList();
                  ViewBag.CompaniaID = new SelectList(Compania.OrderBy(c=> c.CompaniaID), "CompaniaID", "Nombre");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Ausencia");
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Get Ausencias
        /// </summary>
        public void GetAusencias()
        {
            try
            {
                List<BeAusencias> Ausencias = new List<BeAusencias>();
                 Ausencias = BcAusencias.GetAll().ToList();
                ViewBag.AusenciaID = new SelectList(Ausencias.OrderBy(o=> o.ID), "ID", "Nombre");
                ViewBag.TipoNovedadID = new SelectList(Ausencias,"TipoNovedadID", "Nombre");

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Ausencia");
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Get Sexo
        /// </summary>
        public void GetSexo()
        {

            try
            {
                List<BeSexo> Sexo = new List<BeSexo>();
                Sexo = BcComun.GetSexo().Where(a => a.SexoID <= 2).ToList();
                ViewBag.SexoID = new SelectList(Sexo.OrderBy(s=>s.SexoID), "SexoID", "Nombre");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Ausencia");
                throw new Exception(ex.Message);
            }


        }

        /// <summary>
        /// Registro de Novedad Ausencia
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {

            try
            {
                GetAusencias();
                GetRangos();
                GetSexo();
                GetCompanias();
                return View(new BeNovedadAusencia());
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Ausencia");
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// HttpPost
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeNovedadAusencia item)

        {

    
            if(!ModelState.IsValid)
            {
                GetSexo();
                GetRangos();
                GetCompanias();
                GetAusencias();
                return View(item);

            }
            try
            {
                item.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); ///Guarda el usuario logueado
                BcNovedadAusencia.Create(item);
                TempData["success"] = "Ausencia REGISTRADA Satisfactoriamente!";
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Ausencia");
                throw new Exception(ex.Message);
            }
        }
    }
}