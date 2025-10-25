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
}
