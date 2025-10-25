using QuanLyHocSinhTruongPhoThong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class GetListForDatabase
    {
        public static AppDbContext context = new AppDbContext();
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
}
