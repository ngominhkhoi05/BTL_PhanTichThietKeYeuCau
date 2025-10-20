namespace QuanLyHocSinhTruongPhoThong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HocSinh_PhuHuynh
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MaHS { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MaPH { get; set; }

        [StringLength(50)]
        public string QuanHe { get; set; }

        public virtual HocSinh HocSinh { get; set; }

        public virtual PhuHuynh PhuHuynh { get; set; }
    }
}
