namespace DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhapKhoDichVu")]
    public partial class NhapKhoDichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhapKhoDichVu()
        {
            ChiTietNhapKhoes = new HashSet<ChiTietNhapKho>();
        }

        [Key]
        public int MaHoaDonNhap { get; set; }

        public int MaNhaCungCap { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime NgayNhapKho { get; set; }

        public int TongHoaDonNhap { get; set; }

        [Required]
        [StringLength(100)]
        public string GhiChu { get; set; }

        public int MaNhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietNhapKho> ChiTietNhapKhoes { get; set; }

        public virtual NhaCungCapDichVu NhaCungCapDichVu { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
