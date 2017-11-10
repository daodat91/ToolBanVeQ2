using System;

namespace DocumentManage.Object
{
	public class ThongTinHoSo
	{
		public long ThongTinHoSoId
		{
			get;
			set;
		}

		public long? KhoaChaId
		{
			get;
			set;
		}

		public bool LaHoSoMoiNhat
		{
			get;
			set;
		}

		public int? LoaiBienDongId
		{
			get;
			set;
		}

		public string SoBienNhan
		{
			get;
			set;
		}

		public DateTime? NgayNop
		{
			get;
			set;
		}

        public DateTime? NgayHenTra
        {
            get;
            set;
        }

        public DateTime? NgayTraHoSo
        {
            get;
            set;
        }

        public DateTime? NgayKiemTraNoiNghiep
		{
			get;
			set;
		}

		public string SoBanVe
		{
			get;
			set;
		}

		public double? PhiDoVe
		{
			get;
			set;
		}

		public string GhiChu
		{
			get;
			set;
		}

		public bool GioiTinhNguoiNop
		{
			get;
			set;
		}

		public string NguoiNopHoSo
		{
			get;
			set;
		}

		public string SoGiayToNguoiNop
		{
			get;
			set;
		}

		public double? PhiThamDinh
		{
			get;
			set;
		}

        public int? ChuyenVienId
        {
            get;
            set;
        }

        public string ChuyenVienKiemTra
		{
			get;
			set;
		}
        public int? CongTyDoVeId
        {
            get;
            set;
        }
        public string CongTyDoVe
		{
			get;
			set;
		}

		public ChiTietHoSo ThongTinChiTiet
		{
			get;
			set;
		}

		public UserLog LichSuCapNhat
		{
			get;
			set;
		}

		public DateTime? NgayChinhSua
		{
			get;
			set;
		}

		public string NguoiCapNhat
		{
			get;
			set;
		}

		public bool IsNew
		{
			get;
			set;
		}

		public bool IsSuccess
		{
			get;
			set;
		}
	}

    public class ChuyenVien
    {
        public int ChuyenVienId { get; set; }
        public string TenChuyenVien { get; set; }
    }

    public class CongTyDoVe
    {
        public int CongTyDoVeId { get; set; }
        public string TenCongTyDoVe { get; set; }
    }
}
