using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // Giả sử bạn kiểm tra tài khoản ở đây
            //string user = txtUser.Text;
            //string pass = txtPassword.Text;

            if (true) // ví dụ
            {
                // Đăng nhập thành công
                this.DialogResult = DialogResult.OK;
                this.Close(); // đóng form đăng nhập
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Đăng nhập thất bại",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
