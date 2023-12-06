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
    public class EmprestimoController : Controller
    {
        private AlcassaEntities db = new AlcassaEntities();

        // GET: Emprestimo
        public ActionResult Index()
        {
            var tblEmprestimo = db.tblEmprestimo.Include(t => t.tblLivro);
            return View(tblEmprestimo.ToList());
        }

        // GET: Emprestimo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmprestimo tblEmprestimo = db.tblEmprestimo.Find(id);
            if (tblEmprestimo == null)
            {
                return HttpNotFound();
            }
            return View(tblEmprestimo);
        }

        // GET: Emprestimo/Create
        public ActionResult Create()
        {
            ViewBag.Id_Livro = new SelectList(db.tblLivro, "Id_Livro", "Nome");
            return View();
        }

        // POST: Emprestimo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Emprestimo,Id_Livro,DataEmprestimo,DataDevolucao")] tblEmprestimo tblEmprestimo)
        {
            if (ModelState.IsValid)
            {
                db.tblEmprestimo.Add(tblEmprestimo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Livro = new SelectList(db.tblLivro, "Id_Livro", "Nome", tblEmprestimo.Id_Livro);
            return View(tblEmprestimo);
        }

        // GET: Emprestimo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmprestimo tblEmprestimo = db.tblEmprestimo.Find(id);
            if (tblEmprestimo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Livro = new SelectList(db.tblLivro, "Id_Livro", "Nome", tblEmprestimo.Id_Livro);
            return View(tblEmprestimo);
        }

        // POST: Emprestimo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Emprestimo,Id_Livro,DataEmprestimo,DataDevolucao")] tblEmprestimo tblEmprestimo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmprestimo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Livro = new SelectList(db.tblLivro, "Id_Livro", "Nome", tblEmprestimo.Id_Livro);
            return View(tblEmprestimo);
        }

        // GET: Emprestimo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmprestimo tblEmprestimo = db.tblEmprestimo.Find(id);
            if (tblEmprestimo == null)
            {
                return HttpNotFound();
            }
            return View(tblEmprestimo);
        }

        // POST: Emprestimo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEmprestimo var = db.tblEmprestimo.Find(id);
            db.tblEmprestimo.Remove(var);
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
