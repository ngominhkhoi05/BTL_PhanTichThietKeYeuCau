namespace QuanLyHocSinhTruongPhoThong.Views.Dialog
{
    partial class frmLocTheoKy
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
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.cbbMaHK = new System.Windows.Forms.ComboBox();
            this.lblMaPC = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(188, 62);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(77, 30);
            this.btnHuy.TabIndex = 51;
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnLoc
            // 
            this.btnLoc.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.Location = new System.Drawing.Point(76, 62);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(77, 30);
            this.btnLoc.TabIndex = 50;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            // 
            // cbbMaHK
            // 
            this.cbbMaHK.FormattingEnabled = true;
            this.cbbMaHK.Location = new System.Drawing.Point(120, 20);
            this.cbbMaHK.Name = "cbbMaHK";
            this.cbbMaHK.Size = new System.Drawing.Size(220, 21);
            this.cbbMaHK.TabIndex = 49;
            // 
            // lblMaPC
            // 
            this.lblMaPC.AutoSize = true;
            this.lblMaPC.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPC.Location = new System.Drawing.Point(22, 22);
            this.lblMaPC.Name = "lblMaPC";
            this.lblMaPC.Size = new System.Drawing.Size(65, 21);
            this.lblMaPC.TabIndex = 46;
            this.lblMaPC.Text = "Học kỳ";
            this.lblMaPC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmLocTheoKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 116);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.cbbMaHK);
            this.Controls.Add(this.lblMaPC);
            this.Name = "frmLocTheoKy";
            this.Text = "frmLocTheoKy";
            this.Load += new System.EventHandler(this.frmLocTheoKy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.ComboBox cbbMaHK;
        private System.Windows.Forms.Label lblMaPC;
    }
}