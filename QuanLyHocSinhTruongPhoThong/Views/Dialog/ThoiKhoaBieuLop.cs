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
    public partial class ThoiKhoaBieuLop : Form
    {
        public List<string> LopDuocChon { get; private set; } = new List<string>();
        public ThoiKhoaBieuLop()
        {
            InitializeComponent();
            SetupListView();
            LoadDanhSachLop();
        }
        private void SetupListView()
        {
            lvLop.View = View.Details;
            lvLop.FullRowSelect = true;
            lvLop.CheckBoxes = true;
            lvLop.GridLines = true;
            lvLop.Columns.Add("Mã lớp", 100);
            lvLop.Columns.Add("Tên lớp", 150);
            lvLop.Columns.Add("Niên khóa", 120);
            lvLop.Columns.Add("Giáo viên chủ nhiệm", 200);
        }

        private void LoadDanhSachLop()
        {
            var list = GetListForDatabase.getListLop();
            lvLop.Items.Clear();

            foreach (var lop in list)
            {
                var gv = GetListForDatabase.context.GiaoViens
                    .Where(g => g.MaGV == lop.MaGV)
                    .Select(g => g.HoTen)
                    .FirstOrDefault();

                var item = new ListViewItem(lop.MaLop);
                item.SubItems.Add(lop.TenLop);
                item.SubItems.Add(lop.MaNienKhoa);
                item.SubItems.Add(gv ?? "");
                lvLop.Items.Add(item);
            }
        }
        private void ThoiKhoaBieuLop_Load(object sender, EventArgs e)
        {

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            LopDuocChon = lvLop.CheckedItems
                .Cast<ListViewItem>()
                .Select(i => i.SubItems[0].Text)
                .ToList();

            if (LopDuocChon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một lớp để tạo thời khóa biểu!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
