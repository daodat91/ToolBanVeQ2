namespace DocumentManage
{
    partial class FormThongKeTheoCongTyDoVe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThongKeTheoCongTyDoVe));
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.clnSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnSoBienNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnSoBanVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNgayNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNgayTraHoSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCongTyDoVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPhiThamDinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPhiDoVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPhuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkComboboxCTDV = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEndDate = new LIS.Component.TextBoxDate();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtStartDate = new LIS.Component.TextBoxDate();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkComboboxCTDV.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnSTT,
            this.clnSoBienNhan,
            this.clnSoBanVe,
            this.clnNgayNhan,
            this.clnNgayTraHoSo,
            this.clnCongTyDoVe,
            this.clnPhiThamDinh,
            this.clnPhiDoVe,
            this.clnPhuong});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 19);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.Size = new System.Drawing.Size(689, 289);
            this.dgvData.TabIndex = 0;
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
            // clnSoBienNhan
            // 
            this.clnSoBienNhan.DataPropertyName = "SoBienNhan";
            this.clnSoBienNhan.HeaderText = "Số biên nhận";
            this.clnSoBienNhan.MinimumWidth = 120;
            this.clnSoBienNhan.Name = "clnSoBienNhan";
            this.clnSoBienNhan.ReadOnly = true;
            this.clnSoBienNhan.Width = 120;
            // 
            // clnSoBanVe
            // 
            this.clnSoBanVe.DataPropertyName = "SoBanVe";
            this.clnSoBanVe.HeaderText = "Số bản vẽ";
            this.clnSoBanVe.MinimumWidth = 120;
            this.clnSoBanVe.Name = "clnSoBanVe";
            this.clnSoBanVe.ReadOnly = true;
            this.clnSoBanVe.Width = 120;
            // 
            // clnNgayNhan
            // 
            this.clnNgayNhan.DataPropertyName = "NgayNhan";
            this.clnNgayNhan.HeaderText = "Ngày nhận";
            this.clnNgayNhan.MinimumWidth = 120;
            this.clnNgayNhan.Name = "clnNgayNhan";
            this.clnNgayNhan.ReadOnly = true;
            this.clnNgayNhan.Width = 120;
            // 
            // clnNgayTraHoSo
            // 
            this.clnNgayTraHoSo.DataPropertyName = "NgayTrahoSo";
            this.clnNgayTraHoSo.HeaderText = "Ngày trả hồ sơ";
            this.clnNgayTraHoSo.MinimumWidth = 150;
            this.clnNgayTraHoSo.Name = "clnNgayTraHoSo";
            this.clnNgayTraHoSo.ReadOnly = true;
            this.clnNgayTraHoSo.Width = 150;
            // 
            // clnCongTyDoVe
            // 
            this.clnCongTyDoVe.DataPropertyName = "CongTyDoVe";
            this.clnCongTyDoVe.HeaderText = "Công ty đo vẽ";
            this.clnCongTyDoVe.MinimumWidth = 200;
            this.clnCongTyDoVe.Name = "clnCongTyDoVe";
            this.clnCongTyDoVe.ReadOnly = true;
            this.clnCongTyDoVe.Width = 200;
            // 
            // clnPhiThamDinh
            // 
            this.clnPhiThamDinh.DataPropertyName = "PhiThamDinh";
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.clnPhiThamDinh.DefaultCellStyle = dataGridViewCellStyle5;
            this.clnPhiThamDinh.HeaderText = "Phí thẩm định";
            this.clnPhiThamDinh.MinimumWidth = 150;
            this.clnPhiThamDinh.Name = "clnPhiThamDinh";
            this.clnPhiThamDinh.ReadOnly = true;
            this.clnPhiThamDinh.Width = 150;
            // 
            // clnPhiDoVe
            // 
            this.clnPhiDoVe.DataPropertyName = "PhiDoVe";
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.clnPhiDoVe.DefaultCellStyle = dataGridViewCellStyle6;
            this.clnPhiDoVe.HeaderText = "Phí đo vẽ";
            this.clnPhiDoVe.MinimumWidth = 120;
            this.clnPhiDoVe.Name = "clnPhiDoVe";
            this.clnPhiDoVe.ReadOnly = true;
            this.clnPhiDoVe.Width = 120;
            // 
            // clnPhuong
            // 
            this.clnPhuong.DataPropertyName = "Phuong";
            this.clnPhuong.HeaderText = "Phường/xã";
            this.clnPhuong.Name = "clnPhuong";
            this.clnPhuong.ReadOnly = true;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.Image = global::DocumentManage.Properties.Resources.search;
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(501, 20);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(87, 27);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvData);
            this.groupBox2.Location = new System.Drawing.Point(3, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(695, 311);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết quả";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ngày nhận hồ sơ từ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 415);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkComboboxCTDV);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.txtEndDate);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtStartDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 95);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // checkComboboxCTDV
            // 
            this.checkComboboxCTDV.EditValue = "";
            this.checkComboboxCTDV.Location = new System.Drawing.Point(138, 51);
            this.checkComboboxCTDV.Name = "checkComboboxCTDV";
            this.checkComboboxCTDV.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkComboboxCTDV.Properties.Appearance.Options.UseFont = true;
            this.checkComboboxCTDV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkComboboxCTDV.Properties.LookAndFeel.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.False;
            this.checkComboboxCTDV.Size = new System.Drawing.Size(371, 22);
            this.checkComboboxCTDV.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Công ty đo vẽ";
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
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Image = global::DocumentManage.Properties.Resources.export_excel_icon;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(594, 20);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(95, 27);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Xuất excel";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
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
            // FormThongKeTheoCongTyDoVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 415);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormThongKeTheoCongTyDoVe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thống kê theo công ty đo vẽ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkComboboxCTDV.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LIS.Component.TextBoxDate txtStartDate;
        private LIS.Component.TextBoxDate txtEndDate;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkComboboxCTDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSoBienNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSoBanVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNgayNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNgayTraHoSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCongTyDoVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPhiThamDinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPhiDoVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPhuong;
    }
}