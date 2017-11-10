using DocumentManage.Object;
using FTPDotNet20;
using System;
using System.Collections.Generic;

namespace DocumentManage
{
	public class GlobalVariable
	{
		private static FTP _fTPLib;

		public static int NguoiDungId
		{
			get;
			set;
		}

		public static string TenDangNhap
		{
			get;
			set;
		}

		public static string HoTenNguoiDung
		{
			get;
			set;
		}

		public static string MatKhau
		{
			get;
			set;
		}

		public static bool LaQuanTriHeThong
		{
			get;
			set;
		}

		public static int TinhId
		{
			get;
			set;
		}

		public static string MaTinh
		{
			get;
			set;
		}

		public static string TenTinh
		{
			get;
			set;
		}

		public static int HuyenId
		{
			get;
			set;
		}

		public static string MaHuyen
		{
			get;
			set;
		}

		public static string TenHuyen
		{
			get;
			set;
		}

		public static int XaId
		{
			get;
			set;
		}

		public static string MaXa
		{
			get;
			set;
		}

		public static string TenXa
		{
			get;
			set;
		}

		public static FTP FTPLib
		{
			get
			{
				return GlobalVariable._fTPLib;
			}
		}

		public static Dictionary<int, string> DictLoaiGiayToFile
		{
			get;
			set;
		}

		public static bool CreateFTP()
		{
			FTPDetail fTPDetail = ManageBase.GetFTPDetail();
			bool result = false;
			bool flag = fTPDetail != null;
			if (flag)
			{
				GlobalVariable._fTPLib = new FTP(fTPDetail.Server, fTPDetail.Port, fTPDetail.User, fTPDetail.Pass);
				try
				{
					GlobalVariable._fTPLib.GetFileList();
					result = true;
				}
				catch (Exception var_3_45)
				{
					result = false;
					GlobalVariable._fTPLib = null;
				}
			}
			return result;
		}

		public static bool CreateFTP(string server, int port, string user, string pass)
		{
			bool result = false;
			GlobalVariable._fTPLib = new FTP(server, port, user, pass);
			try
			{
				GlobalVariable._fTPLib.GetFileList();
				result = true;
			}
			catch (Exception var_1_22)
			{
				result = false;
				GlobalVariable._fTPLib = null;
			}
			return result;
		}
	}
}
