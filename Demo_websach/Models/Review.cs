//------------------------------------------------------------------------------
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
    
    public partial class Review
    {
        public int ReviewID { get; set; }
        public Nullable<int> BookID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<double> Rating { get; set; }
        public string ReviewText { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Customer Customer { get; set; }
    }
}