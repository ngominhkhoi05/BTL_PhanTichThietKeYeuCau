namespace QuanLyHocSinhTruongPhoThong.Views.Admins
{
    partial class PhanCong_UC
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
            this.btnThem = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnInfo = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.cbbNienKhoa = new System.Windows.Forms.ComboBox();
            this.lblNienKhoa = new System.Windows.Forms.Label();
            this.cbbLop = new System.Windows.Forms.ComboBox();
            this.lblLop = new System.Windows.Forms.Label();
            this.cbbMon = new System.Windows.Forms.ComboBox();
            this.lblMon = new System.Windows.Forms.Label();
            this.cbbGV = new System.Windows.Forms.ComboBox();
            this.lblGV = new System.Windows.Forms.Label();
            this.lblTitleLop = new System.Windows.Forms.Label();
            this.lblTitleGV = new System.Windows.Forms.Label();
            this.lvGV = new System.Windows.Forms.ListView();
            this.lblListGV = new System.Windows.Forms.Label();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.pnInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(152, 177);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(122, 39);
            this.btnThem.TabIndex = 15;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(278, 38);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(441, 40);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "PHÂN CÔNG GIẢNG DẠY";
            // 
            // pnInfo
            // 
            this.pnInfo.BackColor = System.Drawing.Color.White;
            this.pnInfo.Controls.Add(this.btnXoa);
            this.pnInfo.Controls.Add(this.btnSua);
            this.pnInfo.Controls.Add(this.cbbNienKhoa);
            this.pnInfo.Controls.Add(this.btnThem);
            this.pnInfo.Controls.Add(this.lblNienKhoa);
            this.pnInfo.Controls.Add(this.cbbLop);
            this.pnInfo.Controls.Add(this.lblLop);
            this.pnInfo.Controls.Add(this.cbbMon);
            this.pnInfo.Controls.Add(this.lblMon);
            this.pnInfo.Controls.Add(this.cbbGV);
            this.pnInfo.Controls.Add(this.lblGV);
            this.pnInfo.Controls.Add(this.lblTitleLop);
            this.pnInfo.Controls.Add(this.lblTitleGV);
            this.pnInfo.Location = new System.Drawing.Point(131, 99);
            this.pnInfo.Name = "pnInfo";
            this.pnInfo.Size = new System.Drawing.Size(720, 239);
            this.pnInfo.TabIndex = 16;
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(466, 177);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(122, 39);
            this.btnXoa.TabIndex = 17;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(310, 177);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(122, 39);
            this.btnSua.TabIndex = 16;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // cbbNienKhoa
            // 
            this.cbbNienKhoa.FormattingEnabled = true;
            this.cbbNienKhoa.Location = new System.Drawing.Point(491, 114);
            this.cbbNienKhoa.Name = "cbbNienKhoa";
            this.cbbNienKhoa.Size = new System.Drawing.Size(181, 21);
            this.cbbNienKhoa.TabIndex = 10;
            // 
            // lblNienKhoa
            // 
            this.lblNienKhoa.AutoSize = true;
            this.lblNienKhoa.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNienKhoa.Location = new System.Drawing.Point(375, 114);
            this.lblNienKhoa.Name = "lblNienKhoa";
            this.lblNienKhoa.Size = new System.Drawing.Size(85, 21);
            this.lblNienKhoa.TabIndex = 9;
            this.lblNienKhoa.Text = "Niên khoá";
            this.lblNienKhoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbLop
            // 
            this.cbbLop.FormattingEnabled = true;
            this.cbbLop.Location = new System.Drawing.Point(491, 71);
            this.cbbLop.Name = "cbbLop";
            this.cbbLop.Size = new System.Drawing.Size(181, 21);
            this.cbbLop.TabIndex = 8;
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLop.Location = new System.Drawing.Point(375, 71);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(41, 21);
            this.lblLop.TabIndex = 7;
            this.lblLop.Text = "Lớp";
            this.lblLop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbMon
            // 
            this.cbbMon.FormattingEnabled = true;
            this.cbbMon.Location = new System.Drawing.Point(152, 114);
            this.cbbMon.Name = "cbbMon";
            this.cbbMon.Size = new System.Drawing.Size(181, 21);
            this.cbbMon.TabIndex = 6;
            // 
            // lblMon
            // 
            this.lblMon.AutoSize = true;
            this.lblMon.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMon.Location = new System.Drawing.Point(36, 114);
            this.lblMon.Name = "lblMon";
            this.lblMon.Size = new System.Drawing.Size(45, 21);
            this.lblMon.TabIndex = 5;
            this.lblMon.Text = "Môn";
            this.lblMon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbGV
            // 
            this.cbbGV.FormattingEnabled = true;
            this.cbbGV.Location = new System.Drawing.Point(152, 71);
            this.cbbGV.Name = "cbbGV";
            this.cbbGV.Size = new System.Drawing.Size(181, 21);
            this.cbbGV.TabIndex = 4;
            // 
            // lblGV
            // 
            this.lblGV.AutoSize = true;
            this.lblGV.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGV.Location = new System.Drawing.Point(36, 71);
            this.lblGV.Name = "lblGV";
            this.lblGV.Size = new System.Drawing.Size(81, 21);
            this.lblGV.TabIndex = 2;
            this.lblGV.Text = "Giáo viên";
            this.lblGV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitleLop
            // 
            this.lblTitleLop.AutoSize = true;
            this.lblTitleLop.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleLop.Location = new System.Drawing.Point(375, 23);
            this.lblTitleLop.Name = "lblTitleLop";
            this.lblTitleLop.Size = new System.Drawing.Size(47, 24);
            this.lblTitleLop.TabIndex = 1;
            this.lblTitleLop.Text = "Lớp";
            this.lblTitleLop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitleLop.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblTitleGV
            // 
            this.lblTitleGV.AutoSize = true;
            this.lblTitleGV.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleGV.Location = new System.Drawing.Point(36, 23);
            this.lblTitleGV.Name = "lblTitleGV";
            this.lblTitleGV.Size = new System.Drawing.Size(95, 24);
            this.lblTitleGV.TabIndex = 0;
            this.lblTitleGV.Text = "Giáo viên";
            this.lblTitleGV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitleGV.Click += new System.EventHandler(this.label2_Click);
            // 
            // lvGV
            // 
            this.lvGV.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvGV.FullRowSelect = true;
            this.lvGV.GridLines = true;
            this.lvGV.HideSelection = false;
            this.lvGV.Location = new System.Drawing.Point(131, 393);
            this.lvGV.Name = "lvGV";
            this.lvGV.Size = new System.Drawing.Size(720, 234);
            this.lvGV.TabIndex = 18;
            this.lvGV.UseCompatibleStateImageBehavior = false;
            this.lvGV.View = System.Windows.Forms.View.Details;
            // 
            // lblListGV
            // 
            this.lblListGV.AutoSize = true;
            this.lblListGV.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListGV.Location = new System.Drawing.Point(129, 353);
            this.lblListGV.Name = "lblListGV";
            this.lblListGV.Size = new System.Drawing.Size(174, 22);
            this.lblListGV.TabIndex = 19;
            this.lblListGV.Text = "Danh sách giáo viên";
            this.lblListGV.Click += new System.EventHandler(this.lblListGV_Click);
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // PhanCong_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblListGV);
            this.Controls.Add(this.lvGV);
            this.Controls.Add(this.pnInfo);
            this.Controls.Add(this.lblTitle);
            this.Name = "PhanCong_UC";
            this.Size = new System.Drawing.Size(972, 673);
            this.pnInfo.ResumeLayout(false);
            this.pnInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnInfo;
        private System.Windows.Forms.Label lblTitleGV;
        private System.Windows.Forms.Label lblTitleLop;
        private System.Windows.Forms.Label lblGV;
        private System.Windows.Forms.ComboBox cbbGV;
        private System.Windows.Forms.ComboBox cbbMon;
        private System.Windows.Forms.Label lblMon;
        private System.Windows.Forms.ComboBox cbbNienKhoa;
        private System.Windows.Forms.Label lblNienKhoa;
        private System.Windows.Forms.ComboBox cbbLop;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.ListView lvGV;
        private System.Windows.Forms.Label lblListGV;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
    }
}
