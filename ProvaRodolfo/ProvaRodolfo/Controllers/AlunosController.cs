using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProvaRodolfo.Models;

namespace ProvaRodolfo.Controllers
{
    public class AlunosController : Controller
    {
        private bdtaticaEntities db = new bdtaticaEntities();

        // GET: Alunos
        public async Task<ActionResult> Index(string Pesquisa = "")
        {
            var q = db.TBL_ALUNO.AsQueryable();

            if (!string.IsNullOrEmpty(Pesquisa))
                q = q.Where(c => c.NOME.Contains(Pesquisa));

            q = q.OrderBy(c => c.NOME);
            q = q.Include(t => t.TBL_CURSO);

            /*var tBL_ALUNO = db.TBL_ALUNO.Include(t => t.TBL_CURSO);
            return View(await tBL_ALUNO.ToListAsync());*/
            return View(await q.ToListAsync());
        }

        // GET: Alunos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ALUNO tBL_ALUNO = await db.TBL_ALUNO.FindAsync(id);
            if (tBL_ALUNO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ALUNO);
        }

        // GET: Alunos/Create
        public ActionResult Create()
        {
            ViewBag.CURSO_ID = new SelectList(db.TBL_CURSO, "ID", "CURSO");
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CPF,MATRICULA,NOME,CURSO_ID")] TBL_ALUNO tBL_ALUNO)
        {
            if (ModelState.IsValid)
            {
                db.TBL_ALUNO.Add(tBL_ALUNO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CURSO_ID = new SelectList(db.TBL_CURSO, "ID", "CURSO", tBL_ALUNO.CURSO_ID);
            return View(tBL_ALUNO);
        }

        // GET: Alunos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ALUNO tBL_ALUNO = await db.TBL_ALUNO.FindAsync(id);
            if (tBL_ALUNO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CURSO_ID = new SelectList(db.TBL_CURSO, "ID", "CURSO", tBL_ALUNO.CURSO_ID);
            return View(tBL_ALUNO);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CPF,MATRICULA,NOME,CURSO_ID")] TBL_ALUNO tBL_ALUNO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_ALUNO).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CURSO_ID = new SelectList(db.TBL_CURSO, "ID", "CURSO", tBL_ALUNO.CURSO_ID);
            return View(tBL_ALUNO);
        }

        // GET: Alunos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ALUNO tBL_ALUNO = await db.TBL_ALUNO.FindAsync(id);
            if (tBL_ALUNO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ALUNO);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TBL_ALUNO tBL_ALUNO = await db.TBL_ALUNO.FindAsync(id);
            db.TBL_ALUNO.Remove(tBL_ALUNO);
            await db.SaveChangesAsync();
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
