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
    public partial class FormLichSuNguoiDung : Form
    {
        private UserLog _userLog;
        private List<NguoiDung> _lstNguoiDung;
        public UserLog UserLog
        {
            set
            {
                this._userLog = value;
            }
        }
        public FormLichSuNguoiDung()
        {
            InitializeComponent();
        }

        private void AddDataToTreeView(UserLog userLog)
        {
            string str = "Ngày " + (userLog.NgayChinhSua?.ToString("dd/MM/yyyy HH:mm:ss"));
            NguoiDung nguoiDung = this._lstNguoiDung.Find((NguoiDung t) => t.NguoiDungId == userLog.NguoiDungId);
            bool flag = nguoiDung != null;
            if (flag)
            {
                str = str + " - " + nguoiDung.TenNguoiDung;
            }
            TreeNode node = new TreeNode(str + "                    ");
            this.trvLichSuNguoiDung.Nodes.Add(node);
            bool flag2 = userLog.LogHistory != null;
            if (flag2)
            {
                this.AddDataToTreeView(userLog.LogHistory);
            }
        }

        private void FormLichSuNguoiDung_Load(object sender, EventArgs e)
        {
            this.trvLichSuNguoiDung.Nodes.Clear();
            bool flag = this._userLog != null;
            if (flag)
            {
                this._lstNguoiDung = ProcessData.GetAllNguoiDung();
                this.AddDataToTreeView(this._userLog);
            }
            this.trvLichSuNguoiDung.ExpandAll();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
