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
    public class NovedadProtestaController : Controller
    {

        /// <summary>
        /// Get Provincias
        /// </summary>
        public void GetProvincias()
        {

            try
            {
                List<BeProvincias> Provincia = new List<BeProvincias>();
                Provincia = BcComun.GetProvincias().OrderBy(r => r.ProvinciaID).ToList();
                ViewBag.ProvinciaID = new SelectList(Provincia.OrderBy(c => c.ProvinciaID), "ProvinciaID", "Nombre");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Protesta");
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Get Tipo Protesta
        /// </summary>
        public void GetTipoProtesta()
        {

            try
            {
                List<BeTipoProtesta> TipoProtesta = new List<BeTipoProtesta>();
                TipoProtesta = BcComun.GetTipoProtesta().OrderBy(r => r.TipoProtestaID).ToList();
                ViewBag.TipoProtestaID = new SelectList(TipoProtesta.OrderBy(c => c.TipoProtestaID), "TipoProtestaID", "Nombre");
                ViewBag.TipoNovedadID = new SelectList(TipoProtesta.OrderBy(c => c.TipoNovedadID), "TipoNovedadID", "Nombre");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Protesta");
                throw new Exception(ex.Message);
            }

        }
        
        /// <summary>
        /// Get Institución Protestante
        /// </summary>
        public void GetInstitucionProtestante()
        {

            try
            {
                List<BeInstitucionProtestante> InstitucionProtestante = new List<BeInstitucionProtestante>();
                InstitucionProtestante = BcComun.GetInstitucionProtestante().OrderBy(r => r.InstitucionProtestanteID).ToList();
                ViewBag.InstitucionProtestanteID = new SelectList(InstitucionProtestante.OrderBy(c => c.InstitucionProtestanteID), "InstitucionProtestanteID", "Nombre");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Protesta");
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Get Categoria Protesta
        /// </summary>
        public void GetCategoriaProtesta()
        {

            try
            {
                List<BeCategoriaProtesta> CategoriaProtesta = new List<BeCategoriaProtesta>();
                CategoriaProtesta = BcComun.GetCategoriaProtesta().OrderBy(r => r.CategoriaProtestaID).ToList();
                ViewBag.CategoriaProtestaID = new SelectList(CategoriaProtesta.OrderBy(c => c.CategoriaProtestaID), "CategoriaProtestaID", "Nombre");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Protesta");
                throw new Exception(ex.Message);
            }
        }

        // GET: Procesos/NovedadProtestas/Create
        public ActionResult Create()
        {
            try
            {
                var model = new BeNovedadProtesta();
                GetProvincias();
                GetTipoProtesta();
                GetInstitucionProtestante();
                GetCategoriaProtesta();
                return View(model);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al crear Novedad Protesta");
                throw new Exception(ex.Message);
            }

        }

        // POST: Procesos/NovedadProtestas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeNovedadProtesta model)
        {

            if (!ModelState.IsValid)
            {
                GetProvincias();
                GetTipoProtesta();
                GetInstitucionProtestante();
                GetCategoriaProtesta();
                return View(model);
            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); //Usuario Logueado
                BcNovedadProtesta.Create(model);
                TempData["success"] = "Novedad REGISTRADA Satisfactoriamente!";
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al crear Novedad Protesta");
                throw new Exception(ex.Message);
            }
        }


    }
}
