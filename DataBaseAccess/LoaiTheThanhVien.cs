namespace DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiTheThanhVien")]
    public partial class LoaiTheThanhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiTheThanhVien()
        {
            TheThanhViens = new HashSet<TheThanhVien>();
        }

        [Key]
        public int MaLoaiTheThanhVien { get; set; }

        [Required]
        [StringLength(50)]
        public string TenLoaiTheThanhVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TheThanhVien> TheThanhViens { get; set; }
    }
}
