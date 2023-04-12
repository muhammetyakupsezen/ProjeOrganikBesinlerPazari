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
    
    public partial class TblSepet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblSepet()
        {
            this.TblSepetDetay = new HashSet<TblSepetDetay>();
        }
    
        public int SepetId { get; set; }
        public Nullable<int> KisiId { get; set; }
        public Nullable<int> OdemeTipiId { get; set; }
        public System.DateTime OlusturmaTarihi { get; set; }
        public string KargoFirması { get; set; }
        public int AdresId { get; set; }
        public string TeslimatDurumu { get; set; }
        public string OturumNo { get; set; }
        public System.Guid Guid { get; set; }
    
        public virtual TblKisi TblKisi { get; set; }
        public virtual TblOdemeTipleri TblOdemeTipleri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSepetDetay> TblSepetDetay { get; set; }
    }
}
