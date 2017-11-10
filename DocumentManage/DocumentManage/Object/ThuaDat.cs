using System;
using System.Collections.Generic;

namespace DocumentManage.Object
{
	public class ThuaDat
	{
		public string SoThuTuThua
		{
			get;
			set;
		}

		public string SoHieuToBanDo
		{
			get;
			set;
		}

		public string MucDichSuDung
		{
			get;
			set;
		}

		public string DiaChi
		{
			get;
			set;
		}

		public List<MucDichSuDung> ListMucDich
		{
			get;
			set;
		}
	}
}
