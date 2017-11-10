namespace DocumentManage
{
    partial class FormThongTinHoSo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThongTinHoSo));
            this.trvHoSo = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkLayThongTinCu = new System.Windows.Forms.CheckBox();
            this.btnTuiHSMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnChinhSua = new System.Windows.Forms.Button();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvHoSo
            // 
            this.trvHoSo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvHoSo.BackColor = System.Drawing.SystemColors.Window;
            this.trvHoSo.CheckBoxes = true;
            this.trvHoSo.Location = new System.Drawing.Point(3, 34);
            this.trvHoSo.Name = "trvHoSo";
            this.trvHoSo.Size = new System.Drawing.Size(927, 367);
            this.trvHoSo.TabIndex = 6;
            this.trvHoSo.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvHoSo_AfterCheck);
            this.trvHoSo.DoubleClick += new System.EventHandler(this.trvHoSo_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.chkLayThongTinCu);
            this.panel1.Controls.Add(this.btnTuiHSMoi);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnChinhSua);
            this.panel1.Controls.Add(this.btnThemMoi);
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.trvHoSo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 404);
            this.panel1.TabIndex = 1;
            // 
            // chkLayThongTinCu
            // 
            this.chkLayThongTinCu.AutoSize = true;
            this.chkLayThongTinCu.Checked = true;
            this.chkLayThongTinCu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLayThongTinCu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLayThongTinCu.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkLayThongTinCu.Location = new System.Drawing.Point(12, 8);
            this.chkLayThongTinCu.Name = "chkLayThongTinCu";
            this.chkLayThongTinCu.Size = new System.Drawing.Size(132, 20);
            this.chkLayThongTinCu.TabIndex = 12;
            this.chkLayThongTinCu.Text = "Lấy thông tin cũ";
            this.chkLayThongTinCu.UseVisualStyleBackColor = true;
            // 
            // btnTuiHSMoi
            // 
            this.btnTuiHSMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTuiHSMoi.Image = global::DocumentManage.Properties.Resources.gtk_refresh;
            this.btnTuiHSMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTuiHSMoi.Location = new System.Drawing.Point(493, 2);
            this.btnTuiHSMoi.Name = "btnTuiHSMoi";
            this.btnTuiHSMoi.Size = new System.Drawing.Size(81, 26);
            this.btnTuiHSMoi.TabIndex = 11;
            this.btnTuiHSMoi.Text = "Khởi tạo";
            this.btnTuiHSMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTuiHSMoi.UseVisualStyleBackColor = true;
            this.btnTuiHSMoi.Click += new System.EventHandler(this.btnTuiHSMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Image = global::DocumentManage.Properties.Resources.Delete;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(866, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(63, 26);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "Xoá ";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnChinhSua
            // 
            this.btnChinhSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChinhSua.Image = global::DocumentManage.Properties.Resources.edit_file_icon;
            this.btnChinhSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChinhSua.Location = new System.Drawing.Point(770, 2);
            this.btnChinhSua.Name = "btnChinhSua";
            this.btnChinhSua.Size = new System.Drawing.Size(90, 26);
            this.btnChinhSua.TabIndex = 9;
            this.btnChinhSua.Text = "Chỉnh sửa";
            this.btnChinhSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChinhSua.UseVisualStyleBackColor = true;
            this.btnChinhSua.Click += new System.EventHandler(this.btnChinhSua_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemMoi.Image = global::DocumentManage.Properties.Resources.document_add_icon;
            this.btnThemMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemMoi.Location = new System.Drawing.Point(672, 2);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(92, 26);
            this.btnThemMoi.TabIndex = 8;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.Image = global::DocumentManage.Properties.Resources.search;
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(580, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(86, 26);
            this.btnTimKiem.TabIndex = 7;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // FormThongTinHoSo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(933, 404);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormThongTinHoSo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin bản vẽ";
            this.Load += new System.EventHandler(this.FormThongTinHoSo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvHoSo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkLayThongTinCu;
        private System.Windows.Forms.Button btnTuiHSMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnChinhSua;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnTimKiem;
    }
}