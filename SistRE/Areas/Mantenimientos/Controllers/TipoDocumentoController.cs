using BeEntity;
using BusinessControl;
using SistRE.AccesControl;
using SistRE.AccessControl;
using SistRE.Comun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace SistRE.Areas.Mantenimientos.Controllers
{
    [Autorizar(Profiles = new EnumPerfiles.Perfiles[] { EnumPerfiles.Perfiles.Administrador })]
    public class TipoDocumentoController : Controller
    {
        // GET: Mantenimientos/TipoDocumento
        public ActionResult Index()
        {
            try
            {
                var tipoDocumento = BcTipoDocumento.GetTipoDocumento().ToList();
                return View(tipoDocumento); 

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al mostrar Listado Documentos");
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


        // GET: Mantenimientos/TipoDocumento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            try
            {
                var tipodocumento = BcTipoDocumento.Find(id);
                if (tipodocumento == null)
                {
                    return HttpNotFound();

                }
                return View(tipodocumento);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/TipoDocumento/Create
        public ActionResult Create()
        {
            try
            {
                GetEstatus();
                return View();
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al mostrar Vista  Crear Documentos");
                throw new Exception(ex.Message);
            }
           
        }

        // POST: Mantenimientos/TipoDocumento/Create
        [HttpPost]
        public ActionResult Create(BeTipoDocumento model)
        {

            if(!ModelState.IsValid)
            {
                GetEstatus();
                return View();
            }
                
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString();
                BcTipoDocumento.Create(model);
                TempData["success"] = "Tipo Documento CREADO Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al Crear Tipo Documento");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/TipoDocumento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var tipodocumento = BcTipoDocumento.Find(id);
                if(tipodocumento==null)
                {
                    return HttpNotFound();

                }
                GetEstatus();
                return View(tipodocumento);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al BUSCAR Tipo Documemto");
                throw new Exception(ex.Message);
            }
       
        }

        // POST: Mantenimientos/TipoDocumento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeTipoDocumento model)
        {

            if(!ModelState.IsValid)
            {
                GetEstatus();
                return View(model);

            }
            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString();
                BcTipoDocumento.Edit(model);
                TempData["success"] = "Tipo Documento ACTUALIZADO Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }

        //// GET: Mantenimientos/TipoDocumento/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Mantenimientos/TipoDocumento/Delete/5
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
