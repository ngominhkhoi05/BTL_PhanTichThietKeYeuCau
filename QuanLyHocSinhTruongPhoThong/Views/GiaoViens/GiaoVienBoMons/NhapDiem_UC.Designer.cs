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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lvHS = new System.Windows.Forms.ListView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTenLop = new System.Windows.Forms.Label();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.lblMaPC = new System.Windows.Forms.Label();
            this.txtMaNK = new System.Windows.Forms.Label();
            this.cbbMaMon = new System.Windows.Forms.ComboBox();
            this.txtMaGVCN = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbMaHS = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnInfo = new System.Windows.Forms.Panel();
            this.nbrUDDiemGK = new System.Windows.Forms.NumericUpDown();
            this.nbrUDDiemCK = new System.Windows.Forms.NumericUpDown();
            this.txtDiemTK = new System.Windows.Forms.TextBox();
            this.cbbMaHK = new System.Windows.Forms.ComboBox();
            this.lblDS = new System.Windows.Forms.Label();
            this.btnLoc = new System.Windows.Forms.Button();
            this.pnInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrUDDiemGK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrUDDiemCK)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lvHS
            // 
            this.lvHS.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvHS.FullRowSelect = true;
            this.lvHS.GridLines = true;
            this.lvHS.HideSelection = false;
            this.lvHS.Location = new System.Drawing.Point(54, 375);
            this.lvHS.Name = "lvHS";
            this.lvHS.Size = new System.Drawing.Size(864, 269);
            this.lvHS.TabIndex = 25;
            this.lvHS.UseCompatibleStateImageBehavior = false;
            this.lvHS.View = System.Windows.Forms.View.Details;
            this.lvHS.SelectedIndexChanged += new System.EventHandler(this.lvHS_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(410, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(219, 40);
            this.lblTitle.TabIndex = 24;
            this.lblTitle.Text = "NHẬP ĐIỂM";
            // 
            // lblTenLop
            // 
            this.lblTenLop.AutoSize = true;
            this.lblTenLop.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenLop.Location = new System.Drawing.Point(448, 26);
            this.lblTenLop.Name = "lblTenLop";
            this.lblTenLop.Size = new System.Drawing.Size(63, 21);
            this.lblTenLop.TabIndex = 2;
            this.lblTenLop.Text = "Mã HS";
            this.lblTenLop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.Location = new System.Drawing.Point(300, 168);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(122, 39);
            this.btnCapNhat.TabIndex = 16;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // lblMaPC
            // 
            this.lblMaPC.AutoSize = true;
            this.lblMaPC.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPC.Location = new System.Drawing.Point(67, 28);
            this.lblMaPC.Name = "lblMaPC";
            this.lblMaPC.Size = new System.Drawing.Size(65, 21);
            this.lblMaPC.TabIndex = 23;
            this.lblMaPC.Text = "Mã HK";
            this.lblMaPC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaNK
            // 
            this.txtMaNK.AutoSize = true;
            this.txtMaNK.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNK.Location = new System.Drawing.Point(67, 72);
            this.txtMaNK.Name = "txtMaNK";
            this.txtMaNK.Size = new System.Drawing.Size(72, 21);
            this.txtMaNK.TabIndex = 28;
            this.txtMaNK.Text = "Mã môn";
            this.txtMaNK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbMaMon
            // 
            this.cbbMaMon.FormattingEnabled = true;
            this.cbbMaMon.Location = new System.Drawing.Point(165, 72);
            this.cbbMaMon.Name = "cbbMaMon";
            this.cbbMaMon.Size = new System.Drawing.Size(220, 21);
            this.cbbMaMon.TabIndex = 29;
            // 
            // txtMaGVCN
            // 
            this.txtMaGVCN.AutoSize = true;
            this.txtMaGVCN.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaGVCN.Location = new System.Drawing.Point(448, 70);
            this.txtMaGVCN.Name = "txtMaGVCN";
            this.txtMaGVCN.Size = new System.Drawing.Size(82, 21);
            this.txtMaGVCN.TabIndex = 30;
            this.txtMaGVCN.Text = "Điểm GK";
            this.txtMaGVCN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 32;
            this.label1.Text = "Điểm CK";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbMaHS
            // 
            this.cbbMaHS.FormattingEnabled = true;
            this.cbbMaHS.Location = new System.Drawing.Point(587, 28);
            this.cbbMaHS.Name = "cbbMaHS";
            this.cbbMaHS.Size = new System.Drawing.Size(220, 21);
            this.cbbMaHS.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(448, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 35;
            this.label2.Text = "Điểm TK";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pnInfo
            // 
            this.pnInfo.BackColor = System.Drawing.Color.White;
            this.pnInfo.Controls.Add(this.nbrUDDiemGK);
            this.pnInfo.Controls.Add(this.btnLoc);
            this.pnInfo.Controls.Add(this.nbrUDDiemCK);
            this.pnInfo.Controls.Add(this.txtDiemTK);
            this.pnInfo.Controls.Add(this.cbbMaHK);
            this.pnInfo.Controls.Add(this.label2);
            this.pnInfo.Controls.Add(this.cbbMaHS);
            this.pnInfo.Controls.Add(this.label1);
            this.pnInfo.Controls.Add(this.txtMaGVCN);
            this.pnInfo.Controls.Add(this.cbbMaMon);
            this.pnInfo.Controls.Add(this.txtMaNK);
            this.pnInfo.Controls.Add(this.lblMaPC);
            this.pnInfo.Controls.Add(this.btnCapNhat);
            this.pnInfo.Controls.Add(this.lblTenLop);
            this.pnInfo.Location = new System.Drawing.Point(54, 93);
            this.pnInfo.Name = "pnInfo";
            this.pnInfo.Size = new System.Drawing.Size(864, 234);
            this.pnInfo.TabIndex = 26;
            this.pnInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnInfo_Paint);
            // 
            // nbrUDDiemGK
            // 
            this.nbrUDDiemGK.Location = new System.Drawing.Point(587, 75);
            this.nbrUDDiemGK.Name = "nbrUDDiemGK";
            this.nbrUDDiemGK.Size = new System.Drawing.Size(220, 20);
            this.nbrUDDiemGK.TabIndex = 42;
            // 
            // nbrUDDiemCK
            // 
            this.nbrUDDiemCK.Location = new System.Drawing.Point(165, 119);
            this.nbrUDDiemCK.Name = "nbrUDDiemCK";
            this.nbrUDDiemCK.Size = new System.Drawing.Size(220, 20);
            this.nbrUDDiemCK.TabIndex = 41;
            // 
            // txtDiemTK
            // 
            this.txtDiemTK.Location = new System.Drawing.Point(587, 119);
            this.txtDiemTK.Name = "txtDiemTK";
            this.txtDiemTK.ReadOnly = true;
            this.txtDiemTK.Size = new System.Drawing.Size(220, 20);
            this.txtDiemTK.TabIndex = 40;
            // 
            // cbbMaHK
            // 
            this.cbbMaHK.FormattingEnabled = true;
            this.cbbMaHK.Location = new System.Drawing.Point(165, 26);
            this.cbbMaHK.Name = "cbbMaHK";
            this.cbbMaHK.Size = new System.Drawing.Size(220, 21);
            this.cbbMaHK.TabIndex = 37;
            // 
            // lblDS
            // 
            this.lblDS.AutoSize = true;
            this.lblDS.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDS.Location = new System.Drawing.Point(50, 340);
            this.lblDS.Name = "lblDS";
            this.lblDS.Size = new System.Drawing.Size(156, 21);
            this.lblDS.TabIndex = 43;
            this.lblDS.Text = "Danh sách học sinh";
            this.lblDS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLoc
            // 
            this.btnLoc.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.Location = new System.Drawing.Point(506, 168);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(114, 39);
            this.btnLoc.TabIndex = 43;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // NhapDiem_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDS);
            this.Controls.Add(this.pnInfo);
            this.Controls.Add(this.lvHS);
            this.Controls.Add(this.lblTitle);
            this.Name = "NhapDiem_UC";
            this.Size = new System.Drawing.Size(972, 673);
            this.Load += new System.EventHandler(this.NhapDiem_UC_Load);
            this.pnInfo.ResumeLayout(false);
            this.pnInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrUDDiemGK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrUDDiemCK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ListView lvHS;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTenLop;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Label lblMaPC;
        private System.Windows.Forms.Label txtMaNK;
        private System.Windows.Forms.ComboBox cbbMaMon;
        private System.Windows.Forms.Label txtMaGVCN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbMaHS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnInfo;
        private System.Windows.Forms.ComboBox cbbMaHK;
        private System.Windows.Forms.TextBox txtDiemTK;
        private System.Windows.Forms.NumericUpDown nbrUDDiemGK;
        private System.Windows.Forms.NumericUpDown nbrUDDiemCK;
        private System.Windows.Forms.Label lblDS;
        private System.Windows.Forms.Button btnLoc;
    }
}
