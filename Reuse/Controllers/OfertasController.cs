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
using System.Drawing;
using Reuse.Classes;

namespace Reuse.Controllers
{
    public class OfertasController : Controller
    {
        private ReuseContext db = new ReuseContext();

        // GET: Ofertas
        public ViewResult Index(string categoria, string currentFilter, string searchString, int? page, int? success, int? error)
        {
            IQueryable<Anuncio> anuncios;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            if (success != null)
            {
                ViewBag.success = success;
            }
            if (error != null)
            {
                ViewBag.error = error;
            }
            ViewBag.CurrentFilter = searchString;
            if (categoria != null)
            {
                anuncios = db.Anuncios.Include(a => a.categoria)
                    .Include(a => a.pessoa)
                    .Where(a => a.ativo == true)
                    .Where(a => a.tipo == true)
                    .Where(a => a.categoria.titulo == categoria);
            }
            else
            {
                anuncios = db.Anuncios.Include(a => a.categoria)
                    .Include(a => a.pessoa)
                    .Where(a => a.ativo == true)
                    .Where(a => a.tipo == true);
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                anuncios = anuncios.Where(s => s.titulo.Contains(searchString));
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            anuncios = anuncios.OrderBy(a => a.titulo);
            return View(anuncios.ToPagedList(pageNumber, pageSize));
        }

        // GET: Ofertas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anuncio anuncio = db.Anuncios.Include(s => s.imagens).SingleOrDefault(s => s.anuncioID == id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            return View(anuncio);
        }

        // GET: Ofertas/Create
        public ActionResult Create()
        {
            if (User.Identity.Name == "")
            {
                return RedirectToAction("Index", new { error = 2 });
            }
            ViewBag.categoriaID = new SelectList(db.Categorias, "categoriaID", "titulo");
            ViewBag.pessoaID = new SelectList(db.Pessoas, "pessoaID", "nome");
            return View();
        }

        // POST: Ofertas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "anuncioID,pessoaID,categoriaID,subCategoria,condicao,titulo,descricao,tipo,video")] Anuncio anuncio, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var imagem = new Imagem
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        imagem.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    anuncio.imagens = new List<Imagem> { imagem };
                }
                else
                {
                    var imagem = new Imagem
                    {
                        FileName = "Não Disponivel",
                        ContentType = "image/png"
                    };
                    Bitmap bmp = new Bitmap(Image.FromFile(Server.MapPath("~/assets/css/images/300px-No_image_available.svg.png")));
                    imagem.Content = Servicos.imageToByteArray(bmp);
                    anuncio.imagens = new List<Imagem> { imagem };
                }
                anuncio.pessoaID = db.Pessoas.Where(a => a.email == User.Identity.Name).First().pessoaID;
                anuncio.tipo = true;
                if (anuncio.video != null)
                    anuncio.video = anuncio.video.Split(new char[] { '=' })[1];
                anuncio.ativo = true;
                db.Anuncios.Add(anuncio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoriaID = new SelectList(db.Categorias, "categoriaID", "titulo", anuncio.categoriaID);
            ViewBag.pessoaID = new SelectList(db.Pessoas, "pessoaID", "nome", anuncio.pessoaID);
            return View(anuncio);
        }

        // GET: Ofertas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoriaID = new SelectList(db.Categorias, "categoriaID", "titulo", anuncio.categoriaID);
            ViewBag.pessoaID = new SelectList(db.Pessoas, "pessoaID", "nome", anuncio.pessoaID);
            return View(anuncio);
        }

        // POST: Ofertas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "anuncioID,pessoaID,categoriaID,subCategoria,condicao,titulo,descricao,tipo")] Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anuncio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoriaID = new SelectList(db.Categorias, "categoriaID", "titulo", anuncio.categoriaID);
            ViewBag.pessoaID = new SelectList(db.Pessoas, "pessoaID", "nome", anuncio.pessoaID);
            return View(anuncio);
        }

        // GET: Ofertas/Confirmar/5
        public ActionResult Confirmar(int? MensagemID, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            return View(anuncio);
        }

        // POST: Ofertas/Confimar/5
        [HttpPost, ActionName("Confirmar")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarConfirmed(int MensagemID, int id)
        {
            Anuncio anuncio = db.Anuncios.Find(id);
            anuncio.ativo = false;
            Mensagem m = db.Mensagems.Find(MensagemID);
            db.Mensagems.Remove(m);
            db.Entry(anuncio).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", new { success = 2 });
        }

        public ActionResult PegarItem(Anuncio anuncio, String remetente, Pessoa destinatario)
        {
            if (remetente == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (destinatario.Name == User.Identity.Name)
            {
                return RedirectToAction("Index", new { error = 1 });
            }
            var user = new UsuariosController().Detalhes(remetente);
            var mensagem = new Mensagem(anuncio, user, destinatario);
            MensagensController mc = new MensagensController();
            mc.Create(mensagem);
            return RedirectToAction("Index", new { success = 1 });
        }

        public List<Anuncio> getTop6Ofertas()
        {
           return db.Anuncios.Include(a => a.categoria)
                    .Include(a => a.pessoa)
                    .Where(a => a.ativo == true)
                    .Where(a => a.tipo == true)
                    .Take(6).ToList();
        }

        public List<Anuncio> getOfertasByID(string email)
        {
            return db.Anuncios.Include(a => a.categoria)
                    .Include(a => a.pessoa)
                    .Where(a => a.ativo == true)
                    .Where(a => a.tipo == true)
                    .Where(a => a.pessoa.email == email).ToList();
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
