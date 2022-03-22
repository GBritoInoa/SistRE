using BeEntity;
using BusinessControl;
using DataLogic;
using SistRE.AccesControl;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SistRE.Areas.Mantenimientos.Controllers
{
    public class TipoRepatriacionController : Controller
    {
        // GET: Tipo_Novedad
        public ActionResult Index()
        {
            try
            {

                var TipoRepatriacion = BcTipoRepatriacion.GetAll().ToList();
                return View(TipoRepatriacion);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error");
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

        /// <summary>
        /// Details Tipo Novedad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Tipo_Novedad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var TipoRepatriacion = BcTipoRepatriacion.Find(id);
                if (TipoRepatriacion == null)
                {
                    return HttpNotFound();
                }
                return View(TipoRepatriacion);


            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);

            }
        }

        [HttpGet]
        // GET: Tipo_Novedad/Create
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Tipo_Novedad/Create
        public ActionResult Create(BeCausaRepatriacion model)
        {


            if (!ModelState.IsValid)
            {
                GetEstatus();
                return View(model);
            }

            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString();
                BcTipoRepatriacion.Create(model);
                TempData["success"] = "Tipo Repatriación CREADA Satisfactoriamente!";
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);

            }
        }


        /// <summary>
        /// Editar Novedad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Tipo_Novedad/Edit/
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var TipoRepatriacion = BcTipoRepatriacion.Find(id);

                if (TipoRepatriacion == null)
                {
                    return HttpNotFound();
                }
                GetEstatus();
                return View(TipoRepatriacion);

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error");
                throw new Exception(ex.Message);
            }

        }

        // POST: Tipo_Novedad/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeCausaRepatriacion model)
        {

            if (!ModelState.IsValid)
            {
                GetEstatus();
                return View(model);

            }

            try
            {
                model.UserLogueado = SessionData.GetOnlineUserInfo().userName.ToString();
                BcTipoRepatriacion.Edit(model);
                TempData["success"] = "Tipo Repatriación ACTUALIZADA Satisfactoriamente!";
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al crear Tipo Repatriacion");
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
