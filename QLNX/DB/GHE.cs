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
    
    public partial class GHE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GHE()
        {
            this.PHOIXE = new HashSet<PHOIXE>();
        }
    
        public int MAGHE { get; set; }
        public Nullable<int> MAXE { get; set; }
        public string TENGHE { get; set; }
        public string TRANGTHAIGHE { get; set; }
        public Nullable<int> HANG { get; set; }
        public Nullable<int> COT { get; set; }
    
        public virtual XE XE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHOIXE> PHOIXE { get; set; }
    }
}