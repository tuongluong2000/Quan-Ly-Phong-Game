namespace DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietCumMay")]
    public partial class ChiTietCumMay
    {
        [Key]
        public int MaChiTietCumMay { get; set; }

        public int MaCumMay { get; set; }

        public int MaThietBi { get; set; }
    }
}
