using QuanLyHocSinhTruongPhoThong.Models;
using QuanLyHocSinhTruongPhoThong.Views.Dialog;
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

                string email = string.IsNullOrEmpty(txtEmail.Text) ? null : txtEmail.Text.Trim();
                string sdt = txtSDT.Text.Trim();

                bool tonTai;
                if (!string.IsNullOrEmpty(email))
                    tonTai = context.HocSinhs.Any(hs => hs.Sdt == sdt || hs.Email == email);
                else
                    tonTai = context.HocSinhs.Any(hs => hs.Sdt == sdt);

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
                    GioiTinh = (cbbGioiTinh.SelectedItem.ToString() == "Nam") ? true : false,
                    NgaySinh = dtpkNgaySinh.Value.Date,
                    Sdt = sdt,
                    Email = email,
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

                string email = string.IsNullOrEmpty(txtEmail.Text) ? null : txtEmail.Text.Trim();
                string sdt = txtSDT.Text.Trim();

                bool trungThongTinKhac;
                if (!string.IsNullOrEmpty(email))
                    trungThongTinKhac = context.HocSinhs.Any(x =>
                        x.MaHS != hs.MaHS && (x.Sdt == sdt || x.Email == email));
                else
                    trungThongTinKhac = context.HocSinhs.Any(x =>
                        x.MaHS != hs.MaHS && x.Sdt == sdt);

                if (trungThongTinKhac)
                {
                    MessageBox.Show("SĐT hoặc Email đã được dùng bởi học sinh khác!",
                                    "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                hs.HoTen = txtHoTen.Text.Trim();
                hs.GioiTinh = (cbbGioiTinh.SelectedItem.ToString() == "Nam") ? true : false;
                hs.NgaySinh = dtpkNgaySinh.Value.Date;
                hs.Sdt = sdt;
                hs.Email = email;
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
            try
            {
                if (lvPH.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một phụ huynh từ danh sách!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtmaHS.Text))
                {
                    MessageBox.Show("Vui lòng chọn học sinh cần gán phụ huynh!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selected = lvPH.SelectedItems[0];
                string maPH = selected.SubItems[0].Text;
                var ph = context.PhuHuynhs.FirstOrDefault(p => p.MaPH == maPH);
                if (ph == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin phụ huynh!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Gợi ý mặc định quan hệ dựa theo giới tính
                string goiY = ph.GioiTinh ? "Cha" : "Mẹ";

                using (var form = new QuanHe(goiY))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.Cancel)
                        return;

                    string quanHe = form.SelectedQuanHe;
                    string maHS = txtmaHS.Text.Trim();

                    bool tonTai = context.HocSinh_PhuHuynh
                        .Any(x => x.MaHS == maHS && x.MaPH == maPH);
                    if (tonTai)
                    {
                        MessageBox.Show("Phụ huynh này đã được gán cho học sinh!",
                                        "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var hsph = new HocSinh_PhuHuynh
                    {
                        MaHS = maHS,
                        MaPH = maPH,
                        QuanHe = quanHe
                    };

                    context.HocSinh_PhuHuynh.Add(hsph);
                    context.SaveChanges();

                    MessageBox.Show($"Đã gán phụ huynh {ph.HoTen} làm \"{quanHe}\" cho học sinh {maHS}",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi gán phụ huynh cho học sinh:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
            {
                if (string.IsNullOrWhiteSpace(txtmaHS.Text))
                {
                    MessageBox.Show("Vui lòng chọn học sinh!", "Thiếu thông tin",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (lvPH.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một phụ huynh từ danh sách!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selected = lvPH.SelectedItems[0];
                string maPH = selected.SubItems[0].Text;
                string maHS = txtmaHS.Text.Trim();

                var quanHe = context.HocSinh_PhuHuynh
                    .FirstOrDefault(x => x.MaHS == maHS && x.MaPH == maPH);

                if (quanHe == null)
                {
                    MessageBox.Show("Phụ huynh này chưa có quan hệ với học sinh được chọn!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string tenPH = context.PhuHuynhs.FirstOrDefault(x => x.MaPH == maPH)?.HoTen ?? "(không rõ)";
                string tenHS = context.HocSinhs.FirstOrDefault(x => x.MaHS == maHS)?.HoTen ?? "(không rõ)";
                string loaiQuanHe = quanHe.QuanHe ?? "Giám hộ";

                var confirm = MessageBox.Show(
                    $"Bạn có chắc muốn xóa quan hệ \"{loaiQuanHe}\" giữa học sinh \"{tenHS}\" và phụ huynh \"{tenPH}\" không?",
                    "Xác nhận xóa quan hệ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm != DialogResult.Yes)
                    return;

                context.HocSinh_PhuHuynh.Remove(quanHe);
                context.SaveChanges();

                MessageBox.Show("Đã xóa quan hệ phụ huynh–học sinh thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi xóa quan hệ phụ huynh–học sinh:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            cbbGioiTinh.Items.Clear();
            cbbGioiTinh.Items.Add("Nam");
            cbbGioiTinh.Items.Add("Nữ");

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

        private void lvHS_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lvHS.SelectedItems.Count == 0)
                    return;

                var selected = lvHS.SelectedItems[0];
                string maHS = selected.SubItems[0].Text;

                var hs = context.HocSinhs.FirstOrDefault(x => x.MaHS == maHS);
                if (hs == null)
                    return;

                txtmaHS.Text = hs.MaHS;
                txtHoTen.Text = hs.HoTen;
                cbbGioiTinh.SelectedItem = hs.GioiTinh ? "Nam" : "Nữ";

                dtpkNgaySinh.MinDate = DateTimePicker.MinimumDateTime;
                dtpkNgaySinh.MaxDate = DateTimePicker.MaximumDateTime;
                dtpkNgaySinh.Value = hs.NgaySinh;

                // Sau khi gán xong thì đặt lại giới hạn chọn hợp lệ (10–70 tuổi)
                dtpkNgaySinh.MinDate = DateTime.Today.AddYears(-70);
                dtpkNgaySinh.MaxDate = DateTime.Today.AddYears(-10);

                txtSDT.Text = hs.Sdt;
                txtEmail.Text = hs.Email ?? "";
                txtDiaChi.Text = hs.DiaChi ?? "";

                // Gán lại combobox lớp
                if (cbbMaLop.Items.Contains(hs.MaLop))
                    cbbMaLop.SelectedItem = hs.MaLop;
                else
                    cbbMaLop.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị thông tin học sinh:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
