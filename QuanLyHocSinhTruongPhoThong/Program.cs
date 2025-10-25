using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinhTruongPhoThong
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mở form đăng nhập trước
            using (FormDangNhap login = new FormDangNhap())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    // Nếu đăng nhập OK → mở form chính
                    Application.Run(new Index());
                }
                else
                {
                    // Nếu bấm X hoặc đăng nhập sai → thoát chương trình
                    Application.Exit();
                }
            }
        }
    }
}
