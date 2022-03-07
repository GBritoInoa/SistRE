﻿using BeEntity;
using BusinessControl;
using DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistRE.Areas.Procesos.Controllers
{
    public class NovedadProtestaController : Controller
    {

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

        public void GetTipoProtesta()
        {

            try
            {
                List<BeTipoProtesta> TipoProtesta = new List<BeTipoProtesta>();
                TipoProtesta = BcComun.GetTipoProtesta().OrderBy(r => r.TipoProtestaID).ToList();
                ViewBag.TipoProtestaID = new SelectList(TipoProtesta.OrderBy(c => c.TipoProtestaID), "TipoProtestaID", "Nombre");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Protesta");
                throw new Exception(ex.Message);
            }

        }

        public void GetInstitucionProtestante()
        {

            try
            {
                List<BeInstitucionProtestante> InstitucionProtestante = new List<BeInstitucionProtestante>();
                InstitucionProtestante = BcComun.GetInstitucionProtestante().OrderBy(r => r.InstitucionProtestanteID).ToList();
                ViewBag.InstitucionProtestante = new SelectList(InstitucionProtestante.OrderBy(c => c.InstitucionProtestanteID), "InstitucionProtestanteID", "Nombre");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Protesta");
                throw new Exception(ex.Message);
            }

        }

        public void GetCategoriaProtesta()
        {

            try
            {
                List<BeCategoriaProtesta> CategoriaProtesta = new List<BeCategoriaProtesta>();
                CategoriaProtesta = BcComun.GetCategoriaProtesta().OrderBy(r => r.CategoriaProtestaID).ToList();
                ViewBag.CategoriaProtesta = new SelectList(CategoriaProtesta.OrderBy(c => c.CategoriaProtestaID), "CategoriaProtestaID", "Nombre");
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

                BcNovedadProtesta.Create(model);
                TempData["success"] = "Protesta REGISTRADO Satisfactoriamente!";
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
