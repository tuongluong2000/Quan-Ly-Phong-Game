namespace DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThietBi")]
    public partial class ThietBi
    {
        [Key]
        public int MaThietBi { get; set; }

        [Required]
        [StringLength(200)]
        public string TenThietBi { get; set; }

        [Required]
        [StringLength(200)]
        public string MoTa { get; set; }

        [Required]
        [StringLength(200)]
        public string HinhAnh { get; set; }

        public int LoaiThietBi { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime NgayCapNhat { get; set; }

        public int TrangThai { get; set; }

        public int MaThongSo { get; set; }
    }
}
