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
        private void LoadHocKy_ToCombo()
        {
            try
            {
                var listHK = GetListForDatabase.getListHocKy();

                cbbMaHK.Items.Clear();

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

        private void lvListHS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvListHS.SelectedItems.Count == 0)
                return;

            var item = lvListHS.SelectedItems[0];

            txtMaKTKL.Text = item.SubItems[0].Text;
            txtMaHS.Text = item.SubItems[1].Text;
            txtTen.Text = item.SubItems[2].Text;
            string maHK = item.SubItems[3].Text;
            string loai = item.SubItems[4].Text;
            string noiDung = item.SubItems[5].Text;
            string ngay = item.SubItems[6].Text;

            if (cbbLoai.Items.Contains(loai))
                cbbLoai.SelectedItem = loai;
            else
                cbbLoai.SelectedIndex = 0;

            txtNoiDung.Text = noiDung;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void SetupListViewKhenThuongKyLuat()
        {
            lvListHS.View = View.Details;
            lvListHS.FullRowSelect = true;
            lvListHS.GridLines = true;
            lvListHS.MultiSelect = false;

            lvListHS.Columns.Clear();
            lvListHS.Columns.Add("Mã KT/KL", 100);
            lvListHS.Columns.Add("Mã HS", 80);
            lvListHS.Columns.Add("Tên học sinh", 180);
            lvListHS.Columns.Add("Mã học kỳ", 100);
            lvListHS.Columns.Add("Loại", 100);
            lvListHS.Columns.Add("Nội dung", 250);
            lvListHS.Columns.Add("Ngày", 120);
        }
        private void LoadKhenThuongKyLuat(string username)
        {
            try
            {
                lvListHS.Items.Clear();

                string maGV = GetListForDatabase.getMaGVByUsername(username);

                var hsList = GetListForDatabase.getHocSinhByUsername(username);
                var maHSList = hsList.Select(x => x.MaHS).ToList();

                var list = (from kt in GetListForDatabase.context.KhenThuongKyLuats
                            join hs in GetListForDatabase.context.HocSinhs on kt.MaHS equals hs.MaHS
                            where maHSList.Contains(kt.MaHS)
                            orderby kt.Ngay descending
                            select new
                            {
                                kt.MaKTKL,
                                kt.MaHS,
                                hs.HoTen,
                                kt.MaHK,
                                kt.Loai,
                                kt.NoiDung,
                                kt.Ngay
                            }).ToList();

                lvListHS.BeginUpdate();
                foreach (var item in list)
                {
                    var row = new ListViewItem(item.MaKTKL);
                    row.SubItems.Add(item.MaHS);
                    row.SubItems.Add(item.HoTen);
                    row.SubItems.Add(item.MaHK);
                    row.SubItems.Add(item.Loai);
                    row.SubItems.Add(item.NoiDung ?? "");
                    row.SubItems.Add(item.Ngay?.ToString("dd/MM/yyyy") ?? "");
                    lvListHS.Items.Add(row);
                }
                lvListHS.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khen thưởng/kỷ luật:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DanhGiaHanhKiem_UC_Load(object sender, EventArgs e)
        {
            SetupListViewKhenThuongKyLuat();
            LoadHocKy_ToCombo();
            cbbLoai.Items.Clear();
            cbbLoai.Items.AddRange(new string[] { "Khen thưởng", "Kỷ luật", "Không có" });
            cbbLoai.SelectedIndex = 0;

            string username = CurrentUser.Username;
            LoadKhenThuongKyLuat(username);
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
