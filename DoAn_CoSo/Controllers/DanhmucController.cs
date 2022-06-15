using DoAn_CoSo.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_CoSo.Controllers
{
    public class DanhmucController : Controller
    {
        QLbanhang db = new QLbanhang();
        // GET: Danhmuc
        private List<Sanpham> Laysachmoi(int count)
        {
            //Sắp xếp sách theo ngày cập nhật, sau đó lấy top @count 
            return db.Sanphams.OrderByDescending(a => a.Tensach).Take(count).ToList();
        }
        public ActionResult Index(int? page)
        {
            //Lấy top 5 Album bán chạy nhất
            var sachmoi = Laysachmoi(15);
            //Số mẫu tin trên 1 trang
            int pagesize = 3;
            //Thứ tự trang truy xuất
            int pageNum = (page ?? 1);
            return View(sachmoi.ToPagedList(pageNum, pagesize));
        }
        public ActionResult Loaisach()
        {
            var loaisach = from lc in db.Loaisaches select lc;
            return PartialView(loaisach);
        }                    
        public ActionResult SachtheoLoai(int id)
        {
            var sach = from s in db.Sanphams where s.Maloai == id select s;
            return View(sach);
        }
        public ActionResult Nhaxuatban()
        {
            var nhaxuatban = from nxb in db.Nhaxuatbans select nxb;
            return PartialView(nhaxuatban);
        }
        public ActionResult SachTheoNhaxuatban(int id)
        {
            var sach = from s in db.Sanphams where s.Manxb == id select s;
            return View(sach);
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