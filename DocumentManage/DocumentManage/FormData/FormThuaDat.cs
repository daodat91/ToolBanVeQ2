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
    public partial class FormThuaDat : Form
    {
        private ThuaDat _thuaDat;
        public ThuaDat ThuaDat
        {
            get
            {
                return this._thuaDat;
            }
            set
            {
                this._thuaDat = value;
            }
        }
        public bool IsNew;
        public FormThuaDat()
        {
            InitializeComponent();
            this.ThuaDat = null;
        }

        private void ResetValue()
        {
            this.txtDiaChi.Text = "";
            this.txtDienTich1.Text = "";
            this.txtDienTich2.Text = "";
            this.txtDienTich3.Text = "";
            this.txtMucDich1.Text = "";
            this.txtMucDich2.Text = "";
            this.txtMucDich3.Text = "";
            this.txtSoThuTuThua.Text = "";
            this.txtToBanDo.Text = "";
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            bool flag = this.txtSoThuTuThua.Value == 0.0 || this.txtToBanDo.Value == 0.0;
            if (flag)
            {
                MessageBox.Show("Số thửa và tờ bản đồ bắt buộc phải nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtSoThuTuThua.Focus();
            }
            else
            {
                bool isNew = this.IsNew;
                if (isNew)
                {
                    this._thuaDat = new ThuaDat();
                }
                this._thuaDat.SoThuTuThua = this.txtSoThuTuThua.Text.Trim();
                this._thuaDat.SoHieuToBanDo = this.txtToBanDo.Text.Trim();
                this._thuaDat.DiaChi = this.txtDiaChi.Text.Trim();
                this._thuaDat.ListMucDich = null;
                this._thuaDat.MucDichSuDung = "";
                bool flag2 = (this.txtMucDich1.Text.Trim() != "" && this.txtDienTich1.Value > 0.0) || (this.txtMucDich2.Text.Trim() != "" && this.txtDienTich2.Value > 0.0) || (this.txtMucDich3.Text.Trim() != "" && this.txtDienTich3.Value > 0.0);
                if (flag2)
                {
                    this._thuaDat.ListMucDich = new List<MucDichSuDung>();
                    bool flag3 = this.txtMucDich1.Text.Trim() != "" && this.txtDienTich1.Value > 0.0;
                    if (flag3)
                    {
                        this._thuaDat.ListMucDich.Add(new MucDichSuDung
                        {
                            DienTich = this.txtDienTich1.Value,
                            KyHieuMucDich = this.txtMucDich1.Text.Trim()
                        });
                    }
                    bool flag4 = this.txtMucDich2.Text.Trim() != "" && this.txtDienTich2.Value > 0.0;
                    if (flag4)
                    {
                        this._thuaDat.ListMucDich.Add(new MucDichSuDung
                        {
                            DienTich = this.txtDienTich2.Value,
                            KyHieuMucDich = this.txtMucDich2.Text.Trim()
                        });
                    }
                    bool flag5 = this.txtMucDich3.Text.Trim() != "" && this.txtDienTich3.Value > 0.0;
                    if (flag5)
                    {
                        this._thuaDat.ListMucDich.Add(new MucDichSuDung
                        {
                            DienTich = this.txtDienTich3.Value,
                            KyHieuMucDich = this.txtMucDich3.Text.Trim()
                        });
                    }
                }
                bool flag6 = this._thuaDat.ListMucDich != null;
                if (flag6)
                {
                    _thuaDat.MucDichSuDung = string.Join("; ", _thuaDat.ListMucDich.Select(t => t.KyHieuMucDich + ": " + t.DienTich));
                }
                else
                    _thuaDat.MucDichSuDung = "";
                this.Close();
            }
        }

        private void FormThuaDat_Load(object sender, EventArgs e)
        {
            this.ResetValue();
            bool flag = !this.IsNew;
            if (flag)
            {
                this.txtSoThuTuThua.Text = this._thuaDat.SoThuTuThua;
                this.txtToBanDo.Text = this._thuaDat.SoHieuToBanDo;
                this.txtDiaChi.Text = this._thuaDat.DiaChi;
                bool flag2 = this._thuaDat.ListMucDich != null;
                if (flag2)
                {
                    int count = this._thuaDat.ListMucDich.Count;
                    bool flag3 = count >= 1;
                    if (flag3)
                    {
                        this.txtMucDich1.Text = this._thuaDat.ListMucDich[0].KyHieuMucDich;
                        this.txtDienTich1.Value = this._thuaDat.ListMucDich[0].DienTich;
                    }
                    bool flag4 = count >= 2;
                    if (flag4)
                    {
                        this.txtMucDich2.Text = this._thuaDat.ListMucDich[1].KyHieuMucDich;
                        this.txtDienTich2.Value = this._thuaDat.ListMucDich[1].DienTich;
                    }
                    bool flag5 = count == 3;
                    if (flag5)
                    {
                        this.txtMucDich3.Text = this._thuaDat.ListMucDich[2].KyHieuMucDich;
                        this.txtDienTich3.Value = this._thuaDat.ListMucDich[2].DienTich;
                    }
                }
            }
            else
            {
                this.txtDiaChi.Text = string.Concat(new string[]
                {
                    GlobalVariable.TenXa,
                    ", ",
                    GlobalVariable.TenHuyen,
                    ", ",
                    GlobalVariable.TenTinh
                });
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            bool isNew = this.IsNew;
            if (isNew)
            {
                this._thuaDat = null;
            }
            base.Close();
        }
    }
}
