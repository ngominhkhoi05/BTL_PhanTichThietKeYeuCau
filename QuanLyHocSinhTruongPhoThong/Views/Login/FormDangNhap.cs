using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuanLyHocSinhTruongPhoThong.CurrentUser;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyHocSinhTruongPhoThong
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int halfHeight = panel1.Height / 2;
            using (Brush top = new SolidBrush(Color.Teal))
            using (Brush bottom = new SolidBrush(Color.WhiteSmoke))
            {
                e.Graphics.FillRectangle(top, 0, 0, panel1.Width, halfHeight);
                e.Graphics.FillRectangle(bottom, 0, halfHeight, panel1.Width, halfHeight);
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!",
                                "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var checker = new CheckLogin();
            var result = checker.ValidateLogin(username, password);

            if (result.Success)
            {
                CurrentUser.AccountId = result.AccountId;
                CurrentUser.Username = result.Username;
                CurrentUser.DisplayName = result.DisplayName;
                CurrentUser.Email = result.Email;
                CurrentUser.MaGV = result.MaGV;
                CurrentUser.Roles = result.Roles;

                MessageBox.Show($"Xin chào {CurrentUser.DisplayName ?? CurrentUser.Username}!",
                                "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.Message,
                                "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
