using DoAn_CoSo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_CoSo.Controllers
{
    public class GiohangController : Controller
    {
        QLbanhang db = new QLbanhang();
        // GET: GioHang

        //Lấy giỏ hàng 
        public List<Giohang> LayGioHang()
        {
            List<Giohang> lstGioHang = Session["Giohang"] as List<Giohang>;
            if (lstGioHang == null)
            {
                //Nếu giỏ hàng chưa tồn tại thì mình tiến hành khởi tao list giỏ hàng (sessionGioHang)
                lstGioHang = new List<Giohang>();
                Session["Giohang"] = lstGioHang;
            }
            return lstGioHang;
        }
        //Thêm giỏ hàng
        public ActionResult ThemGioHang(int iMasach, string strURL)
        {
            Sanpham sp = db.Sanphams.SingleOrDefault(n => n.Masach == iMasach);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra session giỏ hàng
            List<Giohang> lstGioHang = LayGioHang();
            //Kiểm tra sp này đã tồn tại trong session[giohang] chưa
            Giohang sanpham = lstGioHang.Find(n => n.iMasach == iMasach);
            if (sanpham == null)
            {
                sanpham = new Giohang(iMasach);
                //Add sản phẩm mới thêm vào list
                lstGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoluong++;
                return Redirect(strURL);
            }
        }
        //Cập nhật giỏ hàng 
        public ActionResult CapNhatGioHang(int iMaSach, FormCollection f)
        {
            //Kiểm tra masach
            Sanpham sp = db.Sanphams.SingleOrDefault(n => n.Masach == iMaSach);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<Giohang> lstGioHang = LayGioHang();
            //Kiểm tra sp có tồn tại trong session["GioHang"]
            Giohang sanpham = lstGioHang.SingleOrDefault(n => n.iMasach == iMaSach);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (sanpham != null)
            {
                sanpham.iSoluong = int.Parse(f["txtSoLuong"].ToString());

            }
            return RedirectToAction("Giohang");
        }
        //Xóa giỏ hàng
        public ActionResult XoaGioHang(int iMaSach)
        {
            //Kiểm tra masp
            Sanpham sp = db.Sanphams.SingleOrDefault(n => n.Masach == iMaSach);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<Giohang> lstGioHang = LayGioHang();
            Giohang sanpham = lstGioHang.SingleOrDefault(n => n.iMasach == iMaSach);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(n => n.iMasach == iMaSach);

            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Giohang");
        }
        //Xây dựng trang giỏ hàng
        public ActionResult GioHang()
        {
            if (Session["Giohang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Giohang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
        //Tính tổng số lượng và tổng tiền
        //Tính tổng số lượng
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<Giohang> lstGioHang = Session["Giohang"] as List<Giohang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoluong);
            }
            return iTongSoLuong;
        }
        //Tính tổng thành tiền
        private double TongTien()
        {
            double dTongTien = 0;
            List<Giohang> lstGioHang = Session["Giohang"] as List<Giohang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.ThanhTien);
            }
            return dTongTien;
        }
        //tạo partial giỏ hàng
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        //Xây dựng 1 view cho người dùng chỉnh sửa giỏ hàng
        public ActionResult SuaGioHang()
        {
            if (Session["Giohang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Giohang> lstGioHang = LayGioHang();
            return View(lstGioHang);

        }

        #region // Mới hoàn thiện
        //Xây dựng chức năng đặt hàng
        [HttpPost]
        public ActionResult DatHang()
        {
            //Kiểm tra đăng đăng nhập
            if (Session["use"] == null || Session["use"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "User");
            }
            //Kiểm tra giỏ hàng
            if (Session["Giohang"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            //Thêm đơn hàng
            Donhang ddh = new Donhang();
            Nguoidung kh = (Nguoidung)Session["use"];
            List<Giohang> gh = LayGioHang();
            ddh.MaNguoidung = kh.MaNguoiDung;
            ddh.Ngaydat = DateTime.Now;
            Console.WriteLine(ddh);
            db.Donhangs.Add(ddh);
            db.SaveChanges();
            //Thêm chi tiết đơn hàng
            foreach (var item in gh)
            {
                Chitietdonhang ctDH = new Chitietdonhang();
                decimal thanhtien = item.iSoluong * (decimal)item.dDongia;
                ctDH.Madon = ddh.Madon;
                ctDH.Masach = item.iMasach;
                ctDH.Soluong = item.iSoluong;
                ctDH.Dongia = (decimal)item.dDongia;
                ctDH.Giatien = (decimal)thanhtien;
                db.Chitietdonhangs.Add(ctDH);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Donhangs");
        }
        #endregion
    }
}