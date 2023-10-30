using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_websach.Models;
using PagedList;
using PagedList.Mvc;

namespace Demo_websach.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        WEB_SACHEntities db = new WEB_SACHEntities();   

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult NguoiDungLayout()
        {

           return View(db.Books.Where(n=>n.sachMoi==1).ToList());
        }

        public ActionResult DanhSachAllSanPham(int? page) //đặt biến page ở đây để khi mà người dùng bấm vào trang 2, thì biến này sẽ = 2
        {
            //tạo ra 1 biến số sản phẩm trên 1 trang 
            int pageSize = 15;
            //tạo biến số trang
            int pageNumber = (page ?? 1); //dấu ? ở đây là khi chia trang, khi 1 trang ko đủ 9 sp thì mặc định pageNumber = 1

            return View(db.Books.Where(n=>n.sachMoi == 2).OrderBy(n=>n.Gia).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult GioiThieu()
        {
            return View();
        }

    }
}