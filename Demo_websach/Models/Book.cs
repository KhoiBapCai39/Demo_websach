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
    using System.ComponentModel.DataAnnotations;

    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
            this.Reviews = new HashSet<Review>();
            this.Publishers = new HashSet<Publisher>();
            this.Authors = new HashSet<Author>();
        }
        [Required(ErrorMessage = " Không được để trống !")] //kiểm tra rỗng 
        [Display(Name = "Mã sách")] //đặt lại tên cho thuộc tính
        public int BookID { get; set; }

        [Required(ErrorMessage = " Không được để trống !")] //kiểm tra rỗng 
        [Display(Name = "Tên sách")] //đặt lại tên cho thuộc tính
        public string BookName { get; set; }

        [Required(ErrorMessage = " Không được để trống !")] //kiểm tra rỗng 
        [Display(Name = "Mã thể loại")] //đặt lại tên cho thuộc tính
        public Nullable<int> GenreID { get; set; }

        [Required(ErrorMessage = " Không được để trống !")] //kiểm tra rỗng 
        [Display(Name = "Mã nhà xuất bản")] //đặt lại tên cho thuộc tính
        public Nullable<int> PublisherID { get; set; }

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
    
        public virtual Genre Genre { get; set; }
        public virtual Publisher Publisher { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Publisher> Publishers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Author> Authors { get; set; }
    }
}
