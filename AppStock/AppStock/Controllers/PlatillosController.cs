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
    public class PlatillosController : Controller
    {
        private cocinaContext db = new cocinaContext();

        // GET: Platillos
        public async Task<ActionResult> Index()
        {
            return View(await db.Platillos.ToListAsync());
        }

        // GET: Platillos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platillos platillos = await db.Platillos.FindAsync(id);
            if (platillos == null)
            {
                return HttpNotFound();
            }
            return View(platillos);
        }

        // GET: Platillos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Platillos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idPlatillo,nombre,descripcion,fechaCreacion")] Platillos platillos)
        {
            if (ModelState.IsValid)
            {
                db.Platillos.Add(platillos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(platillos);
        }

        // GET: Platillos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platillos platillos = await db.Platillos.FindAsync(id);
            if (platillos == null)
            {
                return HttpNotFound();
            }
            return View(platillos);
        }

        // POST: Platillos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idPlatillo,nombre,descripcion,fechaCreacion")] Platillos platillos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(platillos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(platillos);
        }

        // GET: Platillos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platillos platillos = await db.Platillos.FindAsync(id);
            if (platillos == null)
            {
                return HttpNotFound();
            }
            return View(platillos);
        }

        // POST: Platillos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Platillos platillos = await db.Platillos.FindAsync(id);
            db.Platillos.Remove(platillos);
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
