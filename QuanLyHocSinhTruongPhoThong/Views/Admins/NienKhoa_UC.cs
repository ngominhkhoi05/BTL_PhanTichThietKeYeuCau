using QuanLyHocSinhTruongPhoThong.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinhTruongPhoThong.Views
{
    public partial class NienKhoa_UC : UserControl,IReloadable
    {
        public NienKhoa_UC()
        {
            InitializeComponent();
        }
        private void SetupListViewNienKhoa()
        {
            lvNienKhoa.View = View.Details;
            lvNienKhoa.FullRowSelect = true;
            lvNienKhoa.GridLines = true;
            lvNienKhoa.MultiSelect = false;

            lvNienKhoa.Columns.Clear();
            lvNienKhoa.Columns.Add("Mã niên khóa", 120);
            lvNienKhoa.Columns.Add("Năm bắt đầu", 120);
            lvNienKhoa.Columns.Add("Năm kết thúc", 120);
        }
        private void LoadNienKhoa()
        {
            try
            {
                lvNienKhoa.Items.Clear();
                var list = GetListForDatabase.getListNienKhoa();

                foreach (var nk in list)
                {
                    var item = new ListViewItem(nk.MaNienKhoa);
                    item.SubItems.Add(nk.NamBatDau.ToString());
                    item.SubItems.Add(nk.NamKetThuc.ToString());
                    lvNienKhoa.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách niên khóa:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetupListViewHocKy()
        {
            lvHK.View = View.Details;
            lvHK.FullRowSelect = true;
            lvHK.GridLines = true;
            lvHK.MultiSelect = false;

            lvHK.Columns.Clear();
            lvHK.Columns.Add("Mã học kỳ", 150);
            lvHK.Columns.Add("Tên học kỳ", 180);
            lvHK.Columns.Add("Mã niên khóa", 150);
        }
        private void LoadHocKy()
        {
            try
            {
                lvHK.Items.Clear();
                var list = GetListForDatabase.getListHocKy();

                foreach (var hk in list)
                {
                    var item = new ListViewItem(hk.MaHK);
                    item.SubItems.Add(hk.TenHK);
                    item.SubItems.Add(hk.MaNienKhoa);
                    lvHK.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách học kỳ:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadMaNienKhoaToComboBox()
        {
            try
            {
                var listNienKhoa = GetListForDatabase.getListNienKhoa();

                cbbMaNienKhoa.Items.Clear();

                foreach (var nk in listNienKhoa)
                {
                    cbbMaNienKhoa.Items.Add(nk.MaNienKhoa);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách mã niên khóa:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTenGV_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblNienKhoa_Click(object sender, EventArgs e)
        {

        }

        private void NienKhoa_UC_Load(object sender, EventArgs e)
        {
            SetupListViewNienKhoa();
            SetupListViewHocKy();
            LoadMaNienKhoaToComboBox();
            LoadNienKhoa();
            LoadHocKy();

            ConfigDateTimePickerNam();
            dtpkNamBatDau.ValueChanged += dtpkNamBatDau_ValueChanged;
            dtpkNamBatDau.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpkNamKetThuc.Value = new DateTime(DateTime.Now.Year + 1, 1, 1);
        }
        private void ConfigDateTimePickerNam()
        {
            // DateTimePicker Năm bắt đầu
            dtpkNamBatDau.Format = DateTimePickerFormat.Custom;
            dtpkNamBatDau.CustomFormat = "yyyy";
            dtpkNamBatDau.ShowUpDown = true; // hiện spinner, không hiện lịch

            // DateTimePicker Năm kết thúc
            dtpkNamKetThuc.Format = DateTimePickerFormat.Custom;
            dtpkNamKetThuc.CustomFormat = "yyyy";
            dtpkNamKetThuc.ShowUpDown = true;
            dtpkNamKetThuc.Enabled = false; // không cho người dùng chọn
        }
        private void dtpkNamBatDau_ValueChanged(object sender, EventArgs e)
        {
            // mỗi khi người dùng chọn năm mới → cập nhật năm kết thúc = năm bắt đầu + 1
            int namBatDau = dtpkNamBatDau.Value.Year;
            dtpkNamKetThuc.Value = new DateTime(namBatDau + 1, 1, 1);
        }

        private void lvNienKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvNienKhoa.SelectedItems.Count == 0)
                return;

            var item = lvNienKhoa.SelectedItems[0];

            txtMaNienKhoa.Text = item.SubItems[0].Text;

            if (int.TryParse(item.SubItems[1].Text, out int namBatDau))
                dtpkNamBatDau.Value = new DateTime(namBatDau, 1, 1);

            if (int.TryParse(item.SubItems[2].Text, out int namKetThuc))
                dtpkNamKetThuc.Value = new DateTime(namKetThuc, 1, 1);
        }

        private void lvHK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHK.SelectedItems.Count == 0)
                return;

            var item = lvHK.SelectedItems[0];

            // Các cột theo thứ tự: Mã học kỳ | Tên học kỳ | Mã niên khóa
            txtMaHocKy.Text = item.SubItems[0].Text;
            txtTenHocKy.Text = item.SubItems[1].Text;

            string maNienKhoa = item.SubItems[2].Text;
            if (cbbMaNienKhoa.Items.Contains(maNienKhoa))
                cbbMaNienKhoa.SelectedItem = maNienKhoa;
            else
                cbbMaNienKhoa.SelectedIndex = -1;
        }
        private void ClearTracker()
        {
            foreach (var entry in GetListForDatabase.context.ChangeTracker.Entries().ToList())
                entry.State = System.Data.Entity.EntityState.Detached;
        }

        private void btnThemNienKhoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maNK = txtMaNienKhoa.Text.Trim();
                int namBD = dtpkNamBatDau.Value.Year;
                int namKT = dtpkNamKetThuc.Value.Year;

                if (string.IsNullOrWhiteSpace(maNK))
                {
                    MessageBox.Show("Vui lòng nhập mã niên khóa!", "Thiếu thông tin",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool tonTai = GetListForDatabase.context.NienKhoas
                    .Any(nk => nk.MaNienKhoa == maNK);
                if (tonTai)
                {
                    MessageBox.Show("Mã niên khóa đã tồn tại!", "Trùng dữ liệu",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newNK = new NienKhoa
                {
                    MaNienKhoa = maNK,
                    NamBatDau = namBD,
                    NamKetThuc = namKT
                };

                GetListForDatabase.context.NienKhoas.Add(newNK);
                GetListForDatabase.context.SaveChanges();
                ClearTracker();

                LoadNienKhoa();
                LoadMaNienKhoaToComboBox();

                MessageBox.Show("Thêm niên khóa thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnClearNienKhoa_Click(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi thêm niên khóa:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaNienKhoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maNK = txtMaNienKhoa.Text.Trim();
                int namBD = dtpkNamBatDau.Value.Year;
                int namKT = dtpkNamKetThuc.Value.Year;

                if (string.IsNullOrWhiteSpace(maNK))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập mã niên khóa cần sửa!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClearTracker();

                var nk = GetListForDatabase.context.NienKhoas
                    .FirstOrDefault(x => x.MaNienKhoa == maNK);
                if (nk == null)
                {
                    MessageBox.Show("Không tìm thấy niên khóa cần sửa!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                nk.NamBatDau = namBD;
                nk.NamKetThuc = namKT;

                GetListForDatabase.context.SaveChanges();
                ClearTracker();

                LoadNienKhoa();
                LoadMaNienKhoaToComboBox();

                MessageBox.Show("Cập nhật niên khóa thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi sửa niên khóa:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaNienKhoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maNK = txtMaNienKhoa.Text.Trim();
                if (string.IsNullOrWhiteSpace(maNK))
                {
                    MessageBox.Show("Vui lòng chọn niên khóa cần xóa!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nk = GetListForDatabase.context.NienKhoas
                    .FirstOrDefault(x => x.MaNienKhoa == maNK);
                if (nk == null)
                {
                    MessageBox.Show("Không tìm thấy niên khóa cần xóa!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa niên khóa {maNK}?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                GetListForDatabase.context.NienKhoas.Remove(nk);
                GetListForDatabase.context.SaveChanges();
                ClearTracker();

                LoadNienKhoa();
                LoadMaNienKhoaToComboBox();
                btnClearNienKhoa_Click(null, EventArgs.Empty);

                MessageBox.Show("Xóa niên khóa thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                ClearTracker();
                MessageBox.Show("Không thể xóa vì niên khóa đang được tham chiếu ở bảng khác (học kỳ, lớp...).",
                                "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi xóa niên khóa:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearNienKhoa_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaNienKhoa.Clear();
                dtpkNamBatDau.Value = new DateTime(DateTime.Now.Year, 1, 1);
                dtpkNamKetThuc.Value = new DateTime(DateTime.Now.Year + 1, 1, 1);

                lvNienKhoa.SelectedItems.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới form:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void Reload(object arg = null)
        {
            LoadNienKhoa();
            LoadHocKy();
        }

        private void btnThemHK_Click(object sender, EventArgs e)
        {
            try
            {
                string maHK = txtMaHocKy.Text.Trim();
                string tenHK = txtTenHocKy.Text.Trim();
                string maNienKhoa = cbbMaNienKhoa.SelectedItem?.ToString();

                if (string.IsNullOrWhiteSpace(maHK) ||
                    string.IsNullOrWhiteSpace(tenHK) ||
                    string.IsNullOrWhiteSpace(maNienKhoa))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin học kỳ!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool tonTai = GetListForDatabase.context.HocKies
                    .Any(hk => hk.MaHK == maHK);
                if (tonTai)
                {
                    MessageBox.Show("Mã học kỳ đã tồn tại!",
                                    "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newHK = new HocKy
                {
                    MaHK = maHK,
                    TenHK = tenHK,
                    MaNienKhoa = maNienKhoa
                };

                GetListForDatabase.context.HocKies.Add(newHK);
                GetListForDatabase.context.SaveChanges();
                ClearTracker();

                LoadHocKy();
                MessageBox.Show("Thêm học kỳ thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClearHK_Click(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi thêm học kỳ:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaHK_Click(object sender, EventArgs e)
        {
            try
            {
                string maHK = txtMaHocKy.Text.Trim();
                string tenHK = txtTenHocKy.Text.Trim();
                string maNienKhoa = cbbMaNienKhoa.SelectedItem?.ToString();

                if (string.IsNullOrWhiteSpace(maHK) ||
                    string.IsNullOrWhiteSpace(tenHK) ||
                    string.IsNullOrWhiteSpace(maNienKhoa))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin để sửa học kỳ!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClearTracker();

                var hk = GetListForDatabase.context.HocKies
                    .FirstOrDefault(x => x.MaHK == maHK);
                if (hk == null)
                {
                    MessageBox.Show("Không tìm thấy học kỳ cần sửa!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                hk.TenHK = tenHK;
                hk.MaNienKhoa = maNienKhoa;

                GetListForDatabase.context.SaveChanges();
                ClearTracker();

                LoadHocKy();
                MessageBox.Show("Cập nhật học kỳ thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi sửa học kỳ:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaHK_Click(object sender, EventArgs e)
        {
            try
            {
                string maHK = txtMaHocKy.Text.Trim();
                if (string.IsNullOrWhiteSpace(maHK))
                {
                    MessageBox.Show("Vui lòng chọn học kỳ cần xóa!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var hk = GetListForDatabase.context.HocKies
                    .FirstOrDefault(x => x.MaHK == maHK);
                if (hk == null)
                {
                    MessageBox.Show("Không tìm thấy học kỳ cần xóa!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa học kỳ {maHK}?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                GetListForDatabase.context.HocKies.Remove(hk);
                GetListForDatabase.context.SaveChanges();
                ClearTracker();

                LoadHocKy();
                btnClearHK_Click(null, EventArgs.Empty);

                MessageBox.Show("Xóa học kỳ thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                ClearTracker();
                MessageBox.Show("Không thể xóa học kỳ vì đang được tham chiếu ở bảng khác (phân công, điểm...).",
                                "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi xóa học kỳ:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearHK_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaHocKy.Clear();
                txtTenHocKy.Clear();

                if (cbbMaNienKhoa.Items.Count > 0)
                    cbbMaNienKhoa.SelectedIndex = 0;

                lvHK.SelectedItems.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới form học kỳ:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
