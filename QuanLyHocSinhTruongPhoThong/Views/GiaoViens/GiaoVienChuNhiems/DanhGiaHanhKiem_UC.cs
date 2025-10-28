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
        

        private void lvListHS_SelectedIndexChanged(object sender, EventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void SetupListViewHocSinh()
        {
            lvHocSinh.View = View.Details;
            lvHocSinh.FullRowSelect = true;
            lvHocSinh.GridLines = true;
            lvHocSinh.MultiSelect = false;

            lvHocSinh.Columns.Clear();
            lvHocSinh.Columns.Add("Mã HS", 80);
            lvHocSinh.Columns.Add("Họ và tên", 180);
            lvHocSinh.Columns.Add("Giới tính", 80);
            lvHocSinh.Columns.Add("Ngày sinh", 100);
            lvHocSinh.Columns.Add("SĐT", 100);
            lvHocSinh.Columns.Add("Email", 150);
            lvHocSinh.Columns.Add("Địa chỉ", 180);
            lvHocSinh.Columns.Add("Lớp", 100);
            lvHocSinh.Columns.Add("Niên khóa", 120);
        }
        private void LoadHocSinhCuaGVCN()
        {
            try
            {
                lvHocSinh.Items.Clear();
                string username = CurrentUser.Username;

                var list = GetListForDatabase.getHocSinhCuaGVCN(username);

                foreach (var hs in list)
                {
                    var lopInfo = (from lop in GetListForDatabase.context.Lops
                                   join nk in GetListForDatabase.context.NienKhoas on lop.MaNienKhoa equals nk.MaNienKhoa
                                   where lop.MaLop == hs.MaLop
                                   select new { lop.TenLop, NamBatDau = nk.NamBatDau, NamKetThuc = nk.NamKetThuc })
                                   .FirstOrDefault();

                    var item = new ListViewItem(hs.MaHS);
                    item.SubItems.Add(hs.HoTen);
                    item.SubItems.Add(hs.GioiTinh ? "Nam" : "Nữ");
                    item.SubItems.Add(hs.NgaySinh.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(hs.Sdt);
                    item.SubItems.Add(hs.Email ?? "");
                    item.SubItems.Add(hs.DiaChi ?? "");
                    item.SubItems.Add(lopInfo?.TenLop ?? "");
                    item.SubItems.Add(lopInfo != null ? $"{lopInfo.NamBatDau}-{lopInfo.NamKetThuc}" : "");

                    lvHocSinh.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách học sinh của giáo viên chủ nhiệm:\n" + ex.Message,
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
            LoadHocSinhCuaGVCN();
        }

        private void DanhGiaHanhKiem_UC_Load(object sender, EventArgs e)
        {
            var user = CurrentUser.Username;
            LoadKhenThuongKyLuat(user);
            cbbMaHK.SelectedIndexChanged += cbbMaHK_SelectedIndexChanged;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
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
    }
}
