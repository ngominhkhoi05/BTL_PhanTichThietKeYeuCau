using QuanLyHocSinhTruongPhoThong.Models;
using QuanLyHocSinhTruongPhoThong.Views.Dialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinhTruongPhoThong.Views.Admins
{
    public partial class ThoiKhoaBieu_UC : UserControl
    {
        public ThoiKhoaBieu_UC()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnTaoTKB_Click(object sender, EventArgs e)
        {
            using (var dialog = new ThoiKhoaBieuLop())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var danhSachLop = dialog.LopDuocChon;
                    if (danhSachLop.Count > 0)
                    {
                        bool thanhCong = TaoThoiKhoaBieu_Auto(danhSachLop);

                        if (thanhCong)
                            MessageBox.Show("Tạo thời khóa biểu thành công!", "Thành công",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Không thể tạo thời khóa biểu cho một số lớp!",
                                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        private bool TaoThoiKhoaBieu_Auto(List<string> dsLop)
        {
            try
            {
                var context = GetListForDatabase.context;

                // Danh sách phân công giảng dạy (MaLop - MaMH)
                var dsPhanCong = context.PhanCongGiangDays
                    .Where(pc => dsLop.Contains(pc.MaLop))
                    .ToList();

                var thuTrongTuan = new[] { 2, 3, 4, 5, 6, 7 };
                const int tietToiDa = 10; 

                var tkbHienTai = context.ThoiKhoaBieux.ToList();

                bool success = true;

                foreach (var pc in dsPhanCong)
                {
                    var monHoc = context.MonHocs.FirstOrDefault(m => m.MaMH == pc.MaMH);
                    int soTietTuan = monHoc?.TietTuan ?? 1; // số tiết cần dạy mỗi tuần

                    int tietDaXep = 0;

                    while (tietDaXep < soTietTuan)
                    {
                        bool daGan = false;

                        foreach (var thu in thuTrongTuan)
                        {
                            for (int tiet = 1; tiet <= tietToiDa; tiet++)
                            {
                                bool lopBiTrung = tkbHienTai.Any(t =>
                                    t.MaLop == pc.MaLop &&
                                    t.Thu == thu &&
                                    tiet >= t.TuTiet &&
                                    tiet < t.TuTiet + t.SoTiet);

                                if (lopBiTrung)
                                    continue;

                                var tkb = new ThoiKhoaBieu
                                {
                                    MaLop = pc.MaLop,
                                    MaMH = pc.MaMH,
                                    Thu = thu,
                                    TuTiet = tiet,
                                    SoTiet = 1
                                };

                                tkbHienTai.Add(tkb);
                                context.ThoiKhoaBieux.Add(tkb);

                                tietDaXep++;
                                daGan = true;
                                break; 
                            }

                            if (daGan)
                                break;
                        }

                        if (!daGan)
                        {
                            success = false;
                            Console.WriteLine($"❌ Không thể xếp đủ {soTietTuan} tiết cho {pc.MaLop} - {pc.MaMH}");
                            break;
                        }
                    }
                }

                context.SaveChanges();
                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo thời khóa biểu:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void LoadComboBoxData()
        {
            try
            {
                var context = GetListForDatabase.context;

                var listLop = context.Lops
                    .OrderBy(l => l.TenLop)
                    .Select(l => new { l.MaLop, l.TenLop })
                    .ToList();

                cbbLop.Items.Clear();
                foreach (var lop in listLop)
                    cbbLop.Items.Add($"{lop.MaLop} - {lop.TenLop}");

                if (cbbLop.Items.Count > 0)
                    cbbLop.SelectedIndex = 0;

                var listGV = context.GiaoViens
                    .OrderBy(g => g.HoTen)
                    .Select(g => new { g.MaGV, g.HoTen })
                    .ToList();

                cbbGiaoVien.Items.Clear();
                foreach (var gv in listGV)
                    cbbGiaoVien.Items.Add($"{gv.MaGV} - {gv.HoTen}");

                if (cbbGiaoVien.Items.Count > 0)
                    cbbGiaoVien.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách lớp/giáo viên:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetupListViewTKB()
        {
            lvTKB.View = View.Details;
            lvTKB.FullRowSelect = true;
            lvTKB.GridLines = true;
            lvTKB.MultiSelect = false;

            lvTKB.Columns.Clear();
            lvTKB.Columns.Add("Thứ", 80);
            lvTKB.Columns.Add("Tiết", 80);
            lvTKB.Columns.Add("Môn học", 250);
            lvTKB.Columns.Add("Lớp", 250);
        }
        private void LoadTKB_Lop(string maLop)
        {
            try
            {
                lvTKB.Items.Clear();

                var data = (from tkb in GetListForDatabase.context.ThoiKhoaBieux
                            join mh in GetListForDatabase.context.MonHocs on tkb.MaMH equals mh.MaMH
                            join pc in GetListForDatabase.context.PhanCongGiangDays
                                on new { tkb.MaLop, tkb.MaMH } equals new { pc.MaLop, pc.MaMH }
                            join gv in GetListForDatabase.context.GiaoViens on pc.MaGV equals gv.MaGV
                            where tkb.MaLop == maLop
                            orderby tkb.Thu, tkb.TuTiet
                            select new
                            {
                                tkb.Thu,
                                tkb.TuTiet,
                                tkb.SoTiet,
                                mh.TenMH,
                                gv.HoTen
                            }).ToList();

                foreach (var row in data)
                {
                    var item = new ListViewItem("Thứ " + row.Thu);
                    item.SubItems.Add(row.TuTiet.ToString());
                    item.SubItems.Add(row.TenMH);
                    item.SubItems.Add(maLop);
                    item.SubItems.Add(row.HoTen);
                    lvTKB.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thời khóa biểu lớp:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadTKB_GiaoVien(string maGV)
        {
            try
            {
                lvTKB.Items.Clear();

                var data = (from tkb in GetListForDatabase.context.ThoiKhoaBieux
                            join mh in GetListForDatabase.context.MonHocs on tkb.MaMH equals mh.MaMH
                            join pc in GetListForDatabase.context.PhanCongGiangDays
                                on new { tkb.MaLop, tkb.MaMH } equals new { pc.MaLop, pc.MaMH }
                            join gv in GetListForDatabase.context.GiaoViens on pc.MaGV equals gv.MaGV
                            where gv.MaGV == maGV
                            orderby tkb.Thu, tkb.TuTiet
                            select new
                            {
                                tkb.Thu,
                                tkb.TuTiet,
                                tkb.SoTiet,
                                mh.TenMH,
                                tkb.MaLop
                            }).ToList();

                foreach (var row in data)
                {
                    var item = new ListViewItem("Thứ " + row.Thu);
                    item.SubItems.Add(row.TuTiet.ToString());
                    item.SubItems.Add(row.TenMH);
                    item.SubItems.Add(row.MaLop);
                    lvTKB.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thời khóa biểu giáo viên:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateLabelTitle(string type, string name)
        {
            if (type == "lop")
            {
                lblLop.Text = $"Thời khoá biểu của lớp {name}";
            }
            else if (type == "gv")
            {
                lblLop.Text = $"Thời khoá biểu của GV. {name}";
            }
        }

        private void ThoiKhoaBieu_UC_Load(object sender, EventArgs e)
        {
            SetupListViewTKB();
            LoadComboBoxData();

            cbbLop.SelectedIndexChanged += (s, ev) =>
            {
                if (cbbLop.SelectedIndex >= 0)
                {
                    string selected = cbbLop.SelectedItem.ToString();
                    string[] parts = selected.Split('-');
                    string maLop = parts[0].Trim();
                    string tenLop = parts.Length > 1 ? parts[1].Trim() : maLop;

                    LoadTKB_Lop(maLop);
                    UpdateLabelTitle("lop", tenLop);
                }
            };

            cbbGiaoVien.SelectedIndexChanged += (s, ev) =>
            {
                if (cbbGiaoVien.SelectedIndex >= 0)
                {
                    string selected = cbbGiaoVien.SelectedItem.ToString();
                    string[] parts = selected.Split('-');
                    string maGV = parts[0].Trim();
                    string tenGV = parts.Length > 1 ? parts[1].Trim() : maGV;

                    LoadTKB_GiaoVien(maGV);
                    UpdateLabelTitle("gv", tenGV);
                }
            };
        }

    }
}
