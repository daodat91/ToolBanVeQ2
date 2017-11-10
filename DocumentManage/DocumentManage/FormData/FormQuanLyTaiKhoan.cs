using DAL.ManageDocument.EntityClasses;
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
    public partial class FormQuanLyTaiKhoan : Form
    {
        private BindingSource _bindingTaiKhoan;
        public FormQuanLyTaiKhoan()
        {
            InitializeComponent();
            this.dgvTaiKhoan.AutoGenerateColumns = false;
            this.cboVaiTro.SelectedIndex = 0;
            this._bindingTaiKhoan = new BindingSource();
            this._bindingTaiKhoan.DataSource = ManageBase.CreateTableNguoiDung();
            this.dgvTaiKhoan.DataSource = this._bindingTaiKhoan;
        }

        private void ClearDataForm()
        {
            this.txtSearchHoTen.Text = "";
            this.txtSearchUser.Text = "";
            ((DataTable)this._bindingTaiKhoan.DataSource).Rows.Clear();
            this.ClearDataTaiKhoan();
            this.btnThemMoi.Enabled = true;
            this.btnCapNhat.Enabled = true;
            this.btnBoQua.Enabled = true;
            this.btnXoa.Enabled = true;
        }

        private void ClearDataTaiKhoan()
        {
            this.txtUser.Text = "";
            this.txtPass.Text = "";
            this.txtHoTen.Text = "";
            this.txtSoDienThoai.Text = "";
            this.txtEmail.Text = "";
            this.cboVaiTro.SelectedIndex = 0;
            this.chkGioiTinh.CheckState = CheckState.Unchecked;
        }

        private void FillData(int rowIndex)
        {
            DataRow row = ((DataRowView)this.dgvTaiKhoan.Rows[rowIndex].DataBoundItem).Row;
            this.btnCapNhat.Tag = row["NguoiDungId"];
            this.txtUser.Text = row["TenDangNhap"].ToString();
            this.txtPass.Text = Util.Decrypt(row["MatKhau"].ToString());
            this.txtHoTen.Text = row["HoTenNguoiDung"].ToString();
            this.txtSoDienThoai.Text = row["SoDienThoai"].ToString();
            this.txtEmail.Text = row["DiaChiEmail"].ToString();
            this.cboVaiTro.SelectedIndex = (int)((byte)row["VaiTro"]);
            bool flag = (byte)row["GioiTinh"] == 1;
            if (flag)
            {
                this.chkGioiTinh.CheckState = CheckState.Checked;
            }
            else
            {
                bool flag2 = (byte)row["GioiTinh"] == 0;
                if (flag2)
                {
                    this.chkGioiTinh.CheckState = CheckState.Unchecked;
                }
                else
                {
                    this.chkGioiTinh.CheckState = CheckState.Indeterminate;
                }
            }
            this.btnCapNhat.Enabled = true;
            this.btnThemMoi.Enabled = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            this.dgvTaiKhoan.SelectionChanged -= new EventHandler(this.dgvTaiKhoan_SelectionChanged);
            DataTable dataSource = ManageBase.SearchNguoiDungRDT(this.txtSearchUser.Text.Trim(), this.txtSearchHoTen.Text.Trim());
            this._bindingTaiKhoan.DataSource = dataSource;
            bool flag = this.dgvTaiKhoan.Rows.Count > 0;
            if (flag)
            {
                this.dgvTaiKhoan.Rows[0].Selected = true;
            }
            this.dgvTaiKhoan.SelectionChanged += new EventHandler(this.dgvTaiKhoan_SelectionChanged);
            bool flag2 = this.dgvTaiKhoan.Rows.Count > 0;
            if (flag2)
            {
                this.FillData(0);
            }
        }

        private void FormQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            this.ClearDataForm();
        }

        private void dgvTaiKhoan_SelectionChanged(object sender, EventArgs e)
        {
            this.ClearDataTaiKhoan();
            bool flag = this.dgvTaiKhoan.SelectedRows != null && this.dgvTaiKhoan.SelectedRows.Count > 0;
            if (flag)
            {
                this.FillData(this.dgvTaiKhoan.SelectedRows[0].Index);
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            this.dgvTaiKhoan.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnCapNhat.Tag = 0;
            this.btnThemMoi.Enabled = false;
            this.ClearDataTaiKhoan();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            bool flag = false;
            int num = Convert.ToInt32(this.btnCapNhat.Tag.ToString());
            NguoiDungEntity nguoiDungEntity = null;
            bool flag2 = !this.btnThemMoi.Enabled && num == 0;
            if (flag2)
            {
                nguoiDungEntity = new NguoiDungEntity();
                flag = true;
            }
            else
            {
                bool flag3 = num > 0;
                if (flag3)
                {
                    nguoiDungEntity = ManageBase.SelectNguoiDungById(num);
                }
            }
            bool flag4 = nguoiDungEntity != null;
            if (flag4)
            {
                bool flag5 = this.txtUser.Text.Trim() == "" || this.txtPass.Text.Trim() == "";
                if (flag5)
                {
                    MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtUser.Focus();
                    this.Cursor = Cursors.Default;
                    return;
                }
                bool flag6 = ManageBase.NguoiDungExist(num, this.txtUser.Text.Trim());
                if (flag6)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại. Hãy chọn tên đăng nhập khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtUser.Focus();
                    this.Cursor = Cursors.Default;
                    return;
                }
                nguoiDungEntity.TenDangNhap = this.txtUser.Text.Trim();
                nguoiDungEntity.MatKhau = Util.Encrypt(this.txtPass.Text.Trim());
                nguoiDungEntity.HoTenNguoiDung = this.txtHoTen.Text.Trim();
                nguoiDungEntity.SoDienThoai = this.txtSoDienThoai.Text.Trim();
                nguoiDungEntity.DiaChiEmail = this.txtEmail.Text.Trim();
                nguoiDungEntity.VaiTro = (byte)this.cboVaiTro.SelectedIndex;
                bool flag7 = this.chkGioiTinh.CheckState == CheckState.Checked;
                if (flag7)
                {
                    nguoiDungEntity.GioiTinh = 1;
                }
                else
                {
                    bool flag8 = this.chkGioiTinh.CheckState == CheckState.Unchecked;
                    if (flag8)
                    {
                        nguoiDungEntity.GioiTinh = 0;
                    }
                    else
                    {
                        nguoiDungEntity.GioiTinh = 3;
                    }
                }
                bool flag9 = ManageBase.SaveNguoiDung(nguoiDungEntity);
                if (flag9)
                {
                    bool flag10 = nguoiDungEntity.NguoiDungId == GlobalVariable.NguoiDungId;
                    if (flag10)
                    {
                        GlobalVariable.TenDangNhap = nguoiDungEntity.TenDangNhap;
                        GlobalVariable.MatKhau = nguoiDungEntity.MatKhau;
                        string text = ProcessConfigXML.LoadData("Account");
                        Dictionary<string, object> dictionary = ProcessConfigXML.ConfigString2Dictionary(text, new Dictionary<string, object>
                        {
                            {
                                "User",
                                "admin"
                            },
                            {
                                "Pass",
                                "123"
                            },
                            {
                                "Remember",
                                "true"
                            }
                        });
                        dictionary["User"] = nguoiDungEntity.TenDangNhap;
                        dictionary["Pass"] = nguoiDungEntity.MatKhau;
                        text = ProcessConfigXML.Dictionary2ConfigString(dictionary);
                        ProcessConfigXML.SaveData("Account", text);
                    }
                    bool flag11 = flag;
                    if (flag11)
                    {
                        DataTable dataTable = (DataTable)this._bindingTaiKhoan.DataSource;
                        DataRow dataRow = dataTable.NewRow();
                        dataRow["NguoiDungId"] = nguoiDungEntity.NguoiDungId;
                        dataRow["TenDangNhap"] = nguoiDungEntity.TenDangNhap;
                        dataRow["MatKhau"] = nguoiDungEntity.MatKhau;
                        dataRow["HoTenNguoiDung"] = nguoiDungEntity.HoTenNguoiDung;
                        dataRow["GioiTinh"] = nguoiDungEntity.GioiTinh;
                        dataRow["SoDienThoai"] = nguoiDungEntity.SoDienThoai;
                        dataRow["DiaChiEmail"] = nguoiDungEntity.DiaChiEmail;
                        dataRow["VaiTro"] = nguoiDungEntity.VaiTro;
                        dataTable.Rows.Add(dataRow);
                        this.dgvTaiKhoan.Rows[this.dgvTaiKhoan.Rows.Count - 1].Selected = true;
                    }
                    this.btnThemMoi.Enabled = true;
                    this.dgvTaiKhoan.Enabled = true;
                    this.btnXoa.Enabled = true;
                    this.dgvTaiKhoan_SelectionChanged(null, null);
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Cập nhật tài khoản không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.btnThemMoi.Enabled = true;
            this.dgvTaiKhoan.Enabled = true;
            this.btnXoa.Enabled = true;
            this.dgvTaiKhoan_SelectionChanged(null, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool flag = this.dgvTaiKhoan.SelectedRows != null && this.dgvTaiKhoan.SelectedRows.Count > 0;
            if (flag)
            {
                DataRow row = ((DataRowView)this.dgvTaiKhoan.SelectedRows[0].DataBoundItem).Row;
                bool flag2 = (int)row["NguoiDungId"] == GlobalVariable.NguoiDungId;
                if (flag2)
                {
                    MessageBox.Show("Không thể xoá tài khoản " + row["TenDangNhap"].ToString() + Environment.NewLine + "Tài khoản cần xoá là của chính bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    bool flag3 = MessageBox.Show("Bạn có chắc chắn muốn xoá tài khoản " + row["TenDangNhap"].ToString(), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK;
                    if (flag3)
                    {
                        bool flag4 = ManageBase.DeleteNguoiDung((int)row["NguoiDungId"]);
                        if (flag4)
                        {
                            this._bindingTaiKhoan.RemoveAt(this.dgvTaiKhoan.SelectedRows[0].Index);
                            MessageBox.Show("Đã xoá tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.btnCapNhat.Tag = 0;
                            this.dgvTaiKhoan_SelectionChanged(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Xoá tài khoản không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có tài khoản được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
