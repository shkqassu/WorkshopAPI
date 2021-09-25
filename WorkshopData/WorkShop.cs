//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkshopData
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkShop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkShop()
        {
            this.Materials = new HashSet<Material>();
            this.Student_WorkShop_Mapping = new HashSet<Student_WorkShop_Mapping>();
            this.Trainer_WorkShop_Mapping = new HashSet<Trainer_WorkShop_Mapping>();
        }
    
        public int WorkShopId { get; set; }
        public string WorkShopTitle { get; set; }
        public Nullable<System.DateTime> WorkShopDate { get; set; }
        public string WorkShopDuration { get; set; }
        public string WorkShopTopics { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Material> Materials { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_WorkShop_Mapping> Student_WorkShop_Mapping { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainer_WorkShop_Mapping> Trainer_WorkShop_Mapping { get; set; }
        public virtual UserDetail UserDetail { get; set; }
    }
}
