using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_CoSo.Models
{
    public class Giohang
    {
        QLbanhang db = new QLbanhang();
        public int iMasach { get; set; }
        public string sTensach { get; set; }
        public string sHinhanh { get; set; }
        public double dDongia { get; set; }
        public int iSoluong { get; set; }
        public double ThanhTien
        {
            get { return iSoluong * dDongia; }
        }
        //Hàm tạo cho giỏ hàng
        public Giohang(int Masach)
        {
            iMasach = Masach;
            Sanpham sp = db.Sanphams.Single(n => n.Masach == iMasach);
            sTensach = sp.Tensach;
            sHinhanh = sp.Hinhanh;
            dDongia = double.Parse(sp.Giatien.ToString());
            iSoluong = 1;
        }
    }
}