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
    public partial class FormHienThiDoanVanBan : Form
    {
        private string strNoiDungDoanVanBan;
        public string NoiDungDoanVanBan
        {
            get
            {
                return this.strNoiDungDoanVanBan;
            }
            set
            {
                this.strNoiDungDoanVanBan = value;
                txtNoiDungDoanVanBan.Text = value;
            }
        }
        public FormHienThiDoanVanBan()
        {
            InitializeComponent();
        }

        private void FormHienThiDoanVanBan_Load(object sender, EventArgs e)
        {

        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            this.strNoiDungDoanVanBan = this.txtNoiDungDoanVanBan.Text;
            base.Close();
        }
    }
}
