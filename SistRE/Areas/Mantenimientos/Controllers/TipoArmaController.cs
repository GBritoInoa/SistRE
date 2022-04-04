using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeEntity;
using BusinessControl;
using SistRE.AccesControl;
using SistRE.AccessControl;
using SistRE.Comun;

namespace SistRE.Areas.Mantenimientos.Controllers
          
{
    [Autorizar(Profiles = new EnumPerfiles.Perfiles[] { EnumPerfiles.Perfiles.Administrador })]
    public class TipoArmaController : Controller
    {

        // GET: TipoArma
        public ActionResult Index()
        {
            try
            {
                var tipoarma = BcTipoArma.GetAll().ToList();
                return View(tipoarma);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al MOSTRAR Listado Tipo Arma.");
                throw new Exception(ex.Message);

            }
        }

        /// <summary>
        /// All Estatus
        /// </summary>
        public void GetStatus()
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


        // GET: TipoArma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            try
            {
                var tipoarma = BcTipoArma.Find(id);

                if (tipoarma == null)
                {
                    return HttpNotFound();
                }
                GetStatus();
                return View(tipoarma);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET: TipoArma/Create
        public ActionResult Create()
        {
            try
            {
                GetStatus();
                return View();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // POST: TipoArma/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeTipoArma model)
        {

            if (!ModelState.IsValid)
            {
                GetStatus(); 
                return View(model);

            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); ///Usuario Loguedo
                BcTipoArma.Create(model);
                TempData["success"] = "Tipo Arma creada Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al REGISTRAR Tipo Arma");
                throw new Exception(ex.Message);
            }
        }

        // GET: TipoArma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                }
            try
            {
                var tipoarma = BcTipoArma.Find(id);
            
                if(tipoarma==null)
                {
                    return HttpNotFound();
                }
                GetStatus();
                return View(tipoarma);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al ACTUALIZAR Tipo Decomiso");
                throw new Exception(ex.Message);
            }
        }

        // POST: TipoArma/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeTipoArma model)
        {
            if (!ModelState.IsValid)
            {
                GetStatus(); 
                return View(model);

            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString(); ///Usuario Loguedo
                BcTipoArma.Edit(model);
                TempData["success"] = "Tipo Arma actualizada Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al EDITAR Tipo Arma");
                throw new Exception(ex.Message);
            }
        }

        //// GET: TipoArma/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: TipoArma/Delete/5
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
