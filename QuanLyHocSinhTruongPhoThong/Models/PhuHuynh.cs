namespace QuanLyHocSinhTruongPhoThong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhuHuynh")]
    public partial class PhuHuynh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhuHuynh()
        {
            HocSinh_PhuHuynh = new HashSet<HocSinh_PhuHuynh>();
        }

        [Key]
        [StringLength(20)]
        public string MaPH { get; set; }

        [Required]
        [StringLength(200)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(15)]
        public string Sdt { get; set; }

        public bool GioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocSinh_PhuHuynh> HocSinh_PhuHuynh { get; set; }
    }
}
