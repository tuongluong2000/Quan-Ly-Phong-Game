namespace DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaoCao")]
    public partial class BaoCao
    {
        [Key]
        public int MaBaoCao { get; set; }

        public int Thang { get; set; }

        public int Nam { get; set; }

        public int TongChi { get; set; }

        public int TongThu { get; set; }

        public int TongLoiNhuan { get; set; }
    }
}
