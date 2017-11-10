using DocumentManage.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DocumentManage
{
    public partial class FormKetNoiFTP : Form
    {
        public FormKetNoiFTP()
        {
            InitializeComponent();
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int port;
            int.TryParse(this.txtPort.Text.Trim(), out port);
            FTPDetail fTPDetail = new FTPDetail
            {
                Pass = this.txtPasswordFTP.Text.Trim(),
                Port = port,
                Server = this.txtHostFTP.Text.Trim(),
                User = this.txtUsernameFTP.Text.Trim()
            };
            bool flag = GlobalVariable.CreateFTP(fTPDetail.Server, fTPDetail.Port, fTPDetail.User, fTPDetail.Pass);
            if (flag)
            {
                bool flag2 = ManageBase.SaveCauHinhFTP(fTPDetail);
                if (flag2)
                {
                    MessageBox.Show("Kết nối thành công. Đã cập nhật thông số kết nối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    base.Close();
                }
                else
                {
                    MessageBox.Show("Kết nối thành công. Không thể cập nhật thông số kết nối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Hãy kiểm tra lại thông số kết nối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtHostFTP.Focus();
            }
            this.Cursor = Cursors.Default;
        }

        private void FormKetNoiFTP_Load(object sender, EventArgs e)
        {
            FTPDetail fTPDetail = ManageBase.GetFTPDetail();
            bool flag = fTPDetail != null;
            if (flag)
            {
                this.txtHostFTP.Text = fTPDetail.Server;
                this.txtPort.Text = fTPDetail.Port.ToString();
                this.txtUsernameFTP.Text = fTPDetail.User;
                this.txtPasswordFTP.Text = fTPDetail.Pass;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
