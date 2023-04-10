namespace DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiSuKien")]
    public partial class LoaiSuKien
    {
        [Key]
        public int MaLoaiSuKien { get; set; }

        [Required]
        [StringLength(100)]
        public string TenLoaiSuKien { get; set; }
    }
}
