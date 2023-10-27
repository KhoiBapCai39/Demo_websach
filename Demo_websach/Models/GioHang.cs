using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Linq;
using System.Web;


namespace Demo_websach.Models
{
    // định nghĩa ra 1 cái class để add sesion đó về kiểu dữu liệu mong muốn
    public class GioHang
    {
        WEB_SACHEntities db = new WEB_SACHEntities();

        //để quản lý giỏ hàng cần có mã sản phẩm ( mã sách )
        public int imaSach {  get; set; } 
        public string sTenSach { get; set;}
        public string sAnhBia {  get; set;}
        public double dDonGia {  get; set;}
        public int iSoLuong {  get; set;}
        public double dThanhTien
        {  
            get { return iSoLuong * dDonGia; }
        }

        //Ham tao gio hang, khi mà gửi vào mã sp sẽ lấy hết thuộc tính
        public GioHang(int maSach)
        {
            imaSach = maSach;
            Book book = db.Books.Single(n=>n.BookID == imaSach);
            sTenSach = book.BookName;
            sAnhBia = book.imgBOOK;
            dDonGia = double.Parse(book.Gia.ToString()); //ep kieu
            iSoLuong = 1;
        }

    }
}