namespace DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietSuKien")]
    public partial class ChiTietSuKien
    {
        [Key]
        public int MaChiTietSuKien { get; set; }

        public int MaSuKien { get; set; }

        public int MaNhanVien { get; set; }
    }
}
