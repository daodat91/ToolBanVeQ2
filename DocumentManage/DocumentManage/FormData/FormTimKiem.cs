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
    public partial class FormTimKiem : Form
    {
        private ThongTinHoSo _thongTinHS;
        public ThongTinHoSo ThongTinHS
        {
            get
            {
                return this._thongTinHS;
            }
        }
        public FormTimKiem()
        {
            InitializeComponent();
            this.dgvKetQua.AutoGenerateColumns = false;
            this.dgvThuaDat.AutoGenerateColumns = false;
            DataTable dataTable = ManageBase.SelectAllLoaiGiayToRDT(0);
            DataRow dataRow = dataTable.NewRow();
            dataRow["LoaiGiayToId"] = 0;
            dataRow["TenLoaiGiayTo"] = "<<Chọn loại giấy tờ>>";
            dataTable.Rows.InsertAt(dataRow, 0);
            this.clnLoaiGiayTo.ValueMember = "LoaiGiayToId";
            this.clnLoaiGiayTo.DisplayMember = "TenLoaiGiayTo";
            this.clnLoaiGiayTo.DataSource = dataTable;
        }

        private void FillData(int rowIndex)
        {
            DataGridViewRow dataGridViewRow = this.dgvKetQua.Rows[rowIndex];
            ThongTinHoSo thongTinHoSo = (ThongTinHoSo)this.dgvKetQua.Rows[rowIndex].DataBoundItem;
            ChiTietHoSo thongTinChiTiet = thongTinHoSo.ThongTinChiTiet;
            bool flag = thongTinChiTiet.ListGiayChungNhan != null;
            BindingList<GiayChungNhan> dataSource;
            if (flag)
            {
                dataSource = new BindingList<GiayChungNhan>(thongTinChiTiet.ListGiayChungNhan);
            }
            else
            {
                dataSource = new BindingList<GiayChungNhan>();
            }
            this.dgvGiayChungNhan.DataSource = dataSource;
            bool flag2 = thongTinChiTiet.ListChu != null;
            BindingList<ChuSuDung> dataSource2;
            if (flag2)
            {
                dataSource2 = new BindingList<ChuSuDung>(thongTinChiTiet.ListChu);
            }
            else
            {
                dataSource2 = new BindingList<ChuSuDung>();
            }
            this.dgvChu.DataSource = dataSource2;
            bool flag3 = thongTinChiTiet.ListThua != null;
            BindingList<ThuaDat> dataSource3;
            if (flag3)
            {
                dataSource3 = new BindingList<ThuaDat>(thongTinChiTiet.ListThua);
            }
            else
            {
                dataSource3 = new BindingList<ThuaDat>();
            }
            this.dgvThuaDat.DataSource = dataSource3;
            bool flag4 = thongTinChiTiet.ListNha != null;
            BindingList<Nha> dataSource4;
            if (flag4)
            {
                dataSource4 = new BindingList<Nha>(thongTinChiTiet.ListNha);
            }
            else
            {
                dataSource4 = new BindingList<Nha>();
            }
            this.dgvNha.DataSource = dataSource4;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            this.dgvChu.Rows.Clear();
            this.dgvGiayChungNhan.Rows.Clear();
            this.dgvNha.Rows.Clear();
            this.dgvThuaDat.Rows.Clear();
            SearchInput searchInput = new SearchInput();
            searchInput.SoBienNhan = this.txtSoBienNhan.Text;
            searchInput.HoTen = this.txtHoTen.Text;
            searchInput.SoGiayTo = this.txtSoGiayTo.Text;
            searchInput.SoSerial = this.txtSoSerial.Text;
            bool flag = this.txtSoThua.Value > 0.0;
            if (flag)
            {
                searchInput.SoThua = this.txtSoThua.Value.ToString();
            }
            bool flag2 = this.txtSoTo.Value > 0.0;
            if (flag2)
            {
                searchInput.SoTo = this.txtSoTo.Value.ToString();
            }
            searchInput.SoBanVe = this.txtSoBanVe.Text;
            searchInput.LaNguoiNopHoSo = this.chkNguoiNopHoSo.Checked;
            this.Cursor = Cursors.WaitCursor;
            this.dgvKetQua.SelectionChanged -= new EventHandler(this.dgvKetQua_SelectionChanged);
            this.dgvKetQua.DataSource = ProcessData.SearchThongTinHoSo(searchInput);
            bool flag3 = this.dgvKetQua.Rows.Count > 0;
            if (flag3)
            {
                this.dgvKetQua.Rows[0].Selected = true;
            }
            this.dgvKetQua.SelectionChanged += new EventHandler(this.dgvKetQua_SelectionChanged);
            bool flag4 = this.dgvKetQua.Rows.Count > 0;
            if (flag4)
            {
                this.FillData(0);
            }
            this.Cursor = Cursors.Default;
        }

        private void dgvKetQua_SelectionChanged(object sender, EventArgs e)
        {
            bool flag = this.dgvKetQua.SelectedRows != null && this.dgvKetQua.SelectedRows.Count > 0;
            if (flag)
            {
                this.FillData(this.dgvKetQua.SelectedRows[0].Index);
            }
        }

        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            this.txtSoBienNhan.Text = "";
            this.txtHoTen.Text = "";
            this.txtSoGiayTo.Text = "";
            this.txtSoSerial.Text = "";
            this.txtSoThua.Text = "";
            this.txtSoTo.Text = "";
            this.dgvKetQua.DataSource = null;
            this.dgvChu.Rows.Clear();
            this.dgvGiayChungNhan.Rows.Clear();
            this.dgvNha.Rows.Clear();
            this.dgvThuaDat.Rows.Clear();
            this._thongTinHS = null;
        }

        private void FormTimKiem_Load(object sender, EventArgs e)
        {
            this.btnKhoiTao_Click(null, null);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            bool flag = this.dgvKetQua.SelectedRows != null && this.dgvKetQua.SelectedRows.Count > 0;
            if (flag)
            {
                this._thongTinHS = (ThongTinHoSo)this.dgvKetQua.SelectedRows[0].DataBoundItem;
                this._thongTinHS.IsNew = false;
                this._thongTinHS.IsSuccess = false;
                base.Close();
            }
            else
            {
                MessageBox.Show("Không có bản ghi nào được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this._thongTinHS = null;
            }
        }

        private void dgvKetQua_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.btnChon_Click(null, null);
        }
    }
}
