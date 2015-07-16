using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Reuse.Models;
using PagedList;

namespace Reuse.Controllers
{
    public class InstituicaosController : Controller
    {
        private ReuseContext db = new ReuseContext();

        // GET: Instituicaos
        public ActionResult Index(string NomeFilter, string CepFilter, int? page, string searchNome, int? searchTipo, string searchCEP)
        {

            if (searchNome != null)
            {
                page = 1;
            }
            else
            {
                searchNome = NomeFilter;
            }

            if (searchCEP != null)
            {
                page = 1;
            }
            else
            {
                searchCEP = CepFilter;
            }
            ViewBag.NomeFilter = searchNome;
            ViewBag.CepFilter = searchCEP;

            IQueryable<Instituicao> pessoas;
            pessoas = db.Instituicaos.Include(i => i.tipo);

            if (!String.IsNullOrEmpty(searchNome))
            {
                pessoas = pessoas.Where(s => s.nome.Contains(searchNome));
            }

            if (searchTipo != null)
            {
                pessoas = pessoas.Where(s => s.tipoID == searchTipo+1);
            }

            if (!String.IsNullOrEmpty(searchCEP))
            {
                pessoas = pessoas.Where(s => s.cep.Contains(searchCEP));
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            pessoas = pessoas.OrderBy(a => a.nome);
            return View(pessoas.ToPagedList(pageNumber, pageSize));
        }

        // GET: Instituicaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = db.Instituicaos.Find(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // GET: Instituicaos/Create
        public ActionResult Create()
        {
            ViewBag.tipoID = new SelectList(db.Tipoes, "tipoID", "titulo");
            return View();
        }

        // POST: Instituicaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pessoaID,nome,email,senha,endereco,cep,cidade,estado,telefone,celular,nomeContato,cnpj,tipoID")] Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                db.Instituicaos.Add(instituicao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tipoID = new SelectList(db.Tipoes, "tipoID", "titulo", instituicao.tipoID);
            return View(instituicao);
        }

        // GET: Instituicaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = db.Instituicaos.Find(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipoID = new SelectList(db.Tipoes, "tipoID", "titulo", instituicao.tipoID);
            return View(instituicao);
        }

        // POST: Instituicaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pessoaID,nome,email,senha,endereco,cep,cidade,estado,telefone,celular,nomeContato,cnpj,tipoID")] Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instituicao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tipoID = new SelectList(db.Tipoes, "tipoID", "titulo", instituicao.tipoID);
            return View(instituicao);
        }

        // GET: Instituicaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = db.Instituicaos.Find(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // POST: Instituicaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instituicao instituicao = db.Instituicaos.Find(id);
            db.Instituicaos.Remove(instituicao);
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
