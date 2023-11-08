using Demo_websach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Demo_websach.Controllers
{
    public class TheLoaiController : Controller
    {
        // GET: TheLoai

        WEB_SACHEntities db = new WEB_SACHEntities();

        public PartialViewResult TheLoaiPartial()
        {
            var lstTheloai = db.Genres.ToList();
            return PartialView(lstTheloai);
        }

        public ActionResult LayDsTheoChuDe(int genreId)
        {
            // Sử dụng Linq để lấy dữ liệu
            var listBooks = db.Books.Where(p => p.Genre.GenreID == genreId).ToList();// Where(p => p.GenreID == genreId): Lambda Expression
            return View(listBooks);

        }
    }
}