using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeEntity;
using BusinessControl;

namespace SistRE.Areas.Procesos.Controllers
{
    public class NovedadDecomisoController : Controller
    {



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
                ModelState.AddModelError(ex.Message, "Error al obtener Listado Provincias");
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get TipoMedidas
        /// </summary>
        private void GetTipoMedida()
        {

            try
            {
                 List<BeTipoMedida> TipoMedidas = BcTipos.GetTipoMedidas();
                ViewBag.TipoMedidaID = new SelectList(TipoMedidas.OrderBy(tm => tm.Medida), "TipoMedidaID", "Medida");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al obtener Listado Tipo Medidas");
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Tipo Decomiso
        /// </summary>
        private void GetTipoDecomiso()
        {
            try
            {
                List<BeTipoDecomiso> TipoDecomiso = BcTipos.GetTipoDecomisos().ToList();
                ViewBag.TipoDecomisoID = new SelectList(TipoDecomiso.OrderBy(td => td.Nombre), "ID", "Nombre");

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al obtener Listado Provincias");
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Tipo Drogas
        /// </summary>
        private void GetTipoDrogas()
        {
            try
            {
                List<BeTipoDroga> TipoDroga = BcTipos.GetTipoDrogas().ToList();
                ViewBag.TipoDrogaID = new SelectList(TipoDroga.OrderBy(td => td.Nombre), "TipoDrogaID", "Nombre");
            }
            catch (Exception ex)
            {


                ModelState.AddModelError(ex.Message, "Error al obtener Listado Tipo Drogas");
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


        // GET: Procesos/Decomisos/Create
        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                GetBrigadas();
                GetTipoDecomiso();
                GetTipoDrogas();
                GetTipoMedida();
                GetProvincias();
            }
            catch (Exception ex )
            {


                ModelState.AddModelError(ex.Message, "Error al mostrar la Vista Novedad Decomisos");
                throw new Exception(ex.Message);
            }
            return View();
        }

        // POST: Procesos/Decomisos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeNovedadDecomiso model)
        { 

            if(!ModelState.IsValid)
            {

                GetTipoDecomiso();
                GetTipoDrogas();
                GetTipoMedida();
                GetProvincias();
                return View(model);

            }
            try
            {
                BcNovedadDecomiso.Create(model);
                TempData["success"] = "Novedad CREADA Satisfactoriamente!";
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al Crear Novedad Decomiso");
                throw new Exception(ex.Message);
            }
        }

        // GET: Procesos/Decomisos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Procesos/Decomisos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

  
    }
}
