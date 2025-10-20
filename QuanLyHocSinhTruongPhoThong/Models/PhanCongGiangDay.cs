namespace QuanLyHocSinhTruongPhoThong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanCongGiangDay")]
    public partial class PhanCongGiangDay
    {
        [Key]
        [StringLength(20)]
        public string MaPC { get; set; }

        [Required]
        [StringLength(20)]
        public string MaGV { get; set; }

        [Required]
        [StringLength(20)]
        public string MaLop { get; set; }

        [Required]
        [StringLength(20)]
        public string MaMH { get; set; }

        [Required]
        [StringLength(20)]
        public string MaHK { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }

        public virtual HocKy HocKy { get; set; }

        public virtual Lop Lop { get; set; }

        public virtual MonHoc MonHoc { get; set; }
    }
}
