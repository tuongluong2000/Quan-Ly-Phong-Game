namespace DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaCungCapDichVu")]
    public partial class NhaCungCapDichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaCungCapDichVu()
        {
            NhapKhoDichVus = new HashSet<NhapKhoDichVu>();
        }

        [Key]
        public int MaNhaCungCap { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNhaCungCap { get; set; }

        [Required]
        [StringLength(100)]
        public string MSTNhaCungCap { get; set; }

        [Required]
        [StringLength(100)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(20)]
        public string SoDienThoai { get; set; }

        [Required]
        [StringLength(100)]
        public string GhiChu { get; set; }

        public int LoaiDichVuCungCap { get; set; }

        public virtual LoaiDichVu LoaiDichVu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhapKhoDichVu> NhapKhoDichVus { get; set; }
    }
}
