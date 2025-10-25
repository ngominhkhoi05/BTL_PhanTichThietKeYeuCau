using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinhTruongPhoThong.Views.Admins
{
    public partial class Lophoc_UC : UserControl,IReloadable
    {
        public Lophoc_UC()
        {
            InitializeComponent();
        }

        private void Lophoc_UC_Load(object sender, EventArgs e)
        {
            LoadGiaoVienToComboBox();
            LoadNienKhoaToComboBox();
        }
        private void ClearTracker()
        {
            foreach (var entry in GetListForDatabase.context.ChangeTracker.Entries().ToList())
                entry.State = System.Data.Entity.EntityState.Detached;
        }
        private void LoadGiaoVienToComboBox()
        {
            try
            {
                var listGV = GetListForDatabase.getListGiaoVien();

                cbbGVCN.Items.Clear();
                foreach (var gv in listGV)
                {
                    cbbGVCN.Items.Add($"{gv.MaGV} - {gv.HoTen}");
                }

                if (cbbGVCN.Items.Count > 0)
                    cbbGVCN.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách giáo viên:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadNienKhoaToComboBox()
        {
            try
            {
                var listNK = GetListForDatabase.getListNienKhoa();

                cbbNienKHoa.Items.Clear();

                foreach (var nk in listNK)
                {
                    cbbNienKHoa.Items.Add($"{nk.MaNienKhoa} - {nk.NamBatDau}-{nk.NamKetThuc}");
                }

                if (cbbNienKHoa.Items.Count > 0)
                    cbbNienKHoa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách niên khóa:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Reload(object arg = null)
        {

        }
    }
}
