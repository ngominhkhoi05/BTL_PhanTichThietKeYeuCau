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

namespace QuanLyHocSinhTruongPhoThong.Views.GiaoViens.GiaoVienChuNhiems
{
    public partial class DanhGiaHanhKiem_UC : UserControl
    {
        public DanhGiaHanhKiem_UC()
        {
            InitializeComponent();
        }
        


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void SetupListViewHanhKiem()
        {
            lvHocSinh.View = View.Details;
            lvHocSinh.FullRowSelect = true;
            lvHocSinh.GridLines = true;
            lvHocSinh.MultiSelect = false;

            lvHocSinh.Columns.Clear();
            lvHocSinh.Columns.Add("Mã HS", 80);
            lvHocSinh.Columns.Add("Họ tên học sinh", 180);
            lvHocSinh.Columns.Add("Lớp", 100);
            lvHocSinh.Columns.Add("Giáo viên chủ nhiệm", 150);
            lvHocSinh.Columns.Add("Mã học kỳ", 100);
            lvHocSinh.Columns.Add("Tên học kỳ", 150);
            lvHocSinh.Columns.Add("Hạnh kiểm", 100);
        }
        private void LoadHanhKiemCuaGVCN()
        {
            try
            {
                lvHocSinh.Items.Clear();
                string username = CurrentUser.Username;

                var list = GetListForDatabase.getDanhSachHanhKiemTheoGVCN(username);

                foreach (var hs in list)
                {
                    var item = new ListViewItem(hs.MaHS);
                    item.SubItems.Add(hs.HoTenHocSinh);
                    item.SubItems.Add(hs.TenLop);
                    item.SubItems.Add(hs.GiaoVienChuNhiem);
                    item.SubItems.Add(hs.MaHK ?? "");
                    item.SubItems.Add(hs.TenHK ?? "");
                    item.SubItems.Add(hs.HanhKiem ?? "Chưa có");

                    lvHocSinh.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hạnh kiểm:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadHocKyCuaHocSinh(string maHS)
        {
            try
            {
                cbbMaHK.Items.Clear();

                var maNienKhoa = (from hs in GetListForDatabase.context.HocSinhs
                                  join lop in GetListForDatabase.context.Lops on hs.MaLop equals lop.MaLop
                                  where hs.MaHS == maHS
                                  select lop.MaNienKhoa)
                                  .FirstOrDefault();

                if (string.IsNullOrEmpty(maNienKhoa))
                {
                    MessageBox.Show("Không tìm thấy niên khóa của học sinh được chọn!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var listHK = GetListForDatabase.context.HocKies
                    .Where(hk => hk.MaNienKhoa == maNienKhoa)
                    .OrderBy(hk => hk.MaHK)
                    .ToList();

                foreach (var hk in listHK)
                {
                    cbbMaHK.Items.Add($"{hk.MaHK} - {hk.TenHK}");
                }

                if (cbbMaHK.Items.Count > 0)
                {
                    var hkHienTai = listHK.FirstOrDefault(h => h.TenHK.Contains("I")) ?? listHK.First();
                    int index = listHK.IndexOf(hkHienTai);
                    cbbMaHK.SelectedIndex = index >= 0 ? index : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách học kỳ của học sinh:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DanhGiaHanhKiem_UC_Load(object sender, EventArgs e)
        {
            SetupListViewHanhKiem();
            LoadHanhKiemCuaGVCN();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvHocSinh.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một học sinh trong danh sách!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbbMaHK.SelectedIndex < 0 || cbbLoai.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn học kỳ và xếp loại hạnh kiểm!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maHS = txtMaHS.Text.Trim();
                string maHK = cbbMaHK.SelectedItem.ToString().Split('-')[0].Trim();
                string loai = cbbLoai.SelectedItem.ToString();

                if (string.IsNullOrWhiteSpace(maHS))
                {
                    MessageBox.Show("Không tìm thấy mã học sinh hợp lệ!",
                                    "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var existing = GetListForDatabase.context.HanhKiems
                    .FirstOrDefault(x => x.MaHS == maHS && x.MaHK == maHK);

                if (existing != null)
                {
                    existing.Loai = loai;

                    GetListForDatabase.context.SaveChanges();

                    MessageBox.Show($"Đã cập nhật hạnh kiểm ({loai}) cho học sinh {txtTen.Text}!",
                                    "Cập nhật thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var newHK = new HanhKiem
                    {
                        MaHS = maHS,
                        MaHK = maHK,
                        Loai = loai
                    };

                    GetListForDatabase.context.HanhKiems.Add(newHK);
                    GetListForDatabase.context.SaveChanges();

                    MessageBox.Show($"Đã thêm mới hạnh kiểm ({loai}) cho học sinh {txtTen.Text}!",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadHanhKiemCuaGVCN();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật hạnh kiểm:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
        private void LoadLoaiHanhKiem()
        {
            try
            {
                cbbLoai.Items.Clear();

                string[] loaiHK = { "Tốt", "Khá", "Trung bình", "Yếu", "Chưa có" };
                cbbLoai.Items.AddRange(loaiHK);

                if (cbbLoai.Items.Count > 0)
                    cbbLoai.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại hạnh kiểm:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvHanhKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHocSinh.SelectedItems.Count == 0)
                return;

            try
            {
                var item = lvHocSinh.SelectedItems[0];

                string maHS = item.SubItems[0].Text;
                string tenHS = item.SubItems[1].Text;

                txtMaHS.Text = maHS;
                txtTen.Text = tenHS;

                LoadHocKyCuaHocSinh(maHS);

                if (cbbLoai.Items.Count == 0)
                    LoadLoaiHanhKiem(); 

                cbbLoai.SelectedIndex = 0; 

                if (cbbMaHK.SelectedIndex >= 0)
                {
                    string maHK = cbbMaHK.SelectedItem.ToString().Split('-')[0].Trim();

                    var hanhKiem = GetListForDatabase.context.HanhKiems
                        .FirstOrDefault(x => x.MaHS == maHS && x.MaHK == maHK);

                    if (hanhKiem != null)
                    {
                        cbbLoai.SelectedItem = hanhKiem.Loai;
                    }
                    else
                    {
                        cbbLoai.SelectedItem = "Chưa có";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị thông tin học sinh:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
