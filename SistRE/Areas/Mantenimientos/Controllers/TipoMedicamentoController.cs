using BeEntity;
using BusinessControl;
using SistRE.AccessControl;
using SistRE.Comun;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SistRE.Areas.Mantenimientos.Controllers
{
    [Autorizar(Profiles = new EnumPerfiles.Perfiles[] { EnumPerfiles.Perfiles.Administrador })]
    public class TipoMedicamentoController : Controller
    {
        // GET: Tipo_Novedad
        public ActionResult Index()
        {
            try
            {

                var TipoMedicamento = BcTipoMedicamento.GetAll().ToList();
                return View(TipoMedicamento);
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
                var TipoMedicamento = BcTipoMedicamento.Find(id);
                if (TipoMedicamento == null)
                {
                    return HttpNotFound();
                }
                return View(TipoMedicamento);


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
        public ActionResult Create(BeTipoMedicamento item)
        {


            if (!ModelState.IsValid)
            {
                GetEstatus();
                return View(item);
            }

            try
            {

                BcTipoMedicamento.Create(item);
                TempData["success"] = "Tipo Medicamento CREADO Satisfactoriamente!";
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
                var TipoMedicamento = BcTipoMedicamento.Find(id);

                if (TipoMedicamento == null)
                {
                    return HttpNotFound();
                }
                GetEstatus();
                return View(TipoMedicamento);

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
        public ActionResult Edit(BeTipoMedicamento item)
        {

            if (!ModelState.IsValid)
            {
                GetEstatus();
                return View(item);

            }

            try
            {
                BcTipoMedicamento.Edit(item);
                TempData["success"] = "Tipo Medicamento ACTUALIZADO Satisfactoriamente!";
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "Error al ACTUALIZAR Tipo Medicamento");
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
