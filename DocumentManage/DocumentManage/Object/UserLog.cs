using System;

namespace DocumentManage.Object
{
	public class UserLog
	{
		public int? NguoiDungId
		{
			get;
			set;
		}

		public DateTime? NgayChinhSua
		{
			get;
			set;
		}

		public UserLog LogHistory
		{
			get;
			set;
		}
	}
}
