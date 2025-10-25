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

namespace QuanLyHocSinhTruongPhoThong.Views.Admins
{
    public partial class Lophoc_UC : UserControl,IReloadable
    {
        public Lophoc_UC()
        {
            InitializeComponent();
        }

        private void Lophoc_UC_Load(object sender, EventArgs e)
        {
            SetupListViewLop();
            LoadGiaoVienToComboBox();
            LoadNienKhoaToComboBox();
            LoadLopHoc();

        }
        private void LoadLopHoc()
        {
            try
            {
                lvLop.Items.Clear();
                var list = GetListForDatabase.getListLop();

                foreach (var lop in list)
                {
                    var item = new ListViewItem(lop.MaLop);
                    item.SubItems.Add(lop.TenLop);
                    item.SubItems.Add($"{lop.MaNienKhoa}");
                    item.SubItems.Add(lop.MaGV);
                    lvLop.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách lớp học:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupListViewLop()
        {
            lvLop.View = View.Details;
            lvLop.FullRowSelect = true;
            lvLop.GridLines = true;
            lvLop.MultiSelect = false;

            lvLop.Columns.Clear();

            int totalWidth = lvLop.ClientSize.Width; 

            int col1 = (int)(totalWidth * 0.15);
            int col2 = (int)(totalWidth * 0.25); 
            int col3 = (int)(totalWidth * 0.25); 
            int col4 = (int)(totalWidth * 0.35); 
            lvLop.Columns.Add("Mã lớp", col1);
            lvLop.Columns.Add("Tên lớp", col2);
            lvLop.Columns.Add("Niên khóa", col3);
            lvLop.Columns.Add("Giáo viên chủ nhiệm", col4);
        }
        private void LoadGiaoVienToComboBox()
        {
            try
            {
                var listGV = GetListForDatabase.getListGiaoVien();

                cbbGVCN.Items.Clear();
                foreach (var gv in listGV)
                {
                    cbbGVCN.Items.Add($"{gv.MaGV} - {gv.HoTen}");
                }

                if (cbbGVCN.Items.Count > 0)
                    cbbGVCN.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách giáo viên:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadNienKhoaToComboBox()
        {
            try
            {
                var listNK = GetListForDatabase.getListNienKhoa();

                cbbNienKHoa.Items.Clear();

                foreach (var nk in listNK)
                {
                    cbbNienKHoa.Items.Add($"{nk.MaNienKhoa} - {nk.NamBatDau}-{nk.NamKetThuc}");
                }

                if (cbbNienKHoa.Items.Count > 0)
                    cbbNienKHoa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách niên khóa:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Reload(object arg = null)
        {
            LoadGiaoVienToComboBox();
            LoadNienKhoaToComboBox();
            LoadLopHoc();
        }

        private void lvLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvLop.SelectedItems.Count == 0)
                return;

            var item = lvLop.SelectedItems[0];

            // Lấy dữ liệu theo thứ tự cột
            string maLop = item.SubItems[0].Text;
            string tenLop = item.SubItems[1].Text;
            string maNienKhoa = item.SubItems[2].Text;
            string maGVCN = item.SubItems[3].Text;

            txtmaGV.Text = maLop;
            txtHoTen.Text = tenLop;

            var nkItem = cbbNienKHoa.Items
                .Cast<string>()
                .FirstOrDefault(x => x.StartsWith(maNienKhoa));
            if (nkItem != null)
                cbbNienKHoa.SelectedItem = nkItem;
            else
                cbbNienKHoa.SelectedIndex = -1;

            var gvItem = cbbGVCN.Items
                .Cast<string>()
                .FirstOrDefault(x => x.StartsWith(maGVCN));
            if (gvItem != null)
                cbbGVCN.SelectedItem = gvItem;
            else
                cbbGVCN.SelectedIndex = -1;
        }
        private void ClearTracker()
        {
            foreach (var entry in GetListForDatabase.context.ChangeTracker.Entries().ToList())
                entry.State = System.Data.Entity.EntityState.Detached;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maLop = txtmaGV.Text.Trim(); // ⚠️ đổi thành txtMaLop nếu bạn rename
                string tenLop = txtHoTen.Text.Trim(); // ⚠️ đổi thành txtTenLop nếu bạn rename

                if (string.IsNullOrWhiteSpace(maLop) ||
                    string.IsNullOrWhiteSpace(tenLop) ||
                    cbbNienKHoa.SelectedIndex < 0 ||
                    cbbGVCN.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin lớp học!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maNienKhoa = cbbNienKHoa.SelectedItem.ToString().Split('-')[0].Trim();
                string maGVCN = cbbGVCN.SelectedItem.ToString().Split('-')[0].Trim();

                bool tonTai = GetListForDatabase.context.Lops
                    .Any(l => l.MaLop == maLop);
                if (tonTai)
                {
                    MessageBox.Show("Mã lớp đã tồn tại!",
                                    "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newLop = new Lop
                {
                    MaLop = maLop,
                    TenLop = tenLop,
                    MaNienKhoa = maNienKhoa,
                    MaGV = maGVCN
                };

                GetListForDatabase.context.Lops.Add(newLop);
                GetListForDatabase.context.SaveChanges();
                ClearTracker();

                LoadLopHoc();
                MessageBox.Show("Thêm lớp học thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnClear_Click(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi thêm lớp học:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string maLop = txtmaGV.Text.Trim();
                string tenLop = txtHoTen.Text.Trim();

                if (string.IsNullOrWhiteSpace(maLop))
                {
                    MessageBox.Show("Vui lòng chọn lớp học cần sửa!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClearTracker();

                var lop = GetListForDatabase.context.Lops
                    .FirstOrDefault(x => x.MaLop == maLop);
                if (lop == null)
                {
                    MessageBox.Show("Không tìm thấy lớp học cần sửa!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string maNienKhoa = cbbNienKHoa.SelectedItem.ToString().Split('-')[0].Trim();
                string maGVCN = cbbGVCN.SelectedItem.ToString().Split('-')[0].Trim();

                lop.TenLop = tenLop;
                lop.MaNienKhoa = maNienKhoa;
                lop.MaGV = maGVCN;

                GetListForDatabase.context.SaveChanges();
                ClearTracker();

                LoadLopHoc();
                MessageBox.Show("Cập nhật lớp học thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi sửa lớp học:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string maLop = txtmaGV.Text.Trim();
                if (string.IsNullOrWhiteSpace(maLop))
                {
                    MessageBox.Show("Vui lòng chọn lớp học cần xóa!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var lop = GetListForDatabase.context.Lops
                    .FirstOrDefault(x => x.MaLop == maLop);
                if (lop == null)
                {
                    MessageBox.Show("Không tìm thấy lớp học cần xóa!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa lớp {maLop}?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                    return;

                GetListForDatabase.context.Lops.Remove(lop);
                GetListForDatabase.context.SaveChanges();
                ClearTracker();

                LoadLopHoc();
                btnClear_Click(null, EventArgs.Empty);

                MessageBox.Show("Xóa lớp học thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                ClearTracker();
                MessageBox.Show("Không thể xóa lớp học vì đang được tham chiếu ở bảng khác (học sinh, phân công...).",
                                "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi xóa lớp học:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtmaGV.Clear();
                txtHoTen.Clear();

                if (cbbNienKHoa.Items.Count > 0)
                    cbbNienKHoa.SelectedIndex = 0;

                if (cbbGVCN.Items.Count > 0)
                    cbbGVCN.SelectedIndex = 0;

                lvLop.SelectedItems.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới form lớp học:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
