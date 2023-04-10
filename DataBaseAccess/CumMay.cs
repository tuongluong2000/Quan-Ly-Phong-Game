namespace DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CumMay")]
    public partial class CumMay
    {
        [Key]
        public int MaCumMay { get; set; }

        public int SoThuTu { get; set; }

        public int LoaiCumMay { get; set; }

        public int LoaiTrangThai { get; set; }

        public int ChiPhiThue { get; set; }
    }
}
