using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeEntity;
using BusinessControl;

namespace SistRE.Areas.Procesos.Controllers
{
    public class NovedadPerdidaDocumentoController : Controller
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
        /// Companías
        /// </summary>
        public void GetCompanias()
        {

            try
            {
        
                List<BeCompania> Compania = BcComun.GetCompania().OrderBy(r => r.CompaniaID).ToList();
                ViewBag.CompaniaID = new SelectList(Compania.OrderBy(c => c.CompaniaID), "CompaniaID", "Nombre");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Ausencia");
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Get TipoDocumentos
        /// </summary>
        public void GetTipoDocumento()
        {

            try
            {

                List<BeTipoDocumento> TipoDocumentoID = BcTipoDocumento.GetTipoDocumento().OrderBy(r => r.ID).ToList();
                ViewBag.TipoDocumentoID = new SelectList(TipoDocumentoID.OrderBy(c => c.ID), "ID", "Nombre");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Ausencia");
                throw new Exception(ex.Message);
            }

        }

        // GET: Procesos/PerdidaDocumento/Create
        public ActionResult Create()
        {
            try
            {
                GetTipoDocumento();
                GetCompanias();
                GetProvincias();
                GetRangos();
                
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
     
        }

        // POST: Procesos/PerdidaDocumento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeNovedadPerdidaDocumento item)
        {
            if(!ModelState.IsValid)
            {
                return View(item);

            }

            try
            {
                BcNovedadPerdidaDocumento.Create(item);
                TempData["success"] = "Novedad creada Satisfactoriamente!";
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //// GET: Procesos/PerdidaDocumento/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Procesos/PerdidaDocumento/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Procesos/PerdidaDocumento/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Procesos/PerdidaDocumento/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
