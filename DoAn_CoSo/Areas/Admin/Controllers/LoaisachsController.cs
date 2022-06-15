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
    public class LoaisachsController : Controller
    {
        private QLbanhang db = new QLbanhang();

        // GET: Admin/Hedieuhanhs
        public ActionResult Index()
        {
            return View(db.Loaisaches.ToList());
        }

        // GET: Admin/Hedieuhanhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaisach loaisach = db.Loaisaches.Find(id);
            if (loaisach == null)
            {
                return HttpNotFound();
            }
            return View(loaisach);
        }

        // GET: Admin/Hedieuhanhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Hedieuhanhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Maloai,Tenloai,Linhvuc")] Loaisach loaisach)
        {
            if (ModelState.IsValid)
            {
                db.Loaisaches.Add(loaisach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaisach);
        }

        // GET: Admin/Hedieuhanhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaisach loaisach = db.Loaisaches.Find(id);
            if (loaisach == null)
            {
                return HttpNotFound();
            }
            return View(loaisach);
        }

        // POST: Admin/Hedieuhanhs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Maloai,Tenloai,Linhvuc")] Loaisach loaisach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaisach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaisach);
        }

        // GET: Admin/Hedieuhanhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaisach loaisach = db.Loaisaches.Find(id);
            if (loaisach == null)
            {
                return HttpNotFound();
            }
            return View(loaisach);
        }

        // POST: Admin/Hedieuhanhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loaisach loaisach = db.Loaisaches.Find(id);
            db.Loaisaches.Remove(loaisach);
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