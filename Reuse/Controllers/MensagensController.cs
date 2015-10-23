using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Reuse.Models;

namespace Reuse.Controllers
{
    public class MensagensController : Controller
    {
        private ReuseContext db = new ReuseContext();

        // GET: Mensagens
        public ActionResult Index()
        {
            return View(db.Mensagems.ToList());
        }

        // GET: Mensagens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensagem mensagem = db.Mensagems.Find(id);
            if (mensagem == null)
            {
                return HttpNotFound();
            }
            return View(mensagem);
        }

        // GET: Mensagens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mensagens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MensagemID,DataPostada,Remetente,Destinatario")] Mensagem mensagem)
        {
            if (ModelState.IsValid)
            {
                db.Mensagems.Add(mensagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mensagem);
        }

        // GET: Mensagens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensagem mensagem = db.Mensagems.Find(id);
            if (mensagem == null)
            {
                return HttpNotFound();
            }
            return View(mensagem);
        }

        // POST: Mensagens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MensagemID,Conteudo,DataPostada,PessoaIDRem,PessoaIDDes")] Mensagem mensagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mensagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mensagem);
        }

        // GET: Mensagens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensagem mensagem = db.Mensagems.Find(id);
            if (mensagem == null)
            {
                return HttpNotFound();
            }
            return View(mensagem);
        }

        // POST: Mensagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mensagem mensagem = db.Mensagems.Find(id);
            db.Mensagems.Remove(mensagem);
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
