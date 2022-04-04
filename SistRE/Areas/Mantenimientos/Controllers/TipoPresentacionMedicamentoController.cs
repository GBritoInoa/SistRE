using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeEntity;
using BusinessControl;
using SistRE.AccessControl;
using SistRE.Comun;

namespace SistRE.Areas.Mantenimientos.Controllers
{
    [Autorizar(Profiles = new EnumPerfiles.Perfiles[] { EnumPerfiles.Perfiles.Administrador })]
    public class TipoPresentacionMedicamentoController : Controller
    {

              
        // GET: Mantenimientos/TipoPresentacionMedicamento
        public ActionResult Index()
        {
            try
            {
                var presentacionMedicamento = BcTipoPresentacionMedicamento.GetAll().ToList();
                return View(presentacionMedicamento);
            }

            catch (Exception ex)
            {

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
                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }


        }


        // GET: Mantenimientos/TipoPresentacionMedicamento/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            { 
            var tipopresentacionM = BcTipoPresentacionMedicamento.Find(id);
            if (tipopresentacionM == null)
            {

                return HttpNotFound();
            }
            return View(tipopresentacionM);
        }
  
            catch (Exception ex)
            

            {
                   ModelState.AddModelError(ex.Message, "Error");
                    throw new Exception(ex.Message);
                }
       
        }

        // GET: Mantenimientos/TipoPresentacionMedicamento/Create
        public ActionResult Create()
        {
            try
            {
                GetEstatus();
                return View();
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }

        // POST: Mantenimientos/TipoPresentacionMedicamento/Create
        [HttpPost]
        public ActionResult Create(BeTipoPresetacionMedicamento model)
        {

            if(!ModelState.IsValid)
            {
                GetEstatus();
                return View(model);

            }
            try
            {
                BcTipoPresentacionMedicamento.Create(model);
                TempData["success"] = "Tipo Presentacion Medicamento CREADO Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);

            }
        }

        // GET: Mantenimientos/TipoPresentacionMedicamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var tipoPresentacionM = BcTipoPresentacionMedicamento.Find(id);
                if (tipoPresentacionM == null)
                {
                    HttpNotFound();
                }
                GetEstatus();
                return View(tipoPresentacionM);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }
        }

        // POST: Mantenimientos/TipoPresentacionMedicamento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeTipoPresetacionMedicamento model)
        {

            if(!ModelState.IsValid)
            {
                GetEstatus();
                return View(model);

            }
            try
            {
                BcTipoPresentacionMedicamento.Edit(model);
                TempData["success"] = "Tipo Presentación Medicamento ACTUALIZADO Satisfactoriamente!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error al ACTUALIZAR  Tipo Presentación Medicamento");
                throw new Exception(ex.Message);
            }
        }

        // GET: Mantenimientos/TipoPresentacionMedicamento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mantenimientos/TipoPresentacionMedicamento/Delete/5
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
