using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YeniData;

namespace ProjeOrganikBesinlerPazari.Controllers
{
    public class KategoriController : Controller
    {
        private DbOrganikUrunEntities db = new DbOrganikUrunEntities();

        // GET: Kategori
        public ActionResult Index()
        {
            return View(db.TblKategori.ToList());
        }

        // GET: Kategori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblKategori tblKategori = db.TblKategori.Find(id);
            if (tblKategori == null)
            {
                return HttpNotFound();
            }
            return View(tblKategori);
        }

        // GET: Kategori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KategoriId,KategoriAdi,KategoriAciklamasi,img")] TblKategori tblKategori)
        {
            if (ModelState.IsValid)
            {
                db.TblKategori.Add(tblKategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblKategori);
        }

        // GET: Kategori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblKategori tblKategori = db.TblKategori.Find(id);
            if (tblKategori == null)
            {
                return HttpNotFound();
            }
            return View(tblKategori);
        }

        // POST: Kategori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KategoriId,KategoriAdi,KategoriAciklamasi,img")] TblKategori tblKategori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblKategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblKategori);
        }

        // GET: Kategori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblKategori tblKategori = db.TblKategori.Find(id);
            if (tblKategori == null)
            {
                return HttpNotFound();
            }
            return View(tblKategori);
        }

        // POST: Kategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblKategori tblKategori = db.TblKategori.Find(id);
            db.TblKategori.Remove(tblKategori);
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
