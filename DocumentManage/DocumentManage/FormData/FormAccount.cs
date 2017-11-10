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
    public partial class FormAccount : Form
    {
        public FormAccount()
        {
            InitializeComponent();
        }

        private void FormAccount_Load(object sender, EventArgs e)
        {
            NguoiDungEntity nguoiDungEntity = ManageBase.SelectNguoiDungById(GlobalVariable.NguoiDungId);
            this.txtUser.Text = nguoiDungEntity.TenDangNhap;
            this.txtPassNew.Text = "";
            this.txtPassOld.Text = "";
            this.txtHoTen.Text = nguoiDungEntity.HoTenNguoiDung;
            this.txtSoDienThoai.Text = nguoiDungEntity.SoDienThoai;
            this.txtEmail.Text = nguoiDungEntity.DiaChiEmail;
            bool flag = nguoiDungEntity.GioiTinh == 0;
            if (flag)
            {
                this.chkGioiTinh.CheckState = CheckState.Unchecked;
            }
            else
            {
                bool flag2 = nguoiDungEntity.GioiTinh == 1;
                if (flag2)
                {
                    this.chkGioiTinh.CheckState = CheckState.Checked;
                }
                else
                {
                    this.chkGioiTinh.CheckState = CheckState.Indeterminate;
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            bool flag = this.txtUser.Text.Trim() == "" || this.txtPassOld.Text.Trim() == "" || this.txtPassNew.Text.Trim() == "";
            if (flag)
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtUser.Focus();
            }
            else
            {
                bool flag2 = this.txtPassOld.Text.Trim() != Util.Decrypt(GlobalVariable.MatKhau);
                if (flag2)
                {
                    MessageBox.Show("Mật khẩu hiện tại không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtUser.Focus();
                }
                else
                {
                    bool flag3 = !ManageBase.NguoiDungExist(GlobalVariable.NguoiDungId, this.txtUser.Text.Trim());
                    if (flag3)
                    {
                        NguoiDungEntity nguoiDungEntity = ManageBase.SelectNguoiDungById(GlobalVariable.NguoiDungId);
                        nguoiDungEntity.TenDangNhap = this.txtUser.Text.Trim();
                        nguoiDungEntity.MatKhau = Util.Encrypt(this.txtPassNew.Text.Trim());
                        nguoiDungEntity.HoTenNguoiDung = this.txtHoTen.Text.Trim();
                        nguoiDungEntity.SoDienThoai = this.txtSoDienThoai.Text.Trim();
                        nguoiDungEntity.DiaChiEmail = this.txtEmail.Text.Trim();
                        bool flag4 = this.chkGioiTinh.CheckState == CheckState.Checked;
                        if (flag4)
                        {
                            nguoiDungEntity.GioiTinh = 1;
                        }
                        else
                        {
                            bool flag5 = this.chkGioiTinh.CheckState == CheckState.Unchecked;
                            if (flag5)
                            {
                                nguoiDungEntity.GioiTinh = 0;
                            }
                            else
                            {
                                nguoiDungEntity.GioiTinh = 3;
                            }
                        }
                        bool flag6 = ManageBase.SaveNguoiDung(nguoiDungEntity);
                        if (flag6)
                        {
                            GlobalVariable.TenDangNhap = nguoiDungEntity.TenDangNhap;
                            GlobalVariable.MatKhau = nguoiDungEntity.MatKhau;
                            string text = ProcessConfigXML.LoadData("Account");
                            Dictionary<string, object> dictionary = ProcessConfigXML.ConfigString2Dictionary(text, new Dictionary<string, object>
                            {
                                {
                                    "User",
                                    ""
                                },
                                {
                                    "Pass",
                                    ""
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
                            MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật tài khoản không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtUser.Focus();
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
