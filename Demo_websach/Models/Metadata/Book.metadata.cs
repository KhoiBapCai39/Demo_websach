using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using thư viện thiết kế class meta data
using System.ComponentModel;
using System.ComponentModel.DataAnnotations; //thêm các thuộc tính validation, displayname
using System.ComponentModel.Composition;

namespace Demo_websach.Models
{
    [MetadataTypeAttribute(typeof(BookMetadata))]
    public partial class Book
    {
        //internal: chỉ sử dụng cho class này, sealed: ko cho kế thừa
        internal sealed class BookMetadata
        {
            [Required(ErrorMessage = " Không được để trống !")] //kiểm tra rỗng 
            [Display(Name = "Mã sách")] //đặt lại tên cho thuộc tính
            public int BookID { get; set; }

            [Required(ErrorMessage = " Không được để trống !")] //kiểm tra rỗng 
            [Display(Name = "Tên sách")] //đặt lại tên cho thuộc tính
            public string BookName { get; set; }


            [Display(Name = "Mã thể loại")] //đặt lại tên cho thuộc tính
            public Nullable<int> GenreID { get; set; }

          
            [Display(Name = "Mã nhà xuất bản")] //đặt lại tên cho thuộc tính
            public Nullable<int> PublisherID { get; set; }

            [Required(ErrorMessage = " Không được để trống !")] //kiểm tra rỗng 
            [Display(Name = "Ảnh sách")] //đặt lại tên cho thuộc tính
            public string imgBOOK { get; set; }

            [Required(ErrorMessage = " Không được để trống !")] //kiểm tra rỗng 
            [Display(Name = "Giá")] //đặt lại tên cho thuộc tính
            public Nullable<int> Gia { get; set; }

            [Required(ErrorMessage = " Không được để trống !")] //kiểm tra rỗng 
            [Display(Name = "Sách mới")] //đặt lại tên cho thuộc tính
            public Nullable<int> sachMoi { get; set; }

            [Required(ErrorMessage = " Không được để trống !")] //kiểm tra rỗng 
            [Display(Name = "Mô tả")] //đặt lại tên cho thuộc tính
            public string MoTa { get; set; }
        }
    }
}