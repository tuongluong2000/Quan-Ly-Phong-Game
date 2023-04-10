namespace DataBaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongSoThietBi")]
    public partial class ThongSoThietBi
    {
        [Key]
        public int MaThongSo { get; set; }

        [Required]
        [StringLength(200)]
        public string NhaSanXuat { get; set; }

        public int NamGioiThieu { get; set; }

        [Required]
        [StringLength(200)]
        public string MoTa { get; set; }
    }
}
