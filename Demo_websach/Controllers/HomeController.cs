using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_websach.Models;

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

        public ActionResult DanhSachAllSanPham()
        {

            return View(db.Books.Where(n => n.sachMoi == 2).ToList());
        }

        public ActionResult GioiThieu()
        {
            return View();
        }

    }
}