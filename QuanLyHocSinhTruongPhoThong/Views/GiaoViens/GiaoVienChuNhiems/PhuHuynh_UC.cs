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
    public partial class PhuHuynh_UC : UserControl,IReloadable
    {
        public PhuHuynh_UC()
        {
            InitializeComponent();
        }
        private void ClearTracker()
        {
            foreach (var entry in GetListForDatabase.context.ChangeTracker.Entries().ToList())
                entry.State = System.Data.Entity.EntityState.Detached;
        }

        private void PhuHuynh_UC_Load(object sender, EventArgs e)
        {
            cbbGioiTinh.Items.Clear();
            cbbGioiTinh.Items.Add("Nam");
            cbbGioiTinh.Items.Add("Nữ");
            SetupListViewPhuHuynh();
            SetupListViewHocSinh();
            LoadPhuHuynh();
            LoadHocSinh();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                    string.IsNullOrWhiteSpace(txtSDT.Text) ||
                    cbbGioiTinh.SelectedIndex < 0 ||
                    string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maPH = GetIDForDatabase.getIDNextPhuHuynh();
                string sdt = txtSDT.Text.Trim();
                string email = txtEmail.Text.Trim();

                // Kiểm tra trùng sđt hoặc email
                bool tonTai = GetListForDatabase.context.PhuHuynhs
                    .Any(ph => ph.Sdt == sdt || ph.Email == email);
                if (tonTai)
                {
                    MessageBox.Show("Phụ huynh có số điện thoại hoặc email này đã tồn tại!",
                                    "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newPH = new PhuHuynh
                {
                    MaPH = maPH,
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = (cbbGioiTinh.SelectedItem.ToString() == "Nam"),
                    NgaySinh = dtpkNgaySinh.Value.Date,
                    Sdt = sdt,
                    Email = email,
                    DiaChi = txtDiaChi.Text.Trim()
                };

                GetListForDatabase.context.PhuHuynhs.Add(newPH);
                GetListForDatabase.context.SaveChanges();
                ClearTracker();

                LoadPhuHuynh();
                MessageBox.Show("Thêm phụ huynh thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnClear_Click(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi thêm phụ huynh:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string maPH = txtmaPH.Text.Trim();
                if (string.IsNullOrWhiteSpace(maPH))
                {
                    MessageBox.Show("Vui lòng chọn phụ huynh cần sửa!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ClearTracker();

                var ph = GetListForDatabase.context.PhuHuynhs
                    .FirstOrDefault(x => x.MaPH == maPH);
                if (ph == null)
                {
                    MessageBox.Show("Không tìm thấy phụ huynh cần sửa!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                    string.IsNullOrWhiteSpace(txtSDT.Text) ||
                    cbbGioiTinh.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sdt = txtSDT.Text.Trim();
                string email = txtEmail.Text.Trim();

                bool trungThongTin = GetListForDatabase.context.PhuHuynhs
                    .Any(x => x.MaPH != maPH && (x.Sdt == sdt || x.Email == email));
                if (trungThongTin)
                {
                    MessageBox.Show("Số điện thoại hoặc email đã được sử dụng bởi phụ huynh khác!",
                                    "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ph.HoTen = txtHoTen.Text.Trim();
                ph.GioiTinh = (cbbGioiTinh.SelectedItem.ToString() == "Nam");
                ph.NgaySinh = dtpkNgaySinh.Value.Date;
                ph.Sdt = sdt;
                ph.Email = email;
                ph.DiaChi = txtDiaChi.Text.Trim();

                GetListForDatabase.context.SaveChanges();
                ClearTracker();

                LoadPhuHuynh();
                MessageBox.Show("Cập nhật phụ huynh thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi sửa phụ huynh:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnChonCon_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtmaPH.Text))
                {
                    MessageBox.Show("Vui lòng chọn phụ huynh cần gán học sinh!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maPH = txtmaPH.Text.Trim();

                if (lvHS.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một học sinh từ danh sách!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selected = lvHS.SelectedItems[0];
                string maHS = selected.SubItems[0].Text;
                string tenHS = selected.SubItems[1].Text;

                var ph = GetListForDatabase.context.PhuHuynhs.FirstOrDefault(x => x.MaPH == maPH);
                if (ph == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin phụ huynh!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string goiY = ph.GioiTinh ? "Cha" : "Mẹ";

                using (var form = new QuanHe(goiY))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.Cancel)
                        return;

                    string quanHe = form.SelectedQuanHe;

                    bool tonTai = GetListForDatabase.context.HocSinh_PhuHuynh
                        .Any(x => x.MaHS == maHS && x.MaPH == maPH);
                    if (tonTai)
                    {
                        MessageBox.Show("Phụ huynh này đã được gán cho học sinh này!",
                                        "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var hsph = new HocSinh_PhuHuynh
                    {
                        MaHS = maHS,
                        MaPH = maPH,
                        QuanHe = quanHe
                    };

                    GetListForDatabase.context.HocSinh_PhuHuynh.Add(hsph);
                    GetListForDatabase.context.SaveChanges();

                    MessageBox.Show($"Đã gán phụ huynh {ph.HoTen} làm \"{quanHe}\" của học sinh {tenHS}",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi gán học sinh cho phụ huynh:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string maPH = txtmaPH.Text.Trim();
                if (string.IsNullOrWhiteSpace(maPH))
                {
                    MessageBox.Show("Vui lòng chọn phụ huynh cần xóa!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var ph = GetListForDatabase.context.PhuHuynhs
                    .FirstOrDefault(x => x.MaPH == maPH);
                if (ph == null)
                {
                    MessageBox.Show("Không tìm thấy phụ huynh cần xóa!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa phụ huynh {ph.HoTen} ({maPH})?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                    return;

                GetListForDatabase.context.PhuHuynhs.Remove(ph);
                GetListForDatabase.context.SaveChanges();
                ClearTracker();

                LoadPhuHuynh();
                btnClear_Click(null, EventArgs.Empty);

                MessageBox.Show("Xóa phụ huynh thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                ClearTracker();
                MessageBox.Show("Không thể xóa vì phụ huynh này đang được liên kết với học sinh!",
                                "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi xóa phụ huynh:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtmaPH.Text = GetIDForDatabase.getIDNextPhuHuynh();
                txtHoTen.Clear();
                txtSDT.Clear();
                txtEmail.Clear();
                txtDiaChi.Clear();

                cbbGioiTinh.SelectedIndex = 0;
                dtpkNgaySinh.Value = new DateTime(DateTime.Now.Year - 40, 1, 1); 
                lvPH.SelectedItems.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới form phụ huynh:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadPhuHuynh()
        {
            lvPH.Items.Clear();
            var list = GetListForDatabase.context.PhuHuynhs.OrderBy(x => x.MaPH).ToList();

            foreach (var ph in list)
            {
                var item = new ListViewItem(ph.MaPH);
                item.SubItems.Add(ph.HoTen);
                item.SubItems.Add(ph.GioiTinh ? "Nam" : "Nữ");
                item.SubItems.Add(ph.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(ph.Sdt);
                item.SubItems.Add(ph.Email);
                item.SubItems.Add(ph.DiaChi ?? "");
                lvPH.Items.Add(item);
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
            lvPH.Columns.Add("Họ và tên", 160);
            lvPH.Columns.Add("Giới tính", 80);
            lvPH.Columns.Add("Ngày sinh", 100);
            lvPH.Columns.Add("SĐT", 120);
            lvPH.Columns.Add("Email", 180);
            lvPH.Columns.Add("Địa chỉ", 200);
        }
        private void SetupListViewHocSinh()
        {
            lvHS.View = View.Details;
            lvHS.FullRowSelect = true;
            lvHS.GridLines = true;
            lvHS.MultiSelect = false;

            lvHS.Columns.Clear();

            lvHS.Columns.Add("Mã HS", 80);
            lvHS.Columns.Add("Họ và tên", 160);
            lvHS.Columns.Add("Giới tính", 80);
            lvHS.Columns.Add("Ngày sinh", 100);
            lvHS.Columns.Add("SĐT", 120);
            lvHS.Columns.Add("Email", 180);
            lvHS.Columns.Add("Địa chỉ", 200);
        }
        private void LoadHocSinh()
        {
            try
            {
                lvHS.Items.Clear();

                var listHS = GetListForDatabase.getListHocSinh();

                foreach (var hs in listHS)
                {
                    var item = new ListViewItem(hs.MaHS);
                    item.SubItems.Add(hs.HoTen);                          
                    item.SubItems.Add(hs.GioiTinh ? "Nam" : "Nữ");            
                    item.SubItems.Add(hs.NgaySinh.ToString("dd/MM/yyyy"));     
                    item.SubItems.Add(hs.Sdt);                                 
                    item.SubItems.Add(hs.Email ?? "");                         
                    item.SubItems.Add(hs.DiaChi ?? "");                      

                    lvHS.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách học sinh:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnBoCon_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtmaPH.Text))
                {
                    MessageBox.Show("Vui lòng chọn phụ huynh trước khi bỏ con!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maPH = txtmaPH.Text.Trim();

                if (lvHS.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn học sinh cần bỏ khỏi danh sách con!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selected = lvHS.SelectedItems[0];
                string maHS = selected.SubItems[0].Text;
                string tenHS = selected.SubItems[1].Text;

                var quanHe = GetListForDatabase.context.HocSinh_PhuHuynh
                    .FirstOrDefault(x => x.MaPH == maPH && x.MaHS == maHS);

                if (quanHe == null)
                {
                    MessageBox.Show($"Phụ huynh này chưa có quan hệ nào với học sinh {tenHS}.",
                                    "Không có quan hệ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa quan hệ \"{quanHe.QuanHe}\" giữa phụ huynh và học sinh {tenHS}?",
                                              "Xác nhận xóa quan hệ",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                GetListForDatabase.context.HocSinh_PhuHuynh.Remove(quanHe);
                GetListForDatabase.context.SaveChanges();
                ClearTracker();

                MessageBox.Show($"Đã bỏ quan hệ với học sinh {tenHS} thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ClearTracker();
                MessageBox.Show("Lỗi khi bỏ quan hệ phụ huynh - học sinh:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Reload(object arg = null)
        {
            
        }

        private void lvPH_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lvPH.SelectedItems.Count == 0)
                return;

            var item = lvPH.SelectedItems[0];
            txtmaPH.Text = item.SubItems[0].Text;
            txtHoTen.Text = item.SubItems[1].Text;
            cbbGioiTinh.SelectedItem = item.SubItems[2].Text;
            dtpkNgaySinh.Value = DateTime.ParseExact(item.SubItems[3].Text, "dd/MM/yyyy", null);
            txtSDT.Text = item.SubItems[4].Text;
            txtEmail.Text = item.SubItems[5].Text;
            txtDiaChi.Text = item.SubItems[6].Text;
        }
    }
}
