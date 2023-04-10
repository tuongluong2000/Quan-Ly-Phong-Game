namespace DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiCumMay")]
    public partial class LoaiCumMay
    {
        [Key]
        public int MaLoaiCumMay { get; set; }

        [Required]
        [StringLength(100)]
        public string TenLoaiCumMay { get; set; }
    }
}
