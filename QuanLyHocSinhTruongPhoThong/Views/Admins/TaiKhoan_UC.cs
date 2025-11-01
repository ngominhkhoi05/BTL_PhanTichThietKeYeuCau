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

            // Cấu hình ListView
            lvTaiKhoan.View = View.Details;
            lvTaiKhoan.FullRowSelect = true;
            lvTaiKhoan.GridLines = true;

            // Thêm các cột
            lvTaiKhoan.Columns.Add("Mã TK", 100);
            lvTaiKhoan.Columns.Add("Tên đăng nhập", 120);
            lvTaiKhoan.Columns.Add("Tên hiển thị", 150);
            lvTaiKhoan.Columns.Add("Email", 150);
            lvTaiKhoan.Columns.Add("Giáo viên", 150);
            lvTaiKhoan.Columns.Add("Trạng thái", 80);
            lvTaiKhoan.Columns.Add("Vai trò", 200);
        }

        /// <summary>
        /// Tải danh sách vai trò (Roles) vào ComboBox cbbRole
        /// </summary>
        private void LoadComboBoxRoles()
        {
            try
            {
                var roleList = context.Roles
                                    .OrderBy(r => r.RoleName)
                                    .ToList();

                // Gán dữ liệu cho ComboBox
                cbbRole.DataSource = roleList;
                cbbRole.DisplayMember = "RoleName"; // Hiển thị tên vai trò
                cbbRole.ValueMember = "RoleId";     // Giá trị là mã vai trò
                cbbRole.SelectedIndex = -1; // Không chọn gì lúc ban đầu
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách vai trò: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải danh sách giáo viên vào ComboBox cbbGiaoVien
        /// Thêm một mục "Không chọn" vì MaGV trong Account có thể là NULL.
        /// </summary>
        private void LoadComboBoxGiaoVien()
        {
            try
            {
                // Lấy danh sách giáo viên
                var giaoVienList = context.GiaoViens
                                        .OrderBy(gv => gv.HoTen)
                                        .Select(gv => new { gv.MaGV, gv.HoTen })
                                        .ToList();

                // Tạo một danh sách mới để thêm mục "Không chọn"
                // Kiểu dữ liệu 'object' (kiểu vô danh) để khớp với danh sách từ LINQ
                var displayList = new List<object>
            {
                // Thêm mục đầu tiên để xử lý trường hợp Account không liên kết với GV
                new { MaGV = (string)null, HoTen = "— Không liên kết GV —" }
            };

                // Thêm danh sách giáo viên thật vào
                displayList.AddRange(giaoVienList);

                // Gán dữ liệu cho ComboBox
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
            lvTaiKhoan.Items.Clear(); // Xóa dữ liệu cũ
            try
            {
                string currentUserId = CurrentUser.AccountId;

                var accounts = context.Accounts
                                      .Include("GiaoVien") // Tải thông tin giáo viên
                                      .Include("Roles")    // Tải danh sách vai trò liên kết
                                      .Where(a => a.AccountId != currentUserId)
                                      .OrderBy(a => a.Username)
                                      .ToList();

                // Duyệt qua từng tài khoản và thêm vào ListView
                foreach (var acc in accounts)
                {
                    // Cột 0: Mã TK
                    ListViewItem lvi = new ListViewItem(acc.AccountId);

                    // Cột 1: Tên đăng nhập
                    lvi.SubItems.Add(acc.Username);

                    // Cột 2: Tên hiển thị
                    lvi.SubItems.Add(acc.DisplayName);

                    // Cột 3: Email (kiểm tra null)
                    lvi.SubItems.Add(acc.Email ?? "");

                    // Cột 4: Tên giáo viên (kiểm tra null)
                    lvi.SubItems.Add(acc.GiaoVien?.HoTen ?? "N/A");

                    // Cột 5: Trạng thái (dùng toán tử 3 ngôi)
                    lvi.SubItems.Add(acc.IsActive == true ? "Hoạt động" : "Bị khóa");

                    // Cột 6: Lấy danh sách vai trò
                    // SỬA ĐỔI NẰM Ở ĐÂY:
                    // Truy cập trực tiếp vào collection 'acc.Roles' đã được Include
                    string roles = string.Join(", ", acc.Roles
                                                        .Select(r => r.RoleName)); // r ở đây chính là một đối tượng Role
                    lvi.SubItems.Add(roles);

                    // Lưu đối tượng Account vào Tag
                    lvi.Tag = acc;

                    // Thêm dòng vào ListView
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
        }

        private void lvTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTaiKhoan.SelectedItems.Count == 0)
            {
                // Nếu không có gì được chọn (ví dụ: bấm vào khoảng trống), thì thoát
                return;
            }

            // 2. Lấy đối tượng Account đầy đủ từ thuộc tính Tag của dòng được chọn
            // (Chúng ta đã gán nó trong hàm LoadDanhSachTaiKhoan)
            ListViewItem selectedItem = lvTaiKhoan.SelectedItems[0];
            Account selectedAccount = selectedItem.Tag as Account;

            // 3. Kiểm tra an toàn (dù hiếm khi xảy ra)
            if (selectedAccount == null)
            {
                MessageBox.Show("Không thể lấy dữ liệu chi tiết của tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Gán dữ liệu lên các controls

            // TextBoxes
            txtAccountId.Text = selectedAccount.AccountId;
            txtUsername.Text = selectedAccount.Username;
            txtDisplayName.Text = selectedAccount.DisplayName ?? ""; // Dùng ?? "" để xử lý nếu giá trị là null
            txtEmail.Text = selectedAccount.Email ?? "";

            // RẤT QUAN TRỌNG: Không bao giờ hiển thị PasswordHash.
            // Để trống để người dùng có thể nhập mật khẩu MỚI nếu muốn Sửa.
            txtPassword.Text = "";

            // CheckBox (xử lý kiểu bool? nullable)
            // Nếu IsActive là null, coi như là false (bị khóa)
            chkActive.Checked = selectedAccount.IsActive == true;

            // DateTimePicker (xử lý kiểu DateTime? nullable)
            if (selectedAccount.CreatedAt.HasValue)
            {
                dtpkCreatedAt.Value = selectedAccount.CreatedAt.Value;
            }
            else
            {
                // Nếu CreatedAt là null, gán một giá trị mặc định (ví dụ: ngày hôm nay)
                dtpkCreatedAt.Value = DateTime.Now;
            }

            // ComboBox Giáo Viên (xử lý MaGV có thể là null)
            // Dòng này sẽ tự động chọn mục "— Không liên kết GV —" nếu MaGV là null,
            // vì chúng ta đã thiết lập ValueMember của mục đó là (string)null
            if (selectedAccount.MaGV == null)
            {
                // Nếu MaGV là null (ví dụ: tài khoản Admin),
                // hãy chủ động chọn mục đầu tiên (là mục "— Không liên kết GV —")
                cbbGiaoVien.SelectedIndex = 0;
            }
            else
            {
                // Nếu MaGV có giá trị, gán bình thường bằng SelectedValue
                cbbGiaoVien.SelectedValue = selectedAccount.MaGV;
            }

            // ComboBox Role (xử lý quan hệ nhiều-nhiều)
            // Một tài khoản có thể có NHIỀU role, nhưng ComboBox chỉ hiển thị được MỘT.
            // Code này sẽ lấy role ĐẦU TIÊN trong danh sách và hiển thị nó.
            var firstRole = selectedAccount.Roles.FirstOrDefault();
            if (firstRole != null)
            {
                cbbRole.SelectedValue = firstRole.RoleId;
            }
            else
            {
                // Nếu tài khoản không có role nào, không chọn gì cả
                cbbRole.SelectedIndex = -1;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // --- 1. Kiểm tra dữ liệu đầu vào ---
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
                // --- 2. Kiểm tra tên đăng nhập đã tồn tại chưa ---
                if (context.Accounts.Any(a => a.Username == username))
                {
                    MessageBox.Show("Tên đăng nhập này đã tồn tại. Vui lòng chọn tên khác.", "Trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                    return;
                }

                // --- 3. Lấy vai trò (Role) ---
                string selectedRoleId = cbbRole.SelectedValue.ToString();
                var roleToAdd = context.Roles.Find(selectedRoleId);
                if (roleToAdd == null)
                {
                    MessageBox.Show("Vai trò được chọn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // --- 4. Tạo tài khoản mới ---
                Account newAccount = new Account
                {
                    AccountId = txtAccountId.Text, // Lấy từ hàm Clear
                    Username = username,
                    //PasswordHash = HashPassword(password), // Băm mật khẩu
                    PasswordHash = password,
                    DisplayName = txtDisplayName.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    IsActive = chkActive.Checked,
                    CreatedAt = DateTime.Now, // Luôn set là thời điểm hiện tại
                    MaGV = cbbGiaoVien.SelectedValue as string // Sẽ là null nếu chọn "Không liên kết"
                };

                // Thêm vai trò vào tài khoản (quan hệ nhiều-nhiều)
                newAccount.Roles.Add(roleToAdd);

                // --- 5. Lưu vào CSDL ---
                context.Accounts.Add(newAccount);
                context.SaveChanges();

                // --- 6. Thông báo và tải lại ---
                MessageBox.Show("Thêm tài khoản mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachTaiKhoan(); // Tải lại danh sách
                btnClear_Click(null, null); // Xóa trắng form
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi chi tiết nếu có
                MessageBox.Show($"Lỗi không mong muốn khi thêm: {ex.Message}", "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAccountId.Text = GetIDForDatabase.getIDNextAccount();

            // Dọn sạch các ô khác
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtDisplayName.Text = "";
            txtEmail.Text = "";

            // Set giá trị mặc định
            chkActive.Checked = true; // Mặc định tài khoản mới là hoạt động
            dtpkCreatedAt.Value = DateTime.Now; // Set ngày tạo là hôm nay

            // Set ComboBox về index 0 (theo yêu cầu của bạn)
            cbbRole.SelectedIndex = 0;
            cbbGiaoVien.SelectedIndex = 0; // Sẽ chọn "— Không liên kết GV —"

            // Bỏ chọn trên ListView
            lvTaiKhoan.SelectedItems.Clear();

            // (Khuyến nghị) Khóa ô Mã TK khi thêm mới và cho phép nhập tên
            txtAccountId.ReadOnly = true;
            txtUsername.ReadOnly = false;
            txtUsername.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // --- 1. Kiểm tra xem có chọn tài khoản để xóa không ---
            if (lvTaiKhoan.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản từ danh sách để xóa.", "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy đối tượng Account đầy đủ từ Tag
            Account accountToDelete = lvTaiKhoan.SelectedItems[0].Tag as Account;
            if (accountToDelete == null)
            {
                MessageBox.Show("Không lấy được thông tin tài khoản, vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- 2. Kiểm tra (Rất quan trọng): Không cho tự xóa chính mình ---
            if (accountToDelete.AccountId == CurrentUser.AccountId)
            {
                MessageBox.Show("Bạn không thể tự xóa tài khoản của chính mình.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // --- 3. Xác nhận xóa ---
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
                    // --- 4. Tìm và xóa tài khoản trong CSDL ---
                    // Chúng ta phải tìm lại đối tượng trong context hiện tại để xóa
                    var accountInDb = context.Accounts.Find(accountToDelete.AccountId);
                    if (accountInDb != null)
                    {
                        context.Accounts.Remove(accountInDb);
                        context.SaveChanges();

                        // --- 5. Thông báo và tải lại ---
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
                    // Lỗi này thường xảy ra nếu có ràng buộc khóa ngoại
                    MessageBox.Show($"Lỗi khi xóa tài khoản: {ex.Message}\n\n(Có thể tài khoản này vẫn còn dữ liệu liên quan không thể xóa.)", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // --- 1. Kiểm tra xem có chọn tài khoản để sửa không ---
            if (lvTaiKhoan.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản từ danh sách để sửa.", "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy AccountId từ TextBox (đã được gán khi bấm vào ListView)
            string accountIdToUpdate = txtAccountId.Text;

            // --- 2. Kiểm tra (Rất quan trọng): Không cho sửa tài khoản của chính mình ---
            if (accountIdToUpdate == CurrentUser.AccountId)
            {
                MessageBox.Show("Không thể tự sửa thông tin tài khoản của chính mình tại đây.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- 3. Kiểm tra dữ liệu ---
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
                // --- 4. Tìm tài khoản trong CSDL ---
                // Phải Include("Roles") để có thể sửa danh sách vai trò
                var accountInDb = context.Accounts
                                         .Include("Roles")
                                         .FirstOrDefault(a => a.AccountId == accountIdToUpdate);

                if (accountInDb == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản này trong CSDL (có thể đã bị xóa).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadDanhSachTaiKhoan();
                    return;
                }

                // --- 5. Kiểm tra trùng tên đăng nhập (với tài khoản khác) ---
                if (context.Accounts.Any(a => a.Username == username && a.AccountId != accountIdToUpdate))
                {
                    MessageBox.Show("Tên đăng nhập này đã tồn tại. Vui lòng chọn tên khác.", "Trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                    return;
                }

                // --- 6. Cập nhật thông tin ---
                accountInDb.Username = username;
                accountInDb.DisplayName = txtDisplayName.Text.Trim();
                accountInDb.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
                accountInDb.IsActive = chkActive.Checked;
                accountInDb.MaGV = cbbGiaoVien.SelectedValue as string;

                // Chỉ cập nhật mật khẩu NẾU người dùng nhập mật khẩu mới
                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    //accountInDb.PasswordHash = HashPassword(txtPassword.Text);
                    accountInDb.PasswordHash = txtPassword.Text;
                }

                // Cập nhật vai trò (Giả định: Xóa hết vai trò cũ, thêm 1 vai trò mới)
                // Vì giao diện của bạn chỉ cho phép chọn 1 vai trò
                accountInDb.Roles.Clear();
                string selectedRoleId = cbbRole.SelectedValue.ToString();
                var newRole = context.Roles.Find(selectedRoleId);
                if (newRole != null)
                {
                    accountInDb.Roles.Add(newRole);
                }

                // --- 7. Lưu thay đổi ---
                context.SaveChanges();

                // --- 8. Thông báo và tải lại ---
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

            // --- 2. Lấy đối tượng Account từ Tag ---
            Account accountToReset = lvTaiKhoan.SelectedItems[0].Tag as Account;
            if (accountToReset == null)
            {
                MessageBox.Show("Không lấy được thông tin tài khoản, vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- 3. (Rất quan trọng) Không cho tự đặt lại mật khẩu của chính mình ---
            if (accountToReset.AccountId == CurrentUser.AccountId)
            {
                MessageBox.Show("Bạn không thể tự đặt lại mật khẩu của chính mình.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // --- 4. Xác nhận với người dùng ---
            string newDefaultPassword = "123456"; // Đặt mật khẩu mặc định

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn đặt lại mật khẩu cho tài khoản '{accountToReset.Username}'?\n\n" +
                $"Mật khẩu mới sẽ được đặt về mặc định là: {newDefaultPassword}",
                "Xác nhận đặt lại mật khẩu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.No)
            {
                return; // Người dùng chọn "Không"
            }

            // --- 5. Tiến hành đặt lại mật khẩu ---
            try
            {
                // Tìm tài khoản trong context hiện tại
                var accountInDb = context.Accounts.Find(accountToReset.AccountId);
                if (accountInDb == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản (có thể đã bị xóa).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadDanhSachTaiKhoan(); // Tải lại danh sách
                    return;
                }

                // Băm mật khẩu mới (dùng hàm HashPassword đã tạo ở lần trước)
                accountInDb.PasswordHash = HashPassword(newDefaultPassword);

                // Lưu thay đổi vào CSDL
                context.SaveChanges();

                // --- 6. Thông báo thành công ---
                MessageBox.Show(
                    $"Đặt lại mật khẩu cho tài khoản '{accountInDb.Username}' thành công!\n\n" +
                    $"Mật khẩu mới là: {newDefaultPassword}\n\n" +
                    "Vui lòng thông báo cho người dùng để họ đổi lại mật khẩu sau khi đăng nhập.",
                    "Hoàn tất",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Xóa trắng form để tránh nhầm lẫn
                btnClear_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không mong muốn khi đặt lại mật khẩu: {ex.Message}", "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
