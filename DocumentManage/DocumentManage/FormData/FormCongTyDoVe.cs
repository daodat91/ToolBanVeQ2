using DocumentManage.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentManage
{
    public partial class FormCongTyDoVe : Form
    {
        public FormCongTyDoVe()
        {
            InitializeComponent();
        }

        private void FormCongTyDoVe_Load(object sender, EventArgs e)
        {
            List<CongTyDoVe> lst = ProcessData.GetAllCongTyDoVe();
            dgvCongTyDoVe.DataSource = new BindingList<CongTyDoVe>(lst);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            List<CongTyDoVe> lst = ((BindingList<CongTyDoVe>)dgvCongTyDoVe.DataSource).ToList();
            ProcessData.SaveCongTyDoVe(lst);
            lst = ProcessData.GetAllCongTyDoVe();
            dgvCongTyDoVe.DataSource = new BindingList<CongTyDoVe>(lst);
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
