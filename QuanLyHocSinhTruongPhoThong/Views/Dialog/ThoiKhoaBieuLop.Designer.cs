namespace QuanLyHocSinhTruongPhoThong.Views.Dialog
{
    partial class ThoiKhoaBieuLop
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
            this.lvLop = new System.Windows.Forms.ListView();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.lblTKB = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvLop
            // 
            this.lvLop.HideSelection = false;
            this.lvLop.Location = new System.Drawing.Point(66, 69);
            this.lvLop.Name = "lvLop";
            this.lvLop.Size = new System.Drawing.Size(701, 298);
            this.lvLop.TabIndex = 0;
            this.lvLop.UseCompatibleStateImageBehavior = false;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.Location = new System.Drawing.Point(222, 382);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(160, 45);
            this.btnXacNhan.TabIndex = 1;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // lblTKB
            // 
            this.lblTKB.AutoSize = true;
            this.lblTKB.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTKB.Location = new System.Drawing.Point(302, 23);
            this.lblTKB.Name = "lblTKB";
            this.lblTKB.Size = new System.Drawing.Size(182, 31);
            this.lblTKB.TabIndex = 2;
            this.lblTKB.Text = "Danh sách lớp";
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(403, 382);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(160, 45);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // ThoiKhoaBieuLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.lblTKB);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.lvLop);
            this.Name = "ThoiKhoaBieuLop";
            this.Text = "ThoiKhoaBieuLop";
            this.Load += new System.EventHandler(this.ThoiKhoaBieuLop_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvLop;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Label lblTKB;
        private System.Windows.Forms.Button btnHuy;
    }
}