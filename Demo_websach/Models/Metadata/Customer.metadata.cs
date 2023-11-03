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
    [MetadataTypeAttribute(typeof(CustomerMetadata))]
    public partial class Customer
    {
        internal sealed class CustomerMetadata
        {
            [Display(Name = "Mã khách hàng")] //đặt lại tên cho thuộc tính
            public int CustomerID { get; set; }


            [Display(Name = "Tên khách hàng")]
            [Required(ErrorMessage = "{0} không được để trống !")] //kiểm tra rỗng 
            [StringLength(30, ErrorMessage = "Không quá 30 ký tự")] //kiểm tra chiều dài tối đa của đầu vào
            [MinLength(5)]
            public string CustomerName { get; set; }


            [Display(Name = "Email")]
            [Required(ErrorMessage = "{0} không được để trống !")] //kiểm tra rỗng
            [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "{0} không hợp lệ ")]
            public string Email { get; set; }


            [Display(Name = "Số điện thoại")]
            [Required(ErrorMessage = "{0} không được để trống !")] //kiểm tra rỗng
            [StringLength(11, ErrorMessage = "Không quá 11 ký tự")]
            [MinLength(9)]
            public string PhoneNumber { get; set; }


            [Display(Name = "Mật khẩu")]
            [Required(ErrorMessage = "{0} không được để trống !")] //kiểm tra rỗng
            [MinLength(8, ErrorMessage = "Mật khẩu phải tối thiểu là 8 ký tự")]
            public string MatKhau { get; set; }


            [Display(Name = "Ngày sinh")]
            [DisplayFormat(DataFormatString = "{0:dd//MM//yyyy}")] //định dạng ngày tháng năm
            public Nullable<System.DateTime> NgaySinh { get; set; }


            [Display(Name = "Địa chỉ")]
            [Required(ErrorMessage = "{0} không được để trống !")] //kiểm tra rỗng
            [StringLength(50, ErrorMessage = "Không quá 50 ký tự")] //kiểm tra chiều dài tối đa của đầu vào
            public string DiaChi { get; set; }
        }
    }
}