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

namespace QuanLyHocSinhTruongPhoThong.Views.Dialog
{
    public partial class ThemKhenThuong : Form
    {
        public ThemKhenThuong()
        {
            InitializeComponent();
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
            lvHocSinh.Columns.Add("Lớp", 100);
        }
        private void LoadHocSinhChuaKTKL(string username)
        {
            try
            {
                lvHocSinh.Items.Clear();

                string maGV = GetListForDatabase.getMaGVByUsername(username);
                if (string.IsNullOrEmpty(maGV)) return;

                string maHK = null;
                if (cbbMaHK.SelectedIndex >= 0)
                    maHK = cbbMaHK.SelectedItem.ToString().Split('-')[0].Trim();
                else
                {
                    MessageBox.Show("Vui lòng chọn học kỳ!", "Thiếu thông tin",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                var lopGV = (from pc in GetListForDatabase.context.PhanCongGiangDays
                             where pc.MaGV == maGV
                             select pc.MaLop)
                            .Union(from l in GetListForDatabase.context.Lops
                                   where l.MaGV == maGV
                                   select l.MaLop)
                            .Distinct()
                            .ToList();

                var hsList = GetListForDatabase.context.HocSinhs
                    .Where(hs => lopGV.Contains(hs.MaLop))
                    .ToList();

                var hsChuaKTKL = hsList
                    .Where(hs => !GetListForDatabase.context.KhenThuongKyLuats
                        .Any(kt => kt.MaHS == hs.MaHS && kt.MaHK == maHK))
                    .OrderBy(hs => hs.MaLop)
                    .ThenBy(hs => hs.HoTen)
                    .ToList();

                foreach (var hs in hsChuaKTKL)
                {
                    var item = new ListViewItem(hs.MaHS);
                    item.SubItems.Add(hs.HoTen);
                    item.SubItems.Add(hs.MaLop);
                    lvHocSinh.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách học sinh chưa có KT/KL:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaHS.Text))
                {
                    MessageBox.Show("Vui lòng chọn học sinh!", "Thiếu thông tin",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbbMaHK.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn học kỳ!", "Thiếu thông tin",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maHK = cbbMaHK.SelectedItem.ToString().Split('-')[0].Trim();
                string maKTKL = txtMaKTKL.Text.Trim();
                string maHS = txtMaHS.Text.Trim();
                string loai = cbbLoai.SelectedItem?.ToString() ?? "Không có";
                string noiDung = string.IsNullOrWhiteSpace(txtNoiDung.Text) ? null : txtNoiDung.Text.Trim();
                DateTime ngay = DateTime.Now;

                var exist = GetListForDatabase.context.KhenThuongKyLuats
                    .FirstOrDefault(x => x.MaHS == maHS && x.MaHK == maHK);
                if (exist != null)
                {
                    MessageBox.Show("Học sinh này đã có khen thưởng / kỷ luật trong học kỳ này!",
                                    "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var ktkl = new KhenThuongKyLuat
                {
                    MaKTKL = maKTKL,
                    MaHS = maHS,
                    MaHK = maHK,
                    Loai = loai,
                    NoiDung = noiDung,
                    Ngay = ngay
                };

                GetListForDatabase.context.KhenThuongKyLuats.Add(ktkl);
                GetListForDatabase.context.SaveChanges();

                MessageBox.Show("Thêm khen thưởng / kỷ luật thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khen thưởng / kỷ luật:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNoiDung.Text) ||
                cbbLoai.SelectedIndex > 0 ||
                !string.IsNullOrWhiteSpace(txtMaHS.Text))
            {
                var result = MessageBox.Show(
                    "Bạn có chắc muốn hủy thao tác thêm khen thưởng/kỷ luật này?",
                    "Xác nhận hủy",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
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

            txtMaKTKL.Text = GetIDForDatabase.getIDNextKhenThuongKyLuat();

            if (cbbMaHK.Items.Count > 0)
            {
                if (cbbMaHK.SelectedIndex < 0)
                    cbbMaHK.SelectedIndex = 0;
            }
            else
            {
                var listHK = GetListForDatabase.getListHocKy();
                foreach (var hk in listHK)
                    cbbMaHK.Items.Add($"{hk.MaHK} - {hk.TenHK}");

                if (cbbMaHK.Items.Count > 0)
                    cbbMaHK.SelectedIndex = 0;
            }

            if (cbbLoai.Items.Count > 0 && cbbLoai.SelectedIndex == -1)
                cbbLoai.SelectedIndex = 0;
        }

        private void ThemKhenThuong_Load(object sender, EventArgs e)
        {
            SetupListViewHocSinh();
            string username = CurrentUser.Username;
            LoadHocSinhChuaKTKL(username);
        }
    }
}
