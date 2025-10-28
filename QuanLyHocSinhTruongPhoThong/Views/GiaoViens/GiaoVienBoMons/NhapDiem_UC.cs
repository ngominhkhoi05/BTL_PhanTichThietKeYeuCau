using QuanLyHocSinhTruongPhoThong.Models;
using QuanLyHocSinhTruongPhoThong.Views.Dialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinhTruongPhoThong.Views.GiaoVienBoMons
{
    public partial class NhapDiem_UC : UserControl
    {
        public NhapDiem_UC()
        {
            InitializeComponent();
        }
        private void SetupListViewHocSinh()
        {
            lvHS.View = View.Details;
            lvHS.FullRowSelect = true;
            lvHS.GridLines = true;
            lvHS.MultiSelect = false;

            lvHS.Columns.Clear();
            lvHS.Columns.Add("Mã HS", 90);
            lvHS.Columns.Add("Họ và tên", 180);
            lvHS.Columns.Add("Lớp", 80);
            lvHS.Columns.Add("Giữa kỳ", 80);
            lvHS.Columns.Add("Cuối kỳ", 80);
            lvHS.Columns.Add("Tổng kết", 90);
        }
        private void LoadMonHoc_ByUser(string username)
        {
            try
            {
                var list = GetListForDatabase.getListMonHocByUsername(username);

                cbbMaMon.Items.Clear();
                foreach (var mh in list)
                    cbbMaMon.Items.Add($"{mh.MaMH} - {mh.TenMH}");

                if (cbbMaMon.Items.Count > 0) cbbMaMon.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadLop_ByUser(string username, ComboBox cbbMaLop)
        {
            try
            {
                var list = GetListForDatabase.getListLopHocByUsername(username);

                cbbMaLop.Items.Clear();
                foreach (var lop in list)
                    cbbMaLop.Items.Add($"{lop.MaLop} - {lop.TenLop}");

                if (cbbMaLop.Items.Count > 0) cbbMaLop.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadHocKy_ToCombo()
        {
            try
            {
                var list = GetListForDatabase.getListHocKy();

                cbbMaHK.Items.Clear();
                foreach (var hk in list)
                    cbbMaHK.Items.Add($"{hk.MaHK} - {hk.TenHK}");

                if (cbbMaHK.Items.Count > 0) cbbMaHK.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải học kỳ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadHocSinh_ForCurrentSelection(string username)
        {
            try
            {
                if (cbbMaMon.SelectedIndex < 0 || cbbMaHK.SelectedIndex < 0)
                    return;

                string maGV = GetListForDatabase.getMaGVByUsername(username);
                if (string.IsNullOrEmpty(maGV)) return;

                string maMH = cbbMaMon.SelectedItem.ToString().Split('-')[0].Trim();
                string maHK = cbbMaHK.SelectedItem.ToString().Split('-')[0].Trim();

                var lopDuocDay = (from pc in GetListForDatabase.context.PhanCongGiangDays
                                  where pc.MaGV == maGV && pc.MaMH == maMH && pc.MaHK == maHK
                                  select pc.MaLop)
                                 .Distinct()
                                 .ToList();

                var hsList = (from hs in GetListForDatabase.context.HocSinhs
                              where lopDuocDay.Contains(hs.MaLop)
                              select hs)
                             .OrderBy(h => h.MaLop).ThenBy(h => h.HoTen)
                             .ToList();

                var bdDict = (from bd in GetListForDatabase.context.BangDiems
                              where bd.MaHK == maHK && bd.MaMH == maMH
                              select new
                              {
                                  bd.MaHS,
                                  bd.DiemGiuaKi,
                                  bd.DiemCuoiKi,
                                  bd.DiemTongKet
                              })
                              .ToList()
                              .ToDictionary(x => x.MaHS, x => x);

                lvHS.BeginUpdate();
                lvHS.Items.Clear();
                cbbMaHS.Items.Clear();

                foreach (var hs in hsList)
                {
                    bdDict.TryGetValue(hs.MaHS, out var bd);

                    var item = new ListViewItem(hs.MaHS);
                    item.SubItems.Add(hs.HoTen);
                    item.SubItems.Add(hs.MaLop);
                    item.SubItems.Add(bd?.DiemGiuaKi?.ToString("0.##") ?? "");
                    item.SubItems.Add(bd?.DiemCuoiKi?.ToString("0.##") ?? "");
                    item.SubItems.Add(bd?.DiemTongKet?.ToString("0.##") ?? "");
                    lvHS.Items.Add(item);

                    cbbMaHS.Items.Add($"{hs.MaHS} - {hs.HoTen}");
                }

                if (cbbMaHS.Items.Count > 0) cbbMaHS.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải học sinh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lvHS.EndUpdate();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void NhapDiem_UC_Load(object sender, EventArgs e)
        {
            SetupListViewHocSinh();

            LoadHocKy_ToCombo();

            string username = CurrentUser.Username;
            LoadMonHoc_ByUser(username);

            LoadHocSinh_ForCurrentSelection(username);

            cbbMaMon.SelectedIndexChanged += (s, ev) => LoadHocSinh_ForCurrentSelection(username);
            cbbMaHK.SelectedIndexChanged += (s, ev) => LoadHocSinh_ForCurrentSelection(username);

            cbbMaHK.Enabled = false;
            cbbMaMon.Enabled = false;
            cbbMaHS.Enabled = false;

            txtDiemTK.Text = "0";
            nbrUDDiemGK.Value = 0;
            nbrUDDiemCK.Value = 0;

            nbrUDDiemGK.ValueChanged += nbrUDDiem_ValueChanged;
            nbrUDDiemCK.ValueChanged += nbrUDDiem_ValueChanged;
        }

        private void lvHS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHS.SelectedItems.Count == 0)
            {
                cbbMaHK.Enabled = true;
                cbbMaMon.Enabled = true;
                cbbMaHS.Enabled = true;
                txtDiemTK.Text = "0";
                nbrUDDiemGK.Value = 0;
                nbrUDDiemCK.Value = 0;
                return;
            }

            var item = lvHS.SelectedItems[0];

            string maHS = item.SubItems[0].Text;
            string hoTen = item.SubItems[1].Text;
            string diemGiuaKy = item.SubItems[3].Text;
            string diemCuoiKy = item.SubItems[4].Text;
            string diemTongKet = item.SubItems[5].Text;

            int index = -1;
            for (int i = 0; i < cbbMaHS.Items.Count; i++)
            {
                if (cbbMaHS.Items[i].ToString().StartsWith(maHS + " "))
                {
                    index = i;
                    break;
                }
            }
            if (index >= 0)
                cbbMaHS.SelectedIndex = index;

            if (decimal.TryParse(diemGiuaKy, out decimal gk))
                nbrUDDiemGK.Value = Math.Min(nbrUDDiemGK.Maximum, Math.Max(nbrUDDiemGK.Minimum, gk));
            else
                nbrUDDiemGK.Value = 0;

            if (decimal.TryParse(diemCuoiKy, out decimal ck))
                nbrUDDiemCK.Value = Math.Min(nbrUDDiemCK.Maximum, Math.Max(nbrUDDiemCK.Minimum, ck));
            else
                nbrUDDiemCK.Value = 0;

            if (decimal.TryParse(diemTongKet, out decimal tk))
                txtDiemTK.Text = tk.ToString("0.##");
            else
                txtDiemTK.Text = "0";

            cbbMaHK.Enabled = false;
            cbbMaMon.Enabled = false;
            cbbMaHS.Enabled = false;
        }
        private void LoadHocSinh_Loc(string username, string maHK, string maMon)
        {
            try
            {
                string maGV = GetListForDatabase.getMaGVByUsername(username);
                if (string.IsNullOrEmpty(maGV)) return;

                var query = from pc in GetListForDatabase.context.PhanCongGiangDays
                            join hs in GetListForDatabase.context.HocSinhs on pc.MaLop equals hs.MaLop
                            where pc.MaGV == maGV
                            select new { hs, pc };
                if (!string.IsNullOrEmpty(maHK))
                    query = query.Where(x => x.pc.MaHK == maHK);
                if (!string.IsNullOrEmpty(maMon))
                    query = query.Where(x => x.pc.MaMH == maMon);

                var hsList = query
                    .Select(x => x.hs)
                    .Distinct()
                    .OrderBy(x => x.MaLop)
                    .ThenBy(x => x.HoTen)
                    .ToList();

                var bdDict = GetListForDatabase.context.BangDiems
                    .Where(b => (string.IsNullOrEmpty(maHK) || b.MaHK == maHK)
                             && (string.IsNullOrEmpty(maMon) || b.MaMH == maMon))
                    .ToList()
                    .ToDictionary(x => x.MaHS, x => x);

                lvHS.BeginUpdate();
                lvHS.Items.Clear();
                foreach (var hs in hsList)
                {
                    bdDict.TryGetValue(hs.MaHS, out var bd);

                    var item = new ListViewItem(hs.MaHS);
                    item.SubItems.Add(hs.HoTen);
                    item.SubItems.Add(hs.MaLop);
                    item.SubItems.Add(bd?.DiemGiuaKi?.ToString("0.##") ?? "");
                    item.SubItems.Add(bd?.DiemCuoiKi?.ToString("0.##") ?? "");
                    item.SubItems.Add(bd?.DiemTongKet?.ToString("0.##") ?? "");
                    lvHS.Items.Add(item);
                }
                lvHS.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc danh sách học sinh:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string username = CurrentUser.Username;

            using (var frm = new frmLocHocSinh(username))
            {
                var result = frm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string maHK = frm.SelectedMaHK;
                    string maMon = frm.SelectedMaMon;

                    LoadHocSinh_Loc(username, maHK, maMon);
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbMaHK.SelectedIndex < 0 || cbbMaMon.SelectedIndex < 0 || cbbMaHS.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ Học kỳ, Môn học và Học sinh!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maHK = cbbMaHK.SelectedItem.ToString().Split('-')[0].Trim();
                string maMH = cbbMaMon.SelectedItem.ToString().Split('-')[0].Trim();
                string maHS = cbbMaHS.SelectedItem.ToString().Split('-')[0].Trim();

                decimal diemGK = nbrUDDiemGK.Value;
                decimal diemCK = nbrUDDiemCK.Value;
                decimal diemTK = Math.Round((diemGK + diemCK * 2) / 3, 2);
                txtDiemTK.Text = diemTK.ToString("0.##");

                var existing = GetListForDatabase.context.BangDiems
                    .FirstOrDefault(b => b.MaHK == maHK && b.MaMH == maMH && b.MaHS == maHS);

                if (existing == null)
                {
                    var newBD = new BangDiem
                    {
                        MaHK = maHK,
                        MaMH = maMH,
                        MaHS = maHS,
                        DiemGiuaKi = diemGK,
                        DiemCuoiKi = diemCK
                    };
                    GetListForDatabase.context.BangDiems.Add(newBD);
                    GetListForDatabase.context.SaveChanges();

                    MessageBox.Show("Đã thêm điểm mới cho học sinh này!", "Thành công",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    existing.DiemGiuaKi = diemGK;
                    existing.DiemCuoiKi = diemCK;
                    GetListForDatabase.context.SaveChanges();

                    MessageBox.Show("Đã cập nhật điểm cho học sinh!", "Thành công",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                string username = CurrentUser.Username;
                LoadHocSinh_ForCurrentSelection(username);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật điểm: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void nbrUDDiem_ValueChanged(object sender, EventArgs e)
        {
            decimal gk = nbrUDDiemGK.Value;
            decimal ck = nbrUDDiemCK.Value;
            decimal tk = Math.Round((gk + ck * 2) / 3, 2);
            txtDiemTK.Text = tk.ToString("0.##");
        }

        private void pnInfo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
