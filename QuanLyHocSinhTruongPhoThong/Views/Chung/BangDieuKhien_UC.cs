using QuanLyHocSinhTruongPhoThong.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinhTruongPhoThong.Views
{
    public partial class BangDieuKhien_UC : UserControl
    {
        public AppDbContext context=new AppDbContext();
        public BangDieuKhien_UC()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            lblSoLuongHS.Text = getSoluongHocSinh()+"";
            lblSoLuongGV.Text=getSoluongGV()+"";
        }
        public int getSoluongHocSinh()
        {
            return context.HocSinhs.Count();
        }
        public int getSoluongGV()
        {
            return context.GiaoViens.Count();
        }
    }
}
