namespace DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiTrangThai")]
    public partial class LoaiTrangThai
    {
        [Key]
        public int MaLoaiTrangThai { get; set; }

        [Required]
        [StringLength(100)]
        public string TenLoaiTrangThai { get; set; }
    }
}
