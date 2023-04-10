namespace DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietNhapKho")]
    public partial class ChiTietNhapKho
    {
        [Key]
        public int MaChiTietNhapKho { get; set; }

        public int MaNhapKho { get; set; }

        public int DichVuNhapKho { get; set; }

        public int SoLuongNhap { get; set; }

        public int ChiPhiNhap { get; set; }

        public virtual DichVu DichVu { get; set; }

        public virtual NhapKhoDichVu NhapKhoDichVu { get; set; }
    }
}
