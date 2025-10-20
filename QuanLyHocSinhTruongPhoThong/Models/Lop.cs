namespace QuanLyHocSinhTruongPhoThong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lop")]
    public partial class Lop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lop()
        {
            HocSinhs = new HashSet<HocSinh>();
            PhanCongGiangDays = new HashSet<PhanCongGiangDay>();
            ThoiKhoaBieux = new HashSet<ThoiKhoaBieu>();
        }

        [Key]
        [StringLength(20)]
        public string MaLop { get; set; }

        [Required]
        [StringLength(20)]
        public string TenLop { get; set; }

        [Required]
        [StringLength(20)]
        public string MaNienKhoa { get; set; }

        [StringLength(20)]
        public string MaGV { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocSinh> HocSinhs { get; set; }

        public virtual NienKhoa NienKhoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanCongGiangDay> PhanCongGiangDays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThoiKhoaBieu> ThoiKhoaBieux { get; set; }
    }
}
