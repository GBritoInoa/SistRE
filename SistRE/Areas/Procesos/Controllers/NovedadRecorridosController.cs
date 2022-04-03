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
    public class NovedadRecorridosController : Controller
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

                ModelState.AddModelError(ex.Message, "Error al Crear Compania");
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

                List<BeRangos> Rango1 = BcComun.GetRangos().OrderBy(r => r.RangoID).ToList();
                ViewBag.Rango1ID = new SelectList(Rango1.OrderBy(r => r.RangoID), "RangoID", "Rango");

                List<BeRangos> Rango2 = BcComun.GetRangos().OrderBy(r => r.RangoID).ToList();
                ViewBag.Rango2ID = new SelectList(Rango2.OrderBy(r => r.RangoID), "RangoID", "Rango");
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

        /// <summary>
        /// Get Type Novedad
        /// </summary>
        private void GetTypeNovedad()
        {

            try
            {
                List<BeTipoNovedad> TipoNovedad = BcTipoNovedad.GetAll().Where(a => a.Nombre.Contains("Recorridos")).ToList();
                ViewBag.TipoNovedadID = new SelectList(TipoNovedad.OrderBy(c => c.TipoNovedadID), "TipoNovedadID", "Nombre");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al obtener Tipo Novedad");
                throw new Exception(ex.Message);
            }



        }

/// <summary>
/// Create Novedad Recorrido
/// </summary>
/// <returns></returns>
        public ActionResult Create()
        {
            try
            {
                var model = new BeNovedadRecorridos();
                GetTypeNovedad();
                GetHospitales();
                GetBrigadas();
                GetRangos();
                GetCompanias();
                //GetEnfermedades();
                GetSexo();
                GetProvincias();
                return View();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al CREAR Novedad Recorridos");
                throw new Exception(ex.Message);
            }

        }

        // POST: Procesos/NovedadRecorridoss/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeNovedadRecorridos model)
        {

            if (!ModelState.IsValid)
            {

                GetTypeNovedad();
                GetHospitales();
                GetBrigadas();
                GetRangos();
                GetCompanias();
                //GetEnfermedades();
                GetSexo();
                GetProvincias();
                return View();



            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); ///Usuario Logueado
                BcNovedadRecorridos.Create(model);
                TempData["success"] = "Novedad Recorrido REGISTRADA Satisfactoriamente!";
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al crear Novedad Recorridos");
                throw new Exception(ex.Message);
            }
        }


    }
}
