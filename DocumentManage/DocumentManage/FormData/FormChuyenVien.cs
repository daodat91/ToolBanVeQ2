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
    public partial class FormChuyenVien : Form
    {
        public FormChuyenVien()
        {
            InitializeComponent();
        }

        private void FormChuyenVien_Load(object sender, EventArgs e)
        {
            List<ChuyenVien> lst = ProcessData.GetAllChuyenVien();
            dgvChuyenVien.DataSource = new BindingList<ChuyenVien>(lst);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            List<ChuyenVien> lst = ((BindingList<ChuyenVien>)dgvChuyenVien.DataSource).ToList();
            ProcessData.SaveChuyenVien(lst);
            lst = ProcessData.GetAllChuyenVien();
            dgvChuyenVien.DataSource = new BindingList<ChuyenVien>(lst);
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
