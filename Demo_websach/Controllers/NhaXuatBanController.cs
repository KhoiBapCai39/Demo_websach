using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_websach.Models;

namespace Demo_websach.Controllers
{
    public class NhaXuatBanController : Controller
    {
        // GET: NhaXuatBan
        
        WEB_SACHEntities db = new WEB_SACHEntities();

        public PartialViewResult NhaXuatBanPartial()
        {

            return PartialView(db.Publishers.OrderBy(x => x.PublisherName).ToList());  //orderby dùng để sort   
        }


        public ActionResult GetAllByNXB(int publisherId) //lấy các sách mà nhà xuất bản đó phát hành
        {
            // Sử dụng Linq để lấy dữ liệu
            var listBooks = db.Books.Where(p => p.Publisher.PublisherID == publisherId).ToList();// Where(p => p.GenreID == genreId): Lambda Expression
            return View(listBooks);
        }
    }
}