using DoAn_CoSo.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_CoSo.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        QLbanhang db = new QLbanhang();
        public ActionResult Index(int? page)
        {
            // 1. Tham số int? dùng để thể hiện null và kiểu int( số nguyên)
            // page có thể có giá trị là null ( rỗng) và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn sql, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo Masp mới có thể phân trang.
            var sp = db.Sanphams.OrderBy(x => x.Masach);

            // 4. Tạo kích thước trang (pageSize) hay là số sản phẩm hiển thị trên 1 trang
            int pageSize = 5;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các sản phẩm được phân trang theo kích thước và số trang.
            return View(sp.ToPagedList(pageNumber, pageSize));

        }
        public ActionResult Details(int id)
        {
            var sach = db.Sanphams.Find(id);
            return View(sach);
        }

        // Tạo sản phẩm mới phương thức GET: Admin/Home/Create
        public ActionResult Create()
        {
            //Để tạo dropdownList bên view
            var hangselected = new SelectList(db.Nhaxuatbans, "Manxb", "Tennxb");
            ViewBag.Manxb = hangselected;
            var hdhselected = new SelectList(db.Loaisaches, "Maloai", "Tenloai");
            ViewBag.Maloai = hdhselected;
            return View();
        }

        // Tạo sản phẩm mới phương thức POST: Admin/Home/Create
        [HttpPost]
        public ActionResult Create(Sanpham sanpham)
        {
            try
            {
                //Thêm  sản phẩm mới
                db.Sanphams.Add(sanpham);
                // Lưu lại
                db.SaveChanges();
                // Thành công chuyển đến trang index
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // Sửa sản phẩm GET lấy ra ID sản phẩm: Admin/Home/Edit/5
        public ActionResult Edit(int id)
        {
            // Hiển thị dropdownlist
            var dt = db.Sanphams.Find(id);
            var hangselected = new SelectList(db.Nhaxuatbans, "Manxb", "Tennxb", dt.Manxb);
            ViewBag.Mahang = hangselected;
            var hdhselected = new SelectList(db.Loaisaches, "Maloai", "Tenloai", dt.Maloai);
            ViewBag.Mahdh = hdhselected;
            // 
            return View(dt);

        }

        // POST: Admin/Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Sanpham sanpham)
        {
            try
            {
                // Sửa sản phẩm theo mã sản phẩm
                var oldItem = db.Sanphams.Find(sanpham.Masach);
                oldItem.Tensach = sanpham.Tensach;
                oldItem.Giatien = sanpham.Giatien;
                oldItem.Soluong = sanpham.Soluong;
                oldItem.Mota = sanpham.Mota;
                oldItem.Theloai = sanpham.Theloai;
                oldItem.Tacgia = sanpham.Tacgia;
                oldItem.Hinhanh = sanpham.Hinhanh;              
                oldItem.Maloai = sanpham.Maloai;
                oldItem.Manxb = sanpham.Manxb;
                // lưu lại
                db.SaveChanges();
                // xong chuyển qua index
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // Xoá sản phẩm phương thức GET: Admin/Home/Delete/5
        public ActionResult Delete(int id)
        {
            var dt = db.Sanphams.Find(id);
            return View(dt);
        }

        // Xoá sản phẩm phương thức POST: Admin/Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                //Lấy được thông tin sản phẩm theo ID(mã sản phẩm)
                var dt = db.Sanphams.Find(id);
                // Xoá
                db.Sanphams.Remove(dt);
                // Lưu lại
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}