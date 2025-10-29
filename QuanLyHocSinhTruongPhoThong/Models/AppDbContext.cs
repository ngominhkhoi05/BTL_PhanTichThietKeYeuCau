using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyHocSinhTruongPhoThong.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext2")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<BangDiem> BangDiems { get; set; }
        public virtual DbSet<GiaoVien> GiaoViens { get; set; }
        public virtual DbSet<HanhKiem> HanhKiems { get; set; }
        public virtual DbSet<HocKy> HocKies { get; set; }
        public virtual DbSet<HocSinh> HocSinhs { get; set; }
        public virtual DbSet<HocSinh_PhuHuynh> HocSinh_PhuHuynh { get; set; }
        public virtual DbSet<KhenThuongKyLuat> KhenThuongKyLuats { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<NienKhoa> NienKhoas { get; set; }
        public virtual DbSet<PhanCongGiangDay> PhanCongGiangDays { get; set; }
        public virtual DbSet<PhuHuynh> PhuHuynhs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ThoiKhoaBieu> ThoiKhoaBieux { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.AccountId)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.MaGV)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Accounts)
                .Map(m => m.ToTable("AccountRole").MapLeftKey("AccountId").MapRightKey("RoleId"));

            modelBuilder.Entity<BangDiem>()
                .Property(e => e.MaHK)
                .IsUnicode(false);

            modelBuilder.Entity<BangDiem>()
                .Property(e => e.MaHS)
                .IsUnicode(false);

            modelBuilder.Entity<BangDiem>()
                .Property(e => e.MaMH)
                .IsUnicode(false);

            modelBuilder.Entity<BangDiem>()
                .Property(e => e.DiemGiuaKi)
                .HasPrecision(4, 2);

            modelBuilder.Entity<BangDiem>()
                .Property(e => e.DiemCuoiKi)
                .HasPrecision(4, 2);

            modelBuilder.Entity<BangDiem>()
                .Property(e => e.DiemTongKet)
                .HasPrecision(4, 2);

            modelBuilder.Entity<GiaoVien>()
                .Property(e => e.MaGV)
                .IsUnicode(false);

            modelBuilder.Entity<GiaoVien>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<GiaoVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<GiaoVien>()
                .HasMany(e => e.PhanCongGiangDays)
                .WithRequired(e => e.GiaoVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HanhKiem>()
                .Property(e => e.MaHS)
                .IsUnicode(false);

            modelBuilder.Entity<HanhKiem>()
                .Property(e => e.MaHK)
                .IsUnicode(false);

            modelBuilder.Entity<HocKy>()
                .Property(e => e.MaHK)
                .IsUnicode(false);

            modelBuilder.Entity<HocKy>()
                .Property(e => e.MaNienKhoa)
                .IsUnicode(false);

            modelBuilder.Entity<HocKy>()
                .HasMany(e => e.BangDiems)
                .WithRequired(e => e.HocKy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HocKy>()
                .HasMany(e => e.HanhKiems)
                .WithRequired(e => e.HocKy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HocKy>()
                .HasMany(e => e.KhenThuongKyLuats)
                .WithRequired(e => e.HocKy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HocKy>()
                .HasMany(e => e.PhanCongGiangDays)
                .WithRequired(e => e.HocKy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HocSinh>()
                .Property(e => e.MaHS)
                .IsUnicode(false);

            modelBuilder.Entity<HocSinh>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<HocSinh>()
                .Property(e => e.MaLop)
                .IsUnicode(false);

            modelBuilder.Entity<HocSinh>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<HocSinh_PhuHuynh>()
                .Property(e => e.MaHS)
                .IsUnicode(false);

            modelBuilder.Entity<HocSinh_PhuHuynh>()
                .Property(e => e.MaPH)
                .IsUnicode(false);

            modelBuilder.Entity<KhenThuongKyLuat>()
                .Property(e => e.MaKTKL)
                .IsUnicode(false);

            modelBuilder.Entity<KhenThuongKyLuat>()
                .Property(e => e.MaHS)
                .IsUnicode(false);

            modelBuilder.Entity<KhenThuongKyLuat>()
                .Property(e => e.MaHK)
                .IsUnicode(false);

            modelBuilder.Entity<Lop>()
                .Property(e => e.MaLop)
                .IsUnicode(false);

            modelBuilder.Entity<Lop>()
                .Property(e => e.MaNienKhoa)
                .IsUnicode(false);

            modelBuilder.Entity<Lop>()
                .Property(e => e.MaGV)
                .IsUnicode(false);

            modelBuilder.Entity<Lop>()
                .HasMany(e => e.PhanCongGiangDays)
                .WithRequired(e => e.Lop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonHoc>()
                .Property(e => e.MaMH)
                .IsUnicode(false);

            modelBuilder.Entity<MonHoc>()
                .HasMany(e => e.BangDiems)
                .WithRequired(e => e.MonHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonHoc>()
                .HasMany(e => e.PhanCongGiangDays)
                .WithRequired(e => e.MonHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonHoc>()
                .HasMany(e => e.ThoiKhoaBieux)
                .WithRequired(e => e.MonHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NienKhoa>()
                .Property(e => e.MaNienKhoa)
                .IsUnicode(false);

            modelBuilder.Entity<PhanCongGiangDay>()
                .Property(e => e.MaPC)
                .IsUnicode(false);

            modelBuilder.Entity<PhanCongGiangDay>()
                .Property(e => e.MaGV)
                .IsUnicode(false);

            modelBuilder.Entity<PhanCongGiangDay>()
                .Property(e => e.MaLop)
                .IsUnicode(false);

            modelBuilder.Entity<PhanCongGiangDay>()
                .Property(e => e.MaMH)
                .IsUnicode(false);

            modelBuilder.Entity<PhanCongGiangDay>()
                .Property(e => e.MaHK)
                .IsUnicode(false);

            modelBuilder.Entity<PhuHuynh>()
                .Property(e => e.MaPH)
                .IsUnicode(false);

            modelBuilder.Entity<PhuHuynh>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<PhuHuynh>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleId)
                .IsUnicode(false);

            modelBuilder.Entity<ThoiKhoaBieu>()
                .Property(e => e.MaLop)
                .IsUnicode(false);

            modelBuilder.Entity<ThoiKhoaBieu>()
                .Property(e => e.MaMH)
                .IsUnicode(false);
        }
    }
}
