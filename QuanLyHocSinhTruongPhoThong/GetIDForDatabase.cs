using QuanLyHocSinhTruongPhoThong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinhTruongPhoThong
{
    public class GetIDForDatabase
    {
        //public static List<string> getListMaLop()
        //{
        //    try
        //    {
        //        using (var context = new AppDbContext())
        //        {
        //            return context.Lops
        //                .Select(l => l.MaLop)
        //                .ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi khi lấy danh sách mã lớp: " + ex.Message);
        //        return new List<string>();
        //    }
        //}
        public static string getIDNextGiaoVien()
        {
            using (var context = new AppDbContext())
            {
                var lastGiaoVien = context.GiaoViens
                    .OrderByDescending(gv => gv.MaGV)
                    .FirstOrDefault();
                string nextID = "GV0001";

                if (lastGiaoVien != null)
                {
                    string numberPart = lastGiaoVien.MaGV.Substring(2);
                    if (int.TryParse(numberPart, out int number))
                    {
                        int nextNumber = number + 1;
                        nextID = "GV" + nextNumber.ToString("D4");
                    }
                }

                return nextID;
            }
        }
        public static string getIDNextMonHoc()
        {
            using (var context = new AppDbContext())
            {
                var lastMon = context.MonHocs
                    .OrderByDescending(mh => mh.MaMH)
                    .FirstOrDefault();

                string nextID = "MH001";

                if (lastMon != null)
                {
                    string numberPart = lastMon.MaMH.Substring(2); // bỏ "MH"
                    if (int.TryParse(numberPart, out int number))
                    {
                        nextID = "MH" + (number + 1).ToString("D3"); // 3 chữ số
                    }
                }
                return nextID;
            }
        }
        public static string getIDNextPhuHuynh()
        {
            using (var context = new AppDbContext())
            {
                var lastPh = context.PhuHuynhs
                    .OrderByDescending(ph => ph.MaPH)
                    .FirstOrDefault();

                string nextID = "PH0001";

                if (lastPh != null)
                {
                    string numberPart = lastPh.MaPH.Substring(2);
                    if (int.TryParse(numberPart, out int number))
                    {
                        nextID = "PH" + (number + 1).ToString("D4");
                    }
                }

                return nextID;
            }
        }
        public static string getIDNextHocSinh()
        {
            using (var context = new AppDbContext())
            {
                var lastHS = context.HocSinhs
                    .OrderByDescending(hs => hs.MaHS)
                    .FirstOrDefault();

                string nextID = "HS0001"; // mặc định nếu bảng trống

                if (lastHS != null)
                {
                    string numberPart = lastHS.MaHS.Substring(2); // bỏ "HS"
                    if (int.TryParse(numberPart, out int number))
                    {
                        nextID = "HS" + (number + 1).ToString("D4");
                    }
                }

                return nextID;
            }
        }
        public static string getIDNextPhanCongGiangDay()
        {
            using (var context = new AppDbContext())
            {
                var lastPC = context.PhanCongGiangDays
                    .OrderByDescending(pc => pc.MaPC)
                    .FirstOrDefault();

                string nextID = "PC001";

                if (lastPC != null)
                {
                    string numberPart = lastPC.MaPC.Substring(2);
                    if (int.TryParse(numberPart, out int number))
                    {
                        nextID = "PC" + (number + 1).ToString("D3");
                    }
                }

                return nextID;
            }
        }
        public static string getIDNextKhenThuongKyLuat()
        {
            using (var context = new AppDbContext())
            {
                var lastKTKL = context.KhenThuongKyLuats
                    .OrderByDescending(kt => kt.MaKTKL)
                    .FirstOrDefault();

                string nextID = "KT001";

                if (lastKTKL != null)
                {
                    string numberPart = lastKTKL.MaKTKL.Substring(2);
                    if (int.TryParse(numberPart, out int number))
                    {
                        nextID = "KT" + (number + 1).ToString("D3");
                    }
                }

                return nextID;
            }
        }

    }
    public class PhanCongGiangDayView
    {
        public string MaPC { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public string MaGV { get; set; }
        public string TenGV { get; set; }
        public string MaHK { get; set; }
        public string TenHK { get; set; }
    }

    public class GetListForDatabase
    {
        public static AppDbContext context = new AppDbContext();
        public class HocSinhKTKLView
        {
            public string MaHS { get; set; }
            public string HoTenHocSinh { get; set; }
            public DateTime NgaySinh { get; set; }
            public bool GioiTinh { get; set; }
            public string TenLop { get; set; }
            public string GiaoVienChuNhiem { get; set; }
            public string TrangThai { get; set; }  // Khen thưởng / Kỷ luật / Không có
            public string NoiDung { get; set; }
            public DateTime? Ngay { get; set; }
        }

        public static List<HocSinhKTKLView> getDanhSachHocSinhTheoGVCN(string username)
        {
            try
            {
                string maGV = getMaGVByUsername(username);
                if (string.IsNullOrEmpty(maGV))
                    return new List<HocSinhKTKLView>();

                var result = (from gv in context.GiaoViens
                              join lop in context.Lops on gv.MaGV equals lop.MaGV
                              join hs in context.HocSinhs on lop.MaLop equals hs.MaLop
                              join kt in context.KhenThuongKyLuats on hs.MaHS equals kt.MaHS into hsKT
                              from kt in hsKT.DefaultIfEmpty()
                              where gv.MaGV == maGV
                              select new HocSinhKTKLView
                              {
                                  MaHS = hs.MaHS,
                                  HoTenHocSinh = hs.HoTen,
                                  NgaySinh = hs.NgaySinh,
                                  GioiTinh = hs.GioiTinh,
                                  TenLop = lop.TenLop,
                                  GiaoVienChuNhiem = gv.HoTen,
                                  TrangThai = kt.Loai ?? "Không có",
                                  NoiDung = kt.NoiDung,
                                  Ngay = kt.Ngay
                              })
                              .OrderBy(x => x.TenLop)
                              .ThenBy(x => x.HoTenHocSinh)
                              .ToList();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách học sinh theo GVCN: " + ex.Message);
                return new List<HocSinhKTKLView>();
            }
        }

        public static List<HocSinh> getHocSinhCuaGVCN(string username)
        {
            try
            {
                string maGV = getMaGVByUsername(username);
                if (string.IsNullOrEmpty(maGV))
                    return new List<HocSinh>();

                var lopCuaGV = context.Lops
                    .Where(l => l.MaGV == maGV)
                    .Select(l => new { l.MaLop, l.TenLop, l.MaNienKhoa })
                    .ToList();

                if (lopCuaGV.Count == 0)
                    return new List<HocSinh>();

                var list = (from hs in context.HocSinhs
                            join lop in context.Lops on hs.MaLop equals lop.MaLop
                            join nk in context.NienKhoas on lop.MaNienKhoa equals nk.MaNienKhoa
                            where lop.MaGV == maGV
                            select new
                            {
                                hs.MaHS,
                                hs.HoTen,
                                hs.GioiTinh,
                                hs.NgaySinh,
                                hs.Sdt,
                                hs.Email,
                                hs.DiaChi,
                                lop.TenLop,
                                NamBatDau = nk.NamBatDau,
                                NamKetThuc = nk.NamKetThuc
                            })
                            .OrderBy(x => x.TenLop)
                            .ThenBy(x => x.HoTen)
                            .ToList();

                return list.Select(x => new HocSinh
                {
                    MaHS = x.MaHS,
                    HoTen = $"{x.HoTen} ({x.TenLop})",
                    GioiTinh = x.GioiTinh,
                    NgaySinh = x.NgaySinh,
                    Sdt = x.Sdt,
                    Email = x.Email,
                    DiaChi = x.DiaChi
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách học sinh của GVCN: " + ex.Message);
                return new List<HocSinh>();
            }
        }

        public static List<HocSinh> getHocSinhByUsername(string username)
        {
            try
            {
                string maGV = getMaGVByUsername(username);
                if (string.IsNullOrEmpty(maGV))
                    return new List<HocSinh>();

                var lopDuocDay = (from pc in context.PhanCongGiangDays
                                  where pc.MaGV == maGV
                                  select pc.MaLop)
                                 .Union(from l in context.Lops
                                        where l.MaGV == maGV
                                        select l.MaLop)
                                 .Distinct()
                                 .ToList();

                var list = context.HocSinhs
                    .Where(hs => lopDuocDay.Contains(hs.MaLop))
                    .OrderBy(hs => hs.MaLop)
                    .ThenBy(hs => hs.HoTen)
                    .ToList();

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách học sinh theo username: " + ex.Message);
                return new List<HocSinh>();
            }
        }

        public static string getMaGVByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return null;

            var maGV = context.Accounts
                              .Where(a => a.Username == username && a.MaGV != null)
                              .Select(a => a.MaGV)
                              .FirstOrDefault();
            if (!string.IsNullOrEmpty(maGV)) return maGV;

            maGV = context.GiaoViens
                          .Where(g => g.Email == username)
                          .Select(g => g.MaGV)
                          .FirstOrDefault();
            if (!string.IsNullOrEmpty(maGV)) return maGV;

            var isGV = context.GiaoViens.Any(g => g.MaGV == username);
            return isGV ? username : null;
        }

        public static List<MonHoc> getListMonHocByUsername(string username)
        {
            try
            {
                var maGV = getMaGVByUsername(username);
                if (string.IsNullOrEmpty(maGV)) return new List<MonHoc>();

                return (from pc in context.PhanCongGiangDays
                        join mh in context.MonHocs on pc.MaMH equals mh.MaMH
                        where pc.MaGV == maGV
                        select mh)
                       .Distinct()
                       .OrderBy(m => m.MaMH)
                       .ToList();
            }
            catch { return new List<MonHoc>(); }
        }

        public static List<Lop> getListLopHocByUsername(string username)
        {
            try
            {
                var maGV = getMaGVByUsername(username);
                if (string.IsNullOrEmpty(maGV)) return new List<Lop>();

                return (from pc in context.PhanCongGiangDays
                        join lop in context.Lops on pc.MaLop equals lop.MaLop
                        where pc.MaGV == maGV
                        select lop)
                       .Distinct()
                       .OrderBy(l => l.MaLop)
                       .ToList();
            }
            catch { return new List<Lop>(); }
        }

        public static List<PhanCongGiangDayView> getListPhanCong()
        {
            try
            {
                var list = (from pc in context.PhanCongGiangDays
                            join lop in context.Lops on pc.MaLop equals lop.MaLop
                            join mh in context.MonHocs on pc.MaMH equals mh.MaMH
                            join gv in context.GiaoViens on pc.MaGV equals gv.MaGV
                            join hk in context.HocKies on pc.MaHK equals hk.MaHK
                            orderby pc.MaPC
                            select new PhanCongGiangDayView
                            {
                                MaPC = pc.MaPC,
                                MaLop = pc.MaLop,
                                TenLop = lop.TenLop,
                                MaMH = pc.MaMH,
                                TenMH = mh.TenMH,
                                MaGV = pc.MaGV,
                                TenGV = gv.HoTen,
                                MaHK = pc.MaHK,
                                TenHK = hk.TenHK
                            }).ToList();

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách phân công giảng dạy: " + ex.Message);
                return new List<PhanCongGiangDayView>();
            }
        }

        public static List<Lop> getListLopHoc()
        {
            try
            {
                return context.Lops
                    .OrderBy(l => l.MaLop)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách lớp học: " + ex.Message);
                return new List<Lop>();
            }
        }

        public static List<NienKhoa> getListNienKhoa()
        {
            try
            {
                return context.NienKhoas
                    .OrderBy(nk => nk.NamBatDau)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách niên khóa: " + ex.Message);
                return new List<NienKhoa>();
            }
        }
        public static List<GiaoVien> getListGiaoVien()
        {
            try
            {
                return context.GiaoViens
                    .OrderBy(gv => gv.HoTen)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách giáo viên: " + ex.Message);
                return new List<GiaoVien>();
            }
        }

        public static List<HocKy> getListHocKy()
        {
            try
            {
                return context.HocKies
                    .OrderBy(hk => hk.MaHK)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách học kỳ: " + ex.Message);
                return new List<HocKy>();
            }
        }
        public static List<PhuHuynh> getListPhuHuynh()
        {
            try
            {
                return context.PhuHuynhs
                    .OrderBy(ph => ph.HoTen)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách phụ huynh: " + ex.Message);
                return new List<PhuHuynh>();
            }
        }

        public static List<HocSinh> getListHocSinh()
        {
            try
            {
                return context.HocSinhs
                    .OrderBy(hs => hs.HoTen)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách học sinh: " + ex.Message);
                return new List<HocSinh>();
            }
        }

        public static List<Lop> getListLop()
        {
            try
            {
                return context.Lops
                    .OrderBy(l => l.MaLop)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách lớp: " + ex.Message);
                return new List<Lop>();
            }
        }

        public static List<MonHoc> getListMonHoc()
        {
            try
            {
                return context.MonHocs
                    .OrderBy(mh => mh.MaMH)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách môn học: " + ex.Message);
                return new List<MonHoc>();
            }
        }
    }

    public static class CurrentUser
    {
        public static string AccountId { get; set; }
        public static string Username { get; set; }
        public static string DisplayName { get; set; }
        public static string Email { get; set; }
        public static string MaGV { get; set; }
        public static List<string> Roles { get; set; } = new List<string>();

        public static void Logout()
        {
            AccountId = null;
            Username = null;
            DisplayName = null;
            Email = null;
            MaGV = null;
            Roles.Clear();
        }

        public static bool HasRole(string roleName)
        {
            return Roles != null && Roles.Contains(roleName);
        }
        

    }
    public class CheckLogin
    {
        public AppDbContext context = new AppDbContext();

        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
        public LoginResult ValidateLogin(string username, string password)
        {
            var result = new LoginResult { Success = false };

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                result.Message = "Vui lòng nhập tên đăng nhập và mật khẩu.";
                return result;
            }

            try
            {
                var acc = context.Accounts
                                 .Include("Roles")
                                 .FirstOrDefault(a => a.Username == username.Trim());

                if (acc == null)
                {
                    result.Message = "Tài khoản không tồn tại.";
                    return result;
                }

                if ((bool)!acc.IsActive)
                {
                    result.Message = "Tài khoản đã bị khóa.";
                    return result;
                }

                //string hashInput = HashPassword(password);
                string hashInput = password;

                if (!string.Equals(acc.PasswordHash, hashInput, StringComparison.OrdinalIgnoreCase))
                {
                    result.Message = "Mật khẩu không chính xác.";
                    return result;
                }

                var roles = acc.Roles.Select(r => r.RoleName).ToList();

                result.Success = true;
                result.AccountId = acc.AccountId;
                result.Username = acc.Username;
                result.DisplayName = acc.DisplayName;
                result.Email = acc.Email;
                result.MaGV = acc.MaGV;
                result.Roles = roles;
                result.Message = "Đăng nhập thành công.";

                return result;
            }
            catch (Exception ex)
            {
                result.Message = "Lỗi khi kiểm tra đăng nhập: " + ex.Message;
                return result;
            }
        }

    }
    public class LoginResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string AccountId { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string MaGV { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
    }

}
