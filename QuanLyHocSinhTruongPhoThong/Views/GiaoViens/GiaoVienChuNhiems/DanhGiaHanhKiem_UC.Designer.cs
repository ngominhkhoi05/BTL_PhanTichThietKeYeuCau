namespace QuanLyHocSinhTruongPhoThong.Views.GiaoViens.GiaoVienChuNhiems
{
    partial class DanhGiaHanhKiem_UC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblListHS = new System.Windows.Forms.Label();
            this.lvHocSinh = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaKTKL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblTenHS = new System.Windows.Forms.Label();
            this.cbbMaHK = new System.Windows.Forms.ComboBox();
            this.cbbLoai = new System.Windows.Forms.ComboBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.txtMaHS = new System.Windows.Forms.TextBox();
            this.lblMaHS = new System.Windows.Forms.Label();
            this.lblHocKi = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblListHS
            // 
            this.lblListHS.AutoSize = true;
            this.lblListHS.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListHS.Location = new System.Drawing.Point(51, 340);
            this.lblListHS.Name = "lblListHS";
            this.lblListHS.Size = new System.Drawing.Size(168, 22);
            this.lblListHS.TabIndex = 35;
            this.lblListHS.Text = "Danh sách học sinh";
            // 
            // lvHocSinh
            // 
            this.lvHocSinh.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvHocSinh.FullRowSelect = true;
            this.lvHocSinh.GridLines = true;
            this.lvHocSinh.HideSelection = false;
            this.lvHocSinh.Location = new System.Drawing.Point(55, 389);
            this.lvHocSinh.Name = "lvHocSinh";
            this.lvHocSinh.Size = new System.Drawing.Size(863, 260);
            this.lvHocSinh.TabIndex = 34;
            this.lvHocSinh.UseCompatibleStateImageBehavior = false;
            this.lvHocSinh.View = System.Windows.Forms.View.Details;
            this.lvHocSinh.SelectedIndexChanged += new System.EventHandler(this.lvListHS_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtNoiDung);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtMaKTKL);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.txtTen);
            this.panel1.Controls.Add(this.lblTenHS);
            this.panel1.Controls.Add(this.cbbMaHK);
            this.panel1.Controls.Add(this.cbbLoai);
            this.panel1.Controls.Add(this.lblLoai);
            this.panel1.Controls.Add(this.txtMaHS);
            this.panel1.Controls.Add(this.lblMaHS);
            this.panel1.Controls.Add(this.lblHocKi);
            this.panel1.Location = new System.Drawing.Point(55, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 240);
            this.panel1.TabIndex = 33;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(580, 121);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(220, 40);
            this.txtNoiDung.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(457, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 21);
            this.label1.TabIndex = 58;
            this.label1.Text = "Nội dung";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaKTKL
            // 
            this.txtMaKTKL.Location = new System.Drawing.Point(169, 25);
            this.txtMaKTKL.Name = "txtMaKTKL";
            this.txtMaKTKL.ReadOnly = true;
            this.txtMaKTKL.Size = new System.Drawing.Size(220, 20);
            this.txtMaKTKL.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 21);
            this.label2.TabIndex = 56;
            this.label2.Text = "Mã KTKL";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(604, 181);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(122, 39);
            this.btnClear.TabIndex = 55;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(452, 181);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(122, 39);
            this.btnDelete.TabIndex = 54;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(296, 181);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(122, 39);
            this.btnSua.TabIndex = 53;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(138, 181);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(122, 39);
            this.btnThem.TabIndex = 52;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(169, 77);
            this.txtTen.Name = "txtTen";
            this.txtTen.ReadOnly = true;
            this.txtTen.Size = new System.Drawing.Size(220, 20);
            this.txtTen.TabIndex = 51;
            // 
            // lblTenHS
            // 
            this.lblTenHS.AutoSize = true;
            this.lblTenHS.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenHS.Location = new System.Drawing.Point(56, 74);
            this.lblTenHS.Name = "lblTenHS";
            this.lblTenHS.Size = new System.Drawing.Size(107, 21);
            this.lblTenHS.TabIndex = 50;
            this.lblTenHS.Text = "Tên học sinh";
            this.lblTenHS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbMaHK
            // 
            this.cbbMaHK.FormattingEnabled = true;
            this.cbbMaHK.Location = new System.Drawing.Point(169, 126);
            this.cbbMaHK.Name = "cbbMaHK";
            this.cbbMaHK.Size = new System.Drawing.Size(220, 21);
            this.cbbMaHK.TabIndex = 45;
            // 
            // cbbLoai
            // 
            this.cbbLoai.FormattingEnabled = true;
            this.cbbLoai.Location = new System.Drawing.Point(580, 77);
            this.cbbLoai.Name = "cbbLoai";
            this.cbbLoai.Size = new System.Drawing.Size(220, 21);
            this.cbbLoai.TabIndex = 38;
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoai.Location = new System.Drawing.Point(457, 77);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(43, 21);
            this.lblLoai.TabIndex = 37;
            this.lblLoai.Text = "Loại";
            this.lblLoai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaHS
            // 
            this.txtMaHS.Location = new System.Drawing.Point(580, 30);
            this.txtMaHS.Name = "txtMaHS";
            this.txtMaHS.ReadOnly = true;
            this.txtMaHS.Size = new System.Drawing.Size(220, 20);
            this.txtMaHS.TabIndex = 33;
            // 
            // lblMaHS
            // 
            this.lblMaHS.AutoSize = true;
            this.lblMaHS.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHS.Location = new System.Drawing.Point(457, 27);
            this.lblMaHS.Name = "lblMaHS";
            this.lblMaHS.Size = new System.Drawing.Size(102, 21);
            this.lblMaHS.TabIndex = 29;
            this.lblMaHS.Text = "Mã học sinh";
            this.lblMaHS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHocKi
            // 
            this.lblHocKi.AutoSize = true;
            this.lblHocKi.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHocKi.Location = new System.Drawing.Point(56, 126);
            this.lblHocKi.Name = "lblHocKi";
            this.lblHocKi.Size = new System.Drawing.Size(62, 21);
            this.lblHocKi.TabIndex = 9;
            this.lblHocKi.Text = "Học kì";
            this.lblHocKi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(275, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(472, 40);
            this.lblTitle.TabIndex = 32;
            this.lblTitle.Text = "KHEN THƯỞNG - KỶ LUẬT";
            // 
            // DanhGiaHanhKiem_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblListHS);
            this.Controls.Add(this.lvHocSinh);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitle);
            this.Name = "DanhGiaHanhKiem_UC";
            this.Size = new System.Drawing.Size(972, 673);
            this.Load += new System.EventHandler(this.DanhGiaHanhKiem_UC_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblListHS;
        private System.Windows.Forms.ListView lvHocSinh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbbMaHK;
        private System.Windows.Forms.ComboBox cbbLoai;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.TextBox txtMaHS;
        private System.Windows.Forms.Label lblMaHS;
        private System.Windows.Forms.Label lblHocKi;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblTenHS;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaKTKL;
        private System.Windows.Forms.Label label2;
    }
}
