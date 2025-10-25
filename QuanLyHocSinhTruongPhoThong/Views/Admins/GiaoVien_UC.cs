using QuanLyHocSinhTruongPhoThong.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyHocSinhTruongPhoThong.Views.Admins
{
    public partial class GiaoVien_UC : UserControl, IReloadable
    {
        public AppDbContext context = new AppDbContext();

        public GiaoVien_UC()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pnInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void GiaoVien_UC_Load(object sender, EventArgs e)
        {
            SetupListView();
            Reload();

            // Gắn sự kiện khi chọn 1 dòng trong ListView
            lvGiaoVien.SelectedIndexChanged += lvGiaoVien_SelectedIndexChanged;

            // Thiết lập giá trị cho combobox giới tính
            cbbGioiTinh.Items.Clear();
            cbbGioiTinh.Items.Add("Nam");
            cbbGioiTinh.Items.Add("Nữ");
            // Cấu hình DateTimePicker hiển thị ngày theo dạng dd/MM/yyyy
            dtpkNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpkNgaySinh.CustomFormat = "dd/MM/yyyy";

            // Giới hạn độ tuổi hợp lệ: từ 23 đến 65 tuổi
            dtpkNgaySinh.MaxDate = DateTime.Now.AddYears(-23); // tối đa chọn người 23 tuổi
            dtpkNgaySinh.MinDate = DateTime.Now.AddYears(-65);
        }

        private void SetupListView()
        {
            lvGiaoVien.View = View.Details;
            lvGiaoVien.FullRowSelect = true;
            lvGiaoVien.GridLines = true;
            lvGiaoVien.MultiSelect = false;

            // Xóa các cột cũ nếu có
            lvGiaoVien.Columns.Clear();

            // Thêm các cột hiển thị
            lvGiaoVien.Columns.Add("Mã GV", 100);
            lvGiaoVien.Columns.Add("Họ và tên", 180);
            lvGiaoVien.Columns.Add("Giới tính", 80);
            lvGiaoVien.Columns.Add("Ngày sinh", 100);
            lvGiaoVien.Columns.Add("SĐT", 100);
            lvGiaoVien.Columns.Add("Email", 180);
            lvGiaoVien.Columns.Add("Địa chỉ", 200);
        }

        private void lvGiaoVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvGiaoVien.SelectedItems.Count == 0)
                return;

            var selected = lvGiaoVien.SelectedItems[0];
            string maGV = selected.SubItems[0].Text;

            var gv = context.GiaoViens.FirstOrDefault(x => x.MaGV == maGV);
            if (gv == null)
                return;

            txtmaGV.Text = gv.MaGV;
            txtHoTen.Text = gv.HoTen;
            cbbGioiTinh.SelectedItem = gv.GioiTinh ? "Nam" : "Nữ";
            dtpkNgaySinh.Value = gv.NgaySinh;
            txtSDT.Text = gv.Sdt;
            txtEmail.Text = gv.Email;
            txtDiaChi.Text = gv.DiaChi ?? "";

            //Cho phép hiển thị cả ngày nằm ngoài giới hạn Min/Max
            dtpkNgaySinh.MinDate = DateTimePicker.MinimumDateTime;
            dtpkNgaySinh.MaxDate = DateTimePicker.MaximumDateTime;
            dtpkNgaySinh.Value = gv.NgaySinh;

            // Sau khi hiển thị xong, đặt lại giới hạn để người dùng chọn hợp lệ
            dtpkNgaySinh.MinDate = DateTime.Now.AddYears(-65);
            dtpkNgaySinh.MaxDate = DateTime.Now.AddYears(-23);
        }

        public void Reload(object arg = null)
        {
            try
            {
                lvGiaoVien.Items.Clear();
                var list = context.GiaoViens.ToList();

                foreach (var gv in list)
                {
                    var item = new ListViewItem(gv.MaGV);
                    item.SubItems.Add(gv.HoTen);
                    item.SubItems.Add(gv.GioiTinh ? "Nam" : "Nữ");
                    item.SubItems.Add(gv.NgaySinh.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(gv.Sdt);
                    item.SubItems.Add(gv.Email);
                    item.SubItems.Add(gv.DiaChi ?? "");

                    lvGiaoVien.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách giáo viên:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                    string.IsNullOrWhiteSpace(txtSDT.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    cbbGioiTinh.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool tonTai = context.GiaoViens.Any(gv => gv.Sdt == txtSDT.Text || gv.Email == txtEmail.Text);
                if (tonTai)
                {
                    MessageBox.Show("Giáo viên có số điện thoại hoặc email này đã tồn tại!",
                                    "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maGV = GetIDForDatabase.getIDNextGiaoVien();

                var newGV = new GiaoVien
                {
                    MaGV = maGV,
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = (cbbGioiTinh.SelectedItem.ToString() == "Nam"),
                    NgaySinh = dtpkNgaySinh.Value.Date,
                    Sdt = txtSDT.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim()
                };

                context.GiaoViens.Add(newGV);
                context.SaveChanges();

                Reload();
                txtmaGV.Text = GetIDForDatabase.getIDNextGiaoVien();
                MessageBox.Show("Thêm giáo viên thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnClear.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm giáo viên:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtmaGV.Text = GetIDForDatabase.getIDNextGiaoVien();
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            int namSinh = DateTime.Now.Year - 24;
            DateTime ngayMacDinh = new DateTime(namSinh, 1, 1);
            dtpkNgaySinh.Value = ngayMacDinh;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtmaGV.Text))
                {
                    MessageBox.Show("Vui lòng chọn giáo viên cần sửa!", "Thiếu thông tin",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Đảm bảo không còn state Deleted treo từ lần xóa lỗi trước
                ClearTracker();

                var gv = context.GiaoViens.FirstOrDefault(x => x.MaGV == txtmaGV.Text);
                if (gv == null)
                {
                    MessageBox.Show("Không tìm thấy giáo viên cần sửa!", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                gv.HoTen = txtHoTen.Text.Trim();
                gv.GioiTinh = (cbbGioiTinh.SelectedItem?.ToString() == "Nam");
                gv.NgaySinh = dtpkNgaySinh.Value.Date;
                gv.Sdt = txtSDT.Text.Trim();
                gv.Email = txtEmail.Text.Trim();
                gv.DiaChi = txtDiaChi.Text.Trim();

                context.SaveChanges();
                Reload();

                MessageBox.Show("Cập nhật thông tin giáo viên thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DbUpdateException ex)
            {
                ClearTracker();
                MessageBox.Show("Không thể cập nhật. Kiểm tra lại dữ liệu (trùng email/sđt hoặc ràng buộc khác).",
                                "Cập nhật thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi sửa giáo viên:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtmaGV.Text))
                {
                    MessageBox.Show("Vui lòng chọn giáo viên cần xóa!", "Thiếu thông tin",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var gv = context.GiaoViens.FirstOrDefault(x => x.MaGV == txtmaGV.Text);
                if (gv == null)
                {
                    MessageBox.Show("Không tìm thấy giáo viên cần xóa!", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa giáo viên {gv.HoTen}?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                context.GiaoViens.Remove(gv);
                context.SaveChanges();

                Reload();
                btnClear.PerformClick();
                MessageBox.Show("Xóa giáo viên thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DbUpdateException)
            {
                // Xóa thất bại do ràng buộc FK → rollback state và báo rõ lý do
                ClearTracker();
                MessageBox.Show("Không thể xóa vì giáo viên đang được tham chiếu ở bảng khác (phân công giảng dạy, lớp, ...).",
                                "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi xóa giáo viên:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearTracker()
        {
            foreach (var e in context.ChangeTracker.Entries().ToList())
                e.State = EntityState.Detached;
        }
    }
}
