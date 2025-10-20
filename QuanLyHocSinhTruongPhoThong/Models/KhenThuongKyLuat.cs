namespace QuanLyHocSinhTruongPhoThong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhenThuongKyLuat")]
    public partial class KhenThuongKyLuat
    {
        [Key]
        [StringLength(20)]
        public string MaKTKL { get; set; }

        [Required]
        [StringLength(20)]
        public string MaHS { get; set; }

        [Required]
        [StringLength(20)]
        public string MaHK { get; set; }

        [Required]
        [StringLength(50)]
        public string Loai { get; set; }

        [StringLength(200)]
        public string NoiDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }

        public virtual HocKy HocKy { get; set; }

        public virtual HocSinh HocSinh { get; set; }
    }
}
