using System;

namespace DocumentManage.Object
{
	public class FileScanInput : FileScan
	{
		public string FullName
		{
			get;
			set;
		}

		public string Extension
		{
			get;
			set;
		}

		public bool IsLocalFile
		{
			get;
			set;
		}

		public FileScanInput()
		{
			this.IsLocalFile = true;
		}

		public FileScanInput(FileScan fileScan)
		{
			base.FileName = fileScan.FileName;
			base.FilePath = fileScan.FilePath;
			base.LoaiGiayToId = fileScan.LoaiGiayToId;
			base.MoTa = fileScan.MoTa;
			this.IsLocalFile = false;
		}
	}
}
