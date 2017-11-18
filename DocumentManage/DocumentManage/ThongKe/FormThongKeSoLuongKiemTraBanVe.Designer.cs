namespace DocumentManage
{
    partial class FormThongKeSoLuongKiemTraBanVe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clnSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPhuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTongHoSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnHoSoHopLy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnHoSoBiHuy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBanVeDaKiemTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnSoBanVeDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTyLeBanVeDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnSoBanVeChuaDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTyLeBanVeChuaDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnSoBanVeDungHan_DKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnSoBanVeQuaHan_DKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTongBanVeChuaKiemTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnSoBanVeDungHan_CKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnSoBanVeQuaHan_CKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEndDate = new LIS.Component.TextBoxDate();
            this.txtStartDate = new LIS.Component.TextBoxDate();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.Location = new System.Drawing.Point(558, 20);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 27);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(639, 20);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 27);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Xuất excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "đến";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(726, 401);
            this.panel1.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvData);
            this.groupBox2.Location = new System.Drawing.Point(3, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(720, 327);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết quả";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnSTT,
            this.clnPhuong,
            this.clnTongHoSo,
            this.clnHoSoHopLy,
            this.clnHoSoBiHuy,
            this.clnBanVeDaKiemTra,
            this.clnSoBanVeDat,
            this.clnTyLeBanVeDat,
            this.clnSoBanVeChuaDat,
            this.clnTyLeBanVeChuaDat,
            this.clnSoBanVeDungHan_DKT,
            this.clnSoBanVeQuaHan_DKT,
            this.clnTongBanVeChuaKiemTra,
            this.clnSoBanVeDungHan_CKT,
            this.clnSoBanVeQuaHan_CKT});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 19);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.Size = new System.Drawing.Size(714, 305);
            this.dgvData.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.txtEndDate);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtStartDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 65);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ngày nhận hồ sơ từ";
            // 
            // clnSTT
            // 
            this.clnSTT.DataPropertyName = "STT";
            this.clnSTT.HeaderText = "STT";
            this.clnSTT.MinimumWidth = 50;
            this.clnSTT.Name = "clnSTT";
            this.clnSTT.ReadOnly = true;
            this.clnSTT.Width = 50;
            // 
            // clnPhuong
            // 
            this.clnPhuong.DataPropertyName = "Phuong";
            this.clnPhuong.HeaderText = "Phường/xã";
            this.clnPhuong.Name = "clnPhuong";
            this.clnPhuong.ReadOnly = true;
            // 
            // clnTongHoSo
            // 
            this.clnTongHoSo.DataPropertyName = "TongSoBienNhan";
            this.clnTongHoSo.HeaderText = "Tổng số biên nhận";
            this.clnTongHoSo.Name = "clnTongHoSo";
            this.clnTongHoSo.ReadOnly = true;
            // 
            // clnHoSoHopLy
            // 
            this.clnHoSoHopLy.DataPropertyName = "BienNhanHopLy";
            this.clnHoSoHopLy.HeaderText = "Biên nhận hợp lý";
            this.clnHoSoHopLy.Name = "clnHoSoHopLy";
            this.clnHoSoHopLy.ReadOnly = true;
            // 
            // clnHoSoBiHuy
            // 
            this.clnHoSoBiHuy.DataPropertyName = "BienNhanHuy";
            this.clnHoSoBiHuy.HeaderText = "Biên nhận bị hủy";
            this.clnHoSoBiHuy.Name = "clnHoSoBiHuy";
            this.clnHoSoBiHuy.ReadOnly = true;
            // 
            // clnBanVeDaKiemTra
            // 
            this.clnBanVeDaKiemTra.DataPropertyName = "TongBanVeDaKiemTra";
            this.clnBanVeDaKiemTra.HeaderText = "Tổng bản vẽ đã KT";
            this.clnBanVeDaKiemTra.Name = "clnBanVeDaKiemTra";
            this.clnBanVeDaKiemTra.ReadOnly = true;
            // 
            // clnSoBanVeDat
            // 
            this.clnSoBanVeDat.DataPropertyName = "SoBanVeDat";
            this.clnSoBanVeDat.HeaderText = "Số bản vẽ đạt";
            this.clnSoBanVeDat.Name = "clnSoBanVeDat";
            this.clnSoBanVeDat.ReadOnly = true;
            // 
            // clnTyLeBanVeDat
            // 
            this.clnTyLeBanVeDat.DataPropertyName = "TyLeBanVeDat";
            this.clnTyLeBanVeDat.HeaderText = "Tỷ lệ bản vẽ đạt";
            this.clnTyLeBanVeDat.Name = "clnTyLeBanVeDat";
            this.clnTyLeBanVeDat.ReadOnly = true;
            // 
            // clnSoBanVeChuaDat
            // 
            this.clnSoBanVeChuaDat.DataPropertyName = "SoBanVeChuaDat";
            this.clnSoBanVeChuaDat.HeaderText = "Số bản vẽ chưa đạt";
            this.clnSoBanVeChuaDat.Name = "clnSoBanVeChuaDat";
            this.clnSoBanVeChuaDat.ReadOnly = true;
            // 
            // clnTyLeBanVeChuaDat
            // 
            this.clnTyLeBanVeChuaDat.DataPropertyName = "TyLeBanVeChuaDat";
            this.clnTyLeBanVeChuaDat.HeaderText = "Tỷ lệ bản vẽ chưa đạt";
            this.clnTyLeBanVeChuaDat.Name = "clnTyLeBanVeChuaDat";
            this.clnTyLeBanVeChuaDat.ReadOnly = true;
            // 
            // clnSoBanVeDungHan_DKT
            // 
            this.clnSoBanVeDungHan_DKT.DataPropertyName = "SoBanVeDungHan_DKT";
            this.clnSoBanVeDungHan_DKT.HeaderText = "Số bản vẽ đúng hạn(ĐKT)";
            this.clnSoBanVeDungHan_DKT.Name = "clnSoBanVeDungHan_DKT";
            this.clnSoBanVeDungHan_DKT.ReadOnly = true;
            // 
            // clnSoBanVeQuaHan_DKT
            // 
            this.clnSoBanVeQuaHan_DKT.DataPropertyName = "SoBanVeQuaHan_DKT";
            this.clnSoBanVeQuaHan_DKT.HeaderText = "Số bản vẽ quá hạn(ĐKT)";
            this.clnSoBanVeQuaHan_DKT.Name = "clnSoBanVeQuaHan_DKT";
            this.clnSoBanVeQuaHan_DKT.ReadOnly = true;
            // 
            // clnTongBanVeChuaKiemTra
            // 
            this.clnTongBanVeChuaKiemTra.DataPropertyName = "TongBanVeChuaKiemTra";
            this.clnTongBanVeChuaKiemTra.HeaderText = "Tổng bản vẽ chưa kiểm tra";
            this.clnTongBanVeChuaKiemTra.Name = "clnTongBanVeChuaKiemTra";
            this.clnTongBanVeChuaKiemTra.ReadOnly = true;
            // 
            // clnSoBanVeDungHan_CKT
            // 
            this.clnSoBanVeDungHan_CKT.DataPropertyName = "SoBanVeDungHan_CKT";
            this.clnSoBanVeDungHan_CKT.HeaderText = "Số bản vẽ đúng hạn(CKT)";
            this.clnSoBanVeDungHan_CKT.Name = "clnSoBanVeDungHan_CKT";
            this.clnSoBanVeDungHan_CKT.ReadOnly = true;
            // 
            // clnSoBanVeQuaHan_CKT
            // 
            this.clnSoBanVeQuaHan_CKT.DataPropertyName = "SoBanVeQuaHan_CKT";
            this.clnSoBanVeQuaHan_CKT.HeaderText = "Số bản vẽ quá hạn(CKT)";
            this.clnSoBanVeQuaHan_CKT.Name = "clnSoBanVeQuaHan_CKT";
            this.clnSoBanVeQuaHan_CKT.ReadOnly = true;
            // 
            // txtEndDate
            // 
            this.txtEndDate.ForeColor = System.Drawing.Color.Black;
            this.txtEndDate.Location = new System.Drawing.Point(279, 22);
            this.txtEndDate.Mask = "00/00/0000";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(100, 23);
            this.txtEndDate.TabIndex = 3;
            this.txtEndDate.Value = null;
            // 
            // txtStartDate
            // 
            this.txtStartDate.ForeColor = System.Drawing.Color.Black;
            this.txtStartDate.Location = new System.Drawing.Point(138, 22);
            this.txtStartDate.Mask = "00/00/0000";
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(100, 23);
            this.txtStartDate.TabIndex = 1;
            this.txtStartDate.Value = null;
            // 
            // FormThongKeSoLuongKiemTraBanVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 401);
            this.Controls.Add(this.panel1);
            this.Name = "FormThongKeSoLuongKiemTraBanVe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thống kê số lượng bản vẽ kiểm tra";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnTimKiem;
        private LIS.Component.TextBoxDate txtEndDate;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox groupBox1;
        private LIS.Component.TextBoxDate txtStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPhuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTongHoSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnHoSoHopLy;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnHoSoBiHuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBanVeDaKiemTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSoBanVeDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTyLeBanVeDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSoBanVeChuaDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTyLeBanVeChuaDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSoBanVeDungHan_DKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSoBanVeQuaHan_DKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTongBanVeChuaKiemTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSoBanVeDungHan_CKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSoBanVeQuaHan_CKT;
    }
}