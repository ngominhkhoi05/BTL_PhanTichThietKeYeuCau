namespace QuanLyHocSinhTruongPhoThong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HocKy")]
    public partial class HocKy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HocKy()
        {
            BangDiems = new HashSet<BangDiem>();
            HanhKiems = new HashSet<HanhKiem>();
            KhenThuongKyLuats = new HashSet<KhenThuongKyLuat>();
            PhanCongGiangDays = new HashSet<PhanCongGiangDay>();
        }

        [Key]
        [StringLength(20)]
        public string MaHK { get; set; }

        [Required]
        [StringLength(50)]
        public string TenHK { get; set; }

        [Required]
        [StringLength(20)]
        public string MaNienKhoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangDiem> BangDiems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HanhKiem> HanhKiems { get; set; }

        public virtual NienKhoa NienKhoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhenThuongKyLuat> KhenThuongKyLuats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanCongGiangDay> PhanCongGiangDays { get; set; }
    }
}
