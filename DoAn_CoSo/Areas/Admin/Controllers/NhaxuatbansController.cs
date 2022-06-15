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
    public class NhaxuatbansController : Controller
    {
        private QLbanhang db = new QLbanhang();

        // GET: Admin/Hangsanxuats
        public ActionResult Index()
        {
            return View(db.Nhaxuatbans.ToList());
        }

        // GET: Admin/Hangsanxuats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhaxuatban nhaxuatban = db.Nhaxuatbans.Find(id);
            if (nhaxuatban == null)
            {
                return HttpNotFound();
            }
            return View(nhaxuatban);
        }

        // GET: Admin/Hangsanxuats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Hangsanxuats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Manxb,Tennxb,Diachi,Sdt,Email")] Nhaxuatban nhaxuatban)
        {
            if (ModelState.IsValid)
            {
                db.Nhaxuatbans.Add(nhaxuatban);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhaxuatban);
        }

        // GET: Admin/Hangsanxuats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhaxuatban nhaxuatban = db.Nhaxuatbans.Find(id);
            if (nhaxuatban == null)
            {
                return HttpNotFound();
            }
            return View(nhaxuatban);
        }

        // POST: Admin/Hangsanxuats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Manxb,Tennxb,Diachi,Sdt,Email")] Nhaxuatban nhaxuatban)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhaxuatban).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhaxuatban);
        }

        // GET: Admin/Hangsanxuats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhaxuatban nhaxuatban = db.Nhaxuatbans.Find(id);
            if (nhaxuatban == null)
            {
                return HttpNotFound();
            }
            return View(nhaxuatban);
        }

        // POST: Admin/Hangsanxuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nhaxuatban nhaxuatban = db.Nhaxuatbans.Find(id);
            db.Nhaxuatbans.Remove(nhaxuatban);
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