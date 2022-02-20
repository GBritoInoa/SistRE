//using BeEntity;
//using BusinessControl;
//using System;
//using System.Linq;
//using System.Net;
//using System.Web.Mvc;

//namespace SistRE.Areas.Mantenimientos.Controllers
//{
//    public class TipoEntregaController : Controller
//    {
//        // GET: Tipo_Novedad
//        public ActionResult Index()
//        {
//            try
//            {

//                var TipoEntrega = BcTipoEntrega.GetAll().ToList();
//                return View(TipoEntrega);
//            }
//            catch (Exception ex)
//            {
//                ModelState.AddModelError(ex.Message, "Error");
//                throw new Exception(ex.Message);

//            }
//        }

//        /// <summary>
//        /// All Estatus
//        /// </summary>
//        public void GetEstatus()
//        {

//            try
//            {
//                var Estados = BcEstatus.GetAll().ToList();
//                ViewBag.EstatusID = new SelectList(Estados, "EstatusID", "Nombre");
//            }
//            catch (Exception ex)
//            {
//                ModelState.AddModelError(ex.Message, "Error");
//                throw new Exception(ex.Message);
//            }


//        }

//        /// <summary>
//        /// Details Tipo Novedad
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        // GET: Tipo_Novedad/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            try
//            {
//                var TipoEntrega = BcTipoEntrega.Find(id);
//                if (TipoEntrega == null)
//                {
//                    return HttpNotFound();
//                }
//                return View(TipoEntrega);


//            }
//            catch (Exception ex)
//            {
//                ModelState.AddModelError(ex.Message, "Error");
//                throw new Exception(ex.Message);

//            }
//        }

//        [HttpGet]
//        // GET: Tipo_Novedad/Create
//        public ActionResult Create()
//        {
//            try
//            {
//                GetEstatus();
//                return View();

//            }
//            catch (Exception ex)
//            {

//                ModelState.AddModelError(ex.Message, "Error");
//                throw new Exception(ex.Message);
//            }


//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        // POST: Tipo_Novedad/Create
//        public ActionResult Create(BeTipoEntrega item)
//        {


//            if (!ModelState.IsValid)
//            {
//                GetEstatus();
//                return View(item);
//            }

//            try
//            {

//                BcTipoEntrega.Create(item);
//                TempData["success"] = "Tipo Entrega creada Satisfactoriamente!";
//                return RedirectToAction("Index");

//            }
//            catch (Exception ex)
//            {
//                ModelState.AddModelError(ex.Message, "Error");
//                throw new Exception(ex.Message);

//            }
//        }


//        /// <summary>
//        /// Editar Novedad
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        // GET: Tipo_Novedad/Edit/
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }

//            try
//            {
//                var TipoEntrega = BcTipoEntrega.Find(id);

//                if (TipoEntrega == null)
//                {
//                    return HttpNotFound();
//                }
//                GetEstatus();
//                return View(TipoEntrega);

//            }
//            catch (Exception ex)
//            {

//                ModelState.AddModelError(ex.Message, "Error");
//                throw new Exception(ex.Message);
//            }

//        }

//        // POST: Tipo_Novedad/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(BeTipoEntrega item)
//        {

//            if (!ModelState.IsValid)
//            {
//                GetEstatus();
//                return View(item);

//            }

//            try
//            {
//                BcTipoEntrega.Edit(item);
//                TempData["success"] = "Tipo Entrega actualizada Satisfactoriamente!";
//                return RedirectToAction("Index");

//            }
//            catch (Exception ex)
//            {

//                ModelState.AddModelError(ex.Message, "Error al crear Tipo Entrega");
//                throw new Exception(ex.Message);


//            }
//        }

//        // GET: Mantenimientos/TipoApresamiento/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: Mantenimientos/TipoApresamiento/Delete/5
//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//    }
//}
