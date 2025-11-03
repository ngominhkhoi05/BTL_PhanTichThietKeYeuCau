using QuanLyHocSinhTruongPhoThong.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinhTruongPhoThong.Views.Admins
{
    public partial class TaiKhoan_UC : UserControl
    {
        public TaiKhoan_UC()
        {
            InitializeComponent();
        }
        public AppDbContext context=new AppDbContext();
        private void SetupListViewTaiKhoan()
        {
            lvTaiKhoan.Items.Clear();
            lvTaiKhoan.Columns.Clear();

            lvTaiKhoan.View = View.Details;
            lvTaiKhoan.FullRowSelect = true;
            lvTaiKhoan.GridLines = true;

            lvTaiKhoan.Columns.Add("Mã TK", 100);
            lvTaiKhoan.Columns.Add("Tên đăng nhập", 120);
            lvTaiKhoan.Columns.Add("Tên hiển thị", 150);
            lvTaiKhoan.Columns.Add("Email", 150);
            lvTaiKhoan.Columns.Add("Giáo viên", 150);
            lvTaiKhoan.Columns.Add("Trạng thái", 80);
            lvTaiKhoan.Columns.Add("Vai trò", 200);
        }
        private void LoadComboBoxRoles()
        {
            try
            {
                var roleList = context.Roles
                                    .OrderBy(r => r.RoleName)
                                    .ToList();

                cbbRole.DataSource = roleList;
                cbbRole.DisplayMember = "RoleName";
                cbbRole.ValueMember = "RoleId";    
                cbbRole.SelectedIndex = -1; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách vai trò: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadComboBoxGiaoVien()
        {
            try
            {
                var giaoVienList = context.GiaoViens
                                        .OrderBy(gv => gv.HoTen)
                                        .Select(gv => new { gv.MaGV, gv.HoTen })
                                        .ToList();

                var displayList = new List<object>
            {
                new { MaGV = (string)null, HoTen = "— Không liên kết GV —" }
            };

                displayList.AddRange(giaoVienList);

                cbbGiaoVien.DataSource = displayList;
                cbbGiaoVien.DisplayMember = "HoTen";
                cbbGiaoVien.ValueMember = "MaGV";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách giáo viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDanhSachTaiKhoan()
        {
            lvTaiKhoan.Items.Clear(); 
            try
            {
                string currentUserId = CurrentUser.AccountId;

                var accounts = context.Accounts
                                      .Include("GiaoVien")
                                      .Include("Roles")    
                                      .Where(a => a.AccountId != currentUserId)
                                      .OrderBy(a => a.Username)
                                      .ToList();

                foreach (var acc in accounts)
                {
                    ListViewItem lvi = new ListViewItem(acc.AccountId);

                    lvi.SubItems.Add(acc.Username);

                    lvi.SubItems.Add(acc.DisplayName);

                    lvi.SubItems.Add(acc.Email ?? "");

                    lvi.SubItems.Add(acc.GiaoVien?.HoTen ?? "N/A");

                    lvi.SubItems.Add(acc.IsActive == true ? "Hoạt động" : "Bị khóa");

                    string roles = string.Join(", ", acc.Roles
                                                        .Select(r => r.RoleName));
                    lvi.SubItems.Add(roles);

                    lvi.Tag = acc;

                    lvTaiKhoan.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
        private void TaiKhoan_UC_Load(object sender, EventArgs e)
        {
            SetupListViewTaiKhoan();
            LoadComboBoxRoles();
            LoadComboBoxGiaoVien();
            LoadDanhSachTaiKhoan();
            dtpkCreatedAt.Format = DateTimePickerFormat.Custom;
            dtpkCreatedAt.CustomFormat = "dd/MM/yyyy";

            this.txtDisplayName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Event.TextBox_KhongNhapSo_KeyPress);
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(Event.TextBox_Email_Validating);

            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Event.TextBox_KhongNhapKyTuDacBiet_KeyPress);
        }

        private void lvTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTaiKhoan.SelectedItems.Count == 0)
            {
                return;
            }
            ListViewItem selectedItem = lvTaiKhoan.SelectedItems[0];
            Account selectedAccount = selectedItem.Tag as Account;

            if (selectedAccount == null)
            {
                MessageBox.Show("Không thể lấy dữ liệu chi tiết của tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtAccountId.Text = selectedAccount.AccountId;
            txtUsername.Text = selectedAccount.Username;
            txtDisplayName.Text = selectedAccount.DisplayName ?? ""; 
            txtEmail.Text = selectedAccount.Email ?? "";

            txtPassword.Text = "";

            chkActive.Checked = selectedAccount.IsActive == true;

            if (selectedAccount.CreatedAt.HasValue)
            {
                dtpkCreatedAt.Value = selectedAccount.CreatedAt.Value;
            }
            else
            {
                dtpkCreatedAt.Value = DateTime.Now;
            }

            if (selectedAccount.MaGV == null)
            {
                cbbGiaoVien.SelectedIndex = 0;
            }
            else
            {
                cbbGiaoVien.SelectedValue = selectedAccount.MaGV;
            }

            var firstRole = selectedAccount.Roles.FirstOrDefault();
            if (firstRole != null)
            {
                cbbRole.SelectedValue = firstRole.RoleId;
            }
            else
            {
                cbbRole.SelectedIndex = -1;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập Mật khẩu cho tài khoản mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (cbbRole.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Vai trò cho tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbRole.Focus();
                return;
            }

            try
            {
                if (context.Accounts.Any(a => a.Username == username))
                {
                    MessageBox.Show("Tên đăng nhập này đã tồn tại. Vui lòng chọn tên khác.", "Trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                    return;
                }

                string selectedRoleId = cbbRole.SelectedValue.ToString();
                var roleToAdd = context.Roles.Find(selectedRoleId);
                if (roleToAdd == null)
                {
                    MessageBox.Show("Vai trò được chọn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Account newAccount = new Account
                {
                    AccountId = txtAccountId.Text, 
                    Username = username,
                    PasswordHash = HashPassword(password), 
                    DisplayName = txtDisplayName.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    IsActive = chkActive.Checked,
                    CreatedAt = DateTime.Now,
                    MaGV = cbbGiaoVien.SelectedValue as string
                };

                newAccount.Roles.Add(roleToAdd);

                context.Accounts.Add(newAccount);
                context.SaveChanges();

                MessageBox.Show("Thêm tài khoản mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachTaiKhoan(); 
                btnClear_Click(null, null); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn khi thêm: {ex.Message}", "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAccountId.Text = GetIDForDatabase.getIDNextAccount();

            txtUsername.Text = "";
            txtPassword.Text = "";
            txtDisplayName.Text = "";
            txtEmail.Text = "";

            chkActive.Checked = true; 
            dtpkCreatedAt.Value = DateTime.Now; 
            cbbRole.SelectedIndex = 0;
            cbbGiaoVien.SelectedIndex = 0; 

            lvTaiKhoan.SelectedItems.Clear();

            txtAccountId.ReadOnly = true;
            txtUsername.ReadOnly = false;
            txtUsername.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvTaiKhoan.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản từ danh sách để xóa.", "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Account accountToDelete = lvTaiKhoan.SelectedItems[0].Tag as Account;
            if (accountToDelete == null)
            {
                MessageBox.Show("Không lấy được thông tin tài khoản, vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (accountToDelete.AccountId == CurrentUser.AccountId)
            {
                MessageBox.Show("Bạn không thể tự xóa tài khoản của chính mình.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa tài khoản '{accountToDelete.Username}' (Tên hiển thị: {accountToDelete.DisplayName}) không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var accountInDb = context.Accounts.Find(accountToDelete.AccountId);
                    if (accountInDb != null)
                    {
                        context.Accounts.Remove(accountInDb);
                        context.SaveChanges();

                        MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachTaiKhoan();
                        btnClear_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tài khoản (có thể đã bị xóa bởi người khác).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadDanhSachTaiKhoan();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa tài khoản: {ex.Message}\n\n(Có thể tài khoản này vẫn còn dữ liệu liên quan không thể xóa.)", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvTaiKhoan.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản từ danh sách để sửa.", "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string accountIdToUpdate = txtAccountId.Text;

            if (accountIdToUpdate == CurrentUser.AccountId)
            {
                MessageBox.Show("Không thể tự sửa thông tin tài khoản của chính mình tại đây.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = txtUsername.Text.Trim();
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Tên đăng nhập không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }
            if (cbbRole.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Vai trò cho tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbRole.Focus();
                return;
            }

            try
            {
                var accountInDb = context.Accounts
                                         .Include("Roles")
                                         .FirstOrDefault(a => a.AccountId == accountIdToUpdate);

                if (accountInDb == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản này trong CSDL (có thể đã bị xóa).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadDanhSachTaiKhoan();
                    return;
                }

                if (context.Accounts.Any(a => a.Username == username && a.AccountId != accountIdToUpdate))
                {
                    MessageBox.Show("Tên đăng nhập này đã tồn tại. Vui lòng chọn tên khác.", "Trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                    return;
                }

                accountInDb.Username = username;
                accountInDb.DisplayName = txtDisplayName.Text.Trim();
                accountInDb.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
                accountInDb.IsActive = chkActive.Checked;
                accountInDb.MaGV = cbbGiaoVien.SelectedValue as string;

                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    accountInDb.PasswordHash = txtPassword.Text;
                }

                accountInDb.Roles.Clear();
                string selectedRoleId = cbbRole.SelectedValue.ToString();
                var newRole = context.Roles.Find(selectedRoleId);
                if (newRole != null)
                {
                    accountInDb.Roles.Add(newRole);
                }

                context.SaveChanges();

                MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachTaiKhoan();
                btnClear_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn khi cập nhật: {ex.Message}", "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (lvTaiKhoan.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản từ danh sách để đặt lại mật khẩu.", "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Account accountToReset = lvTaiKhoan.SelectedItems[0].Tag as Account;
            if (accountToReset == null)
            {
                MessageBox.Show("Không lấy được thông tin tài khoản, vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (accountToReset.AccountId == CurrentUser.AccountId)
            {
                MessageBox.Show("Bạn không thể tự đặt lại mật khẩu của chính mình.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string newDefaultPassword = "123456"; 

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn đặt lại mật khẩu cho tài khoản '{accountToReset.Username}'?\n\n" +
                $"Mật khẩu mới sẽ được đặt về mặc định là: {newDefaultPassword}",
                "Xác nhận đặt lại mật khẩu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.No)
            {
                return;
            }

            try
            {
                var accountInDb = context.Accounts.Find(accountToReset.AccountId);
                if (accountInDb == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản (có thể đã bị xóa).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadDanhSachTaiKhoan(); 
                    return;
                }

                accountInDb.PasswordHash = HashPassword(newDefaultPassword);

                context.SaveChanges();

                MessageBox.Show(
                    $"Đặt lại mật khẩu cho tài khoản '{accountInDb.Username}' thành công!\n\n" +
                    $"Mật khẩu mới là: {newDefaultPassword}\n\n" +
                    "Vui lòng thông báo cho người dùng để họ đổi lại mật khẩu sau khi đăng nhập.",
                    "Hoàn tất",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                btnClear_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn khi đặt lại mật khẩu: {ex.Message}", "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
