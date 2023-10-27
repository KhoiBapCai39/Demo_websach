using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_websach.Models;

namespace Demo_websach.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung

        WEB_SACHEntities db = new WEB_SACHEntities();

        public ActionResult Index()
        {
            return View();
        }

        //phương thức get dùng để khi load lại trang, có thể truyền lại các tham số query string. Nếu muốn truyền query dữ liệu các textbox thì xài phương thức post
        [HttpGet]

        public ActionResult DangKy() 
        {

            return View();
        }

        [HttpPost]//khi nhập liệu đủ các thông số, nó sẽ chạy phương thức post thay vì phương thức get
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(Customer cus) //gửi vào 1 đối tượng khách hàng
        {
            if(ModelState.IsValid)
            {
                //chèn dữ liệu vào bảng khách hàng
                db.Customers.Add(cus);

                //Lưu vào cơ sở dữ liệu
                db.SaveChanges();
            }

            return View();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {

            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sEmail = f["txtEmail"].ToString();  //1
            string sMatKhau = f.Get("txtMatKhau").ToString();//2

            //1 và 2 là 2 đoạn code có chức năng giống nhau, xài cái nào cũng được

            Customer cus = db.Customers.SingleOrDefault(n => n.Email == sEmail && n.MatKhau == sMatKhau); //giống điều kiện where, nếu email và mk thỏa mãn trong csdl thì đăng nhập thành công
            if (cus != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành công rồi nha bạn ơi "; 
                Session["Email"] = cus;  //lưu lại tài khoản khách hàng, session là kiểu dữu liệu object nên có thể lưu mọi thứ
                return RedirectToAction("NguoiDungLayout", "Home");
            }
            ViewBag.ThongBao = "Email hoặc mật khẩu bạn vừa nhập không đúng !";
            return View();
           


        }
    }
}