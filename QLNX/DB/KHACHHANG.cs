//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLNX.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            this.PHOIXE = new HashSet<PHOIXE>();
        }
    
        public int MAKH { get; set; }
        public string HOTENKH { get; set; }
        public string SDTKH { get; set; }
        public string EMAIL { get; set; }
        public string MATKHAUKH { get; set; }
        public string TRANGTHAIKH { get; set; }
        public Nullable<int> DIEMDON { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHOIXE> PHOIXE { get; set; }
    }
}