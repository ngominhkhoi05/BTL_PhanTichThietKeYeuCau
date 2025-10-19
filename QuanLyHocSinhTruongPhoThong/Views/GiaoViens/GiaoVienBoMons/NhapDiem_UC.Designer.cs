namespace QuanLyHocSinhTruongPhoThong.Views.GiaoVienBoMons
{
    partial class NhapDiem_UC
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
            this.components = new System.ComponentModel.Container();
            this.lbtListHS = new System.Windows.Forms.Label();
            this.lvListHS = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDiemTK = new System.Windows.Forms.TextBox();
            this.nbrudDiemCK = new System.Windows.Forms.NumericUpDown();
            this.nbrudDiemGK = new System.Windows.Forms.NumericUpDown();
            this.lblDiemTK = new System.Windows.Forms.Label();
            this.lblDiemCK = new System.Windows.Forms.Label();
            this.lblDiemGK = new System.Windows.Forms.Label();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.lblNienKhoa = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblMon = new System.Windows.Forms.Label();
            this.lblTenHS = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtTenHS = new System.Windows.Forms.TextBox();
            this.txtLop = new System.Windows.Forms.TextBox();
            this.txtNienKhoa = new System.Windows.Forms.TextBox();
            this.txtMon = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrudDiemCK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrudDiemGK)).BeginInit();
            this.SuspendLayout();
            // 
            // lbtListHS
            // 
            this.lbtListHS.AutoSize = true;
            this.lbtListHS.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtListHS.Location = new System.Drawing.Point(129, 371);
            this.lbtListHS.Name = "lbtListHS";
            this.lbtListHS.Size = new System.Drawing.Size(168, 22);
            this.lbtListHS.TabIndex = 23;
            this.lbtListHS.Text = "Danh sách học sinh";
            // 
            // lvListHS
            // 
            this.lvListHS.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvListHS.FullRowSelect = true;
            this.lvListHS.GridLines = true;
            this.lvListHS.HideSelection = false;
            this.lvListHS.Location = new System.Drawing.Point(126, 403);
            this.lvListHS.Name = "lvListHS";
            this.lvListHS.Size = new System.Drawing.Size(720, 238);
            this.lvListHS.TabIndex = 22;
            this.lvListHS.UseCompatibleStateImageBehavior = false;
            this.lvListHS.View = System.Windows.Forms.View.Details;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtMon);
            this.panel1.Controls.Add(this.txtNienKhoa);
            this.panel1.Controls.Add(this.txtLop);
            this.panel1.Controls.Add(this.txtTenHS);
            this.panel1.Controls.Add(this.txtDiemTK);
            this.panel1.Controls.Add(this.nbrudDiemCK);
            this.panel1.Controls.Add(this.nbrudDiemGK);
            this.panel1.Controls.Add(this.lblDiemTK);
            this.panel1.Controls.Add(this.lblDiemCK);
            this.panel1.Controls.Add(this.lblDiemGK);
            this.panel1.Controls.Add(this.btnCapNhat);
            this.panel1.Controls.Add(this.lblNienKhoa);
            this.panel1.Controls.Add(this.lblLop);
            this.panel1.Controls.Add(this.lblMon);
            this.panel1.Controls.Add(this.lblTenHS);
            this.panel1.Location = new System.Drawing.Point(126, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 242);
            this.panel1.TabIndex = 21;
            // 
            // txtDiemTK
            // 
            this.txtDiemTK.Location = new System.Drawing.Point(167, 182);
            this.txtDiemTK.Name = "txtDiemTK";
            this.txtDiemTK.ReadOnly = true;
            this.txtDiemTK.Size = new System.Drawing.Size(181, 20);
            this.txtDiemTK.TabIndex = 28;
            // 
            // nbrudDiemCK
            // 
            this.nbrudDiemCK.Location = new System.Drawing.Point(506, 139);
            this.nbrudDiemCK.Name = "nbrudDiemCK";
            this.nbrudDiemCK.Size = new System.Drawing.Size(181, 20);
            this.nbrudDiemCK.TabIndex = 27;
            // 
            // nbrudDiemGK
            // 
            this.nbrudDiemGK.Location = new System.Drawing.Point(167, 140);
            this.nbrudDiemGK.Name = "nbrudDiemGK";
            this.nbrudDiemGK.Size = new System.Drawing.Size(181, 20);
            this.nbrudDiemGK.TabIndex = 26;
            // 
            // lblDiemTK
            // 
            this.lblDiemTK.AutoSize = true;
            this.lblDiemTK.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiemTK.Location = new System.Drawing.Point(51, 182);
            this.lblDiemTK.Name = "lblDiemTK";
            this.lblDiemTK.Size = new System.Drawing.Size(115, 21);
            this.lblDiemTK.TabIndex = 21;
            this.lblDiemTK.Text = "Điểm tổng kết";
            this.lblDiemTK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiemCK
            // 
            this.lblDiemCK.AutoSize = true;
            this.lblDiemCK.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiemCK.Location = new System.Drawing.Point(390, 139);
            this.lblDiemCK.Name = "lblDiemCK";
            this.lblDiemCK.Size = new System.Drawing.Size(107, 21);
            this.lblDiemCK.TabIndex = 19;
            this.lblDiemCK.Text = "Điểm cuối kì";
            this.lblDiemCK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiemGK
            // 
            this.lblDiemGK.AutoSize = true;
            this.lblDiemGK.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiemGK.Location = new System.Drawing.Point(51, 139);
            this.lblDiemGK.Name = "lblDiemGK";
            this.lblDiemGK.Size = new System.Drawing.Size(106, 21);
            this.lblDiemGK.TabIndex = 17;
            this.lblDiemGK.Text = "Điểm giữa kì";
            this.lblDiemGK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.Location = new System.Drawing.Point(507, 171);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(122, 39);
            this.btnCapNhat.TabIndex = 15;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblNienKhoa
            // 
            this.lblNienKhoa.AutoSize = true;
            this.lblNienKhoa.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNienKhoa.Location = new System.Drawing.Point(390, 95);
            this.lblNienKhoa.Name = "lblNienKhoa";
            this.lblNienKhoa.Size = new System.Drawing.Size(85, 21);
            this.lblNienKhoa.TabIndex = 9;
            this.lblNienKhoa.Text = "Niên khoá";
            this.lblNienKhoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLop.Location = new System.Drawing.Point(390, 52);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(41, 21);
            this.lblLop.TabIndex = 7;
            this.lblLop.Text = "Lớp";
            this.lblLop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMon
            // 
            this.lblMon.AutoSize = true;
            this.lblMon.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMon.Location = new System.Drawing.Point(51, 95);
            this.lblMon.Name = "lblMon";
            this.lblMon.Size = new System.Drawing.Size(45, 21);
            this.lblMon.TabIndex = 5;
            this.lblMon.Text = "Môn";
            this.lblMon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTenHS
            // 
            this.lblTenHS.AutoSize = true;
            this.lblTenHS.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenHS.Location = new System.Drawing.Point(51, 52);
            this.lblTenHS.Name = "lblTenHS";
            this.lblTenHS.Size = new System.Drawing.Size(107, 21);
            this.lblTenHS.TabIndex = 2;
            this.lblTenHS.Text = "Tên học sinh";
            this.lblTenHS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(367, 32);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(219, 40);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "NHẬP ĐIỂM";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtTenHS
            // 
            this.txtTenHS.Location = new System.Drawing.Point(167, 54);
            this.txtTenHS.Name = "txtTenHS";
            this.txtTenHS.ReadOnly = true;
            this.txtTenHS.Size = new System.Drawing.Size(181, 20);
            this.txtTenHS.TabIndex = 29;
            // 
            // txtLop
            // 
            this.txtLop.Location = new System.Drawing.Point(506, 52);
            this.txtLop.Name = "txtLop";
            this.txtLop.ReadOnly = true;
            this.txtLop.Size = new System.Drawing.Size(181, 20);
            this.txtLop.TabIndex = 30;
            // 
            // txtNienKhoa
            // 
            this.txtNienKhoa.Location = new System.Drawing.Point(506, 97);
            this.txtNienKhoa.Name = "txtNienKhoa";
            this.txtNienKhoa.ReadOnly = true;
            this.txtNienKhoa.Size = new System.Drawing.Size(181, 20);
            this.txtNienKhoa.TabIndex = 31;
            // 
            // txtMon
            // 
            this.txtMon.Location = new System.Drawing.Point(167, 97);
            this.txtMon.Name = "txtMon";
            this.txtMon.ReadOnly = true;
            this.txtMon.Size = new System.Drawing.Size(181, 20);
            this.txtMon.TabIndex = 32;
            // 
            // NhapDiem_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbtListHS);
            this.Controls.Add(this.lvListHS);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitle);
            this.Name = "NhapDiem_UC";
            this.Size = new System.Drawing.Size(972, 673);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrudDiemCK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrudDiemGK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbtListHS;
        private System.Windows.Forms.ListView lvListHS;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Label lblNienKhoa;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblMon;
        private System.Windows.Forms.Label lblTenHS;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDiemCK;
        private System.Windows.Forms.Label lblDiemGK;
        private System.Windows.Forms.Label lblDiemTK;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtDiemTK;
        private System.Windows.Forms.NumericUpDown nbrudDiemCK;
        private System.Windows.Forms.NumericUpDown nbrudDiemGK;
        private System.Windows.Forms.TextBox txtTenHS;
        private System.Windows.Forms.TextBox txtNienKhoa;
        private System.Windows.Forms.TextBox txtLop;
        private System.Windows.Forms.TextBox txtMon;
    }
}
