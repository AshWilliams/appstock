using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppStock;

namespace AppStock.Controllers
{
    public class IngredientesController : Controller
    {
        private cocinaContext db = new cocinaContext();

        // GET: Ingredientes
        public async Task<ActionResult> Index()
        {
            return View(await db.Ingredientes.ToListAsync());
        }

        // GET: Ingredientes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredientes ingredientes = await db.Ingredientes.FindAsync(id);
            if (ingredientes == null)
            {
                return HttpNotFound();
            }
            return View(ingredientes);
        }

        // GET: Ingredientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingredientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idIngrediente,nombre,descripcion,cantidad,fechaCreacion")] Ingredientes ingredientes)
        {
            if (ModelState.IsValid)
            {
                db.Ingredientes.Add(ingredientes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ingredientes);
        }

        // GET: Ingredientes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredientes ingredientes = await db.Ingredientes.FindAsync(id);
            if (ingredientes == null)
            {
                return HttpNotFound();
            }
            return View(ingredientes);
        }

        // POST: Ingredientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idIngrediente,nombre,descripcion,cantidad,fechaCreacion")] Ingredientes ingredientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingredientes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ingredientes);
        }

        // GET: Ingredientes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredientes ingredientes = await db.Ingredientes.FindAsync(id);
            if (ingredientes == null)
            {
                return HttpNotFound();
            }
            return View(ingredientes);
        }

        // POST: Ingredientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ingredientes ingredientes = await db.Ingredientes.FindAsync(id);
            db.Ingredientes.Remove(ingredientes);
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
