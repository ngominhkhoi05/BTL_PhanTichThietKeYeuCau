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

namespace QuanLyHocSinhTruongPhoThong.Views.GiaoViens.GiaoVienChuNhiems
{
    public partial class KhenThuongKyLuat_UC : UserControl
    {
        public KhenThuongKyLuat_UC()
        {
            InitializeComponent();
        }

        private void KhenThuongKyLuat_UC_Load(object sender, EventArgs e)
        {
            var user = CurrentUser.Username;
            LoadKhenThuongKyLuat(user);
            cbbMaHK.SelectedIndexChanged += cbbMaHK_SelectedIndexChanged;
        }
        private void SetupListViewHocSinh()
        {
            lvHocSinh.View = View.Details;
            lvHocSinh.FullRowSelect = true;
            lvHocSinh.GridLines = true;
            lvHocSinh.MultiSelect = false;

            lvHocSinh.Columns.Clear();
            lvHocSinh.Columns.Add("Mã HS", 80);
            lvHocSinh.Columns.Add("Họ tên học sinh", 180);
            lvHocSinh.Columns.Add("Ngày sinh", 100);
            lvHocSinh.Columns.Add("Giới tính", 80);
            lvHocSinh.Columns.Add("Lớp", 80);
            lvHocSinh.Columns.Add("Giáo viên chủ nhiệm", 150);
            lvHocSinh.Columns.Add("Trạng thái", 100);
            lvHocSinh.Columns.Add("Nội dung", 220);
            lvHocSinh.Columns.Add("Ngày", 100);
        }

        private void lvHocSinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHocSinh.SelectedItems.Count == 0)
                return;

            var item = lvHocSinh.SelectedItems[0];
            string maHS = item.SubItems[0].Text;
            string tenHS = item.SubItems[1].Text;

            txtMaHS.Text = maHS;
            txtTen.Text = tenHS;

            LoadHocKy_ByNienKhoa(maHS);

            if (cbbMaHK.Items.Count > 0)
            {
                string maHK = cbbMaHK.SelectedItem.ToString().Split('-')[0].Trim();
                LoadKhenThuongKyLuatTheoHocSinhVaHocKy(maHS, maHK);
            }
            else
            {
                txtMaKTKL.Text = GetIDForDatabase.getIDNextKhenThuongKyLuat();
                txtNoiDung.Clear();
                cbbLoai.SelectedIndex = 0;
            }
        }
        private void LoadHocSinhTheoGVCN()
        {
            try
            {
                lvHocSinh.Items.Clear();
                string username = CurrentUser.Username;

                var list = GetListForDatabase.getDanhSachHocSinhTheoGVCN(username);

                foreach (var hs in list)
                {
                    var item = new ListViewItem(hs.MaHS);
                    item.SubItems.Add(hs.HoTenHocSinh);
                    item.SubItems.Add(hs.NgaySinh.ToString("yyyy-MM-dd"));
                    item.SubItems.Add(hs.GioiTinh ? "Nam" : "Nữ");
                    item.SubItems.Add(hs.TenLop);
                    item.SubItems.Add(hs.GiaoVienChuNhiem);
                    item.SubItems.Add(hs.TrangThai);
                    item.SubItems.Add(hs.NoiDung ?? "");
                    item.SubItems.Add(hs.Ngay?.ToString("yyyy-MM-dd") ?? "");
                    lvHocSinh.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách học sinh của GVCN:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadHocKy_ByNienKhoa(string maHS)
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
                    return;

                var listHK = GetListForDatabase.context.HocKies
                    .Where(hk => hk.MaNienKhoa == maNienKhoa)
                    .OrderBy(hk => hk.MaHK)
                    .ToList();

                foreach (var hk in listHK)
                {
                    cbbMaHK.Items.Add($"{hk.MaHK} - {hk.TenHK}");
                }

                if (cbbMaHK.Items.Count > 0)
                    cbbMaHK.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách học kỳ: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbbMaHK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHocSinh.SelectedItems.Count == 0 || cbbMaHK.SelectedIndex < 0)
                return;

            var item = lvHocSinh.SelectedItems[0];
            string maHS = item.SubItems[0].Text;
            string maHK = cbbMaHK.SelectedItem.ToString().Split('-')[0].Trim();

            LoadKhenThuongKyLuatTheoHocSinhVaHocKy(maHS, maHK);
        }
        private void LoadKhenThuongKyLuatTheoHocSinhVaHocKy(string maHS, string maHK)
        {
            try
            {
                var record = GetListForDatabase.context.KhenThuongKyLuats
                    .FirstOrDefault(x => x.MaHS == maHS && x.MaHK == maHK);

                if (record != null)
                {
                    txtMaKTKL.Text = record.MaKTKL;
                    txtMaHS.Text = record.MaHS;
                    txtTen.Text = (from hs in GetListForDatabase.context.HocSinhs
                                   where hs.MaHS == record.MaHS
                                   select hs.HoTen).FirstOrDefault() ?? "";
                    cbbLoai.SelectedItem = record.Loai;
                    txtNoiDung.Text = record.NoiDung ?? "";
                }
                else
                {
                    txtMaKTKL.Text = GetIDForDatabase.getIDNextKhenThuongKyLuat();
                    txtNoiDung.Clear();
                    cbbLoai.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin Khen thưởng/Kỷ luật:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadLoai_ToComboBox()
        {
            try
            {
                cbbLoai.Items.Clear();

                string[] loaiList = { "Khen thưởng", "Kỷ luật", "Không có" };

                cbbLoai.Items.AddRange(loaiList);

                if (cbbLoai.Items.Count > 0)
                    cbbLoai.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại khen thưởng/kỷ luật:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadKhenThuongKyLuat(string username)
        {
            LoadLoai_ToComboBox();
            SetupListViewHocSinh();
            LoadHocSinhTheoGVCN();
        }

        private void lblListHS_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Vui lòng chọn học kỳ và loại khen thưởng/kỷ luật!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maHS = txtMaHS.Text.Trim();
                string maHK = cbbMaHK.SelectedItem.ToString().Split('-')[0].Trim();
                string loai = cbbLoai.SelectedItem.ToString();
                string noiDung = txtNoiDung.Text.Trim();
                DateTime ngay = DateTime.Now;

                if (string.IsNullOrWhiteSpace(maHS))
                {
                    MessageBox.Show("Không tìm thấy mã học sinh hợp lệ!",
                                    "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var existing = GetListForDatabase.context.KhenThuongKyLuats
                    .FirstOrDefault(x => x.MaHS == maHS && x.MaHK == maHK);

                if (existing != null)
                {
                    existing.Loai = loai;
                    existing.NoiDung = noiDung;
                    existing.Ngay = ngay;

                    GetListForDatabase.context.SaveChanges();

                    MessageBox.Show("Cập nhật thông tin Khen thưởng / Kỷ luật thành công!",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string maKTKL = GetIDForDatabase.getIDNextKhenThuongKyLuat();

                    var newKTKL = new KhenThuongKyLuat
                    {
                        MaKTKL = maKTKL,
                        MaHS = maHS,
                        MaHK = maHK,
                        Loai = loai,
                        NoiDung = noiDung,
                        Ngay = ngay
                    };

                    GetListForDatabase.context.KhenThuongKyLuats.Add(newKTKL);
                    GetListForDatabase.context.SaveChanges();

                    MessageBox.Show("Thêm mới Khen thưởng / Kỷ luật thành công!",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadHocSinhTheoGVCN();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật Khen thưởng / Kỷ luật:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
