﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo_websach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Orders = new HashSet<Order>();
            this.Reviews = new HashSet<Review>();
        }
        [Display(Name = "Mã khách hàng")] //thuộc tính display dùng để đặt tên lại
        [Required(ErrorMessage = "{0} không được để trống")] //kiểm tra rỗng
        public int CustomerID { get; set; }

        [Display(Name = "Họ tên")] //thuộc tính display dùng để đặt tên lại
        [Required(ErrorMessage = "{0} không được để trống")] //kiểm tra rỗng
        [StringLength(50, ErrorMessage ="Không quá 50 kí tự")] //kiểm tra chiều dài tối đa
        [MinLength(10, ErrorMessage = "Ít nhất 10 kí tự")]
        public string CustomerName { get; set; }

        [Display(Name = "Email")] //thuộc tính display dùng để đặt tên lại
        [Required(ErrorMessage = "{0} không được để trống")] //kiểm tra rỗng
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$", ErrorMessage = "Email không hợp lệ")]
        [MinLength(10, ErrorMessage = "Ít nhất 10 kí tự")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")] //thuộc tính display dùng để đặt tên lại
        [Required(ErrorMessage = "{0} không được để trống")] //kiểm tra rỗng
        [StringLength(11, ErrorMessage = "Không quá 11 kí tự")] //kiểm tra chiều dài tối đa
        [MinLength(10, ErrorMessage = "Ít nhất 10 kí tự")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Mật khẩu")] //thuộc tính display dùng để đặt tên lại
        [Required(ErrorMessage = "{0} không được để trống")] //kiểm tra rỗng
        [StringLength(50, ErrorMessage = "Không quá 50 kí tự")] //kiểm tra chiều dài tối đa
        [MinLength(10, ErrorMessage = "Ít nhất 10 kí tự")]
        public string MatKhau { get; set; }

        [Display(Name = "Ngày sinh")] //thuộc tính display dùng để đặt tên lại
        [Required(ErrorMessage = "{0} không được để trống")] //kiểm tra rỗng
        [DisplayFormat(DataFormatString ="0:dd//MM//yyyy")] //định dạng dữ liệu
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> NgaySinh { get; set; }

        [Display(Name = "Địa chỉ")] //thuộc tính display dùng để đặt tên lại
        [Required(ErrorMessage = "{0} không được để trống")] //kiểm tra rỗng
        [StringLength(60, ErrorMessage = "Không quá 60 kí tự")] //kiểm tra chiều dài tối đa
        [MinLength(15, ErrorMessage = "Ít nhất 15 kí tự")]
        public string DiaChi { get; set; }


    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
