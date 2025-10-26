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

namespace QuanLyHocSinhTruongPhoThong.Views.Admins
{
    public partial class PhanCong_UC : UserControl,IReloadable
    {
        public PhanCong_UC()
        {
            InitializeComponent();
        }
        public AppDbContext context = new AppDbContext();

        private void LoadLopToComboBox()
        {
            try
            {
                var listLop = GetListForDatabase.getListLopHoc();

                cbbMaLop.Items.Clear();
                foreach (var lop in listLop)
                {
                    cbbMaLop.Items.Add($"{lop.MaLop} - {lop.TenLop}");
                }

                if (cbbMaLop.Items.Count > 0)
                    cbbMaLop.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách lớp học:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadHocKyToComboBox()
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
                MessageBox.Show("Lỗi khi tải danh sách học kỳ:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadGiaoVienToComboBox()
        {
            try
            {
                var listGV = GetListForDatabase.getListGiaoVien();

                cbbMaGV.Items.Clear();
                foreach (var gv in listGV)
                {
                    cbbMaGV.Items.Add($"{gv.MaGV} - {gv.HoTen}");
                }

                if (cbbMaGV.Items.Count > 0)
                    cbbMaGV.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách giáo viên:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadMonHocToComboBox()
        {
            try
            {
                var listMon = GetListForDatabase.getListMonHoc();

                cbbMaMon.Items.Clear();
                foreach (var mh in listMon)
                {
                    cbbMaMon.Items.Add($"{mh.MaMH} - {mh.TenMH}");
                }

                if (cbbMaMon.Items.Count > 0)
                    cbbMaMon.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách môn học:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetupListViewPhanCong()
        {
            lvLop.View = View.Details;
            lvLop.FullRowSelect = true;
            lvLop.GridLines = true;
            lvLop.MultiSelect = false;

            lvLop.Columns.Clear();
            lvLop.Columns.Add("Mã PC", 90);
            lvLop.Columns.Add("Lớp", 150);
            lvLop.Columns.Add("Môn học", 150);
            lvLop.Columns.Add("Giáo viên", 200);
            lvLop.Columns.Add("Học kỳ", 150);
        }
        private void LoadPhanCong()
        {
            try
            {
                lvLop.Items.Clear();

                var list = GetListForDatabase.getListPhanCong();

                foreach (var pc in list)
                {
                    var item = new ListViewItem(pc.MaPC);
                    item.SubItems.Add($"{pc.MaLop} - {pc.TenLop}");
                    item.SubItems.Add($"{pc.MaMH} - {pc.TenMH}");
                    item.SubItems.Add($"{pc.MaGV} - {pc.TenGV}");
                    item.SubItems.Add($"{pc.MaHK} - {pc.TenHK}");
                    lvLop.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phân công:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblListGV_Click(object sender, EventArgs e)
        {

        }

        private void PhanCong_UC_Load(object sender, EventArgs e)
        {
            SetupListViewPhanCong();
            LoadPhanCong();
            LoadLopToComboBox();
            LoadHocKyToComboBox();
            LoadGiaoVienToComboBox();
            LoadMonHocToComboBox();
        }

        private void lvLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvLop.SelectedItems.Count == 0)
                return;

            var item = lvLop.SelectedItems[0];
            txtMaPC.Text = item.SubItems[0].Text;
            cbbMaLop.SelectedIndex = cbbMaLop.FindString(item.SubItems[1].Text);
            cbbMaMon.SelectedIndex = cbbMaMon.FindString(item.SubItems[2].Text);
            cbbMaGV.SelectedIndex = cbbMaGV.FindString(item.SubItems[3].Text);
            cbbMaHK.SelectedIndex = cbbMaHK.FindString(item.SubItems[4].Text);
        }

        private void ClearTracker()
        {
            foreach (var entry in context.ChangeTracker.Entries().ToList())
                entry.State = System.Data.Entity.EntityState.Detached;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbMaLop.SelectedIndex < 0 || cbbMaMon.SelectedIndex < 0 || cbbMaGV.SelectedIndex < 0 || cbbMaHK.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ thông tin phân công!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maPC = GetIDForDatabase.getIDNextPhanCongGiangDay();
                string maLop = cbbMaLop.SelectedItem.ToString().Split('-')[0].Trim();
                string maMon = cbbMaMon.SelectedItem.ToString().Split('-')[0].Trim();
                string maGV = cbbMaGV.SelectedItem.ToString().Split('-')[0].Trim();
                string maHK = cbbMaHK.SelectedItem.ToString().Split('-')[0].Trim();

                bool tonTai = context.PhanCongGiangDays.Any(x =>
                    x.MaLop == maLop && x.MaMH == maMon && x.MaGV == maGV && x.MaHK == maHK);

                if (tonTai)
                {
                    MessageBox.Show("Phân công giảng dạy này đã tồn tại!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var pc = new PhanCongGiangDay
                {
                    MaPC = maPC,
                    MaLop = maLop,
                    MaMH = maMon,
                    MaGV = maGV,
                    MaHK = maHK
                };

                context.PhanCongGiangDays.Add(pc);
                context.SaveChanges();
                ClearTracker();

                LoadPhanCong();

                MessageBox.Show("Thêm phân công giảng dạy thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear_Click(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi thêm phân công giảng dạy:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaPC.Text))
                {
                    MessageBox.Show("Vui lòng chọn phân công cần sửa!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maPC = txtMaPC.Text.Trim();
                string maLop = cbbMaLop.SelectedItem.ToString().Split('-')[0].Trim();
                string maMon = cbbMaMon.SelectedItem.ToString().Split('-')[0].Trim();
                string maGV = cbbMaGV.SelectedItem.ToString().Split('-')[0].Trim();
                string maHK = cbbMaHK.SelectedItem.ToString().Split('-')[0].Trim();

                var pc = context.PhanCongGiangDays.FirstOrDefault(x => x.MaPC == maPC);
                if (pc == null)
                {
                    MessageBox.Show("Không tìm thấy phân công cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool tonTai = context.PhanCongGiangDays.Any(x =>
                    x.MaPC != maPC && x.MaLop == maLop && x.MaMH == maMon && x.MaGV == maGV && x.MaHK == maHK);

                if (tonTai)
                {
                    MessageBox.Show("Phân công này đã tồn tại, không thể sửa trùng!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                pc.MaLop = maLop;
                pc.MaMH = maMon;
                pc.MaGV = maGV;
                pc.MaHK = maHK;

                context.SaveChanges();
                ClearTracker();

                LoadPhanCong();
                MessageBox.Show("Cập nhật phân công thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi sửa phân công:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaPC.Text))
                {
                    MessageBox.Show("Vui lòng chọn phân công cần xóa!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maPC = txtMaPC.Text.Trim();
                var pc = context.PhanCongGiangDays.FirstOrDefault(x => x.MaPC == maPC);
                if (pc == null)
                {
                    MessageBox.Show("Không tìm thấy phân công cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa phân công {maPC} này không?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                    return;

                context.PhanCongGiangDays.Remove(pc);
                context.SaveChanges();
                ClearTracker();

                LoadPhanCong();
                btnClear_Click(null, EventArgs.Empty);

                MessageBox.Show("Xóa phân công thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                ClearTracker();
                MessageBox.Show("Không thể xóa phân công vì đang được sử dụng trong bảng khác!",
                                "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi xóa phân công:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaPC.Text = GetIDForDatabase.getIDNextPhanCongGiangDay();

                if (cbbMaLop.Items.Count > 0)
                    cbbMaLop.SelectedIndex = 0;
                if (cbbMaMon.Items.Count > 0)
                    cbbMaMon.SelectedIndex = 0;
                if (cbbMaGV.Items.Count > 0)
                    cbbMaGV.SelectedIndex = 0;
                if (cbbMaHK.Items.Count > 0)
                    cbbMaHK.SelectedIndex = 0;

                lvLop.SelectedItems.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới form phân công:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void Reload(object arg = null)
        {
            LoadPhanCong();
            LoadLopToComboBox();
            LoadHocKyToComboBox();
            LoadGiaoVienToComboBox();
            LoadMonHocToComboBox();
        }
    }
}
