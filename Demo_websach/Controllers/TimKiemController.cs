using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_websach.Models;
using PagedList.Mvc;
using PagedList;

namespace Demo_websach.Controllers
{
    public class TimKiemController : Controller
    {
        WEB_SACHEntities db = new WEB_SACHEntities();
        // GET: TimKiem
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<Book> lstKQTK = db.Books.Where(n => n.BookName.Contains(sTuKhoa)).ToList();


            //Phân trang 
            int pageNumber = (page ?? 1);
            int pageSize = 9;

            if (lstKQTK.Count == 0 )
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.Books.OrderBy(n=>n.BookName).ToPagedList(pageNumber, pageSize));
            }

            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + "kết quả";
            return View(lstKQTK.OrderBy(n=>n.BookName).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult KetQuaTimKiem(string sTuKhoa, int? page)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<Book> lstKQTK = db.Books.Where(n => n.BookName.Contains(sTuKhoa)).ToList();


            //Phân trang 
            int pageNumber = (page ?? 1);
            int pageSize = 9;

            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào nên chúng tôi sẽ show ra hết sách";
                return View(db.Books.OrderBy(n => n.BookName).ToPagedList(pageNumber, pageSize));
            }

            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả luôn á";
            return View(lstKQTK.OrderBy(n => n.BookName).ToPagedList(pageNumber, pageSize));
        }
    }
}