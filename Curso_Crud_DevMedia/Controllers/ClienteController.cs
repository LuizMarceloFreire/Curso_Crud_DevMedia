using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Curso_Crud_DevMedia.Context;
using Curso_Crud_DevMedia.Models;

namespace Curso_Crud_DevMedia.Controllers
{
    public class ClienteController : Controller
    {
        private LojaContext db = new LojaContext();

        public ActionResult Index()
        {
            var clientes = db.Clientes.Include(c => c.Consultor);
            return View(clientes.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes
                                .Include(c => c.Consultor)
                                .Include(c => c.Telefones)
                                .FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        public ActionResult Create()
        {
            ViewBag.IdConsultor = new SelectList(db.Consultores, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Email,IdConsultor,Telefones")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdConsultor = new SelectList(db.Consultores, "Id", "Nome", cliente.IdConsultor);
            return View(cliente);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes
                                .Include(c => c.Consultor)
                                .Include(c => c.Telefones)
                                .FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdConsultor = new SelectList(db.Consultores, "Id", "Nome", cliente.IdConsultor);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Email,IdConsultor,Telefones")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                foreach (var telefone in cliente.Telefones)
                {
                    if (telefone.Id > 0)
                        db.Entry(telefone).State = EntityState.Modified;
                    else
                        db.Entry(telefone).State = EntityState.Added;
                }
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdConsultor = new SelectList(db.Consultores, "Id", "Nome", cliente.IdConsultor);
            return View(cliente);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Telefones.RemoveRange(cliente.Telefones);
            db.Clientes.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public void RemoverTelefone(int id)
        {
            var telefone = db.Telefones.Find(id);
            db.Entry(telefone).State = EntityState.Deleted;
            db.SaveChanges();
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
