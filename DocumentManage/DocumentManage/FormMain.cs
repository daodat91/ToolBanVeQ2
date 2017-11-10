using DAL.ManageDocument.EntityClasses;
using DAL.ManageDocument.HelperClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DocumentManage
{
    public partial class FormMain : Form
    {
        private FormThongTinHoSo frmThongTinHoSo;

        private FormKetNoiFTP frmKetNoiFTP;

        private FormAccount frmAccount;

        private FormQuanLyTaiKhoan frmQuanLyTaiKhoan;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            bool flag = !GlobalVariable.LaQuanTriHeThong;
            if (flag)
            {
                this.mnQuanLyTaiKhoan.Visible = false;
                this.mnThietLapThongSoFTP.Visible = false;
            }
            GlobalVariable.TinhId = 79;
            GlobalVariable.MaTinh = "79";
            GlobalVariable.TenTinh = "TP. Hồ Chí Minh";
            GlobalVariable.HuyenId = 769;
            GlobalVariable.MaHuyen = "769";
            GlobalVariable.TenHuyen = "Quận 2";
            this.frmThongTinHoSo = new FormThongTinHoSo();
            this.frmThongTinHoSo.Show(this.dockPanel, DockState.Document);
            this.toolStripXa.DropDownItems.Clear();
            EntityCollection entityCollection = ManageBase.SelectXaByHuyenId(GlobalVariable.HuyenId);
            foreach (XaEntity xaEntity in entityCollection)
            {
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(xaEntity.TenXa);
                toolStripMenuItem.Tag = xaEntity.XaId;
                toolStripMenuItem.Click += new EventHandler(this.menuItemCommune_Click);
                this.toolStripXa.DropDownItems.Add(toolStripMenuItem);
            }
            this.toolStripXa.Text = this.toolStripXa.DropDownItems[0].Text;
            this.menuItemCommune_Click(this.toolStripXa.DropDownItems[0], null);
        }

        private void menuItemCommune_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            this.toolStripXa.Text = toolStripMenuItem.Text;
            XaEntity xaEntity = ManageBase.SelectXaByXaId((int)toolStripMenuItem.Tag);
            GlobalVariable.XaId = xaEntity.XaId;
            GlobalVariable.MaXa = xaEntity.MaXa;
            GlobalVariable.TenXa = xaEntity.TenXa;
            this.frmThongTinHoSo.ClearData();
            this.Text = "Phần mềm quản lý hồ sơ đo vẽ; " + GlobalVariable.TenXa + " - " + GlobalVariable.TenHuyen;
        }

        private void mnThongTinTaiKhoan_Click(object sender, EventArgs e)
        {
            bool flag = this.frmAccount == null;
            if (flag)
            {
                this.frmAccount = new FormAccount();
            }
            this.frmAccount.ShowDialog();
        }

        private void mnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            bool flag = this.frmQuanLyTaiKhoan == null;
            if (flag)
            {
                this.frmQuanLyTaiKhoan = new FormQuanLyTaiKhoan();
            }
            this.frmQuanLyTaiKhoan.ShowDialog();
        }

        private void mnThietLapThongSoFTP_Click(object sender, EventArgs e)
        {
            bool flag = this.frmKetNoiFTP == null;
            if (flag)
            {
                this.frmKetNoiFTP = new FormKetNoiFTP();
            }
            this.frmKetNoiFTP.ShowDialog();
        }

        FormThongKePhiDoVe frmTKPhiDoVe;
        private void mnThongKePhiDoVe_Click(object sender, EventArgs e)
        {
            if (frmTKPhiDoVe == null)
                frmTKPhiDoVe = new DocumentManage.FormThongKePhiDoVe();
            frmTKPhiDoVe.ShowDialog();
        }
    }
}
