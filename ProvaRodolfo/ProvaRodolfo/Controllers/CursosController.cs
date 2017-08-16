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
    public class CursosController : Controller
    {
        private bdtaticaEntities db = new bdtaticaEntities();

        // GET: Cursos
        public async Task<ActionResult> Index(string Pesquisa = "")
        {
            var q = db.TBL_CURSO.AsQueryable();

            if (!string.IsNullOrEmpty(Pesquisa))
                q = q.Where(c => c.CURSO.Contains(Pesquisa));

            q = q.OrderBy(c => c.CURSO);


            //return View(await db.TBL_CURSO.ToListAsync());
            return View(await q.ToListAsync());
        }

        // GET: Cursos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_CURSO tBL_CURSO = await db.TBL_CURSO.FindAsync(id);
            if (tBL_CURSO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_CURSO);
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,CURSO")] TBL_CURSO tBL_CURSO)
        {
            if (ModelState.IsValid)
            {
                db.TBL_CURSO.Add(tBL_CURSO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tBL_CURSO);
        }

        // GET: Cursos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_CURSO tBL_CURSO = await db.TBL_CURSO.FindAsync(id);
            if (tBL_CURSO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_CURSO);
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,CURSO")] TBL_CURSO tBL_CURSO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_CURSO).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tBL_CURSO);
        }

        // GET: Cursos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_CURSO tBL_CURSO = await db.TBL_CURSO.FindAsync(id);
            if (tBL_CURSO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_CURSO);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TBL_CURSO tBL_CURSO = await db.TBL_CURSO.FindAsync(id);
            db.TBL_CURSO.Remove(tBL_CURSO);
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
