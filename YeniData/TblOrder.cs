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
    
    public partial class TblOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblOrder()
        {
            this.TblOrderLines = new HashSet<TblOrderLines>();
        }
    
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public Nullable<double> OrderTotal { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public string KullaniciAdi { get; set; }
        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string UlkeAdi { get; set; }
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
        public string SiparisDurumu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblOrderLines> TblOrderLines { get; set; }
    }
}
