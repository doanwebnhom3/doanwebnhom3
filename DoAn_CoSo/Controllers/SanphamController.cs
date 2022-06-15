using DoAn_CoSo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_CoSo.Controllers
{
    public class SanphamController : Controller
    {
        QLbanhang db = new QLbanhang();

        // GET: Sanpham
        public ActionResult sachmoipartial()
        {
            var sachmoi = db.Sanphams.Where(n => n.Manxb == 1).Take(3).ToList();
            return PartialView(sachmoi);
        }
        public ActionResult sachbanchaypartial()
        {
            var sachbanchay = db.Sanphams.Where(n => n.Manxb == 2).Take(3).ToList();
            return PartialView(sachbanchay);
        }
        public ActionResult vanhocvnpartial()
        {
            var vanhocvn = db.Sanphams.Where(n => n.Manxb == 3).Take(3).ToList();
            return PartialView(vanhocvn);
        }
        public ActionResult vanhocnnpartial()
        {
            var vanhocnn = db.Sanphams.Where(n => n.Manxb == 4).Take(3).ToList();
            return PartialView(vanhocnn);
        }
        
        public ActionResult xemchitiet(int Masach = 0)
        {
            var chitiet = db.Sanphams.SingleOrDefault(n => n.Masach == Masach);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }
    }
}