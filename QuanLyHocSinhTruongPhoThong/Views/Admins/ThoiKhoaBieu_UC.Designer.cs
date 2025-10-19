namespace QuanLyHocSinhTruongPhoThong.Views.Admins
{
    partial class ThoiKhoaBieu_UC
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
            this.lvTKB = new System.Windows.Forms.ListView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.cbbLop = new System.Windows.Forms.ComboBox();
            this.cbbGV = new System.Windows.Forms.ComboBox();
            this.btnTaoTKB = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvTKB
            // 
            this.lvTKB.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTKB.FullRowSelect = true;
            this.lvTKB.GridLines = true;
            this.lvTKB.HideSelection = false;
            this.lvTKB.Location = new System.Drawing.Point(67, 171);
            this.lvTKB.Name = "lvTKB";
            this.lvTKB.Size = new System.Drawing.Size(846, 417);
            this.lvTKB.TabIndex = 12;
            this.lvTKB.UseCompatibleStateImageBehavior = false;
            this.lvTKB.View = System.Windows.Forms.View.Details;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(312, 38);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(318, 40);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "THỜI KHOÁ BIỂU";
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.BackColor = System.Drawing.SystemColors.Control;
            this.lblLop.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLop.Location = new System.Drawing.Point(63, 121);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(100, 24);
            this.lblLop.TabIndex = 13;
            this.lblLop.Text = "Lớp 10A3";
            // 
            // cbbLop
            // 
            this.cbbLop.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLop.FormattingEnabled = true;
            this.cbbLop.Location = new System.Drawing.Point(578, 116);
            this.cbbLop.Name = "cbbLop";
            this.cbbLop.Size = new System.Drawing.Size(160, 29);
            this.cbbLop.TabIndex = 14;
            this.cbbLop.Text = "Lớp";
            // 
            // cbbGV
            // 
            this.cbbGV.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbGV.FormattingEnabled = true;
            this.cbbGV.Location = new System.Drawing.Point(753, 116);
            this.cbbGV.Name = "cbbGV";
            this.cbbGV.Size = new System.Drawing.Size(160, 29);
            this.cbbGV.TabIndex = 15;
            this.cbbGV.Text = "Giáo viên";
            // 
            // btnTaoTKB
            // 
            this.btnTaoTKB.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoTKB.Location = new System.Drawing.Point(247, 612);
            this.btnTaoTKB.Name = "btnTaoTKB";
            this.btnTaoTKB.Size = new System.Drawing.Size(207, 39);
            this.btnTaoTKB.TabIndex = 18;
            this.btnTaoTKB.Text = "Tạo thời khoá biểu";
            this.btnTaoTKB.UseVisualStyleBackColor = true;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.Location = new System.Drawing.Point(520, 612);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(122, 39);
            this.btnXacNhan.TabIndex = 17;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            // 
            // ThoiKhoaBieu_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTaoTKB);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.cbbGV);
            this.Controls.Add(this.cbbLop);
            this.Controls.Add(this.lblLop);
            this.Controls.Add(this.lvTKB);
            this.Controls.Add(this.lblTitle);
            this.Name = "ThoiKhoaBieu_UC";
            this.Size = new System.Drawing.Size(972, 673);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvTKB;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.ComboBox cbbLop;
        private System.Windows.Forms.ComboBox cbbGV;
        private System.Windows.Forms.Button btnTaoTKB;
        private System.Windows.Forms.Button btnXacNhan;
    }
}
