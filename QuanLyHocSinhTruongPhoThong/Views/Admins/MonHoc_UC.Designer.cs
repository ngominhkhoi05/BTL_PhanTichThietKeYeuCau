namespace QuanLyHocSinhTruongPhoThong.Views.Admins
{
    partial class MonHoc_UC
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
            this.pnInfo = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtMaMon = new System.Windows.Forms.TextBox();
            this.lblMaMH = new System.Windows.Forms.Label();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.lblTenMH = new System.Windows.Forms.Label();
            this.lvMonHoc = new System.Windows.Forms.ListView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTietTuan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnInfo
            // 
            this.pnInfo.BackColor = System.Drawing.Color.White;
            this.pnInfo.Controls.Add(this.txtTietTuan);
            this.pnInfo.Controls.Add(this.label1);
            this.pnInfo.Controls.Add(this.btnClear);
            this.pnInfo.Controls.Add(this.txtMaMon);
            this.pnInfo.Controls.Add(this.lblMaMH);
            this.pnInfo.Controls.Add(this.txtTenMon);
            this.pnInfo.Controls.Add(this.btnDelete);
            this.pnInfo.Controls.Add(this.btnSua);
            this.pnInfo.Controls.Add(this.btnThem);
            this.pnInfo.Controls.Add(this.lblTenMH);
            this.pnInfo.Location = new System.Drawing.Point(54, 91);
            this.pnInfo.Name = "pnInfo";
            this.pnInfo.Size = new System.Drawing.Size(864, 190);
            this.pnInfo.TabIndex = 20;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(650, 115);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(157, 39);
            this.btnClear.TabIndex = 25;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtMaMon
            // 
            this.txtMaMon.Location = new System.Drawing.Point(166, 27);
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.ReadOnly = true;
            this.txtMaMon.Size = new System.Drawing.Size(220, 20);
            this.txtMaMon.TabIndex = 24;
            // 
            // lblMaMH
            // 
            this.lblMaMH.AutoSize = true;
            this.lblMaMH.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaMH.Location = new System.Drawing.Point(67, 28);
            this.lblMaMH.Name = "lblMaMH";
            this.lblMaMH.Size = new System.Drawing.Size(68, 21);
            this.lblMaMH.TabIndex = 23;
            this.lblMaMH.Text = "Mã MH";
            this.lblMaMH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTenMon
            // 
            this.txtTenMon.Location = new System.Drawing.Point(587, 27);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(220, 20);
            this.txtTenMon.TabIndex = 19;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(452, 115);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(181, 39);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(650, 70);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(157, 39);
            this.btnSua.TabIndex = 16;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(452, 70);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(181, 39);
            this.btnThem.TabIndex = 15;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // lblTenMH
            // 
            this.lblTenMH.AutoSize = true;
            this.lblTenMH.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenMH.Location = new System.Drawing.Point(448, 26);
            this.lblTenMH.Name = "lblTenMH";
            this.lblTenMH.Size = new System.Drawing.Size(110, 21);
            this.lblTenMH.TabIndex = 2;
            this.lblTenMH.Text = "Tên môn học";
            this.lblTenMH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lvMonHoc
            // 
            this.lvMonHoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvMonHoc.FullRowSelect = true;
            this.lvMonHoc.GridLines = true;
            this.lvMonHoc.HideSelection = false;
            this.lvMonHoc.Location = new System.Drawing.Point(54, 287);
            this.lvMonHoc.Name = "lvMonHoc";
            this.lvMonHoc.Size = new System.Drawing.Size(864, 355);
            this.lvMonHoc.TabIndex = 19;
            this.lvMonHoc.UseCompatibleStateImageBehavior = false;
            this.lvMonHoc.View = System.Windows.Forms.View.Details;
            this.lvMonHoc.SelectedIndexChanged += new System.EventHandler(this.lvMonHoc_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(385, 31);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(191, 40);
            this.lblTitle.TabIndex = 18;
            this.lblTitle.Text = "MÔN HỌC";
            // 
            // txtTietTuan
            // 
            this.txtTietTuan.Location = new System.Drawing.Point(166, 81);
            this.txtTietTuan.Name = "txtTietTuan";
            this.txtTietTuan.Size = new System.Drawing.Size(220, 20);
            this.txtTietTuan.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 21);
            this.label1.TabIndex = 26;
            this.label1.Text = "Tiết / tuần";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MonHoc_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnInfo);
            this.Controls.Add(this.lvMonHoc);
            this.Controls.Add(this.lblTitle);
            this.Name = "MonHoc_UC";
            this.Size = new System.Drawing.Size(972, 673);
            this.Load += new System.EventHandler(this.MonHoc_UC_Load);
            this.pnInfo.ResumeLayout(false);
            this.pnInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnInfo;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtMaMon;
        private System.Windows.Forms.Label lblMaMH;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lblTenMH;
        private System.Windows.Forms.ListView lvMonHoc;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTietTuan;
        private System.Windows.Forms.Label label1;
    }
}
