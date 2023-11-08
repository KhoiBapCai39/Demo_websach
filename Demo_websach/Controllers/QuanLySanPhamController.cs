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
        [ValidateInput(false)]
      
        public ActionResult ThemMoi(Book book, HttpPostedFileBase fileUpload)
        {
           
            //đưa dữ liệu vào drop downlist
            ViewBag.GenreID = new SelectList(db.Genres.ToList().OrderBy(n => n.GenreName), "GenreID", "GenreName");
            ViewBag.PublisherID = new SelectList(db.Publishers.ToList().OrderBy(n => n.PublisherName), "PublisherID", "PublisherName");

            //kiểm tra đường dẫn ảnh bìa
            if(fileUpload == null)
            {
                ViewBag.ThongBao = "Yêu cầu chọn hình ảnh để hiển thị !";
                return View();
            }

            //Thêm vào cơ sở dữ liệu
            if(ModelState.IsValid)
            {
                //lưu tên file
                var fileName = Path.GetFileName(fileUpload.FileName);

                //lưu đường dẫn của file
                var path = Path.Combine(Server.MapPath("~/HinhAnhSP"), fileName);

                //kiểm tra hình ảnh đã tồn tại chưa ?
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại !!!!!";
                }
                else
                {
                    //save vào đường dẫn, để lấy hình đưa vào thư mục của mình ( thư mục HinhAnhSP )
                    fileUpload.SaveAs(path);
                }
                book.imgBOOK = fileUpload.FileName;

                db.Books.Add(book);
                db.SaveChanges();

            }    
            return View();
        }
        [HttpGet]

        public ActionResult ChinhSua()
        {
            ViewBag.GenreId = new SelectList(db.Genres.ToList(), "GenreID", "GenreName");
            ViewBag.PublisherId = new SelectList(db.Publishers.ToList(), "PublisherID", "PublisherName");//cho ID la tui viet hoa 2 chu luon a
            return View();
        }

        //chỉnh sửa sản phẩm
        [HttpPost]
        public ActionResult ChinhSua(int BookID)
        {
            //lấy ra đối tượng sách theo mã
            Book book = db.Books.SingleOrDefault(n => n.BookID ==  BookID); //trả về 1 đối tượng sách thỏa mãn điều kiện này
            if (book == null)
            {
                Response.StatusCode = 404;
                return null;

            }
            ViewBag.GenreID = new SelectList(db.Genres.ToList().OrderBy(n => n.GenreName), "GenreID", "GenreName");
            ViewBag.PublisherID = new SelectList(db.Publishers.ToList().OrderBy(n => n.PublisherName), "PublisherID", "PublisherName");
            return View(book);
        }
    }
}