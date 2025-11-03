using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyHocSinhTruongPhoThong
{
    public static class Event 
    {
        public static void TextBox_KhongNhapSo_KeyPress(object sender, KeyPressEventArgs e) // Thêm 'static'
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static void TextBox_KhongNhapChu_KeyPress(object sender, KeyPressEventArgs e) // Thêm 'static'
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static void TextBox_Email_Validating(object sender, CancelEventArgs e) // Thêm 'static'
        {
            System.Windows.Forms.TextBox txt = sender as System.Windows.Forms.TextBox;
            if (txt == null || string.IsNullOrWhiteSpace(txt.Text))
            {
                return;
            }
            txt.Text = txt.Text.ToLower();
            string email = txt.Text;
            try
            {
                MailAddress m = new MailAddress(email);
            }
            catch (FormatException)
            {
                MessageBox.Show("Định dạng email không hợp lệ. Vui lòng nhập lại.",
                                "Lỗi định dạng",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        public static void TextBox_KhongNhapKyTuDacBiet_KeyPress(object sender, KeyPressEventArgs e) // Thêm 'static'
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }
            if (!Regex.IsMatch(e.KeyChar.ToString(), "^[a-zA-Z0-9]$"))
            {
                e.Handled = true;
            }
        }
    }
}