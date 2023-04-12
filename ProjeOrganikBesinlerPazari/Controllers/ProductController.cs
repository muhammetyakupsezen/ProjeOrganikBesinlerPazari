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
    public class ProductController : Controller
    {
        private DbOrganikUrunEntities db = new DbOrganikUrunEntities();

        // GET: Product
        public ActionResult Index()
        {
            return View(db.TblUrun.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUrun tblUrun = db.TblUrun.Find(id);
            if (tblUrun == null)
            {
                return HttpNotFound();
            }
            return View(tblUrun);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UrunId,UrunAdi,UrunKategorisi,UrunFiyati,img,StokAdedi,IsApproved,Aciklama,UrunNo,IsExist,IsAtDiscount,Yol,KategoriId")] TblUrun tblUrun)
        {
            if (ModelState.IsValid)
            {
                db.TblUrun.Add(tblUrun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblUrun);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUrun tblUrun = db.TblUrun.Find(id);
            if (tblUrun == null)
            {
                return HttpNotFound();
            }
            return View(tblUrun);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UrunId,UrunAdi,UrunKategorisi,UrunFiyati,img,StokAdedi,IsApproved,Aciklama,UrunNo,IsExist,IsAtDiscount,Yol,KategoriId")] TblUrun tblUrun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUrun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblUrun);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUrun tblUrun = db.TblUrun.Find(id);
            if (tblUrun == null)
            {
                return HttpNotFound();
            }
            return View(tblUrun);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblUrun tblUrun = db.TblUrun.Find(id);
            db.TblUrun.Remove(tblUrun);
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
