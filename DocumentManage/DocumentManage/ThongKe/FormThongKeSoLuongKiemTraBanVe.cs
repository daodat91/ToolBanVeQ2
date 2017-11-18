﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentManage
{
    public partial class FormThongKeSoLuongKiemTraBanVe : Form
    {
        BindingSource _bindingSource;
        public FormThongKeSoLuongKiemTraBanVe()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            _bindingSource = new BindingSource();
            dgvData.DataSource = _bindingSource;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //if(!txtStartDate.Value.HasValue)
            //{
            //    MessageBox.Show("Hãy nhập ngày bắt đầu thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    txtStartDate.Focus();
            //    return;
            //}

            //if (!txtEndDate.Value.HasValue)
            //{
            //    MessageBox.Show("Hãy nhập ngày bắt kết thúc thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    txtEndDate.Focus();
            //    return;
            //}

            _bindingSource.DataSource = ExportData.GetDataSoLuongKiemTraBanVe(txtStartDate.Value, txtEndDate.Value);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)_bindingSource.DataSource;
            string strNgayThongKe = "Ngày nhận hồ sơ: ";
            if (txtStartDate.Value.HasValue)
                strNgayThongKe += txtStartDate.Value.Value.ToString("dd/MM/yyyy");
            if (txtEndDate.Value.HasValue)
                strNgayThongKe += " đến " + txtEndDate.Value.Value.ToString("dd/MM/yyyy");

            string strFilePathTemplate = Application.StartupPath + "\\Template\\ThongKeKiemTraBanVe.xlsx";
            using (ExcelOpenXml exDoc = new ExcelOpenXml(strFilePathTemplate, "Sheet1"))
            {
                exDoc.AddItemToSpreadsheet(1, 1, strNgayThongKe);
                exDoc.AddDataTable(1, 6, dt);

                saveFileDialog1.Title = "Lưu file excel";
                saveFileDialog1.FileName = exDoc.FileName2Response;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string strFileSave = saveFileDialog1.FileName.Substring(0, saveFileDialog1.FileName.LastIndexOf('.')) + exDoc.FileType2Response;
                    FileInfo fileSave = new FileInfo(strFileSave);
                    exDoc.SaveAndClose(fileSave);
                    System.Diagnostics.Process.Start(strFileSave);
                }
                else
                    exDoc.Exit();
            }
        }
    }
}