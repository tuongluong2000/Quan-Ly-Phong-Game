namespace DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SuKien")]
    public partial class SuKien
    {
        [Key]
        public int MaSuKien { get; set; }

        [StringLength(100)]
        public string TenSuKien { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime NgayBatDau { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime NgayKetThuc { get; set; }

        [Required]
        [StringLength(200)]
        public string MoTa { get; set; }

        [Required]
        public int LoaiSuKien { get; set; }
    }
}
