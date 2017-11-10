namespace DocumentManage
{
    partial class FormKetNoiFTP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKetNoiFTP));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnKetNoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPortFTP = new System.Windows.Forms.Label();
            this.lblPasswordFTP = new System.Windows.Forms.Label();
            this.lblUsernameFTP = new System.Windows.Forms.Label();
            this.lblHostFTP = new System.Windows.Forms.Label();
            this.txtPasswordFTP = new System.Windows.Forms.TextBox();
            this.txtUsernameFTP = new System.Windows.Forms.TextBox();
            this.txtHostFTP = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnKetNoi);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.lblPortFTP);
            this.groupBox1.Controls.Add(this.lblPasswordFTP);
            this.groupBox1.Controls.Add(this.lblUsernameFTP);
            this.groupBox1.Controls.Add(this.lblHostFTP);
            this.groupBox1.Controls.Add(this.txtPasswordFTP);
            this.groupBox1.Controls.Add(this.txtUsernameFTP);
            this.groupBox1.Controls.Add(this.txtHostFTP);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông số kết nối FTP";
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKetNoi.Image = global::DocumentManage.Properties.Resources.server_connect_icon;
            this.btnKetNoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKetNoi.Location = new System.Drawing.Point(238, 112);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(76, 30);
            this.btnKetNoi.TabIndex = 26;
            this.btnKetNoi.Text = "Kết nối ";
            this.btnKetNoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKetNoi.UseVisualStyleBackColor = true;
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Image = global::DocumentManage.Properties.Resources.Exit;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(320, 112);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(70, 30);
            this.btnThoat.TabIndex = 25;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPort.Location = new System.Drawing.Point(312, 22);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(78, 22);
            this.txtPort.TabIndex = 19;
            // 
            // lblPortFTP
            // 
            this.lblPortFTP.AutoSize = true;
            this.lblPortFTP.BackColor = System.Drawing.Color.Transparent;
            this.lblPortFTP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortFTP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPortFTP.Location = new System.Drawing.Point(269, 24);
            this.lblPortFTP.Name = "lblPortFTP";
            this.lblPortFTP.Size = new System.Drawing.Size(37, 16);
            this.lblPortFTP.TabIndex = 14;
            this.lblPortFTP.Text = "Cổng";
            // 
            // lblPasswordFTP
            // 
            this.lblPasswordFTP.AutoSize = true;
            this.lblPasswordFTP.BackColor = System.Drawing.Color.Transparent;
            this.lblPasswordFTP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordFTP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPasswordFTP.Location = new System.Drawing.Point(8, 84);
            this.lblPasswordFTP.Name = "lblPasswordFTP";
            this.lblPasswordFTP.Size = new System.Drawing.Size(60, 16);
            this.lblPasswordFTP.TabIndex = 15;
            this.lblPasswordFTP.Text = "Mật khẩu";
            // 
            // lblUsernameFTP
            // 
            this.lblUsernameFTP.AutoSize = true;
            this.lblUsernameFTP.BackColor = System.Drawing.Color.Transparent;
            this.lblUsernameFTP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameFTP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUsernameFTP.Location = new System.Drawing.Point(8, 54);
            this.lblUsernameFTP.Name = "lblUsernameFTP";
            this.lblUsernameFTP.Size = new System.Drawing.Size(94, 16);
            this.lblUsernameFTP.TabIndex = 16;
            this.lblUsernameFTP.Text = "Tên đăng nhập";
            // 
            // lblHostFTP
            // 
            this.lblHostFTP.AutoSize = true;
            this.lblHostFTP.BackColor = System.Drawing.Color.Transparent;
            this.lblHostFTP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHostFTP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHostFTP.Location = new System.Drawing.Point(8, 24);
            this.lblHostFTP.Name = "lblHostFTP";
            this.lblHostFTP.Size = new System.Drawing.Size(55, 16);
            this.lblHostFTP.TabIndex = 17;
            this.lblHostFTP.Text = "Máy chủ";
            // 
            // txtPasswordFTP
            // 
            this.txtPasswordFTP.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswordFTP.Location = new System.Drawing.Point(114, 82);
            this.txtPasswordFTP.Name = "txtPasswordFTP";
            this.txtPasswordFTP.PasswordChar = '*';
            this.txtPasswordFTP.Size = new System.Drawing.Size(276, 22);
            this.txtPasswordFTP.TabIndex = 13;
            // 
            // txtUsernameFTP
            // 
            this.txtUsernameFTP.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsernameFTP.Location = new System.Drawing.Point(114, 52);
            this.txtUsernameFTP.Name = "txtUsernameFTP";
            this.txtUsernameFTP.Size = new System.Drawing.Size(276, 22);
            this.txtUsernameFTP.TabIndex = 12;
            // 
            // txtHostFTP
            // 
            this.txtHostFTP.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHostFTP.Location = new System.Drawing.Point(114, 22);
            this.txtHostFTP.Name = "txtHostFTP";
            this.txtHostFTP.Size = new System.Drawing.Size(149, 22);
            this.txtHostFTP.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 163);
            this.panel1.TabIndex = 1;
            // 
            // FormKetNoiFTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 163);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormKetNoiFTP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết nối FTP";
            this.Load += new System.EventHandler(this.FormKetNoiFTP_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnKetNoi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPortFTP;
        private System.Windows.Forms.Label lblPasswordFTP;
        private System.Windows.Forms.Label lblUsernameFTP;
        private System.Windows.Forms.Label lblHostFTP;
        private System.Windows.Forms.TextBox txtPasswordFTP;
        private System.Windows.Forms.TextBox txtUsernameFTP;
        private System.Windows.Forms.TextBox txtHostFTP;
        private System.Windows.Forms.Panel panel1;
    }
}