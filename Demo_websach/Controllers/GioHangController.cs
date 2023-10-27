using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using Demo_websach.Models;

namespace Demo_websach.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        WEB_SACHEntities db = new WEB_SACHEntities();
        #region Giỏ hàng
        //xây dựng 1 số phương thức thêm giỏ hàng, tính tổng,...
        //lấy giỏ hàng
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;// dung as de ep kieu session, khong thi tra ve null
            if(lstGioHang == null)
            {
                //nếu giỏ hàng chưa tồn tại thì tiến hành khởi tạo list giỏ hàng cũng như là session giỏ hàng
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;

            }
            return lstGioHang;
        }

        // thêm giỏ hàng
        public ActionResult ThemGioHang(int iMaSach, string strURL)
        {
            Book book = db.Books.SingleOrDefault(n => n.BookID == iMaSach);
            if(book == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //gọi và lấy ra phương thức Giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            //kiểm tra sách này đã tồn tại trong session[giohang] chưa
            GioHang sanpham = lstGioHang.Find(n => n.imaSach == iMaSach); // nêu có tồn tại mã SP này thì tức là đã có đặt SP này 1 lần trước đó rồi
            if(sanpham == null)
            {
                sanpham = new GioHang(iMaSach);
                //add sản phẩm mới thêm
                lstGioHang.Add(sanpham);
                return Redirect(strURL);
            }    
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }

        }

        //Cập nhật giỏ hàng
        public ActionResult CapNhatGioHang(int iMaSP, FormCollection f)
        {
            //kiem tra ma san pham
            Book book = db.Books.SingleOrDefault(n => n.BookID == iMaSP);
            //nếu get sai masp thì sẽ trả về trang lỗi 404
            if(book == null )
            {
                Response.StatusCode = 404;
                return null;
            }
            // phai lay ra thi moi biet trong do co SP nao
            // nếu đúng thì lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            //kiểm tra sp có tồn tại trong sesion["GioHang]
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.imaSach == iMaSP);
            //nếu mà tồn tại thì cho sửa số lượng
            if(sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());

            }
            return RedirectToAction("GioHang");
        }

        //Xóa giỏ hàng
        public ActionResult XoaGioHang(int iMaSP)
        {
            //kiem tra ma san pham
            Book book = db.Books.SingleOrDefault(n => n.BookID == iMaSP);
            //nếu get sai masp thì sẽ trả về trang lỗi 404
            if (book == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            // phai lay ra thi moi biet trong do co SP nao
            // nếu đúng thì lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            //kiểm tra sp có tồn tại trong sesion["GioHang]
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.imaSach == iMaSP);
            //nếu mà tồn tại thì cho sửa số lượng
            if (sanpham != null)
            {
                //nếu ví dụ số lượng sp đó là 10, nhưng ta muốn xóa sp đó thì sẽ xóa hết luôn 10 cuốn
                lstGioHang.RemoveAll(n=>n.imaSach==iMaSP);
            }
            if(lstGioHang.Count == 0)
            {
                return RedirectToAction("NguoiDungLayout", "Home");
            }
            return RedirectToAction("GioHang");
        } 


        //xây dựng trang giỏ hang
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("NguoiDungLayout", "Home");
            }

            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }

        //tính tổng số lượng và tổng tiền
        //tính tổng số lượng
        private int TongSoLuong()
        {
            //khởi tạo tổng số lượng đơn hàng khi chưa đặt hàng là = 0
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if(lstGioHang != null)
            {
                //khi đã đặt hàng thì sẽ sum số lượng lại
                iTongSoLuong = lstGioHang.Sum(n=>n.iSoLuong);
            }
            return iTongSoLuong;
        }
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if(lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.dThanhTien);
            }
            return dTongTien;
        }

        //tạo ra partial giỏ hàng
        public ActionResult GioHangPartial()
        {
            if(TongSoLuong() == 0)
            {
                return PartialView();
            }

            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();

        }

        //xây dựng 1 view cho người dùng chỉnh sửa giỏ hàng
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("NguoiDungLayout", "Home");
            }

            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }

        #endregion

        #region Đặt hàng
        //xây dựng chức năng đặt hàng
        [HttpPost]
        public ActionResult DatHang()
        {
            //Kiem tra đăng nhập, phải đăng nhập thì mới được đặt hàng
            if (Session["Email"] == null || Session["Email"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }

            //kiểm tra giỏ hàng
            if (Session["GioHang"] == null)
            {
                RedirectToAction("NguoiDungLayout", "Home");
            }

            //thêm đơn hàng
            Order order = new Order();
            //phải gán vì bên NguoiDungController đã gán customer = session["Email"] rồi, nên bên đây phải ép kiểu
            Customer customer = (Customer)Session["Email"];
            List<GioHang> gh = LayGioHang();
            order.CustomerID = customer.CustomerID;
            order.OrderDate = DateTime.Now;
            db.Orders.Add(order);
            db.SaveChanges();
            

            //thêm chi tiêt đơn hàng
            //vì mỗi đơn hàng có rất nhiều sản phẩm nên phải chạy vòng lặp foreach
            foreach (var item in gh)
            {
                OrderDetail ctDH = new OrderDetail();
                ctDH.OrderDetailID = order.OrderID;
                ctDH.OrderID = order.OrderID;
                ctDH.BookID = item.imaSach;
                ctDH.Quantity = item.iSoLuong;
                ctDH.DonGia = (int)(item.dDonGia);
                db.OrderDetails.Add(ctDH);
            }
            db.SaveChanges();
            return RedirectToAction("NguoiDungLayout", "Home");
        }
        #endregion
    }
}