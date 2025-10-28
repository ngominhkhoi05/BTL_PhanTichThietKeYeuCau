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
    public partial class frmLocHocSinh : Form
    {
        public string SelectedMaHK { get; private set; }
        public string SelectedMaMon { get; private set; }

        public frmLocHocSinh(string username)
        {
            InitializeComponent();
            LoadCombos(username);
        }

        private void LoadCombos(string username)
        {
            try
            {
                // Học kỳ
                var hkList = GetListForDatabase.getListHocKy();
                cbbMaHK.Items.Clear();
                cbbMaHK.Items.Add("Tất cả");
                foreach (var hk in hkList)
                    cbbMaHK.Items.Add($"{hk.MaHK} - {hk.TenHK}");
                cbbMaHK.SelectedIndex = 0;

                // Môn học
                var monList = GetListForDatabase.getListMonHocByUsername(username);
                cbbMaMon.Items.Clear();
                cbbMaMon.Items.Add("Tất cả");
                foreach (var mh in monList)
                    cbbMaMon.Items.Add($"{mh.MaMH} - {mh.TenMH}");
                cbbMaMon.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu lọc: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Loc_Load(object sender, EventArgs e)
        {

        }

        private void btnLoc_Click_1(object sender, EventArgs e)
        {
            SelectedMaHK = cbbMaHK.SelectedIndex > 0
                ? cbbMaHK.SelectedItem.ToString().Split('-')[0].Trim()
                : null;

            SelectedMaMon = cbbMaMon.SelectedIndex > 0
                ? cbbMaMon.SelectedItem.ToString().Split('-')[0].Trim()
                : null;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
