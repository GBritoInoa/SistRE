using BeEntity;
using BusinessControl;
using SistRE.AccesControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistRE.Areas.Mantenimientos.Controllers
{
    public class TipoAusenciasController : Controller
    {
        // GET: TipoAusencias
        public ActionResult Index()
        {

            try
            {
                var ausencia = BcAusencias.GetAll().ToList();
                return View(ausencia);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
    
        }


        /// <summary>
        /// Carga Tipo Novedad
        /// </summary>
        public void LoadTypeNovedad()
        {

            try
            {
                var TypeNovedad = BcTipoNovedad.GetAll().ToList();
               var TipoNovedad = new SelectList(TypeNovedad.Where(a => a.Nombre.Contains("Ausencias"))).ToList();
                List<BeTipoNovedad> tipoNovedad = new List<BeTipoNovedad>();
                // = BcAusencias.GetAll().ToList();
               // ViewBag.AusenciaID = new SelectList(tipoNovedad.OrderBy(o => o.ID), "T", "Nombre");
                ViewBag.TipoNovedadID = new SelectList(TipoNovedad, "TipoNovedadID", "Nombre");
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// All Estatus
        /// </summary>
        public void AllEstados()
        {

            try
            {
                var Estados = BcEstatus.GetAll().ToList();
                ViewBag.EstatusID = new SelectList(Estados, "EstatusID", "Nombre");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }


        }

        // GET: TipoAusencias/Details/5
        public ActionResult Details(int? id)
        {

            if(id==null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var ausencia = BcAusencias.Find(id);
                if(ausencia==null)
                {
                 return HttpNotFound();
                }

                return View(ausencia);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }

        // GET: TipoAusencias/Create
        public ActionResult Create()
        {
            try
            {
                LoadTypeNovedad();
                AllEstados();
                return View();
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Ausencia");
                throw new Exception(ex.Message);
            }
        }

        // POST: TipoAusencias/Create
        [HttpPost]
        public ActionResult Create(BeAusencias model)
        {

            if(model==null)

            {
                LoadTypeNovedad();
                AllEstados();
                return View(model);
            }

            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); ///Usuario Loguedo
                BcAusencias.Create(model);
                TempData["success"] = "Tipo Ausencia creada Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Ausencia");
                throw new Exception(ex.Message);
            }
        }

        // GET: TipoAusencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var ausencia = BcAusencias.Find(id);
                if (ausencia == null)
                {
                    return HttpNotFound();
                }

                AllEstados();
                return View(ausencia);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }

        // POST: TipoAusencias/Edit/5
        [HttpPost]
        public ActionResult Edit(BeAusencias item)
        {
            if(item==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);

            }
            try
            {
                BcAusencias.Edit(item);
                TempData["success"] = "Tipo Ausencia actualizada Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }

        // GET: TipoAusencias/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: TipoAusencias/Delete/5
        [HttpPost]
        public ActionResult Delete(BeAusencias item)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
