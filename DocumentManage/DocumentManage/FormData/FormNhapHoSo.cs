using DocumentManage.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DocumentManage
{
    public partial class FormNhapHoSo : Form
    {
        public ThongTinHoSo _thongTinHoSo;

        private FormThuaDat _frmThuaDat = new FormThuaDat();

        private FormLichSuNguoiDung _frmLichSuNguoiDung;
        public FormNhapHoSo()
        {
            InitializeComponent();
            this.dgvFileScan.AutoGenerateColumns = false;
            this.dgvThuaDat.AutoGenerateColumns = false;
            DataTable dataTable = ManageBase.SelectAllLoaiGiayToRDT(0);
            DataRow dataRow = dataTable.NewRow();
            dataRow["LoaiGiayToId"] = 0;
            dataRow["TenLoaiGiayTo"] = "<<Chọn loại giấy tờ>>";
            dataTable.Rows.InsertAt(dataRow, 0);
            this.clnLoaiGiayTo.ValueMember = "LoaiGiayToId";
            this.clnLoaiGiayTo.DisplayMember = "TenLoaiGiayTo";
            this.clnLoaiGiayTo.DataSource = dataTable;
            dataTable = ManageBase.SelectAllLoaiGiayToRDT(1);
            GlobalVariable.DictLoaiGiayToFile = new Dictionary<int, string>();
            foreach (DataRow dataRow2 in dataTable.Rows)
            {
                GlobalVariable.DictLoaiGiayToFile.Add((int)dataRow2["LoaiGiayToId"], dataRow2["MaLoaiGiayTo"].ToString());
            }
            dataRow = dataTable.NewRow();
            dataRow["LoaiGiayToId"] = 0;
            dataRow["TenLoaiGiayTo"] = "<<Chọn loại giấy tờ>>";
            dataTable.Rows.InsertAt(dataRow, 0);
            this.clnLoaiGiayToFile.ValueMember = "LoaiGiayToId";
            this.clnLoaiGiayToFile.DisplayMember = "TenLoaiGiayTo";
            this.clnLoaiGiayToFile.DataSource = dataTable;

            DataTable dataTable2 = ManageBase.SelectAllLoaiBienDongRDT();
            dataRow = dataTable2.NewRow();
            dataRow["LoaiBienDongId"] = 0;
            dataRow["TenLoaiBienDong"] = "<<Chọn loại biến động>>";
            dataTable2.Rows.InsertAt(dataRow, 0);
            this.cboLoaiBienDong.DataSource = dataTable2;

            dataTable2 = ManageBase.SelectAllChuyenVienRDT();
            dataRow = dataTable2.NewRow();
            dataRow["ChuyenVienId"] = 0;
            dataRow["TenChuyenVien"] = "<<Chọn người kiểm tra nội nghiệp>>";
            dataTable2.Rows.InsertAt(dataRow, 0);
            this.cboChuyenVienKiemTra.DataSource = dataTable2;

            dataTable2 = ManageBase.SelectAllCongTyDoVeRDT();
            dataRow = dataTable2.NewRow();
            dataRow["CongTyDoVeId"] = 0;
            dataRow["TenCongTyDoVe"] = "<<Chọn công ty đo vẽ>>";
            dataTable2.Rows.InsertAt(dataRow, 0);
            this.cboCongTyDoVe.DataSource = dataTable2;
        }

        private void FormNhapHoSo_Load(object sender, EventArgs e)
        {
            bool isNew = this._thongTinHoSo.IsNew;
            if (isNew)
            {
                this.Text = "Thêm bản vẽ kỹ thuật";
            }
            else
            {
                this.Text = "Chỉnh sửa thông tin bản vẽ";
            }
            this.dgvChu.Rows.Clear();
            this.dgvFileScan.Rows.Clear();
            this.dgvGiayChungNhan.Rows.Clear();
            this.dgvNha.Rows.Clear();
            this.dgvThuaDat.Rows.Clear();
            bool flag = this._thongTinHoSo.IsNew && this._thongTinHoSo.ThongTinChiTiet == null;
            if (flag)
            {
                this._thongTinHoSo.ThongTinChiTiet = new ChiTietHoSo();
            }
            this.txtSoBienNhan.Text = this._thongTinHoSo.SoBienNhan;
            this.txtNgayNop.Value = this._thongTinHoSo.NgayNop;
            this.txtNgayHenTra.Value = this._thongTinHoSo.NgayHenTra;
            this.txtNgayTraHoSo.Value = this._thongTinHoSo.NgayTraHoSo;
            this.txtNgayKiemTraNoiNghiep.Value = this._thongTinHoSo.NgayKiemTraNoiNghiep;
            this.txtSoBanVe.Text = this._thongTinHoSo.SoBanVe;
            bool hasValue = this._thongTinHoSo.PhiDoVe.HasValue;
            if (hasValue)
            {
                this.txtPhiDoVe.Value = this._thongTinHoSo.PhiDoVe.Value;
            }
            else
            {
                this.txtPhiDoVe.Text = "";
            }
            this.txtGhiChu.Text = this._thongTinHoSo.GhiChu;
            this.chkGioiTinhNguoiNop.Checked = this._thongTinHoSo.GioiTinhNguoiNop;
            this.txtHoTenNguoiNop.Text = this._thongTinHoSo.NguoiNopHoSo;
            this.txtSoGiayToNguoiNop.Text = this._thongTinHoSo.SoGiayToNguoiNop;
            chkHoSoHopLy.Checked = _thongTinHoSo.HoSoKhongHopLy;
            chkHoSoDaKiemTra.Checked = _thongTinHoSo.HoSoDaKiemTra;
            chkHoSoChuaDat.Checked = _thongTinHoSo.HoSoChuaDat;
            bool hasValue2 = this._thongTinHoSo.PhiThamDinh.HasValue;
            if (hasValue2)
            {
                this.txtPhiThamDinh.Value = this._thongTinHoSo.PhiThamDinh.Value;
            }
            else
            {
                this.txtPhiThamDinh.Text = "";
            }
            if (_thongTinHoSo.ChuyenVienId != null)
                cboChuyenVienKiemTra.SelectedValue = _thongTinHoSo.ChuyenVienId;
            else
                cboChuyenVienKiemTra.SelectedIndex = 0;
            if (_thongTinHoSo.CongTyDoVeId != null)
                cboCongTyDoVe.SelectedValue = _thongTinHoSo.CongTyDoVeId;
            else
                cboCongTyDoVe.SelectedIndex = 0;
            string text = "";
            bool flag2 = !string.IsNullOrEmpty(this._thongTinHoSo.NguoiCapNhat);
            if (flag2)
            {
                text += this._thongTinHoSo.NguoiCapNhat;
            }
            DateTime? ngayChinhSua = this._thongTinHoSo.NgayChinhSua;
            bool hasValue3 = ngayChinhSua.HasValue;
            if (hasValue3)
            {
                string arg_2B7_0 = text;
                string arg_2B7_1 = " cập nhật lần cuối cùng vào lúc ";
                ngayChinhSua = this._thongTinHoSo.NgayChinhSua;
                text = arg_2B7_0 + arg_2B7_1 + (ngayChinhSua.HasValue ? ngayChinhSua.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss") : null);
            }
            this.txtNguoiCapNhatCuoi.Text = text;
            this.cboLoaiBienDong.SelectedIndex = 0;
            bool hasValue4 = this._thongTinHoSo.LoaiBienDongId.HasValue;
            if (hasValue4)
            {
                this.cboLoaiBienDong.SelectedValue = this._thongTinHoSo.LoaiBienDongId;
            }
            bool flag3 = this._thongTinHoSo.ThongTinChiTiet.ListGiayChungNhan != null;
            BindingList<GiayChungNhan> dataSource;
            if (flag3)
            {
                dataSource = new BindingList<GiayChungNhan>(this._thongTinHoSo.ThongTinChiTiet.ListGiayChungNhan);
            }
            else
            {
                dataSource = new BindingList<GiayChungNhan>();
            }
            this.dgvGiayChungNhan.DataSource = dataSource;
            bool flag4 = this._thongTinHoSo.ThongTinChiTiet.ListChu != null;
            BindingList<ChuSuDung> dataSource2;
            if (flag4)
            {
                dataSource2 = new BindingList<ChuSuDung>(this._thongTinHoSo.ThongTinChiTiet.ListChu);
            }
            else
            {
                dataSource2 = new BindingList<ChuSuDung>();
            }
            this.dgvChu.DataSource = dataSource2;
            bool flag5 = this._thongTinHoSo.ThongTinChiTiet.ListThua != null;
            BindingList<ThuaDat> dataSource3;
            if (flag5)
            {
                dataSource3 = new BindingList<ThuaDat>(this._thongTinHoSo.ThongTinChiTiet.ListThua);
            }
            else
            {
                dataSource3 = new BindingList<ThuaDat>();
            }
            this.dgvThuaDat.DataSource = dataSource3;
            bool flag6 = this._thongTinHoSo.ThongTinChiTiet.ListNha != null;
            BindingList<Nha> dataSource4;
            if (flag6)
            {
                dataSource4 = new BindingList<Nha>(this._thongTinHoSo.ThongTinChiTiet.ListNha);
            }
            else
            {
                dataSource4 = new BindingList<Nha>();
            }
            this.dgvNha.DataSource = dataSource4;
            bool flag7 = this._thongTinHoSo.ThongTinChiTiet.ListFile != null;
            BindingList<FileScanInput> bindingList;
            if (flag7)
            {
                bindingList = new BindingList<FileScanInput>();
                foreach (FileScan current in this._thongTinHoSo.ThongTinChiTiet.ListFile)
                {
                    bindingList.Add(new FileScanInput(current));
                }
            }
            else
            {
                bindingList = new BindingList<FileScanInput>();
            }
            this.dgvFileScan.DataSource = bindingList;
        }

        private void dgvChu_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvFileScan_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvGiayChungNhan_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            bool flag = this.dgvGiayChungNhan.Columns[e.ColumnIndex].Name == "clnNgayVaoSo";
            if (flag)
            {
                this.dgvGiayChungNhan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                this.dgvGiayChungNhan.RefreshEdit();
                this.dgvGiayChungNhan.Refresh();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            bool flag = this.dgvChu.Rows.Count == 0;
            if (flag)
            {
                MessageBox.Show("Hãy nhập thông tin chủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                bool flag2 = this.dgvThuaDat.Rows.Count == 0 && this.dgvNha.Rows.Count == 0;
                if (flag2)
                {
                    MessageBox.Show("Hãy nhập thông tin thửa đất hoặc nhà!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    bool flag3 = this.dgvChu.Rows.Count == 0;
                    if (flag3)
                    {
                        MessageBox.Show("Bạn có chắc chắn không chọn file đính kèm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        this.Cursor = Cursors.WaitCursor;
                        BindingList<GiayChungNhan> bindingList = (BindingList<GiayChungNhan>)this.dgvGiayChungNhan.DataSource;
                        BindingList<ChuSuDung> bindingList2 = (BindingList<ChuSuDung>)this.dgvChu.DataSource;
                        BindingList<ThuaDat> bindingList3 = (BindingList<ThuaDat>)this.dgvThuaDat.DataSource;
                        BindingList<Nha> bindingList4 = (BindingList<Nha>)this.dgvNha.DataSource;
                        BindingList<FileScanInput> bindingList5 = (BindingList<FileScanInput>)this.dgvFileScan.DataSource;
                        bool flag4 = ProcessData.UploadFile2Server(this.txtSoBienNhan.Text.Trim().Replace('/', '_').Replace('\\', '_'), ref bindingList5);
                        if (flag4)
                        {
                            ChiTietHoSo chiTietHoSo = new ChiTietHoSo();
                            bool flag5 = bindingList2.Count > 0;
                            if (flag5)
                            {
                                chiTietHoSo.ListChu = bindingList2.ToList<ChuSuDung>();
                            }
                            bool flag6 = bindingList5.Count > 0;
                            if (flag6)
                            {
                                chiTietHoSo.ListFile = new List<FileScan>();
                                foreach (FileScanInput current in bindingList5)
                                {
                                    chiTietHoSo.ListFile.Add(new FileScan
                                    {
                                        FileName = current.FileName,
                                        FilePath = current.FilePath,
                                        LoaiGiayToId = current.LoaiGiayToId,
                                        MoTa = current.MoTa
                                    });
                                }
                            }
                            bool flag7 = bindingList.Count > 0;
                            if (flag7)
                            {
                                chiTietHoSo.ListGiayChungNhan = bindingList.ToList<GiayChungNhan>();
                            }
                            bool flag8 = bindingList4.Count > 0;
                            if (flag8)
                            {
                                chiTietHoSo.ListNha = bindingList4.ToList<Nha>();
                            }
                            bool flag9 = bindingList3.Count > 0;
                            if (flag9)
                            {
                                chiTietHoSo.ListThua = bindingList3.ToList<ThuaDat>();
                            }
                            this._thongTinHoSo.ThongTinChiTiet = chiTietHoSo;
                            bool flag10 = this.cboLoaiBienDong.SelectedIndex > 0;
                            if (flag10)
                            {
                                this._thongTinHoSo.LoaiBienDongId = new int?((int)this.cboLoaiBienDong.SelectedValue);
                            }
                            this._thongTinHoSo.SoBienNhan = this.txtSoBienNhan.Text.Trim();
                            this._thongTinHoSo.NgayNop = this.txtNgayNop.Value;
                            this._thongTinHoSo.NgayHenTra = this.txtNgayHenTra.Value;
                            this._thongTinHoSo.NgayTraHoSo = this.txtNgayTraHoSo.Value;
                            this._thongTinHoSo.NgayKiemTraNoiNghiep = this.txtNgayKiemTraNoiNghiep.Value;
                            bool flag11 = this.txtPhiDoVe.Value > 0.0;
                            if (flag11)
                            {
                                this._thongTinHoSo.PhiDoVe = new double?(this.txtPhiDoVe.Value);
                            }
                            else
                            {
                                this._thongTinHoSo.PhiDoVe = null;
                            }
                            this._thongTinHoSo.SoBanVe = this.txtSoBanVe.Text.Trim();
                            this._thongTinHoSo.GhiChu = this.txtGhiChu.Text;
                            this._thongTinHoSo.GioiTinhNguoiNop = this.chkGioiTinhNguoiNop.Checked;
                            this._thongTinHoSo.NguoiNopHoSo = this.txtHoTenNguoiNop.Text.Trim();
                            this._thongTinHoSo.SoGiayToNguoiNop = this.txtSoGiayToNguoiNop.Text.Trim();
                            _thongTinHoSo.HoSoChuaDat = chkHoSoChuaDat.Checked;
                            _thongTinHoSo.HoSoDaKiemTra = chkHoSoDaKiemTra.Checked;
                            _thongTinHoSo.HoSoKhongHopLy = chkHoSoHopLy.Checked;
                            bool flag12 = this.txtPhiThamDinh.Value > 0.0;
                            if (flag12)
                            {
                                this._thongTinHoSo.PhiThamDinh = new double?(this.txtPhiThamDinh.Value);
                            }
                            else
                            {
                                this._thongTinHoSo.PhiThamDinh = null;
                            }
                            if(cboChuyenVienKiemTra.SelectedIndex > 0)
                            {
                                _thongTinHoSo.ChuyenVienId = (int)cboChuyenVienKiemTra.SelectedValue;
                                _thongTinHoSo.ChuyenVienKiemTra = cboChuyenVienKiemTra.Text;
                            }
                            else
                            {
                                _thongTinHoSo.ChuyenVienId = null;
                                _thongTinHoSo.ChuyenVienKiemTra = "";
                            }
                            if (cboCongTyDoVe.SelectedIndex > 0)
                            {
                                _thongTinHoSo.CongTyDoVeId = (int)cboCongTyDoVe.SelectedValue;
                                _thongTinHoSo.CongTyDoVe = cboCongTyDoVe.Text;
                            }
                            else
                            {
                                _thongTinHoSo.CongTyDoVeId = null;
                                _thongTinHoSo.CongTyDoVe = "";
                            }
                            bool flag13 = ProcessData.SaveThongTinHoSo(ref this._thongTinHoSo);
                            if (flag13)
                            {
                                string text = "";
                                bool flag14 = !string.IsNullOrEmpty(this._thongTinHoSo.NguoiCapNhat);
                                if (flag14)
                                {
                                    text += this._thongTinHoSo.NguoiCapNhat;
                                }
                                DateTime? ngayChinhSua = this._thongTinHoSo.NgayChinhSua;
                                bool hasValue = ngayChinhSua.HasValue;
                                if (hasValue)
                                {
                                    string arg_4CC_0 = text;
                                    string arg_4CC_1 = " cập nhật lần cuối cùng vào lúc ";
                                    ngayChinhSua = this._thongTinHoSo.NgayChinhSua;
                                    text = arg_4CC_0 + arg_4CC_1 + (ngayChinhSua.HasValue ? ngayChinhSua.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss") : null);
                                }
                                this.txtNguoiCapNhatCuoi.Text = text;
                                MessageBox.Show("Cập nhật hồ sơ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật hồ sơ không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật hồ sơ không thành công!" + Environment.NewLine + "Lỗi upload file scan.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        this.dgvFileScan.Refresh();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void dgvChu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool flag = e.ColumnIndex >= 0 && this.dgvChu.Columns[e.ColumnIndex].Name == "clnLoaiGiayTo";
            if (flag)
            {
                this.dgvChu.BeginEdit(true);
                ComboBox comboBox = (ComboBox)this.dgvChu.EditingControl;
                comboBox.DroppedDown = true;
            }
        }

        private void dgvFileScan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool flag = e.ColumnIndex >= 0;
            if (flag)
            {
                bool flag2 = this.dgvFileScan.Columns[e.ColumnIndex].Name == "clnLoaiGiayToFile";
                if (flag2)
                {
                    this.dgvFileScan.BeginEdit(true);
                    ComboBox comboBox = (ComboBox)this.dgvFileScan.EditingControl;
                    comboBox.DroppedDown = true;
                }
                else
                {
                    bool flag3 = this.dgvFileScan.Columns[e.ColumnIndex].Name == "clnView";
                    if (flag3)
                    {
                        FileScanInput fileScanInput = (FileScanInput)this.dgvFileScan.Rows[e.RowIndex].DataBoundItem;
                        bool flag4 = fileScanInput.IsLocalFile || !string.IsNullOrEmpty(fileScanInput.FullName);
                        if (flag4)
                        {
                            Process.Start(fileScanInput.FullName);
                        }
                        else
                        {
                            ProcessData.ReadFileFromServer(fileScanInput.FilePath);
                        }
                    }
                    else
                    {
                        bool flag5 = this.dgvFileScan.Columns[e.ColumnIndex].Name == "clnXoaFile";
                        if (flag5)
                        {
                            bool flag6 = MessageBox.Show("Bạn chắc chắn muốn xoá file đã chọn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK;
                            if (flag6)
                            {
                                this.dgvFileScan.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                    }
                }
            }
        }

        private void lblThemGCN_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BindingList<GiayChungNhan> bindingList = (BindingList<GiayChungNhan>)this.dgvGiayChungNhan.DataSource;
            bindingList.Add(new GiayChungNhan());
        }

        private void lblThemChu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BindingList<ChuSuDung> bindingList = (BindingList<ChuSuDung>)this.dgvChu.DataSource;
            bindingList.Add(new ChuSuDung
            {
                LoaiGiayToId = 0
            });
        }

        private void lblThemThua_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool flag = this._frmThuaDat == null;
            if (flag)
            {
                this._frmThuaDat = new FormThuaDat();
            }
            this._frmThuaDat.IsNew = true;
            this._frmThuaDat.ShowDialog();
            bool flag2 = this._frmThuaDat.ThuaDat != null;
            if (flag2)
            {
                BindingList<ThuaDat> bindingList = (BindingList<ThuaDat>)this.dgvThuaDat.DataSource;
                bindingList.Add(this._frmThuaDat.ThuaDat);
            }
            this.dgvThuaDat.Refresh();
        }

        private void lblChinhSuaThuaDat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool flag = this.dgvThuaDat.SelectedRows != null && this.dgvThuaDat.SelectedRows.Count > 0;
            if (flag)
            {
                ThuaDat thuaDat = (ThuaDat)this.dgvThuaDat.SelectedRows[0].DataBoundItem;
                bool flag2 = this._frmThuaDat == null;
                if (flag2)
                {
                    this._frmThuaDat = new FormThuaDat();
                }
                this._frmThuaDat.IsNew = false;
                this._frmThuaDat.ThuaDat = thuaDat;
                this._frmThuaDat.ShowDialog();
            }
            this.dgvThuaDat.Refresh();
        }

        private void dgvThuaDat_DoubleClick(object sender, EventArgs e)
        {
            bool flag = this.dgvThuaDat.SelectedRows != null && this.dgvThuaDat.SelectedRows.Count > 0;
            if (flag)
            {
                ThuaDat thuaDat = (ThuaDat)this.dgvThuaDat.SelectedRows[0].DataBoundItem;
                bool flag2 = this._frmThuaDat == null;
                if (flag2)
                {
                    this._frmThuaDat = new FormThuaDat();
                }
                this._frmThuaDat.IsNew = false;
                this._frmThuaDat.ThuaDat = thuaDat;
                this._frmThuaDat.ShowDialog();
            }
            this.dgvThuaDat.Refresh();
        }

        private void lblThemNha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BindingList<Nha> bindingList = (BindingList<Nha>)this.dgvNha.DataSource;
            bindingList.Add(new Nha());
        }

        private void lblThemFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool flag = this.openFileScan.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                BindingList<FileScanInput> bindingList = (BindingList<FileScanInput>)this.dgvFileScan.DataSource;
                string[] fileNames = this.openFileScan.FileNames;
                for (int i = 0; i < fileNames.Length; i++)
                {
                    string fileName = fileNames[i];
                    FileInfo fileInfo = new FileInfo(fileName);
                    bindingList.Add(new FileScanInput
                    {
                        IsLocalFile = true,
                        FullName = fileInfo.FullName,
                        Extension = fileInfo.Extension,
                        FileName = fileInfo.Name,
                        LoaiGiayToId = 7
                    });
                }
            }
        }

        private void txtGhiChu_DoubleClick(object sender, EventArgs e)
        {
            ProcessData.HienThiDoanVanBan((TextBox)sender, "Nội dung ghi chú");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            bool flag = this._thongTinHoSo.LichSuCapNhat != null;
            if (flag)
            {
                this.Cursor = Cursors.WaitCursor;
                bool flag2 = this._frmLichSuNguoiDung == null;
                if (flag2)
                {
                    this._frmLichSuNguoiDung = new FormLichSuNguoiDung();
                }
                this._frmLichSuNguoiDung.UserLog = this._thongTinHoSo.LichSuCapNhat;
                this._frmLichSuNguoiDung.ShowDialog();
                this.Cursor = Cursors.Default;
            }
        }

        private void txtNgayHenTra_DoubleClick(object sender, EventArgs e)
        {
            if (txtNgayNop.Value != null)
                txtNgayHenTra.Value = txtNgayNop.Value.Value.AddDays(10);
        }

        FormChuyenVien frmChuyenVien;
        private void btnChuyenVien_Click(object sender, EventArgs e)
        {
            if (frmChuyenVien == null)
                frmChuyenVien = new DocumentManage.FormChuyenVien();
            frmChuyenVien.ShowDialog();

            DataTable dataTable2 = ManageBase.SelectAllChuyenVienRDT();
            DataRow dataRow = dataTable2.NewRow();
            dataRow["ChuyenVienId"] = 0;
            dataRow["TenChuyenVien"] = "<<Chọn người kiểm tra nội nghiệp>>";
            dataTable2.Rows.InsertAt(dataRow, 0);
            this.cboChuyenVienKiemTra.DataSource = dataTable2;
        }

        FormCongTyDoVe frmCongTyDoVe;
        private void btnCongTyDoVe_Click(object sender, EventArgs e)
        {
            if (frmCongTyDoVe == null)
                frmCongTyDoVe = new DocumentManage.FormCongTyDoVe();
            frmCongTyDoVe.ShowDialog();

            DataTable dataTable2 = ManageBase.SelectAllCongTyDoVeRDT();
            DataRow dataRow = dataTable2.NewRow();
            dataRow["CongTyDoVeId"] = 0;
            dataRow["TenCongTyDoVe"] = "<<Chọn công ty đo vẽ>>";
            dataTable2.Rows.InsertAt(dataRow, 0);
            this.cboCongTyDoVe.DataSource = dataTable2;
        }
    }
}
