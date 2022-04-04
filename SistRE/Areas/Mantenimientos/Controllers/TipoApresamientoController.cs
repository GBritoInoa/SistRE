using BeEntity;
using BusinessControl;
using SistRE.AccesControl;
using SistRE.AccessControl;
using SistRE.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistRE.Areas.Mantenimientos.Controllers
{
    [Autorizar(Profiles = new EnumPerfiles.Perfiles[] { EnumPerfiles.Perfiles.Administrador })]
    public class TipoApresamientoController : Controller
    {



        /// <summary>
        /// Get Tipo Apresamientos
        /// </summary>
        private void GetTypeApresamientos()
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
        /// All Estatus
        /// </summary>
        public void GetEstatus()
        {

            try
            {
                var Estados = BcEstatus.GetAll().ToList();
                ViewBag.EstatusID = new SelectList(Estados, "EstatusID", "Nombre");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/TipoApresamiento
        public ActionResult Index()
        {
            try
            {
                var tipoApresamiento = BcTipoApresamiento.GetAll().ToList();
                return View(tipoApresamiento);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al mostrar listado Tipo Apresamientos");
                throw new Exception(ex.Message);
            }
       
        }

        // GET: Mantenimientos/TipoApresamiento/Details/5
        public ActionResult Details(int? id)
        {

            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


            }
            try
            {
                var tipoapresamiento = BcTipoApresamiento.Find(id);
                if(tipoapresamiento ==null)
                {
                    return HttpNotFound();
                }
                return View(tipoapresamiento);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        
        }

        // GET: Mantenimientos/TipoApresamiento/Create
        public ActionResult Create()
        {
            try
            {
                GetTypeApresamientos();
                GetEstatus();
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        
        }

        // POST: Mantenimientos/TipoApresamiento/Create
        [HttpPost]
        public ActionResult Create(BeTipoApresamiento model)
        {
            if(!ModelState.IsValid)
            {
                GetTypeApresamientos();
                GetEstatus();
                return View(model);

            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); ///Usuario Loguedo
                BcTipoApresamiento.Create(model);
                TempData["success"] = "Tipo Apresamiento creado Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al crear tipo Apresamiento");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/TipoApresamiento/Edit/5
        public ActionResult Edit(int? id)
        {

            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            try
            {
                var tipoapresamiento = BcTipoApresamiento.Find(id);
                if(tipoapresamiento==null)
                {
                    HttpNotFound();

                }
                GetTypeApresamientos();
                GetEstatus();
                ViewBag.AuditoriaID = tipoapresamiento.AuditoriaID;
                return View(tipoapresamiento);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al Encontrar tipo Apresamiento");
                throw new Exception(ex.Message);
            }
          
        }

        // POST: Mantenimientos/TipoApresamiento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeTipoApresamiento model)
        {

            if(!ModelState.IsValid)
            {
                GetTypeApresamientos();
                GetEstatus();
                return View(model);

            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); ///Usuario Loguedo
                BcTipoApresamiento.Edit(model);
                TempData["success"] = "Tipo Apresamiento actualiado Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al crear Novedad Tipo Apresamiento");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/TipoApresamiento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mantenimientos/TipoApresamiento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
