using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinhTruongPhoThong.Views.Dialog
{
    public partial class QuanHe : Form
    {
        public QuanHe()
        {
            InitializeComponent();
        }

        private void QuanHe_Load(object sender, EventArgs e)
        {

        }
        public string SelectedQuanHe { get; private set; }

        public QuanHe(string goiYMacDinh)
        {
            InitializeComponent();
            cbbQuanHe.Items.AddRange(new string[] { "Cha", "Mẹ", "Người giám hộ" });

            if (!string.IsNullOrEmpty(goiYMacDinh) && cbbQuanHe.Items.Contains(goiYMacDinh))
                cbbQuanHe.SelectedItem = goiYMacDinh;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbbQuanHe.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn quan hệ!", "Thiếu thông tin",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelectedQuanHe = cbbQuanHe.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
