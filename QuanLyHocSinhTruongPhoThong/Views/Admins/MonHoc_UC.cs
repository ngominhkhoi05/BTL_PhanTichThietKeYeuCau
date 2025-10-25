using QuanLyHocSinhTruongPhoThong.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinhTruongPhoThong.Views.Admins
{
    public partial class MonHoc_UC : UserControl,IReloadable
    {
        public AppDbContext context=new AppDbContext();
        public MonHoc_UC()
        {
            InitializeComponent();
        }

        public void Reload(object arg = null)
        {
            LoadMonHoc();
        }
        private void SetupListViewMonHoc()
        {
            lvMonHoc.View = View.Details;
            lvMonHoc.FullRowSelect = true;
            lvMonHoc.GridLines = true;
            lvMonHoc.MultiSelect = false;

            lvMonHoc.Columns.Clear();

            int totalWidth = lvMonHoc.ClientSize.Width;
            int col1 = (int)(totalWidth * 0.4); // 40%
            int col2 = (int)(totalWidth * 0.6); // 60%

            lvMonHoc.Columns.Add("Mã môn", col1);
            lvMonHoc.Columns.Add("Tên môn học", col2);
        }
        private void LoadMonHoc()
        {
            try
            {
                lvMonHoc.BeginUpdate();
                lvMonHoc.Items.Clear();

                var list = context.MonHocs
                    .AsNoTracking()              
                    .OrderBy(m => m.MaMH)
                    .ToList();

                foreach (var mh in list)
                {
                    var item = new ListViewItem(mh.MaMH);
                    item.SubItems.Add(mh.TenMH);
                    lvMonHoc.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách môn học:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lvMonHoc.EndUpdate();
            }
        }


        private void MonHoc_UC_Load(object sender, EventArgs e)
        {
            SetupListViewMonHoc();
            LoadMonHoc();
        }

        private void lvMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMonHoc.SelectedItems.Count == 0)
                return;

            var item = lvMonHoc.SelectedItems[0];
            txtMaMon.Text = item.SubItems[0].Text;
            txtTenMon.Text = item.SubItems[1].Text;
        }

        private void ClearTracker()
        {
            foreach (var entry in context.ChangeTracker.Entries().ToList())
                entry.State = EntityState.Detached;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenMon.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên môn học!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maMH = GetIDForDatabase.getIDNextMonHoc();
                string tenMH = txtTenMon.Text.Trim();

                bool tonTai = context.MonHocs.Any(m => m.TenMH == tenMH);
                if (tonTai)
                {
                    MessageBox.Show("Tên môn học đã tồn tại!",
                                    "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newMon = new MonHoc
                {
                    MaMH = maMH,
                    TenMH = tenMH
                };

                context.MonHocs.Add(newMon);
                context.SaveChanges();
                ClearTracker();

                LoadMonHoc();
                MessageBox.Show("Thêm môn học thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnClear_Click(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi thêm môn học:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaMon.Text))
                {
                    MessageBox.Show("Vui lòng chọn môn học cần sửa!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maMH = txtMaMon.Text.Trim();
                string tenMH = txtTenMon.Text.Trim();

                if (string.IsNullOrWhiteSpace(tenMH))
                {
                    MessageBox.Show("Tên môn học không được để trống!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var monHoc = context.MonHocs.FirstOrDefault(m => m.MaMH == maMH);
                if (monHoc == null)
                {
                    MessageBox.Show("Không tìm thấy môn học cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool trungTen = context.MonHocs.Any(m => m.MaMH != maMH && m.TenMH == tenMH);
                if (trungTen)
                {
                    MessageBox.Show("Tên môn học đã được sử dụng!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                monHoc.TenMH = tenMH;
                context.SaveChanges();
                ClearTracker();

                MessageBox.Show("Cập nhật môn học thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadMonHoc();

                foreach (ListViewItem item in lvMonHoc.Items)
                {
                    if (item.SubItems[0].Text == maMH)
                    {
                        item.Selected = true;
                        lvMonHoc.EnsureVisible(item.Index);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi sửa môn học:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaMon.Text))
                {
                    MessageBox.Show("Vui lòng chọn môn học cần xóa!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maMH = txtMaMon.Text.Trim();
                var monHoc = context.MonHocs.FirstOrDefault(m => m.MaMH == maMH);
                if (monHoc == null)
                {
                    MessageBox.Show("Không tìm thấy môn học cần xóa!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa môn học '{monHoc.TenMH}' không?",
                                              "Xác nhận xóa",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                    return;

                context.MonHocs.Remove(monHoc);
                context.SaveChanges();
                ClearTracker();

                LoadMonHoc();
                btnClear_Click(null, EventArgs.Empty);

                MessageBox.Show("Xóa môn học thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                ClearTracker();
                MessageBox.Show("Không thể xóa môn học vì đang được sử dụng trong phân công giảng dạy hoặc bảng khác!",
                                "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi xóa môn học:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaMon.Text = GetIDForDatabase.getIDNextMonHoc();
                txtTenMon.Clear();
                lvMonHoc.SelectedItems.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới form môn học:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
