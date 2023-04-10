namespace DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HuHaiCSVC")]
    public partial class HuHaiCSVC
    {
        [Key]
        public int MaHuHai { get; set; }

        public int ThietBiHuHai { get; set; }

        [Required]
        [StringLength(100)]
        public string MoTa { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime NgayHuHai { get; set; }

        public int TinhTrang { get; set; }

        public int ChiPhiSuaChua { get; set; }
    }
}
