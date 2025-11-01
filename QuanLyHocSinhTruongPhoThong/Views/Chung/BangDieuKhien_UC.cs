using QuanLyHocSinhTruongPhoThong.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinhTruongPhoThong.Views
{
    public partial class BangDieuKhien_UC : UserControl
    {
        public AppDbContext context=new AppDbContext();
        public BangDieuKhien_UC()
        {
            InitializeComponent();
        }
        public static double? GetDiemTrungBinhToanTruong()
        {
            using (var context = new AppDbContext())
            {
                decimal? averageDecimal = context.BangDiems
                    .Average(bd => (decimal?)bd.DiemTongKet);

                return (double?)averageDecimal;
            }
        }
        public static double GetTiLeLenLopTrungBinh_ToanBoLichSu()
        {
            using (var context = new AppDbContext())
            {
                // 1. Lấy danh sách tất cả các niên khóa
                var allNienKhoas = context.NienKhoas.ToList();

                if (!allNienKhoas.Any())
                {
                    return 0.0; // Không có niên khóa nào
                }

                // 2. Tạo một list để lưu trữ tỉ lệ lên lớp của MỖI NĂM
                List<double> yearlyPassRates = new List<double>();

                // 3. Lặp qua từng niên khóa để tính tỉ lệ của năm đó
                foreach (var nk in allNienKhoas)
                {
                    string maNienKhoa = nk.MaNienKhoa;

                    // --- (Phần code này giống hệt hàm trước, dùng để tính cho 1 năm) ---

                    // Lấy TẤT CẢ các điểm (DiemTongKet) trong niên khóa
                    var allGradesInYear = from bd in context.BangDiems
                                          join hk in context.HocKies on bd.MaHK equals hk.MaHK
                                          where hk.MaNienKhoa == maNienKhoa
                                          select new { bd.MaHS, bd.DiemTongKet };

                    // Tính điểm TBC CẢ NĂM cho TỪNG HỌC SINH
                    var studentYearlyAverages = allGradesInYear
                        .GroupBy(g => g.MaHS)
                        .Select(group => new {
                            MaHS = group.Key,
                            DiemTBCaNam = group.Average(x => x.DiemTongKet)
                        })
                        .ToList();

                    // Đếm tổng số học sinh
                    int totalStudents = studentYearlyAverages.Count();

                    // --- Kết thúc phần code giống ---

                    // Nếu năm đó có học sinh (tránh chia cho 0)
                    if (totalStudents > 0)
                    {
                        // Đếm số học sinh "Lên lớp" (>= 3.5)
                        int passedStudentsCount = studentYearlyAverages
                            .Count(s => s.DiemTBCaNam >= 3.5m);

                        // Tính tỉ lệ của năm đó
                        double passRateOfYear = (double)passedStudentsCount / totalStudents;

                        // Thêm tỉ lệ của năm này vào danh sách
                        yearlyPassRates.Add(passRateOfYear);
                    }
                    // Nếu năm đó không có học sinh (totalStudents == 0),
                    // chúng ta bỏ qua, không thêm vào list
                }

                // 4. Tính TBC của các tỉ lệ
                if (yearlyPassRates.Any())
                {
                    return yearlyPassRates.Average();
                }
                else
                {
                    return 0.0;
                }
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            lblSoLuongHS.Text = getSoluongHocSinh()+"";
            lblSoLuongGV.Text=getSoluongGV()+"";
            lblDiemTB.Text = GetDiemTrungBinhToanTruong() + "";
            lblTiLeDauPhamTram.Text = GetTiLeLenLopTrungBinh_ToanBoLichSu()*100 + " %";
        }
        public int getSoluongHocSinh()
        {
            return context.HocSinhs.Count();
            //return 0;
        }
        public int getSoluongGV()
        {
            return context.GiaoViens.Count();
            //return 0;
        }
    }
}
