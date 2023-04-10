namespace DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietThanhToan")]
    public partial class ChiTietThanhToan
    {
        [Key]
        public int MaChiTietThanhToan { get; set; }

        public int MaThanhToan { get; set; }

        public int DichVuSuDung { get; set; }

        public int SoLuongSuDung { get; set; }

        public virtual DichVu DichVu { get; set; }

        public virtual ThanhToan ThanhToan { get; set; }
    }
}
