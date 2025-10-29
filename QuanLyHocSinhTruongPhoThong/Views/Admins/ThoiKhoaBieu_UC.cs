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

namespace QuanLyHocSinhTruongPhoThong.Views.Admins
{
    public partial class ThoiKhoaBieu_UC : UserControl
    {
        public ThoiKhoaBieu_UC()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnTaoTKB_Click(object sender, EventArgs e)
        {
            using (var dialog = new ThoiKhoaBieuLop())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var danhSachLop = dialog.LopDuocChon;
                    if (danhSachLop.Count > 0)
                    {
                        bool thanhCong = TaoThoiKhoaBieu_Auto(danhSachLop);

                        if (thanhCong)
                            MessageBox.Show("Tạo thời khóa biểu thành công!", "Thành công",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Không thể tạo thời khóa biểu cho một số lớp!",
                                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        private bool TaoThoiKhoaBieu_Auto(List<string> dsLop)
        {
            try
            {
                var context = GetListForDatabase.context;

                var dsPhanCong = context.PhanCongGiangDays
                    .Where(pc => dsLop.Contains(pc.MaLop))
                    .ToList();

                var thuTrongTuan = new[] { 2, 3, 4, 5, 6 }; 
                const int tietToiDa = 10;

                var tkbHienTai = context.ThoiKhoaBieux.ToList();

                bool success = true;

                foreach (var pc in dsPhanCong)
                {
                    bool duocGan = false;

                    // Duyệt qua từng thứ trong tuần
                    foreach (var thu in thuTrongTuan)
                    {
                        for (int tiet = 1; tiet <= tietToiDa; tiet++)
                        {
                            bool lopBiTrung = tkbHienTai.Any(t =>
                                t.MaLop == pc.MaLop &&
                                t.Thu == thu &&
                                tiet >= t.TuTiet && tiet < t.TuTiet + t.SoTiet);

                            if (lopBiTrung)
                                continue;

                            var tkb = new ThoiKhoaBieu
                            {
                                MaLop = pc.MaLop,
                                MaMH = pc.MaMH,
                                Thu = thu,
                                TuTiet = tiet,
                                SoTiet = 1 // mặc định 1 tiết nếu không có thông tin khác
                            };

                            tkbHienTai.Add(tkb);
                            context.ThoiKhoaBieux.Add(tkb);
                            duocGan = true;
                            break;
                        }

                        if (duocGan)
                            break; // đã gán được thì sang môn tiếp theo
                    }

                    if (!duocGan)
                    {
                        success = false;
                        Console.WriteLine($" Không thể xếp lịch cho lớp {pc.MaLop} - môn {pc.MaMH}");
                    }
                }

                context.SaveChanges();
                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo thời khóa biểu:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


    }
}
