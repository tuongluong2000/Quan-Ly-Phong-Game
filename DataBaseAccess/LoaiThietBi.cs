namespace DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiThietBi")]
    public partial class LoaiThietBi
    {
        [Key]
        public int MaLoaiThietBi { get; set; }

        [Required]
        [StringLength(200)]
        public string TenLoaiThietBi { get; set; }
    }
}
