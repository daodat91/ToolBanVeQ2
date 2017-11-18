using DAL.ManageDocument.EntityClasses;
using DAL.ManageDocument.HelperClasses;
using DocumentManage.Object;
using Newtonsoft.Json;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace DocumentManage
{
	public class ProcessData
	{
		public static void HienThiDoanVanBan(TextBox textBox, string strTieuDe)
		{
			FormHienThiDoanVanBan formHienThiDoanVanBan = new FormHienThiDoanVanBan();
			formHienThiDoanVanBan.Text = strTieuDe;
			formHienThiDoanVanBan.NoiDungDoanVanBan = textBox.Text;
			formHienThiDoanVanBan.ShowDialog();
			textBox.Text = formHienThiDoanVanBan.NoiDungDoanVanBan;
		}

		public static bool SaveThongTinHoSo(ref ThongTinHoSo value)
		{
			bool result = true;
			try
			{
				DateTime dateNow = ManageBase.GetDateNow();
				ThongTinHoSoEntity thongTinHoSoEntity = new ThongTinHoSoEntity();
				thongTinHoSoEntity.ThongTinHoSoId = value.ThongTinHoSoId;
				thongTinHoSoEntity.IsNew = value.IsNew;
				thongTinHoSoEntity.XaId = GlobalVariable.XaId;
				thongTinHoSoEntity.SoBienNhan = value.SoBienNhan;
				thongTinHoSoEntity.NgayNop = value.NgayNop;
                thongTinHoSoEntity.NgayHenTra = value.NgayHenTra;
                thongTinHoSoEntity.NgayTraHoSo = value.NgayTraHoSo;
                thongTinHoSoEntity.NgayKiemTraNoiNghiep = value.NgayKiemTraNoiNghiep;
				thongTinHoSoEntity.SoBanVe = value.SoBanVe;
				thongTinHoSoEntity.PhiDoVe = value.PhiDoVe;
				thongTinHoSoEntity.GioiTinhNguoiNop = new bool?(value.GioiTinhNguoiNop);
				thongTinHoSoEntity.NguoiNopHoSo = value.NguoiNopHoSo;
				thongTinHoSoEntity.SoGiayToNguoiNop = value.SoGiayToNguoiNop;
				thongTinHoSoEntity.PhiThamDinh = value.PhiThamDinh;
                thongTinHoSoEntity.ChuyenVienId = value.ChuyenVienId;
                thongTinHoSoEntity.ChuyenVienKiemTra = value.ChuyenVienKiemTra;
                thongTinHoSoEntity.CongTyDoVeId = value.CongTyDoVeId;
                thongTinHoSoEntity.CongTyDoVe = value.CongTyDoVe;
                thongTinHoSoEntity.HoSoChuaDat = value.HoSoChuaDat;
                thongTinHoSoEntity.HoSoDaKiemTra = value.HoSoDaKiemTra;
                thongTinHoSoEntity.HoSoKhongHopLy = value.HoSoKhongHopLy;
                thongTinHoSoEntity.RootId = value.RootId;
                UserLog userLog = new UserLog();
				userLog.NguoiDungId = new int?(GlobalVariable.NguoiDungId);
				userLog.NgayChinhSua = new DateTime?(dateNow);
				userLog.LogHistory = value.LichSuCapNhat;
				thongTinHoSoEntity.LichSuCapNhat = JsonConvert.SerializeObject(userLog);
				List<string> list = new List<string>();
				bool flag = value.ThongTinChiTiet.ListGiayChungNhan != null;
				if (flag)
				{
					foreach (GiayChungNhan current in value.ThongTinChiTiet.ListGiayChungNhan)
					{
						bool flag2 = !string.IsNullOrEmpty(current.SoSerial);
						if (flag2)
						{
							list.Add(current.SoSerial);
						}
					}
				}
				thongTinHoSoEntity.SoHieuGiayChungNhan = string.Join(" ", list);
				list = new List<string>();
				List<string> list2 = new List<string>();
				bool flag3 = value.ThongTinChiTiet.ListChu != null;
				if (flag3)
				{
					foreach (ChuSuDung current2 in value.ThongTinChiTiet.ListChu)
					{
						bool flag4 = !string.IsNullOrEmpty(current2.HoTen);
						if (flag4)
						{
							list.Add(current2.HoTen);
						}
						bool flag5 = !string.IsNullOrEmpty(current2.SoGiayTo);
						if (flag5)
						{
							list2.Add(current2.SoGiayTo);
						}
					}
				}
				thongTinHoSoEntity.HoTen = string.Join(" ", list);
				thongTinHoSoEntity.SoGiayTo = string.Join(" ", list2);
				list = new List<string>();
				list2 = new List<string>();
				List<string> list3 = new List<string>();
				bool flag6 = value.ThongTinChiTiet.ListThua != null;
				if (flag6)
				{
					foreach (ThuaDat current3 in value.ThongTinChiTiet.ListThua)
					{
						bool flag7 = !list.Contains(current3.SoThuTuThua);
						if (flag7)
						{
							list.Add(current3.SoThuTuThua);
						}
						bool flag8 = !list2.Contains(current3.SoHieuToBanDo);
						if (flag8)
						{
							list2.Add(current3.SoHieuToBanDo);
						}
					}
				}
				thongTinHoSoEntity.SoThuTuThua = string.Join(" ", list);
				thongTinHoSoEntity.SoHieuToBanDo = string.Join(" ", list2);
				thongTinHoSoEntity.GhiChu = value.GhiChu;
				thongTinHoSoEntity.LoaiBienDongId = value.LoaiBienDongId;
				bool isNew = value.IsNew;
				if (isNew)
				{
					thongTinHoSoEntity.HoSoMoiNhat = true;
				}
				else
				{
					thongTinHoSoEntity.HoSoMoiNhat = value.LaHoSoMoiNhat;
				}
				thongTinHoSoEntity.NguoiDungId = new int?(GlobalVariable.NguoiDungId);
				thongTinHoSoEntity.ChiTietHoSo = JsonConvert.SerializeObject(value.ThongTinChiTiet);
				thongTinHoSoEntity.KhoaChaId = value.KhoaChaId;
				value.ThongTinHoSoId = ManageBase.SaveThongTinHoSo(thongTinHoSoEntity);
				value.IsSuccess = true;
				value.NguoiCapNhat = GlobalVariable.HoTenNguoiDung;
				bool flag9 = string.IsNullOrEmpty(value.NguoiCapNhat);
				if (flag9)
				{
					value.NguoiCapNhat = GlobalVariable.TenDangNhap;
				}
				value.NgayChinhSua = new DateTime?(dateNow);
				value.LichSuCapNhat = userLog;
				value.LaHoSoMoiNhat = thongTinHoSoEntity.HoSoMoiNhat;
				bool flag10 = value.IsNew && value.KhoaChaId.HasValue;
				if (flag10)
				{
					ManageBase.Update(new ThongTinHoSoEntity
					{
						HoSoMoiNhat = false,
						NguoiDungId = new int?(GlobalVariable.NguoiDungId)
					}, new RelationPredicateBucket
					{
						PredicateExpression = 
						{
							ThongTinHoSoFields.ThongTinHoSoId == value.KhoaChaId
						}
					});
				}
                value.IsNew = false;
            }
			catch (Exception var_27_4C1)
			{
				result = false;
			}
			return result;
		}

		public static ThongTinHoSo MapThongTinHoSo(ThongTinHoSoEntity entity)
		{
			ThongTinHoSo thongTinHoSo = new ThongTinHoSo();
			thongTinHoSo.SoBienNhan = entity.SoBienNhan;
			thongTinHoSo.NgayNop = entity.NgayNop;
            thongTinHoSo.NgayHenTra = entity.NgayHenTra;
            thongTinHoSo.NgayTraHoSo = entity.NgayTraHoSo;
            thongTinHoSo.NgayKiemTraNoiNghiep = entity.NgayKiemTraNoiNghiep;
			thongTinHoSo.SoBanVe = entity.SoBanVe;
			thongTinHoSo.PhiDoVe = entity.PhiDoVe;
			thongTinHoSo.GhiChu = entity.GhiChu;
			thongTinHoSo.GioiTinhNguoiNop = entity.GioiTinhNguoiNop.Value;
			thongTinHoSo.NguoiNopHoSo = entity.NguoiNopHoSo;
			thongTinHoSo.SoGiayToNguoiNop = entity.SoGiayToNguoiNop;
			thongTinHoSo.IsNew = false;
			thongTinHoSo.IsSuccess = false;
			thongTinHoSo.LaHoSoMoiNhat = entity.HoSoMoiNhat;
			thongTinHoSo.KhoaChaId = entity.KhoaChaId;
			thongTinHoSo.LoaiBienDongId = entity.LoaiBienDongId;
			thongTinHoSo.ThongTinChiTiet = JsonConvert.DeserializeObject<ChiTietHoSo>(entity.ChiTietHoSo);
			thongTinHoSo.ThongTinHoSoId = entity.ThongTinHoSoId;
			thongTinHoSo.PhiThamDinh = entity.PhiThamDinh;
            thongTinHoSo.ChuyenVienId = entity.ChuyenVienId;
            thongTinHoSo.ChuyenVienKiemTra = entity.ChuyenVienKiemTra;
            thongTinHoSo.CongTyDoVeId = entity.CongTyDoVeId;
            thongTinHoSo.CongTyDoVe = entity.CongTyDoVe;
            thongTinHoSo.HoSoChuaDat = entity.HoSoChuaDat;
            thongTinHoSo.HoSoDaKiemTra = entity.HoSoDaKiemTra;
            thongTinHoSo.HoSoKhongHopLy = entity.HoSoKhongHopLy;
            thongTinHoSo.RootId = entity.RootId;
            thongTinHoSo.NgayChinhSua = entity.NgayChinhSua;
			bool flag3 = !string.IsNullOrEmpty(entity.LichSuCapNhat);
			if (flag3)
			{
				thongTinHoSo.LichSuCapNhat = JsonConvert.DeserializeObject<UserLog>(entity.LichSuCapNhat);
			}
			bool hasValue = entity.NguoiDungId.HasValue;
			if (hasValue)
			{
				NguoiDungEntity nguoiDungEntity = ManageBase.SelectNguoiDungById(entity.NguoiDungId.Value);
				thongTinHoSo.NguoiCapNhat = nguoiDungEntity.HoTenNguoiDung;
				bool flag4 = string.IsNullOrEmpty(thongTinHoSo.NguoiCapNhat);
				if (flag4)
				{
					thongTinHoSo.NguoiCapNhat = nguoiDungEntity.TenDangNhap;
				}
			}
			return thongTinHoSo;
		}

		public static List<ThongTinHoSo> SearchThongTinHoSo(SearchInput input)
		{
			List<ThongTinHoSo> list = new List<ThongTinHoSo>();
			EntityCollection entityCollection = ManageBase.SearchThongTinHoSo(input);
			using (IEnumerator<EntityBase2> enumerator = entityCollection.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ThongTinHoSoEntity entity = (ThongTinHoSoEntity)enumerator.Current;
					list.Add(ProcessData.MapThongTinHoSo(entity));
				}
			}
			return list;
		}

		public static List<NguoiDung> GetAllNguoiDung()
		{
			List<NguoiDung> list = new List<NguoiDung>();
			EntityCollection entityCollection = ManageBase.SelectAllNguoiDung();
			using (IEnumerator<EntityBase2> enumerator = entityCollection.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					NguoiDungEntity nguoiDungEntity = (NguoiDungEntity)enumerator.Current;
					NguoiDung nguoiDung = new NguoiDung();
					nguoiDung.NguoiDungId = nguoiDungEntity.NguoiDungId;
					nguoiDung.TenNguoiDung = nguoiDungEntity.HoTenNguoiDung;
					bool flag = string.IsNullOrEmpty(nguoiDung.TenNguoiDung);
					if (flag)
					{
						nguoiDung.TenNguoiDung = nguoiDungEntity.TenDangNhap;
					}
					list.Add(nguoiDung);
				}
			}
			return list;
		}

		public static string TaoThuMucTuiHoSo(string maHoSo = "")
		{
			bool flag = string.IsNullOrEmpty(maHoSo);
			string result;
			if (flag)
			{
				result = string.Format("HS-T{0}-{1}", ManageBase.GetSoThuTuHoSo(), DateTime.Now.Year);
			}
			else
			{
				result = string.Format("HS-T{0}-{1}-{2}", ManageBase.GetSoThuTuHoSo(), maHoSo, DateTime.Now.Year);
			}
			return result;
		}

		public static string TaoTenFile(string folderInServer, int loaiGiayToId, string soBienNhan, string tenFile)
		{
			bool flag = GlobalVariable.DictLoaiGiayToFile.ContainsKey(loaiGiayToId);
			string text;
			if (flag)
			{
				text = GlobalVariable.DictLoaiGiayToFile[loaiGiayToId];
			}
			else
			{
				text = "GTK";
			}
			string text2 = string.Format("{0}-{1}-{2}", text, soBienNhan, tenFile);
			int num = 1;
			GlobalVariable.FTPLib.WorkingDirectory = folderInServer;
			while (GlobalVariable.FTPLib.FileExist(text2))
			{
				num++;
				text2 = string.Format("{0}{1}-{2}-{3}", new object[]
				{
					text,
					num,
					soBienNhan,
					tenFile
				});
			}
			return text2;
		}

		public static bool UploadFile2Server(string soBienNhan, ref BindingList<FileScanInput> values)
		{
			bool result = true;
            if (values.Count > 0)
            {
                string maXa = GlobalVariable.MaXa;
                int xaId = GlobalVariable.XaId;
                string text = "";
                string workingDirectory = "";
                string workingDirectory2 = "";
                GlobalVariable.FTPLib.WorkingDirectory = "/";
                try
                {
                    workingDirectory = GlobalVariable.FTPLib.WorkingDirectory;
                    GlobalVariable.FTPLib.WorkingDirectory = maXa;
                    GlobalVariable.FTPLib.GetFileList();
                }
                catch
                {
                    GlobalVariable.FTPLib.WorkingDirectory = workingDirectory;
                    GlobalVariable.FTPLib.MakeDir(maXa);
                    GlobalVariable.FTPLib.WorkingDirectory = maXa;
                }
                workingDirectory2 = GlobalVariable.FTPLib.WorkingDirectory;
                try
                {
                    foreach (FileScanInput current in values)
                    {
                        bool flag = !current.IsLocalFile;
                        if (flag)
                        {
                            text = current.FilePath.Split(new char[]
                            {
                            '/'
                            })[2];
                            break;
                        }
                    }
                    bool flag2 = text == "";
                    if (flag2)
                    {
                        text = ProcessData.TaoThuMucTuiHoSo("");
                        GlobalVariable.FTPLib.WorkingDirectory = workingDirectory2;
                        GlobalVariable.FTPLib.MakeDir(text);
                        GlobalVariable.FTPLib.WorkingDirectory = text;
                    }
                    string text2 = "/" + maXa + "/" + text;
                    foreach (FileScanInput current2 in values)
                    {
                        bool isLocalFile = current2.IsLocalFile;
                        if (isLocalFile)
                        {
                            string strFileServer = ProcessData.TaoTenFile(text2, current2.LoaiGiayToId, soBienNhan, current2.FileName);
                            current2.FilePath = text2 + "/" + ProcessData.UploadToServer(current2.FullName, text2, strFileServer);
                            current2.IsLocalFile = false;
                        }
                    }
                }
                catch (Exception var_15_1D0)
                {
                    result = false;
                }
            }
			return result;
		}

		private static string UploadToServer(string strFileLocal, string strWorkingDirectoryOnServer, string strFileServer)
		{
			bool flag = strFileLocal.Contains("\\");
			if (flag)
			{
				GlobalVariable.FTPLib.WorkingDirectory = strWorkingDirectoryOnServer;
				GlobalVariable.FTPLib.OpenUpload(strFileLocal, strFileServer);
				while (GlobalVariable.FTPLib.DoUpload() > 0L)
				{
				}
			}
			return strFileServer;
		}

		private static string GetLocalPathFromServerPath(string strServerFilePath)
		{
			string[] array = strServerFilePath.Split(new char[]
			{
				'/'
			});
			string text = "";
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text2 = array2[i];
				bool flag = text2.Trim() != "" && !text2.Contains(".");
				if (flag)
				{
					text = text + "\\" + text2;
				}
			}
			return text;
		}

		public static void ReadFileFromServer(string filePathServer)
		{
			bool flag = !string.IsNullOrEmpty(filePathServer);
			if (flag)
			{
				string localPathFromServerPath = ProcessData.GetLocalPathFromServerPath(filePathServer);
				string text = string.Format("{0}\\{1}{2}", Application.StartupPath, "Temp", localPathFromServerPath);
				bool flag2 = !Directory.Exists(text);
				if (flag2)
				{
					Directory.CreateDirectory(text);
				}
				string workingDirectory = filePathServer.Substring(0, filePathServer.LastIndexOf('/'));
				string text2 = filePathServer.Substring(filePathServer.LastIndexOf('/') + 1);
				string text3 = string.Format("{0}\\{1}", text, text2);
				bool flag3 = File.Exists(text3);
				if (flag3)
				{
					Process.Start(text3);
				}
				else
				{
					try
					{
						GlobalVariable.FTPLib.WorkingDirectory = workingDirectory;
						GlobalVariable.FTPLib.OpenDownload(text2, text3, false);
						while (GlobalVariable.FTPLib.DoDownload() > 0L)
						{
						}
						Process.Start(text3);
					}
					catch (Exception ex)
					{
						MessageBox.Show("File hồ sơ này không tồn tại!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
			}
			else
			{
				MessageBox.Show("File hồ sơ này không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

        public static List<ChuyenVien> GetAllChuyenVien()
        {
            List<ChuyenVien> lst = new List<Object.ChuyenVien>();
            EntityCollection ec = ManageBase.SelectAllChuyenVien();
            foreach (ChuyenVienEntity item in ec)
            {
                lst.Add(new ChuyenVien
                {
                    ChuyenVienId = item.ChuyenVienId,
                    TenChuyenVien = item.TenChuyenVien
                });
            }
            return lst;
        }

        public static void SaveChuyenVien(List<ChuyenVien> lst)
        {
            EntityCollection ec = new EntityCollection();
            foreach (ChuyenVien item in lst)
            {
                ec.Add(new ChuyenVienEntity
                {
                    ChuyenVienId = item.ChuyenVienId,
                    TenChuyenVien = item.TenChuyenVien,
                    IsNew = (item.ChuyenVienId == 0)
                });
            }
            if (ec.Count > 0)
                ManageBase.SaveEntityCollection(ec);
        }

        public static List<CongTyDoVe> GetAllCongTyDoVe()
        {
            List<CongTyDoVe> lst = new List<Object.CongTyDoVe>();
            EntityCollection ec = ManageBase.SelectAllCongTyDoVe();
            foreach (CongTyDoVeEntity item in ec)
            {
                lst.Add(new CongTyDoVe
                {
                    CongTyDoVeId = item.CongTyDoVeId,
                    TenCongTyDoVe = item.TenCongTyDoVe
                });
            }
            return lst;
        }

        public static void SaveCongTyDoVe(List<CongTyDoVe> lst)
        {
            EntityCollection ec = new EntityCollection();
            foreach (CongTyDoVe item in lst)
            {
                ec.Add(new CongTyDoVeEntity
                {
                    CongTyDoVeId = item.CongTyDoVeId,
                    TenCongTyDoVe = item.TenCongTyDoVe,
                    IsNew = (item.CongTyDoVeId == 0)
                });
            }
            if (ec.Count > 0)
                ManageBase.SaveEntityCollection(ec);
        }
    }
}
