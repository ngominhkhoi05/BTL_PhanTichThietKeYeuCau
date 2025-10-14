namespace QuanLyHocSinhTruongPhoThong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HocSinh")]
    public partial class HocSinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HocSinh()
        {
            BangDiems = new HashSet<BangDiem>();
            HanhKiems = new HashSet<HanhKiem>();
            HocSinh_PhuHuynh = new HashSet<HocSinh_PhuHuynh>();
            KhenThuongKyLuats = new HashSet<KhenThuongKyLuat>();
        }

        [Key]
        [StringLength(20)]
        public string MaHS { get; set; }

        [Required]
        [StringLength(200)]
        public string HoTen { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        [Required]
        [StringLength(200)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(15)]
        public string Sdt { get; set; }

        public bool GioiTinh { get; set; }

        [Required]
        [StringLength(20)]
        public string MaLop { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangDiem> BangDiems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HanhKiem> HanhKiems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocSinh_PhuHuynh> HocSinh_PhuHuynh { get; set; }

        public virtual Lop Lop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhenThuongKyLuat> KhenThuongKyLuats { get; set; }
    }
}
