using OfficeOpenXml;
using System;
using System.Data;
using System.IO;
using System.Net;

namespace DocumentManage
{
    public class ExcelOpenXml : IDisposable
    {
        private string _templatePath;
        private string _fileName2Response;
        public string FileName2Response
        {
            get { return _fileName2Response; }
        }


        private string _fileType2Response;
        public string FileType2Response
        {
            get { return _fileType2Response; }
        }

        private string _tempFilePath2Respone;
        public string FilePath2Respone
        {
            get { return _tempFilePath2Respone; }
        }


        private string _tempFolderPath;

        private ExcelPackage _xlPackage;
        private ExcelWorksheet _xlWorksheet;




        private bool _disposed = false;
        // Instantiate a SafeHandle instance.
        private System.Runtime.InteropServices.SafeHandle _handle = new Microsoft.Win32.SafeHandles.SafeFileHandle(IntPtr.Zero, true);



        public ExcelOpenXml(string templatePath, string sheetName)
        {
            initialize(templatePath);
            _xlWorksheet = _xlPackage.Workbook.Worksheets[sheetName];
        }

        public ExcelOpenXml(string templatePath, int sheetNumber)
        {
            initialize(templatePath);
            _xlWorksheet = _xlPackage.Workbook.Worksheets[sheetNumber];
        }

        private void initialize(string templatePath)
        {
            _templatePath = templatePath;
            FileInfo templateFile = new FileInfo(_templatePath);
            if (!templateFile.Exists) throw new Exception("Template file does not exist!" + _templatePath);

            _fileName2Response = _templatePath.Substring(_templatePath.LastIndexOf('\\') + 1);
            _fileType2Response = _fileName2Response.Substring(_fileName2Response.LastIndexOf('.'));

            _xlPackage = new ExcelPackage(templateFile, true);
        }


        ~ExcelOpenXml()
        {
            Dispose();
        }

        public void AddDataTable(int startCol, int startRow, DataTable data)
        {
            int idataRowCount = data.Rows.Count;
            int idataColumnCount = data.Columns.Count;
            _xlWorksheet.InsertRow(startRow + 1, idataRowCount - 2, startRow);

            for (int iRow = 0; iRow < idataRowCount; iRow++)
            {
                for (int iColumn = 0; iColumn < idataColumnCount; iColumn++)
                {
                    _xlWorksheet.SetValue(startRow + iRow, startCol + iColumn, data.Rows[iRow][iColumn]);
                }
            }
        }

        public void AddItemToSpreadsheet(int row, int col, string value)
        {
            _xlWorksheet.SetValue(row, col, value);
        }
        public void AddItemToSpreadsheet(int row, int col, object value)
        {
            _xlWorksheet.SetValue(row, col, value);
        }
        public void RemoveValue(int row, int col)
        {
            _xlWorksheet.SetValue(row, col, null);
        }

        public void SetWrapText(int row, int col, bool bWrapText)
        {
            _xlWorksheet.Cells[row, col].Style.WrapText = bWrapText;  //false by default
        }

        public void SetStyle(int srcRow, int srcFromColumn, int srcToColumn, int desFromRowNumber, int desToRowNumber)
        {
            for (int iCol = srcFromColumn; iCol <= srcToColumn; iCol++)
            {
                for (int iRow = desFromRowNumber; iRow <= desToRowNumber; iRow++)
                {
                    _xlWorksheet.Row(iRow).StyleID = _xlWorksheet.Row(srcRow).StyleID;
                }
            }
        }

        public void SaveAndClose(FileInfo returnFile)
        {
            _xlPackage.SaveAs(returnFile);
            _xlPackage.Dispose();

            _xlWorksheet = null;
            _xlPackage = null;
        }

        public void Exit()
        {
            _xlPackage.Dispose();

            _xlWorksheet = null;
            _xlPackage = null;
        }

        public virtual void Dispose()
        {
            if (_disposed)
                return;

            _handle.Dispose();
            // Free any other managed objects here.
            _xlWorksheet = null;
            _xlPackage = null;


            // Free any unmanaged objects here.
            _disposed = true;
        }






    }
}
