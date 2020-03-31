using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Curso_Crud_DevMedia.Models;

namespace Curso_Crud_DevMedia.Context
{
    public class ConsultoresController : Controller
    {
        private LojaContext db = new LojaContext();

        public ActionResult Index()
        {
            return View(db.Consultores.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultor consultor = db.Consultores.Find(id);
            if (consultor == null)
            {
                return HttpNotFound();
            }
            return View(consultor);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Consultor consultor)
        {
            if (ModelState.IsValid)
            {
                db.Consultores.Add(consultor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(consultor);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultor consultor = db.Consultores.Find(id);
            if (consultor == null)
            {
                return HttpNotFound();
            }
            return View(consultor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Consultor consultor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consultor);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultor consultor = db.Consultores.Find(id);
            if (consultor == null)
            {
                return HttpNotFound();
            }
            return View(consultor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consultor consultor = db.Consultores.Find(id);
            db.Consultores.Remove(consultor);
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
