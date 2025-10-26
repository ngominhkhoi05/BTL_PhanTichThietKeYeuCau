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
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.pnInfo = new System.Windows.Forms.Panel();
            this.cbbMaGV = new System.Windows.Forms.ComboBox();
            this.cbbMaHK = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbMaMon = new System.Windows.Forms.ComboBox();
            this.txtMaGVCN = new System.Windows.Forms.Label();
            this.cbbMaLop = new System.Windows.Forms.ComboBox();
            this.txtMaNK = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtMaPC = new System.Windows.Forms.TextBox();
            this.lblMaPC = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.lblTenLop = new System.Windows.Forms.Label();
            this.lvLop = new System.Windows.Forms.ListView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // pnInfo
            // 
            this.pnInfo.BackColor = System.Drawing.Color.White;
            this.pnInfo.Controls.Add(this.cbbMaGV);
            this.pnInfo.Controls.Add(this.cbbMaHK);
            this.pnInfo.Controls.Add(this.label1);
            this.pnInfo.Controls.Add(this.cbbMaMon);
            this.pnInfo.Controls.Add(this.txtMaGVCN);
            this.pnInfo.Controls.Add(this.cbbMaLop);
            this.pnInfo.Controls.Add(this.txtMaNK);
            this.pnInfo.Controls.Add(this.btnClear);
            this.pnInfo.Controls.Add(this.txtMaPC);
            this.pnInfo.Controls.Add(this.lblMaPC);
            this.pnInfo.Controls.Add(this.btnDelete);
            this.pnInfo.Controls.Add(this.btnSua);
            this.pnInfo.Controls.Add(this.btnThem);
            this.pnInfo.Controls.Add(this.lblTenLop);
            this.pnInfo.Location = new System.Drawing.Point(54, 91);
            this.pnInfo.Name = "pnInfo";
            this.pnInfo.Size = new System.Drawing.Size(864, 234);
            this.pnInfo.TabIndex = 23;
            // 
            // cbbMaGV
            // 
            this.cbbMaGV.FormattingEnabled = true;
            this.cbbMaGV.Location = new System.Drawing.Point(587, 28);
            this.cbbMaGV.Name = "cbbMaGV";
            this.cbbMaGV.Size = new System.Drawing.Size(220, 21);
            this.cbbMaGV.TabIndex = 34;
            // 
            // cbbMaHK
            // 
            this.cbbMaHK.FormattingEnabled = true;
            this.cbbMaHK.Location = new System.Drawing.Point(165, 117);
            this.cbbMaHK.Name = "cbbMaHK";
            this.cbbMaHK.Size = new System.Drawing.Size(220, 21);
            this.cbbMaHK.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 21);
            this.label1.TabIndex = 32;
            this.label1.Text = "Mã HK";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbMaMon
            // 
            this.cbbMaMon.FormattingEnabled = true;
            this.cbbMaMon.Location = new System.Drawing.Point(587, 72);
            this.cbbMaMon.Name = "cbbMaMon";
            this.cbbMaMon.Size = new System.Drawing.Size(220, 21);
            this.cbbMaMon.TabIndex = 31;
            // 
            // txtMaGVCN
            // 
            this.txtMaGVCN.AutoSize = true;
            this.txtMaGVCN.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaGVCN.Location = new System.Drawing.Point(448, 70);
            this.txtMaGVCN.Name = "txtMaGVCN";
            this.txtMaGVCN.Size = new System.Drawing.Size(72, 21);
            this.txtMaGVCN.TabIndex = 30;
            this.txtMaGVCN.Text = "Mã môn";
            this.txtMaGVCN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbMaLop
            // 
            this.cbbMaLop.FormattingEnabled = true;
            this.cbbMaLop.Location = new System.Drawing.Point(165, 72);
            this.cbbMaLop.Name = "cbbMaLop";
            this.cbbMaLop.Size = new System.Drawing.Size(220, 21);
            this.cbbMaLop.TabIndex = 29;
            // 
            // txtMaNK
            // 
            this.txtMaNK.AutoSize = true;
            this.txtMaNK.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNK.Location = new System.Drawing.Point(67, 72);
            this.txtMaNK.Name = "txtMaNK";
            this.txtMaNK.Size = new System.Drawing.Size(63, 21);
            this.txtMaNK.TabIndex = 28;
            this.txtMaNK.Text = "Mã lớp";
            this.txtMaNK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(619, 167);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(122, 39);
            this.btnClear.TabIndex = 25;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtMaPC
            // 
            this.txtMaPC.Location = new System.Drawing.Point(166, 27);
            this.txtMaPC.Name = "txtMaPC";
            this.txtMaPC.ReadOnly = true;
            this.txtMaPC.Size = new System.Drawing.Size(220, 20);
            this.txtMaPC.TabIndex = 24;
            // 
            // lblMaPC
            // 
            this.lblMaPC.AutoSize = true;
            this.lblMaPC.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPC.Location = new System.Drawing.Point(67, 28);
            this.lblMaPC.Name = "lblMaPC";
            this.lblMaPC.Size = new System.Drawing.Size(63, 21);
            this.lblMaPC.TabIndex = 23;
            this.lblMaPC.Text = "Mã PC";
            this.lblMaPC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(467, 167);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(122, 39);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(311, 167);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(122, 39);
            this.btnSua.TabIndex = 16;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(153, 167);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(122, 39);
            this.btnThem.TabIndex = 15;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // lblTenLop
            // 
            this.lblTenLop.AutoSize = true;
            this.lblTenLop.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenLop.Location = new System.Drawing.Point(448, 26);
            this.lblTenLop.Name = "lblTenLop";
            this.lblTenLop.Size = new System.Drawing.Size(66, 21);
            this.lblTenLop.TabIndex = 2;
            this.lblTenLop.Text = "Mã GV";
            this.lblTenLop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lvLop
            // 
            this.lvLop.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLop.FullRowSelect = true;
            this.lvLop.GridLines = true;
            this.lvLop.HideSelection = false;
            this.lvLop.Location = new System.Drawing.Point(54, 351);
            this.lvLop.Name = "lvLop";
            this.lvLop.Size = new System.Drawing.Size(864, 291);
            this.lvLop.TabIndex = 22;
            this.lvLop.UseCompatibleStateImageBehavior = false;
            this.lvLop.View = System.Windows.Forms.View.Details;
            this.lvLop.SelectedIndexChanged += new System.EventHandler(this.lvLop_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(276, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(441, 40);
            this.lblTitle.TabIndex = 21;
            this.lblTitle.Text = "PHÂN CÔNG GIẢNG DẠY";
            // 
            // PhanCong_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnInfo);
            this.Controls.Add(this.lvLop);
            this.Controls.Add(this.lblTitle);
            this.Name = "PhanCong_UC";
            this.Size = new System.Drawing.Size(972, 673);
            this.Load += new System.EventHandler(this.PhanCong_UC_Load);
            this.pnInfo.ResumeLayout(false);
            this.pnInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.Panel pnInfo;
        private System.Windows.Forms.ComboBox cbbMaMon;
        private System.Windows.Forms.Label txtMaGVCN;
        private System.Windows.Forms.ComboBox cbbMaLop;
        private System.Windows.Forms.Label txtMaNK;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtMaPC;
        private System.Windows.Forms.Label lblMaPC;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lblTenLop;
        private System.Windows.Forms.ListView lvLop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cbbMaGV;
        private System.Windows.Forms.ComboBox cbbMaHK;
        private System.Windows.Forms.Label label1;
    }
}
