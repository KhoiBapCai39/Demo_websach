using Demo_websach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_websach.Models;

namespace Demo_websach.Controllers
{
    public class SachController : Controller
    {
        // GET: SachMoiPartial

        WEB_SACHEntities db = new WEB_SACHEntities();

        public ActionResult Index()
        {

            return View();
        }

        public PartialViewResult SachMoiPartial() { 
            
            var lstSach = db.Books.Take(5).ToList();
            return PartialView(lstSach);
        }

        //Xem chi tiet 
        public ActionResult XemChiTiet(int MaSach) 
        {
            //co the chon actionresult neu nhu ko biet doi tuong tra ve cua no la gi
            //ham singleordefault giup ta thoa man de tra ve cac doi tuong sau:
            //ở đây hàm single giúp thỏa mãn đk mã sách = mã sách truyền vào
            Book book = db.Books.SingleOrDefault(n => n.BookID == MaSach);
            if (book == null)
            {
                return RedirectToAction("Home");
            }
            //cach 1:
            ViewBag.TenChuDe = db.Genres.Single(n => n.GenreID == book.GenreID).GenreName; //single là lấy ra 1 đối tượng, đây là biểu thức lamda, với mã chủ đề, truyền vào mã chủ đề, lấy ra mã chủ đề nào thì mã sách bằng mã chủ đề, thì đối tượng đó lấy ra tên chủ đề
            ViewBag.NhaXuatBan = db.Publishers.Single(n => n.PublisherID == book.PublisherID).PublisherName;
            //cach 2
            //Genre genre = db.Genres.Single(n => n.GenreID == book.GenreID);
            //ViewBag.TenChuDe = genre.GenreName;
            return View(book);
        }

    }
}