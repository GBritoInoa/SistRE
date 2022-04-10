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
    public class NovedadMuertesController : Controller
    {


        /// <summary>
        /// Get Sexo
        /// </summary>
        public void GetSexo()
        {

            try
            {
                List<BeSexo> Sexo = new List<BeSexo>();
                Sexo = BcComun.GetSexo().Where(a=> a.SexoID <= 2).ToList();
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
                var tiponovedad = BcTipoNovedad.GetAll().Where(a => a.Nombre.Equals("Defunciones")).ToList();
                ViewBag.TipoNovedadID = new SelectList(tiponovedad.OrderBy(c => c.TipoNovedadID), "TipoNovedadID", "Nombre");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error");
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
        /// Get Tipo Miembro
        /// </summary>
        private void GetTiMiembro()
        {

            try
            {
                List<BeTipoMiembro> TipoMiembro = BcComun.GetTipoMiembro().ToList();
                ViewBag.TipoMiembroID = new SelectList(TipoMiembro.OrderBy(p => p.Nombre), "TipoMiembroID", "Nombre");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al obtener List Tipo Miembro");
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// GetNacionalidades
        /// </summary>
        private void GetTipoMuertes()
        {

            try
            {
                List<BeTipoMuertes> TipoMuertes = BcComun.GetTipoMuertes().ToList();
                ViewBag.TipoMuerteID = new SelectList(TipoMuertes.OrderBy(p => p.Nombre), "TipoMuerteID", "Nombre");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al obtener List Tipo Defunciones");
                throw new Exception(ex.Message);
            }
        }




        [Route("Defunciones")]
        /// <summary>
        /// Create Novedad Defunciones
        /// </summary>
        /// <returns></returns>
        // GET: Procesos/NovedadMuertes/Create
        public ActionResult Create()
        {
            try
            {
                var model = new BeNovedadMuertes();
                GetTypeNovedad();
                GetTiMiembro();
                GetBrigadas();
                GetRangos();
                GetCompanias();
                GetTipoMuertes();
                GetSexo();
                GetProvincias();
                return View();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al CREAR Defunción");
                throw new Exception(ex.Message);
            }

        }


        /// Create<summary>
        ///  Novedad Defunciones
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST: Procesos/NovedadMuertes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeNovedadMuertes model)
        {

            if (!ModelState.IsValid)
            {
                GetTypeNovedad();
                GetTiMiembro();
                GetBrigadas();
                GetRangos();
                GetCompanias();
                GetTipoMuertes();
                GetSexo();
                GetProvincias();
                return View();



            }
            try
            {

                model.UserLogueado = SessionData.GetOnlineUserInfo().userName;
                BcNovedadMuerte.Create(model);
                TempData["success"] = "Defuncion REGISTRADA Satisfactoriamente!";
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al crear Novedad Muerte");
                throw new Exception(ex.Message);
            }
        }


    }
}
