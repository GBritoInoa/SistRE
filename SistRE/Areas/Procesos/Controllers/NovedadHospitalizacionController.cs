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
    public class NovedadHospitalizacionController : Controller
    {


        /// <summary>
        /// Get Sexo
        /// </summary>
        public void GetSexo()
        {

            try
            {
                List<BeSexo> Sexo = new List<BeSexo>();
                Sexo = BcComun.GetSexo().ToList().Where(s=> s.SexoID <= 2).ToList();
                ViewBag.SexoID = new SelectList(Sexo.OrderBy(s => s.SexoID), "SexoID", "Nombre");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Ausencia");
                throw new Exception(ex.Message);
            }


        }

        /// <summary>
        /// Get TypeNovedad
        /// </summary>
        public void GetTypeNovedad()
        {

            try
            {
                var tiponovedad = BcTipoNovedad.GetAll().Where(a => a.Nombre.Equals("Hospitalización")).ToList();
                ViewBag.TipoNovedadID = new SelectList(tiponovedad.OrderBy(c => c.TipoNovedadID), "TipoNovedadID", "Nombre");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error");
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

                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Ausencia");
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
        private void GetHospitales()
        {

            try
            {
                List<BeHospitales> Hospitales = BcComun.GetBeHospitales().ToList();
                ViewBag.HospitalID = new SelectList(Hospitales.OrderBy(p => p.Nombre), "HospitalID", "Nombre");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al obtener List Hospitales");
                throw new Exception(ex.Message);
            }
        }

        private void GetEnfermedades()
        {

            try
            {
                List<BeEnfermedades> Enfermedades = BcComun.GetBeEnfermedades().ToList();
                ViewBag.EnfermedadID = new SelectList(Enfermedades.OrderBy(p => p.Nombre), "EnfermedadID", "Nombre");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al obtener List Enfermedades");
                throw new Exception(ex.Message);
            }
        }

        // GET: Procesos/NovedadHospitalizacions/Create
        public ActionResult Create()
        {
            try
            {
                var model = new BeNovedadHospitalizacion();
                GetTypeNovedad();
                GetHospitales();
                GetBrigadas();
                GetRangos();
                GetCompanias();
                GetEnfermedades();
                GetSexo();
                GetProvincias();
                return View();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al crear Novedad Hospitalizacion");
                throw new Exception(ex.Message);
            }

        }

        // POST: Procesos/NovedadHospitalizacions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeNovedadHospitalizacion model)
        {

            if (!ModelState.IsValid)
            {
                GetTypeNovedad();
                GetHospitales();
                GetBrigadas();
                GetRangos();
                GetCompanias();
                GetEnfermedades();
                GetSexo();
                GetProvincias();
                return View();



            }
            try
            {

                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); ///Usuario Logueado
                BcNovedadHospitalizacion.Create(model);
                TempData["success"] = "Hospitalizacion REGISTRADA Satisfactoriamente!";
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al crear Novedad Hospitalizacion");
                throw new Exception(ex.Message);
            }
        }


    }
}
