using DoAn_CoSo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DoAn_CoSo.Areas.Admin.Controllers
{
    public class PhanquyensController : Controller
    {
        private QLbanhang db = new QLbanhang();

        // GET: Admin/PhanQuyens
        public ActionResult Index()
        {
            return View(db.Phanquyens.ToList());
        }

        // GET: Admin/PhanQuyens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phanquyen phanquyen = db.Phanquyens.Find(id);
            if (phanquyen == null)
            {
                return HttpNotFound();
            }
            return View(phanquyen);
        }

        // GET: Admin/PhanQuyens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PhanQuyens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDQuyen,TenQuyen")] Phanquyen phanquyen)
        {
            if (ModelState.IsValid)
            {
                db.Phanquyens.Add(phanquyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phanquyen);
        }

        // GET: Admin/PhanQuyens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phanquyen phanquyen = db.Phanquyens.Find(id);
            if (phanquyen == null)
            {
                return HttpNotFound();
            }
            return View(phanquyen);
        }

        // POST: Admin/PhanQuyens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDQuyen,TenQuyen")] Phanquyen phanquyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phanquyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phanquyen);
        }

        // GET: Admin/PhanQuyens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phanquyen phanquyen = db.Phanquyens.Find(id);
            if (phanquyen == null)
            {
                return HttpNotFound();
            }
            return View(phanquyen);
        }

        // POST: Admin/PhanQuyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phanquyen phanquyen = db.Phanquyens.Find(id);
            db.Phanquyens.Remove(phanquyen);
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