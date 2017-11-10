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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void loadInfo()
        {
            string configString = ProcessConfigXML.LoadData("ConnectiontString");
            Dictionary<string, object> dictionary = ProcessConfigXML.ConfigString2Dictionary(configString, new Dictionary<string, object>
            {
                {
                    "Data Source",
                    ""
                },
                {
                    "Database",
                    ""
                },
                {
                    "User ID",
                    ""
                },
                {
                    "Password",
                    ""
                }
            });
            this.txtServerName.Text = dictionary["Data Source"].ToString();
            this.txtDatabasename.Text = dictionary["Database"].ToString();
            this.txtUsernameSQL.Text = dictionary["User ID"].ToString();
            this.txtPasswordSQL.Text = Util.Decrypt(dictionary["Password"].ToString());
            string configString2 = ProcessConfigXML.LoadData("Account");
            dictionary = ProcessConfigXML.ConfigString2Dictionary(configString2, new Dictionary<string, object>
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
            this.txtLISloginUserName.Text = dictionary["User"].ToString();
            this.txtLISloginPassword.Text = Util.Decrypt(dictionary["Pass"].ToString());
            bool flag = dictionary["Remember"].ToString() == "true";
            if (flag)
            {
                this.chkLoginRemember.Checked = true;
            }
            else
            {
                this.chkLoginRemember.Checked = false;
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            loadInfo();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("Data Source", this.txtServerName.Text.Trim());
            dictionary.Add("Database", this.txtDatabasename.Text.Trim());
            dictionary.Add("User ID", this.txtUsernameSQL.Text.Trim());
            dictionary.Add("Password", this.txtPasswordSQL.Text.Trim());
            string text = ProcessConfigXML.Dictionary2ConfigString(dictionary);
            bool flag = ManageBase.IsConnectDatabase(text);
            if (flag)
            {
                string text2 = Util.Encrypt(this.txtLISloginPassword.Text.Trim());
                NguoiDungEntity nguoiDungEntity = ManageBase.SelectNguoiDung(this.txtLISloginUserName.Text.Trim(), text2);
                bool flag2 = nguoiDungEntity != null;
                if (flag2)
                {
                    Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
                    bool @checked = this.chkLoginRemember.Checked;
                    if (@checked)
                    {
                        dictionary2.Add("User", this.txtLISloginUserName.Text.Trim());
                        dictionary2.Add("Pass", text2);
                        dictionary2.Add("Remember", this.chkLoginRemember.Checked ? "true" : "false");
                    }
                    else
                    {
                        dictionary2.Add("User", "");
                        dictionary2.Add("Pass", "");
                        dictionary2.Add("Remember", "false");
                    }
                    GlobalVariable.NguoiDungId = nguoiDungEntity.NguoiDungId;
                    GlobalVariable.TenDangNhap = nguoiDungEntity.TenDangNhap;
                    GlobalVariable.HoTenNguoiDung = nguoiDungEntity.HoTenNguoiDung;
                    GlobalVariable.MatKhau = nguoiDungEntity.MatKhau;
                    GlobalVariable.LaQuanTriHeThong = (nguoiDungEntity.VaiTro == 1);
                    dictionary["Password"] = Util.Encrypt(this.txtPasswordSQL.Text.Trim());
                    text = ProcessConfigXML.Dictionary2ConfigString(dictionary);
                    string strValue = ProcessConfigXML.Dictionary2ConfigString(dictionary2);
                    ProcessConfigXML.SaveData("ConnectiontString", text);
                    ProcessConfigXML.SaveData("Account", strValue);
                    bool flag3 = GlobalVariable.CreateFTP();
                    if (flag3)
                    {
                        base.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        bool laQuanTriHeThong = GlobalVariable.LaQuanTriHeThong;
                        if (laQuanTriHeThong)
                        {
                            FormKetNoiFTP formKetNoiFTP = new FormKetNoiFTP();
                            formKetNoiFTP.ShowDialog();
                            bool flag4 = GlobalVariable.FTPLib != null;
                            if (flag4)
                            {
                                base.DialogResult = DialogResult.OK;
                                base.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hiện tại không thể kết nối tới FTP. Hãy liên hệ quản trị hệ thống thiết lập lại thông số kết nối.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtLISloginUserName.Focus();
                }
            }
            else
            {
                MessageBox.Show("Không kết nối được cơ sở dữ liệu. Kiểm tra lại thông số kết nối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtServerName.Focus();
            }
            this.Cursor = Cursors.Default;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }
    }
}
