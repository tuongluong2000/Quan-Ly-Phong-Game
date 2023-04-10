namespace DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThanhToan")]
    public partial class ThanhToan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThanhToan()
        {
            ChiTietThanhToans = new HashSet<ChiTietThanhToan>();
        }

        [Key]
        public int MaThanhToan { get; set; }

        public int MaKhachHang { get; set; }

        public int MaNhanVien { get; set; }

        public int TongThanhToan { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime NgayThanhToan { get; set; }

        [Required]
        [StringLength(100)]
        public string HinhThucThanhToan { get; set; }

        [Required]
        [StringLength(100)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietThanhToan> ChiTietThanhToans { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
