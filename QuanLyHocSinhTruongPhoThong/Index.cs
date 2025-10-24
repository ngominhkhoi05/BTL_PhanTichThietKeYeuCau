using QuanLyHocSinhTruongPhoThong.Views;
using QuanLyHocSinhTruongPhoThong.Views.Admins;
using QuanLyHocSinhTruongPhoThong.Views.GiaoVienBoMons;
using QuanLyHocSinhTruongPhoThong.Views.GiaoViens.GiaoVienChuNhiems;
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
    public partial class Index : Form
    {
        private NavManager _nav;


        public string userName = "";
        public string passwordHash = "";
        private int _smoothTargetY = 0;
        private System.Windows.Forms.Timer _smoothTimer;

        public Index()
        {
            InitializeComponent();
            // Khởi tạo NavManager
            _nav = new NavManager(pnHost);
            _nav.Register("BangDieuKhien", () => new BangDieuKhien_UC());
            _nav.Show("BangDieuKhien");
            _nav.Register("NienKhoa", () => new NienKhoa_UC());
            _nav.Register("LopHoc", () => new Lophoc_UC());
            _nav.Register("GiaoVien", () => new GiaoVien_UC());
            _nav.Register("HocSinh", () => new HocSinh_UC());
            _nav.Register("PhuHuynh", () => new PhuHuynh_UC());
            _nav.Register("MonHoc", () => new MonHoc_UC());
            _nav.Register("PhanCong", () => new PhanCong_UC());
            _nav.Register("TKB", () => new ThoiKhoaBieu_UC());
            _nav.Register("NhapDiem", () => new NhapDiem_UC());
            _nav.Register("DanhGiaHanhKiem", () => new DanhGiaHanhKiem_UC());
            _nav.Register("KhenThuong", () => new KhenThuongKyLuat_UC());
            //_nav.Register("TraCuu", () => new TraCuu_UC());
            _nav.Register("TaiKhoan", () => new TaiKhoan_UC());
            _nav.Register("HanhKiem", () => new DanhGiaHanhKiem_UC());
        }

        private void Index_Load(object sender, EventArgs e)
        {
            using (var dlg = new FormDangNhap())
            {
                var result = dlg.ShowDialog(this);
                if (result == DialogResult.OK)
                {

                }
            }
            flbnScrollBar.AutoScroll = true;
            flbnScrollBar.FlowDirection = FlowDirection.TopDown;
            flbnScrollBar.WrapContents = false;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            _nav.Show("BangDieuKhien");
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void btnNienKhoa_Click(object sender, EventArgs e)
        {
            _nav.Show("NienKhoa");
        }

        private void btnLop_Click(object sender, EventArgs e)
        {
            _nav.Show("LopHoc");
        }

        private void btnGiaoVien_Click(object sender, EventArgs e)
        {
            _nav.Show("GiaoVien");
        }

        private void btnHocSinh_Click(object sender, EventArgs e)
        {
            _nav.Show("HocSinh");
        }

        private void btnPhuHuynh_Click(object sender, EventArgs e)
        {
            _nav.Show("PhuHuynh");
        }

        private void btnMon_Click(object sender, EventArgs e)
        {
            _nav.Show("MonHoc");
        }

        private void btnGiangDay_Click(object sender, EventArgs e)
        {
            _nav.Show("PhanCong");
        }

        private void btnTKB_Click(object sender, EventArgs e)
        {
            _nav.Show("TKB");
        }

        private void btnNhapDiem_Click(object sender, EventArgs e)
        {
            _nav.Show("NhapDiem");
        }

        private void btnHanhKiem_Click(object sender, EventArgs e)
        {
            _nav.Show("HanhKiem");
        }

        private void btnKhenThuong_Click(object sender, EventArgs e)
        {

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {

        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {

        }
    }
}
