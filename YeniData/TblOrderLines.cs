//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YeniData
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblOrderLines
    {
        public int Id { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> UrunId { get; set; }
    
        public virtual TblOrder TblOrder { get; set; }
        public virtual TblUrun TblUrun { get; set; }
    }
}