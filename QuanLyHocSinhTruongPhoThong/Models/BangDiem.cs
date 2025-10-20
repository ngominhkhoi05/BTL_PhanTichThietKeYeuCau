namespace QuanLyHocSinhTruongPhoThong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BangDiem")]
    public partial class BangDiem
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MaHK { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MaHS { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string MaMH { get; set; }

        public decimal? DiemGiuaKi { get; set; }

        public decimal? DiemCuoiKi { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? DiemTongKet { get; set; }

        public virtual HocKy HocKy { get; set; }

        public virtual HocSinh HocSinh { get; set; }

        public virtual MonHoc MonHoc { get; set; }
    }
}
