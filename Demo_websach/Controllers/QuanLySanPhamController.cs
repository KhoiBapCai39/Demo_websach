using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_websach.Models;
using PagedList;
using PagedList.Mvc;

namespace Demo_websach.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        // GET: QuanLySanPham
        WEB_SACHEntities db = new WEB_SACHEntities();
        public ActionResult Index(int? page) //trang index sẽ là trang xuất ra danh sách các sản phẩm
        {
            int pageNumber = (page ?? 1);
            int pageSize = 20; //1 trang cho 20 quyển
            return View(db.Books.ToList().OrderBy(n=>n.BookID).ToPagedList(pageNumber, pageSize));
        }

        //Thêm mới
        [HttpGet]
        public ActionResult ThemMoi()
        {
            //đưa dữ liệu vào drop downlist
            ViewBag.GenreID = new SelectList( db.Genres.ToList().OrderBy(n=>n.GenreName), "GenreID", "GenreName");
            ViewBag.PublisherID = new SelectList( db.Publishers.ToList().OrderBy(n=>n.PublisherName), "PublisherID", "PublisherName");
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(Book book, HttpPostedFileBase fileUpload)
        {
            //lưu tên file
            var filename = Path.GetFileName(fileUpload.FileName);

            //lưu đường dẫn của file
            var path = Path.Combine(Server.MapPath("~/HinhAnhSP"), filename);

            //kiểm tra hình ảnh đã tồn tại chưa ?
            if(System.IO.File.Exists(path))
            {
                ViewBag.ThongBao = "Hình ảnh đã tồn tại !!!!!";
            }
            else
            {
                //save vào đường dẫn, để lấy hình đưa vào thư mục của mình ( thư mục HinhAnhSP )
                fileUpload.SaveAs(path);
            }
            //đưa dữ liệu vào drop downlist
            ViewBag.GenreID = new SelectList(db.Genres.ToList().OrderBy(n => n.GenreName), "GenreID", "GenreName");
            ViewBag.PublisherID = new SelectList(db.Publishers.ToList().OrderBy(n => n.PublisherName), "PublisherID", "PublisherName");
            return View();
        }
    }
}