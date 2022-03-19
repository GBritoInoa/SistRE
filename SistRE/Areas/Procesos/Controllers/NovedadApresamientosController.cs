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
    public class NovedadApresamientosController : Controller
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
        /// Get Tipo Apresamientos
        /// </summary>
        private void GetTipoApresamientos()
        {

            try
            {
                List<BeTipoApresamiento> TipoApresamientos = BcTipoApresamiento.GetAll().ToList();
                ViewBag.TipoApresamientoID = new SelectList(TipoApresamientos.OrderBy(p => p.Nombre), "ID", "Nombre");
                ViewBag.TipoNovedadID = new SelectList(TipoApresamientos.OrderBy(c => c.TipoNovedadID), "TipoNovedadID", "Nombre");

      
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al obtener Listado Tipo Apresamientos");
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
                var tiponovedad = BcTipoNovedad.GetAll().Where(a => a.Nombre.Equals("Apresamientos")).ToList();
                ViewBag.TipoNovedadID = new SelectList(tiponovedad.OrderBy(c => c.TipoNovedadID), "TipoNovedadID", "Nombre");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }


        }

        // GET: Procesos/NovedadApresamientos/Create
        public ActionResult Create()
        {
            try
            {

              
                var model = new BeNovedadApresamientos();
                GetTypeNovedad();
                GetTipoApresamientos();
                GetBrigadas();
                GetRangos();
                GetCompanias();
                GetNacionalidades();
                GetSexo();
                GetProvincias();
                return View(model);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al crear Novedad Apresamiento");
                throw new Exception(ex.Message);
            }
          
        }

        // POST: Procesos/NovedadApresamientos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeNovedadApresamientos model)
        {

            if(!ModelState.IsValid)
            {
                GetTypeNovedad();
                GetTipoApresamientos();
                GetBrigadas();
                GetRangos();
                GetCompanias();
                GetNacionalidades();
                GetSexo();
                GetProvincias();
                return View(model);

             

            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); ///Guarda el usuario logueado
                BcNovedadApresamiento.Create(model);
                TempData["success"] = "Apresamiento REGISTRADO Satisfactoriamente!";
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
