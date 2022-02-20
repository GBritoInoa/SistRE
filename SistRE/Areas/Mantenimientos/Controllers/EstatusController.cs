using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLogic;

namespace SistRE.Areas.Mantenimientos.Controllers
{
    public class EstatusController : Controller
    {
      private Context_SistRE db = new Context_SistRE();

        // GET: Estatus
        public ActionResult Index()
        {
            return View(db.Estatus.ToList());
        }

        // GET: Estatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estatus estatus = db.Estatus.Find(id);
            if (estatus == null)
            {
                return HttpNotFound();
            }
            return View(estatus);
        }

        // GET: Estatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estatus/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Estatus estatus)
        {
            if (ModelState.IsValid)
            {
                db.Estatus.Add(estatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estatus);
        }

        // GET: Estatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estatus estatus = db.Estatus.Find(id);
            if (estatus == null)
            {
                return HttpNotFound();
            }
            return View(estatus);
        }

        // POST: Estatus/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstatusID,Nombre")] Estatus estatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estatus);
        }

        // GET: Estatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estatus estatus = db.Estatus.Find(id);
            if (estatus == null)
            {
                return HttpNotFound();
            }
            return View(estatus);
        }

        // POST: Estatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estatus estatus = db.Estatus.Find(id);
            db.Estatus.Remove(estatus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
