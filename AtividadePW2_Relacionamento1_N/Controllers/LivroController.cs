using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AtividadePW2_Relacionamento1_N.Models;

namespace AtividadePW2_Relacionamento1_N.Controllers
{
    public class LivroController : Controller
    {
        private AlcassaEntities db = new AlcassaEntities();

        // GET: Livro
        public ActionResult Index()
        {
            return View(db.tblLivro.ToList());
        }

        // GET: Livro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLivro tblLivro = db.tblLivro.Find(id);
            if (tblLivro == null)
            {
                return HttpNotFound();
            }
            return View(tblLivro);
        }

        // GET: Livro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Livro,Nome,Autor,Ano_Publicacao")] tblLivro tblLivro)
        {
            if (ModelState.IsValid)
            {
                db.tblLivro.Add(tblLivro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblLivro);
        }

        // GET: Livro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLivro tblLivro = db.tblLivro.Find(id);
            if (tblLivro == null)
            {
                return HttpNotFound();
            }
            return View(tblLivro);
        }

        // POST: Livro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Livro,Nome,Autor,Ano_Publicacao")] tblLivro tblLivro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblLivro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblLivro);
        }

        // GET: Livro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLivro tblLivro = db.tblLivro.Find(id);
            if (tblLivro == null)
            {
                return HttpNotFound();
            }
            return View(tblLivro);
        }

        // POST: Livro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblLivro tblLivro = db.tblLivro.Find(id);
            db.tblLivro.Remove(tblLivro);
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
