namespace DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TheThanhVien")]
    public partial class TheThanhVien
    {
        [Key]
        public int MaTheThanhVien { get; set; }

        public int MaKhachHang { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime NgayKichHoat { get; set; }

        public int MaLoaiTheThanhVien { get; set; }

        [Required]
        [StringLength(50)]
        public string TinhTrangThe { get; set; }

        public int CapBacThe { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual LoaiTheThanhVien LoaiTheThanhVien { get; set; }
    }
}
