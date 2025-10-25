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
    public partial class HocSinh_UC : UserControl,IReloadable
    {
        public AppDbContext context = new AppDbContext();

        public HocSinh_UC()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearTracker();

                txtmaHS.Text = GetIDForDatabase.getIDNextHocSinh();
                txtHoTen.Clear();
                txtSDT.Clear();
                txtEmail.Clear();
                txtDiaChi.Clear();

                cbbGioiTinh.SelectedIndex = -1;
                cbbMaLop.SelectedIndex = -1;

                int defaultAge = 15;
                dtpkNgaySinh.Value = new DateTime(DateTime.Today.Year - defaultAge, 1, 1);

                lvHS.SelectedItems.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới biểu mẫu:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                    string.IsNullOrWhiteSpace(txtSDT.Text) ||
                    cbbGioiTinh.SelectedIndex < 0 ||
                    string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                    cbbMaLop.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool tonTai = context.HocSinhs.Any(hs =>
                    hs.Sdt == txtSDT.Text.Trim() ||
                    (!string.IsNullOrWhiteSpace(txtEmail.Text) && hs.Email == txtEmail.Text.Trim())
                );
                if (tonTai)
                {
                    MessageBox.Show("Đã tồn tại học sinh với SĐT hoặc Email này!",
                                    "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maHS = GetIDForDatabase.getIDNextHocSinh();

                var newHS = new HocSinh
                {
                    MaHS = maHS,
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = (cbbGioiTinh.SelectedItem.ToString() == "Nam"),
                    NgaySinh = dtpkNgaySinh.Value.Date,
                    Sdt = txtSDT.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    MaLop = cbbMaLop.SelectedItem.ToString()
                };

                context.HocSinhs.Add(newHS);
                context.SaveChanges();

                Reload();
                MessageBox.Show("Thêm học sinh thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear_Click(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi thêm học sinh:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtmaHS.Text))
                {
                    MessageBox.Show("Vui lòng chọn học sinh cần sửa!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClearTracker();

                var hs = context.HocSinhs.FirstOrDefault(x => x.MaHS == txtmaHS.Text.Trim());
                if (hs == null)
                {
                    MessageBox.Show("Không tìm thấy học sinh cần sửa!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                    string.IsNullOrWhiteSpace(txtSDT.Text) ||
                    cbbGioiTinh.SelectedIndex < 0 ||
                    string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                    cbbMaLop.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool trungThongTinKhac = context.HocSinhs.Any(x =>
                    x.MaHS != hs.MaHS &&
                    (x.Sdt == txtSDT.Text.Trim() ||
                     (!string.IsNullOrWhiteSpace(txtEmail.Text) && x.Email == txtEmail.Text.Trim()))
                );
                if (trungThongTinKhac)
                {
                    MessageBox.Show("SĐT hoặc Email đã được dùng bởi học sinh khác!",
                                    "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                hs.HoTen = txtHoTen.Text.Trim();
                hs.GioiTinh = (cbbGioiTinh.SelectedItem?.ToString() == "Nam");
                hs.NgaySinh = dtpkNgaySinh.Value.Date;
                hs.Sdt = txtSDT.Text.Trim();
                hs.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
                hs.DiaChi = txtDiaChi.Text.Trim();
                hs.MaLop = cbbMaLop.SelectedItem.ToString();

                context.SaveChanges();
                Reload();
                MessageBox.Show("Cập nhật học sinh thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                ClearTracker();
                MessageBox.Show("Không thể cập nhật do ràng buộc dữ liệu. Vui lòng kiểm tra lại!",
                                "Cập nhật thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi sửa học sinh:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnChonGD_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtmaHS.Text))
                {
                    MessageBox.Show("Vui lòng chọn học sinh cần xóa!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var hs = context.HocSinhs.FirstOrDefault(x => x.MaHS == txtmaHS.Text.Trim());
                if (hs == null)
                {
                    MessageBox.Show("Không tìm thấy học sinh cần xóa!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa học sinh {hs.HoTen}?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                context.HocSinhs.Remove(hs);
                context.SaveChanges();

                Reload();
                MessageBox.Show("Xóa học sinh thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear_Click(null, EventArgs.Empty);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                ClearTracker();
                MessageBox.Show("Không thể xóa vì học sinh đang được tham chiếu ở bảng khác (PH, bảng điểm, khen thưởng, ...).",
                                "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi xóa học sinh:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnGD_Click(object sender, EventArgs e)
        {

        }

        private void LoadHocSinh()
        {
            try
            {
                lvHS.Items.Clear();
                var list = context.HocSinhs
                    .OrderBy(hs => hs.MaHS)
                    .ToList();

                foreach (var hs in list)
                {
                    var item = new ListViewItem(hs.MaHS);
                    item.SubItems.Add(hs.HoTen);
                    item.SubItems.Add(hs.GioiTinh ? "Nam" : "Nữ");
                    item.SubItems.Add(hs.NgaySinh.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(hs.Sdt);
                    item.SubItems.Add(hs.Email ?? "");
                    item.SubItems.Add(hs.DiaChi);
                    item.SubItems.Add(hs.MaLop);

                    lvHS.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách học sinh:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetupListViewHocSinh()
        {
            lvHS.View = View.Details;
            lvHS.FullRowSelect = true;
            lvHS.GridLines = true;
            lvHS.MultiSelect = false;

            lvHS.Columns.Clear();
            lvHS.Columns.Add("Mã HS", 80);
            lvHS.Columns.Add("Họ và tên", 180);
            lvHS.Columns.Add("Giới tính", 80);
            lvHS.Columns.Add("Ngày sinh", 100);
            lvHS.Columns.Add("SĐT", 100);
            lvHS.Columns.Add("Email", 180);
            lvHS.Columns.Add("Địa chỉ", 200);
            lvHS.Columns.Add("Mã lớp", 80);
        }
        private void LoadPhuHuynh()
        {
            try
            {
                lvPH.Items.Clear();
                var list = context.PhuHuynhs
                    .OrderBy(ph => ph.MaPH)
                    .ToList();

                foreach (var ph in list)
                {
                    var item = new ListViewItem(ph.MaPH);
                    item.SubItems.Add(ph.HoTen);
                    item.SubItems.Add(ph.GioiTinh ? "Nam" : "Nữ");
                    item.SubItems.Add(ph.NgaySinh.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(ph.Sdt);
                    item.SubItems.Add(ph.Email ?? "");
                    item.SubItems.Add(ph.DiaChi ?? "");

                    lvPH.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phụ huynh:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetupListViewPhuHuynh()
        {
            lvPH.View = View.Details;
            lvPH.FullRowSelect = true;
            lvPH.GridLines = true;
            lvPH.MultiSelect = false;

            lvPH.Columns.Clear();
            lvPH.Columns.Add("Mã PH", 80);
            lvPH.Columns.Add("Họ và tên", 180);
            lvPH.Columns.Add("Giới tính", 80);
            lvPH.Columns.Add("Ngày sinh", 100);
            lvPH.Columns.Add("SĐT", 100);
            lvPH.Columns.Add("Email", 180);
            lvPH.Columns.Add("Địa chỉ", 200);
        }

        private void ConfigNgaySinhHocSinh()
        {
            dtpkNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpkNgaySinh.CustomFormat = "dd/MM/yyyy";

            const int MIN_AGE = 10; // trẻ nhất 10 tuổi
            const int MAX_AGE = 70; // lớn nhất 70 tuổi

            dtpkNgaySinh.MaxDate = DateTime.Today.AddYears(-MIN_AGE);
            dtpkNgaySinh.MinDate = DateTime.Today.AddYears(-MAX_AGE);

            int defaultAge = 15; // tuổi mặc định hợp lý
            dtpkNgaySinh.Value = new DateTime(DateTime.Today.Year - defaultAge, 1, 1);
        }

        private void HocSinh_UC_Load(object sender, EventArgs e)
        {
            var listLop = GetListForDatabase.getListLop();
            cbbMaLop.Items.Clear();
            cbbMaLop.Items.AddRange(listLop.Select(l => l.MaLop).Cast<object>().ToArray());

            ConfigNgaySinhHocSinh();
            SetupListViewHocSinh();
            SetupListViewPhuHuynh();
            Reload();
        }

        public void Reload(object arg = null)
        {

            LoadHocSinh();
            LoadPhuHuynh();
        }
        private void ClearTracker()
        {
            foreach (var e in context.ChangeTracker.Entries().ToList())
                e.State = EntityState.Detached;
        }
    }
}
