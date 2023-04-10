namespace DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichVu")]
    public partial class DichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVu()
        {
            ChiTietNhapKhoes = new HashSet<ChiTietNhapKho>();
            ChiTietThanhToans = new HashSet<ChiTietThanhToan>();
        }

        [Key]
        public int MaDichVu { get; set; }

        [Required]
        [StringLength(200)]
        public string TenDichVu { get; set; }

        public int LoaiDichVu { get; set; }

        public int GiaKinhDoanh { get; set; }

        [Required]
        [StringLength(50)]
        public string DonViTinh { get; set; }

        [Required]
        [StringLength(100)]
        public string MoTa { get; set; }

        public int SoLuongConLai { get; set; }

        public int HinhAnh { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime NgayCapNhat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietNhapKho> ChiTietNhapKhoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietThanhToan> ChiTietThanhToans { get; set; }

        public virtual LoaiDichVu LoaiDichVu1 { get; set; }
    }
}
