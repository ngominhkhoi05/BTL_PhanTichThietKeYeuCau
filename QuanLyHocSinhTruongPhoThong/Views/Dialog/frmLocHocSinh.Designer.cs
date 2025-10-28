namespace QuanLyHocSinhTruongPhoThong.Views.Dialog
{
    partial class frmLocHocSinh
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
            this.cbbMaHK = new System.Windows.Forms.ComboBox();
            this.cbbMaMon = new System.Windows.Forms.ComboBox();
            this.txtMaNK = new System.Windows.Forms.Label();
            this.lblMaPC = new System.Windows.Forms.Label();
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbbMaHK
            // 
            this.cbbMaHK.FormattingEnabled = true;
            this.cbbMaHK.Location = new System.Drawing.Point(120, 17);
            this.cbbMaHK.Name = "cbbMaHK";
            this.cbbMaHK.Size = new System.Drawing.Size(220, 21);
            this.cbbMaHK.TabIndex = 41;
            // 
            // cbbMaMon
            // 
            this.cbbMaMon.FormattingEnabled = true;
            this.cbbMaMon.Location = new System.Drawing.Point(120, 63);
            this.cbbMaMon.Name = "cbbMaMon";
            this.cbbMaMon.Size = new System.Drawing.Size(220, 21);
            this.cbbMaMon.TabIndex = 40;
            // 
            // txtMaNK
            // 
            this.txtMaNK.AutoSize = true;
            this.txtMaNK.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNK.Location = new System.Drawing.Point(22, 63);
            this.txtMaNK.Name = "txtMaNK";
            this.txtMaNK.Size = new System.Drawing.Size(78, 21);
            this.txtMaNK.TabIndex = 39;
            this.txtMaNK.Text = "Môn học";
            this.txtMaNK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMaPC
            // 
            this.lblMaPC.AutoSize = true;
            this.lblMaPC.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPC.Location = new System.Drawing.Point(22, 19);
            this.lblMaPC.Name = "lblMaPC";
            this.lblMaPC.Size = new System.Drawing.Size(65, 21);
            this.lblMaPC.TabIndex = 38;
            this.lblMaPC.Text = "Học kỳ";
            this.lblMaPC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLoc
            // 
            this.btnLoc.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.Location = new System.Drawing.Point(89, 117);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(77, 30);
            this.btnLoc.TabIndex = 44;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click_1);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(201, 117);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(77, 30);
            this.btnHuy.TabIndex = 45;
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click_1);
            // 
            // frmLocHocSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 165);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.cbbMaHK);
            this.Controls.Add(this.cbbMaMon);
            this.Controls.Add(this.txtMaNK);
            this.Controls.Add(this.lblMaPC);
            this.Name = "frmLocHocSinh";
            this.Text = "Loc";
            this.Load += new System.EventHandler(this.Loc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbMaHK;
        private System.Windows.Forms.ComboBox cbbMaMon;
        private System.Windows.Forms.Label txtMaNK;
        private System.Windows.Forms.Label lblMaPC;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnHuy;
    }
}