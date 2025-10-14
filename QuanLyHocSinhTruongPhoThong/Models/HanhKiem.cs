namespace QuanLyHocSinhTruongPhoThong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HanhKiem")]
    public partial class HanhKiem
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MaHS { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MaHK { get; set; }

        [Required]
        [StringLength(50)]
        public string Loai { get; set; }

        public virtual HocKy HocKy { get; set; }

        public virtual HocSinh HocSinh { get; set; }
    }
}
