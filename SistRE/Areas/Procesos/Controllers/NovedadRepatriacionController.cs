using BeEntity;
using BusinessControl;
using SistRE.AccesControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistRE.Areas.Procesos.Controllers
{
    public class NovedadRepatriacionController : Controller
    {

        /// <summary>
        /// Get Sexo
        /// </summary>
        public void GetSexo()
        {

            try
            {
                List<BeSexo> Sexo = new List<BeSexo>();
                Sexo = BcComun.GetSexo().ToList();
                ViewBag.SexoID = new SelectList(Sexo.OrderBy(s => s.SexoID), "SexoID", "Nombre");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Ausencia");
                throw new Exception(ex.Message);
            }


        }


        /// <summary>
        /// Causa Apresamiento
        /// </summary>
        public void GetCausaRepatriación()
        {
            try
            {

                List<BeCausaRepatriacion> Brigadas = BcTipos.GetCausaRepatriacion().ToList();
                ViewBag.CausaID = new SelectList(Brigadas.OrderBy(b => b.Nombre), "ID", "Nombre");

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Cargar  Causa Apresamiento");
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
                ViewBag.CompaniaID = new SelectList(Compania.OrderBy(c => c.CompaniaID), "CompaniaID", "Nombre");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Ausencia");
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Rangos
        /// </summary>
        public void GetRangos()
        {
            try
            {

                List<BeRangos> Rango = BcComun.GetRangos().OrderBy(r => r.RangoID).ToList();
                ViewBag.RangoID = new SelectList(Rango.OrderBy(r => r.RangoID), "RangoID", "Rango");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al obtener Listado Rangos");
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Get Brigadas
        /// </summary>
        private void GetBrigadas()
        {

            try
            {
                List<BeBrigada> Brigadas = BcComun.GetBrigadas().ToList();
                ViewBag.BrigadaID = new SelectList(Brigadas.OrderBy(b => b.UnidadID), "UnidadID", "Nombre");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al obtener List Provincias");
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// GetProvincias
        /// </summary>
        private void GetProvincias()
        {

            try
            {
                List<BeProvincias> Provincias = BcComun.GetProvincias().ToList();
                ViewBag.ProvinciaID = new SelectList(Provincias.OrderBy(p => p.Nombre), "ProvinciaID", "Nombre");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al obtener List Provincias");
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// GetNacionalidades
        /// </summary>
        private void GetNacionalidades()
        {

            try
            {
                List<BeNacionalidad> Nacionalidades = BcNacionalidad.GetAll().ToList();
                ViewBag.NacionalidadID = new SelectList(Nacionalidades.OrderBy(p => p.Nombre), "ID", "Nombre");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al obtener List Nacionalidades");
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// GetPaíses
        /// </summary>
        private void GetPais()
        {
            try
            {
                List<BePais> paises = BcPais.GetAll().ToList();
                ViewBag.PaisID = new SelectList(paises.OrderBy(p => p.Nombre), "PaisID", "Nombre");

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al obtener List Países");
                throw new Exception(ex.Message);
            }
        }


        // GET: Procesos/NovedadRepatriacion/Create
        public ActionResult Create()
        {

            var model = new BeNovedadRepatriacion();
            GetCausaRepatriación();
            GetBrigadas();
            GetCompanias();
            GetNacionalidades();
            GetProvincias();
            GetPais();
            GetSexo();
            GetRangos();
            return View(model);
        }

        // POST: Procesos/NovedadRepatriacion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeNovedadRepatriacion model)
        {

            if (!ModelState.IsValid)
            {
                GetCausaRepatriación();
                GetBrigadas();
                GetCompanias();
                GetNacionalidades();
                GetProvincias();
                GetPais();
                GetSexo();
                GetRangos();
                return View(model);

            }

            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); //Usuario Logueado
                BcNovedadRepatriacion.Create(model);
                TempData["success"] = "Novedad REGISTRADA Satisfactoriamente!";
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al crear Novedad Apresamiento");
                throw new Exception(ex.Message);
            }


        }
    }
}

