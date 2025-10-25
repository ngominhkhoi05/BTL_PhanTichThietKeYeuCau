namespace QuanLyHocSinhTruongPhoThong
{
    partial class FormDangNhap
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnDangNhap = new System.Windows.Forms.Panel();
            this.lblQuenMK = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ptrbDangNhap = new System.Windows.Forms.PictureBox();
            this.lblDangNhap = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnDangNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptrbDangNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnDangNhap);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.pnDangNhap);
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1228, 731);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnDangNhap.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.Location = new System.Drawing.Point(470, 595);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(241, 69);
            this.btnDangNhap.TabIndex = 2;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(505, 137);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(162, 42);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Xin chào!";
            // 
            // pnDangNhap
            // 
            this.pnDangNhap.BackColor = System.Drawing.Color.White;
            this.pnDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnDangNhap.Controls.Add(this.lblQuenMK);
            this.pnDangNhap.Controls.Add(this.lblMatKhau);
            this.pnDangNhap.Controls.Add(this.txtMatKhau);
            this.pnDangNhap.Controls.Add(this.lblTenDangNhap);
            this.pnDangNhap.Controls.Add(this.txtTenDangNhap);
            this.pnDangNhap.Controls.Add(this.panel3);
            this.pnDangNhap.Controls.Add(this.ptrbDangNhap);
            this.pnDangNhap.Controls.Add(this.lblDangNhap);
            this.pnDangNhap.Location = new System.Drawing.Point(346, 215);
            this.pnDangNhap.Name = "pnDangNhap";
            this.pnDangNhap.Size = new System.Drawing.Size(473, 351);
            this.pnDangNhap.TabIndex = 0;
            // 
            // lblQuenMK
            // 
            this.lblQuenMK.AutoSize = true;
            this.lblQuenMK.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuenMK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblQuenMK.Location = new System.Drawing.Point(161, 300);
            this.lblQuenMK.Name = "lblQuenMK";
            this.lblQuenMK.Size = new System.Drawing.Size(152, 23);
            this.lblQuenMK.TabIndex = 6;
            this.lblQuenMK.Text = "Quên mật khẩu?";
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMatKhau.Location = new System.Drawing.Point(52, 208);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(159, 27);
            this.lblMatKhau.TabIndex = 5;
            this.lblMatKhau.Text = "Nhập mật khẩu";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(55, 249);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(370, 35);
            this.txtMatKhau.TabIndex = 4;
            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.BackColor = System.Drawing.Color.White;
            this.lblTenDangNhap.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTenDangNhap.Location = new System.Drawing.Point(52, 109);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(154, 27);
            this.lblTenDangNhap.TabIndex = 3;
            this.lblTenDangNhap.Text = "Tên đăng nhập";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDangNhap.Location = new System.Drawing.Point(55, 150);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(370, 35);
            this.txtTenDangNhap.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.IndianRed;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(55, 85);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(370, 2);
            this.panel3.TabIndex = 1;
            // 
            // ptrbDangNhap
            // 
            this.ptrbDangNhap.Image = global::QuanLyHocSinhTruongPhoThong.Properties.Resources.iconDangNhap;
            this.ptrbDangNhap.Location = new System.Drawing.Point(134, 35);
            this.ptrbDangNhap.Name = "ptrbDangNhap";
            this.ptrbDangNhap.Size = new System.Drawing.Size(40, 36);
            this.ptrbDangNhap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptrbDangNhap.TabIndex = 1;
            this.ptrbDangNhap.TabStop = false;
            // 
            // lblDangNhap
            // 
            this.lblDangNhap.AutoSize = true;
            this.lblDangNhap.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDangNhap.Location = new System.Drawing.Point(180, 35);
            this.lblDangNhap.Name = "lblDangNhap";
            this.lblDangNhap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDangNhap.Size = new System.Drawing.Size(166, 36);
            this.lblDangNhap.TabIndex = 0;
            this.lblDangNhap.Text = "Đăng nhập";
            this.lblDangNhap.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FormDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 731);
            this.Controls.Add(this.panel1);
            this.Name = "FormDangNhap";
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnDangNhap.ResumeLayout(false);
            this.pnDangNhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptrbDangNhap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnDangNhap;
        private System.Windows.Forms.Label lblDangNhap;
        private System.Windows.Forms.PictureBox ptrbDangNhap;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblQuenMK;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDangNhap;
    }
}

