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
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyHocSinhTruongPhoThong.Views
{
    public partial class BangDieuKhien_UC : UserControl
    {
        public AppDbContext _context=new AppDbContext();    
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
                var allNienKhoas = context.NienKhoas.ToList();

                if (!allNienKhoas.Any())
                {
                    return 0.0; 
                }

                List<double> yearlyPassRates = new List<double>();

                foreach (var nk in allNienKhoas)
                {
                    string maNienKhoa = nk.MaNienKhoa;

                    var allGradesInYear = from bd in context.BangDiems
                                          join hk in context.HocKies on bd.MaHK equals hk.MaHK
                                          where hk.MaNienKhoa == maNienKhoa
                                          select new { bd.MaHS, bd.DiemTongKet };

                    var studentYearlyAverages = allGradesInYear
                        .GroupBy(g => g.MaHS)
                        .Select(group => new {
                            MaHS = group.Key,
                            DiemTBCaNam = group.Average(x => x.DiemTongKet)
                        })
                        .ToList();

                    int totalStudents = studentYearlyAverages.Count();

                    if (totalStudents > 0)
                    {
                        int passedStudentsCount = studentYearlyAverages
                            .Count(s => s.DiemTBCaNam >= 3.5m);

                        double passRateOfYear = (double)passedStudentsCount / totalStudents;

                        yearlyPassRates.Add(passRateOfYear);
                    }
                }

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
        private void CapNhatBieuDo()
        {
            string selectedLop = cboLop.SelectedValue?.ToString();
            string selectedHk = cboHocKy.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(selectedLop) || string.IsNullOrEmpty(selectedHk))
            {
                return;
            }

            List<DiemTrungBinhMonHocDTO> data =GetListForDatabase.GetDiemTrungBinhCacMon(selectedLop, selectedHk);
            if (data.Count == 0)
            {
                chartDiemMonHoc.Series.Clear();
                chartDiemMonHoc.Titles.Clear();
                chartDiemMonHoc.Titles.Add("Không có dữ liệu điểm cho lựa chọn này.");
                return;
            }

            LoadChart(data);
        }
        private void LoadChart(List<DiemTrungBinhMonHocDTO> data)
        {
            chartDiemMonHoc.Titles.Clear();
            chartDiemMonHoc.Titles.Add("Biểu đồ Điểm Trung Bình Môn Học");

            chartDiemMonHoc.Series.Clear();

            Series series = new Series("DiemTrungBinh");
            series.ChartType = SeriesChartType.Column; 

            series.XValueMember = "TenMonHoc";
            series.YValueMembers = "DiemTrungBinh";

            series.IsValueShownAsLabel = true;
            series.LabelFormat = "{0.N2}"; 

            var chartArea = chartDiemMonHoc.ChartAreas[0];
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 10;
            chartArea.AxisY.Title = "Điểm Trung Bình";
            chartArea.AxisX.Title = "Môn Học";
            chartArea.AxisX.MajorGrid.Enabled = false; 
            chartArea.AxisY.MajorGrid.Enabled = false;

            chartDiemMonHoc.DataSource = data;

            chartDiemMonHoc.Series.Add(series);

            chartDiemMonHoc.DataBind();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
        public int getSoluongHocSinh()
        {
            return context.HocSinhs.Count();
        }
        public int getSoluongGV()
        {
            return context.GiaoViens.Count();
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHocKyTheoLop();
            CapNhatBieuDo();
        }

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatBieuDo();
        }
        private void LoadHocKyTheoLop()
        {
            string selectedLop = cboLop.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(selectedLop))
            {
                cboHocKy.DataSource = null;
                return;
            }

            var lop = _context.Lops.FirstOrDefault(l => l.MaLop == selectedLop);

            if (lop == null)
            {
                cboHocKy.DataSource = null;
                return;
            }

            string maNienKhoa = lop.MaNienKhoa;

            var hocKyList = _context.HocKies
                                    .Where(hk => hk.MaNienKhoa == maNienKhoa)
                                    .ToList();

            this.cboHocKy.SelectedIndexChanged -= new System.EventHandler(this.cboHocKy_SelectedIndexChanged);

            cboHocKy.DataSource = hocKyList;
            cboHocKy.DisplayMember = "TenHK"; 
            cboHocKy.ValueMember = "MaHK";

            this.cboHocKy.SelectedIndexChanged += new System.EventHandler(this.cboHocKy_SelectedIndexChanged);
        }
        private void BangDieuKhien_UC_Load(object sender, EventArgs e)
        {
            lblSoLuongHS.Text = getSoluongHocSinh() + "";
            lblSoLuongGV.Text = getSoluongGV() + "";
            lblDiemTB.Text = GetDiemTrungBinhToanTruong() + "";
            lblTiLeDauPhamTram.Text = GetTiLeLenLopTrungBinh_ToanBoLichSu() * 100 + " %";

            this.cboLop.SelectedIndexChanged -= new System.EventHandler(this.cboLop_SelectedIndexChanged);
            this.cboHocKy.SelectedIndexChanged -= new System.EventHandler(this.cboHocKy_SelectedIndexChanged);

            cboLop.DataSource = _context.Lops.ToList();
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";

            this.cboLop.SelectedIndexChanged += new System.EventHandler(this.cboLop_SelectedIndexChanged);
            this.cboHocKy.SelectedIndexChanged += new System.EventHandler(this.cboHocKy_SelectedIndexChanged);

            LoadHocKyTheoLop();

            CapNhatBieuDo();
        }
    }
}
