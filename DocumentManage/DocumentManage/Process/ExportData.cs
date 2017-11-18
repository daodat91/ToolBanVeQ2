using DAL.ManageDocument.EntityClasses;
using DAL.ManageDocument.FactoryClasses;
using DAL.ManageDocument.HelperClasses;
using DocumentManage.Object;
using Newtonsoft.Json;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace DocumentManage
{
    public class ExportData
    {
        public static DataTable GetPhiDoVeByNgayKiemTraNoiNghiep(DateTime? startDate, DateTime? endDate)
        {
            #region Get data
            RelationPredicateBucket filter = new RelationPredicateBucket();
            if (startDate != null)
                filter.PredicateExpression.Add(ThongTinHoSoFields.NgayKiemTraNoiNghiep >= startDate);
            if (endDate != null)
                filter.PredicateExpression.Add(ThongTinHoSoFields.NgayKiemTraNoiNghiep <= endDate);

            IncludeFieldsList includeFields = new IncludeFieldsList();
            includeFields.AddRange(new List<EntityField2> { ThongTinHoSoFields.SoBienNhan, ThongTinHoSoFields.SoBanVe, ThongTinHoSoFields.NgayNop, ThongTinHoSoFields.NgayTraHoSo, ThongTinHoSoFields.NguoiNopHoSo, ThongTinHoSoFields.NgayKiemTraNoiNghiep, ThongTinHoSoFields.SoThuTuThua, ThongTinHoSoFields.SoHieuToBanDo, ThongTinHoSoFields.PhiDoVe, ThongTinHoSoFields.PhiThamDinh, ThongTinHoSoFields.XaId });

            EntityCollection ec = GenericEntityColManagerBase<ThongTinHoSoEntityFactory>.SelectAll(0, null, filter, includeFields);

            EntityCollection ecXa = GenericEntityColManagerBase<XaEntityFactory>.SelectAll(0, null, new RelationPredicateBucket());
            Dictionary<int, string> dictXa = new Dictionary<int, string>();
            foreach (XaEntity item in ecXa)
            {
                dictXa.Add(item.XaId, item.TenXa);
            }
            #endregion

            #region create datatable
            DataTable dt = new DataTable("PhiDoVe");
            DataColumn dc = new DataColumn("STT", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("SoBienNhan", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("SoBanVe", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("NgayNhan", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("NgayTraHoSo", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("TenNguoiNop", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("NgayKiemTraNoiNghiep", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("SoThua", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("SoTo", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("Phuong", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("PhiDoVe", typeof(double));
            dt.Columns.Add(dc);
            dc = new DataColumn("PhiThamDinh", typeof(double));
            dt.Columns.Add(dc);
            #endregion

            #region Set data
            int stt = 1;
            foreach (ThongTinHoSoEntity item in ec)
            {
                DataRow dr = dt.NewRow();
                dr["STT"] = stt.ToString();
                dr["SoBienNhan"] = item.SoBienNhan;
                dr["SoBanVe"] = item.SoBanVe;
                dr["NgayNhan"] = item.NgayNop?.ToString("dd/MM/yyyy");
                dr["NgayTraHoSo"] = item.NgayTraHoSo?.ToString("dd/MM/yyyy");
                dr["TenNguoiNop"] = item.NguoiNopHoSo;
                dr["NgayKiemTraNoiNghiep"] = item.NgayKiemTraNoiNghiep?.ToString("dd/MM/yyyy");
                dr["SoThua"] = item.SoThuTuThua;
                dr["SoTo"] = item.SoHieuToBanDo;
                if (dictXa.ContainsKey(item.XaId))
                    dr["Phuong"] = dictXa[item.XaId];
                if (item.PhiDoVe.HasValue)
                    dr["PhiDoVe"] = item.PhiDoVe;
                if (item.PhiThamDinh.HasValue)
                    dr["PhiThamDinh"] = item.PhiThamDinh;

                stt++;
                dt.Rows.Add(dr);
            }
            #endregion

            return dt;
        }

        public static DataTable GetDataByCongTyDoVe(DateTime? startDate, DateTime? endDate, List<int> lstCongTyDoVeId)
        {
            #region Get data
            RelationPredicateBucket filter = new RelationPredicateBucket();
            if (startDate != null)
                filter.PredicateExpression.Add(ThongTinHoSoFields.NgayNop >= startDate);
            if (endDate != null)
                filter.PredicateExpression.Add(ThongTinHoSoFields.NgayNop <= endDate);
            if (lstCongTyDoVeId.Count > 0)
                filter.PredicateExpression.Add(ThongTinHoSoFields.CongTyDoVeId == lstCongTyDoVeId);

            IncludeFieldsList includeFields = new IncludeFieldsList();
            includeFields.AddRange(new List<EntityField2> { ThongTinHoSoFields.SoBienNhan, ThongTinHoSoFields.SoBanVe, ThongTinHoSoFields.NgayNop, ThongTinHoSoFields.NgayTraHoSo, ThongTinHoSoFields.CongTyDoVe, ThongTinHoSoFields.PhiDoVe, ThongTinHoSoFields.PhiThamDinh, ThongTinHoSoFields.XaId });
            EntityCollection ec = GenericEntityColManagerBase<ThongTinHoSoEntityFactory>.SelectAll(0, null, filter, includeFields);

            EntityCollection ecXa = GenericEntityColManagerBase<XaEntityFactory>.SelectAll(0, null, new RelationPredicateBucket());
            Dictionary<int, string> dictXa = new Dictionary<int, string>();
            foreach (XaEntity item in ecXa)
            {
                dictXa.Add(item.XaId, item.TenXa);
            }
            #endregion

            #region create datatable
            DataTable dt = new DataTable("Data");
            DataColumn dc = new DataColumn("STT", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("SoBienNhan", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("SoBanVe", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("NgayNhan", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("NgayTraHoSo", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("CongTyDoVe", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("PhiDoVe", typeof(double));
            dt.Columns.Add(dc);
            dc = new DataColumn("PhiThamDinh", typeof(double));
            dt.Columns.Add(dc);
            dc = new DataColumn("Phuong", typeof(string));
            dt.Columns.Add(dc);
            #endregion

            #region Set data
            int stt = 1;
            foreach (ThongTinHoSoEntity item in ec)
            {
                DataRow dr = dt.NewRow();
                dr["STT"] = stt.ToString();
                dr["SoBienNhan"] = item.SoBienNhan;
                dr["SoBanVe"] = item.SoBanVe;
                dr["NgayNhan"] = item.NgayNop?.ToString("dd/MM/yyyy");
                dr["NgayTraHoSo"] = item.NgayTraHoSo?.ToString("dd/MM/yyyy");
                dr["CongTyDoVe"] = item.CongTyDoVe;
                if (item.PhiDoVe.HasValue)
                    dr["PhiDoVe"] = item.PhiDoVe;
                if (item.PhiThamDinh.HasValue)
                    dr["PhiThamDinh"] = item.PhiThamDinh;
                if (dictXa.ContainsKey(item.XaId))
                    dr["Phuong"] = dictXa[item.XaId];
                stt++;
                dt.Rows.Add(dr);
            }
            #endregion

            return dt;
        }

        public static DataTable GetDataByNguoiKiemTraNoiNghiep(DateTime? startDate, DateTime? endDate, List<int> lstChuyenVienId)
        {
            #region Get data
            RelationPredicateBucket filter = new RelationPredicateBucket();
            if (startDate != null)
                filter.PredicateExpression.Add(ThongTinHoSoFields.NgayKiemTraNoiNghiep >= startDate);
            if (endDate != null)
                filter.PredicateExpression.Add(ThongTinHoSoFields.NgayKiemTraNoiNghiep <= endDate);
            if (lstChuyenVienId.Count > 0)
                filter.PredicateExpression.Add(ThongTinHoSoFields.ChuyenVienId == lstChuyenVienId);

            IncludeFieldsList includeFields = new IncludeFieldsList();
            includeFields.AddRange(new List<EntityField2> { ThongTinHoSoFields.SoBienNhan, ThongTinHoSoFields.SoBanVe, ThongTinHoSoFields.NgayNop, ThongTinHoSoFields.NgayTraHoSo, ThongTinHoSoFields.CongTyDoVe, ThongTinHoSoFields.PhiDoVe, ThongTinHoSoFields.PhiThamDinh, ThongTinHoSoFields.ChuyenVienKiemTra, ThongTinHoSoFields.XaId });
            EntityCollection ec = GenericEntityColManagerBase<ThongTinHoSoEntityFactory>.SelectAll(0, null, filter, includeFields);

            EntityCollection ecXa = GenericEntityColManagerBase<XaEntityFactory>.SelectAll(0, null, new RelationPredicateBucket());
            Dictionary<int, string> dictXa = new Dictionary<int, string>();
            foreach (XaEntity item in ecXa)
            {
                dictXa.Add(item.XaId, item.TenXa);
            }
            #endregion

            #region create datatable
            DataTable dt = new DataTable("Data");
            DataColumn dc = new DataColumn("STT", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("ChuyenVien", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("SoBienNhan", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("SoBanVe", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("NgayNhan", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("NgayTraHoSo", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("CongTyDoVe", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("PhiDoVe", typeof(double));
            dt.Columns.Add(dc);
            dc = new DataColumn("PhiThamDinh", typeof(double));
            dt.Columns.Add(dc);
            dc = new DataColumn("Phuong", typeof(string));
            dt.Columns.Add(dc);
            #endregion

            #region Set data
            int stt = 1;
            foreach (ThongTinHoSoEntity item in ec)
            {
                DataRow dr = dt.NewRow();
                dr["STT"] = stt.ToString();
                dr["ChuyenVien"] = item.ChuyenVienKiemTra;
                dr["SoBienNhan"] = item.SoBienNhan;
                dr["SoBanVe"] = item.SoBanVe;
                dr["NgayNhan"] = item.NgayNop?.ToString("dd/MM/yyyy");
                dr["NgayTraHoSo"] = item.NgayTraHoSo?.ToString("dd/MM/yyyy");
                dr["CongTyDoVe"] = item.CongTyDoVe;
                if (item.PhiDoVe.HasValue)
                    dr["PhiDoVe"] = item.PhiDoVe;
                if (item.PhiThamDinh.HasValue)
                    dr["PhiThamDinh"] = item.PhiThamDinh;
                if (dictXa.ContainsKey(item.XaId))
                    dr["Phuong"] = dictXa[item.XaId];
                stt++;
                dt.Rows.Add(dr);
            }
            #endregion

            return dt;
        }

        public static DataTable GetDataByLoaiBienDong(DateTime? startDate, DateTime? endDate, List<int> lstLoaibienDongId)
        {
            #region Get data
            RelationPredicateBucket filter = new RelationPredicateBucket();
            if (startDate != null)
                filter.PredicateExpression.Add(ThongTinHoSoFields.NgayNop >= startDate);
            if (endDate != null)
                filter.PredicateExpression.Add(ThongTinHoSoFields.NgayNop <= endDate);
            if (lstLoaibienDongId.Count > 0)
                filter.PredicateExpression.Add(ThongTinHoSoFields.LoaiBienDongId == lstLoaibienDongId);

            IncludeFieldsList includeFields = new IncludeFieldsList();
            includeFields.AddRange(new List<EntityField2> { ThongTinHoSoFields.SoBienNhan, ThongTinHoSoFields.LoaiBienDongId, ThongTinHoSoFields.NgayNop, ThongTinHoSoFields.PhiDoVe, ThongTinHoSoFields.PhiThamDinh, ThongTinHoSoFields.XaId });
            EntityCollection ec = GenericEntityColManagerBase<ThongTinHoSoEntityFactory>.SelectAll(0, null, filter, includeFields);

            EntityCollection ecXa = GenericEntityColManagerBase<XaEntityFactory>.SelectAll(0, null, new RelationPredicateBucket());
            Dictionary<int, string> dictXa = new Dictionary<int, string>();
            foreach (XaEntity item in ecXa)
            {
                dictXa.Add(item.XaId, item.TenXa);
            }

            EntityCollection ecLoaiBD = GenericEntityColManagerBase<LoaiBienDongEntityFactory>.SelectAll(0, null, new RelationPredicateBucket());
            Dictionary<int, string> dictLoaiBD = new Dictionary<int, string>();
            foreach (LoaiBienDongEntity item in ecLoaiBD)
            {
                dictLoaiBD.Add(item.LoaiBienDongId, item.TenLoaiBienDong);
            }
            #endregion

            #region create datatable
            DataTable dt = new DataTable("Data");
            DataColumn dc = new DataColumn("STT", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("LoaiBienDong", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("SoBienNhan", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("NgayNhan", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("PhiDoVe", typeof(double));
            dt.Columns.Add(dc);
            dc = new DataColumn("PhiThamDinh", typeof(double));
            dt.Columns.Add(dc);
            dc = new DataColumn("Phuong", typeof(string));
            dt.Columns.Add(dc);
            #endregion

            #region Set data
            int stt = 1;
            foreach (ThongTinHoSoEntity item in ec)
            {
                DataRow dr = dt.NewRow();
                dr["STT"] = stt.ToString();
                if (item.LoaiBienDongId != null && dictLoaiBD.ContainsKey((int)item.LoaiBienDongId))
                    dr["LoaiBienDong"] = dictLoaiBD[(int)item.LoaiBienDongId];
                dr["SoBienNhan"] = item.SoBienNhan;
                dr["NgayNhan"] = item.NgayNop?.ToString("dd/MM/yyyy");
                if (item.PhiDoVe.HasValue)
                    dr["PhiDoVe"] = item.PhiDoVe;
                if (item.PhiThamDinh.HasValue)
                    dr["PhiThamDinh"] = item.PhiThamDinh;
                if (dictXa.ContainsKey(item.XaId))
                    dr["Phuong"] = dictXa[item.XaId];
                stt++;
                dt.Rows.Add(dr);
            }
            #endregion

            return dt;
        }

        public static DataTable GetDataTongPhiDoVe(DateTime? startDate, DateTime? endDate)
        {
            #region Get data
            RelationPredicateBucket filter = new RelationPredicateBucket();
            if (startDate != null)
                filter.PredicateExpression.Add(ThongTinHoSoFields.NgayNop >= startDate);
            if (endDate != null)
                filter.PredicateExpression.Add(ThongTinHoSoFields.NgayNop <= endDate);
            filter.PredicateExpression.Add(ThongTinHoSoFields.HoSoMoiNhat == true);

            IncludeFieldsList includeFields = new IncludeFieldsList();
            includeFields.AddRange(new List<EntityField2> { ThongTinHoSoFields.SoThuTuThua, ThongTinHoSoFields.SoHieuToBanDo, ThongTinHoSoFields.LoaiBienDongId, ThongTinHoSoFields.PhiDoVe, ThongTinHoSoFields.PhiThamDinh, ThongTinHoSoFields.XaId, ThongTinHoSoFields.RootId, ThongTinHoSoFields.KhoaChaId });
            EntityCollection ec = GenericEntityColManagerBase<ThongTinHoSoEntityFactory>.SelectAll(0, null, filter, includeFields);

            EntityCollection ecXa = GenericEntityColManagerBase<XaEntityFactory>.SelectAll(0, null, new RelationPredicateBucket());
            Dictionary<int, string> dictXa = new Dictionary<int, string>();
            foreach (XaEntity item in ecXa)
            {
                dictXa.Add(item.XaId, item.TenXa);
            }
            #endregion

            #region create datatable
            DataTable dt = new DataTable("Data");
            DataColumn dc = new DataColumn("STT", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("SoThua", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("SoTo", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("Phuong", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("SoLanBienDong", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("PhiDoVe", typeof(double));
            dt.Columns.Add(dc);
            dc = new DataColumn("PhiThamDinh", typeof(double));
            dt.Columns.Add(dc);

            #endregion

            #region Set data
            int stt = 1;
            foreach (ThongTinHoSoEntity item in ec)
            {
                DataRow dr = dt.NewRow();
                dr["STT"] = stt.ToString();
                dr["SoThua"] = item.SoThuTuThua;
                dr["SoTo"] = item.SoHieuToBanDo;
                if (dictXa.ContainsKey(item.XaId))
                    dr["Phuong"] = dictXa[item.XaId];

                int soLanBienDong = 0;
                double tongPhiDoVe = 0, tongPhiThamDinh = 0;
                if (item.KhoaChaId.HasValue)
                {
                    filter = new RelationPredicateBucket();
                    filter.PredicateExpression.Add(ThongTinHoSoFields.RootId == item.RootId);

                    includeFields = new IncludeFieldsList();
                    includeFields.AddRange(new List<EntityField2> { ThongTinHoSoFields.LoaiBienDongId, ThongTinHoSoFields.PhiDoVe, ThongTinHoSoFields.PhiThamDinh });
                    EntityCollection ecTemp = GenericEntityColManagerBase<ThongTinHoSoEntityFactory>.SelectAll(0, null, filter, includeFields);
                    foreach (ThongTinHoSoEntity itemTTHS in ecTemp)
                    {
                        if (itemTTHS.LoaiBienDongId.HasValue)
                            soLanBienDong++;
                        if (itemTTHS.PhiDoVe.HasValue)
                            tongPhiDoVe += itemTTHS.PhiDoVe.Value;
                        if (itemTTHS.PhiThamDinh.HasValue)
                            tongPhiThamDinh += itemTTHS.PhiThamDinh.Value;
                    }

                }
                else
                {
                    if (item.LoaiBienDongId.HasValue)
                        soLanBienDong = 1;
                    if (item.PhiDoVe.HasValue)
                        tongPhiDoVe = item.PhiDoVe.Value;
                    if (item.PhiThamDinh.HasValue)
                        tongPhiThamDinh = item.PhiThamDinh.Value;
                }


                dr["SoLanBienDong"] = soLanBienDong;
                dr["PhiDoVe"] = tongPhiDoVe;
                dr["PhiThamDinh"] = tongPhiThamDinh;

                stt++;
                dt.Rows.Add(dr);
            }
            #endregion

            return dt;
        }

        public static DataTable GetDataSoLuongKiemTraBanVe(DateTime? startDate, DateTime? endDate)
        {
            DateTime dateNow = ManageBase.GetDateNow();

            #region Create datatable
            DataTable dt = new DataTable("Data");
            DataColumn dc = new DataColumn("STT", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("Phuong", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("TongSoBienNhan", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("BienNhanHopLy", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("BienNhanHuy", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("TongBanVeDaKiemTra", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("SoBanVeDat", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("TyLeBanVeDat", typeof(double));
            dt.Columns.Add(dc);
            dc = new DataColumn("SoBanVeChuaDat", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("TyLeBanVeChuaDat", typeof(double));
            dt.Columns.Add(dc);
            dc = new DataColumn("SoBanVeDungHan_DKT", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("SoBanVeQuaHan_DKT", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("TongBanVeChuaKiemTra", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("SoBanVeDungHan_CKT", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("SoBanVeQuaHan_CKT", typeof(int));
            dt.Columns.Add(dc);
            #endregion

            #region Set data
            int stt = 1;
            RelationPredicateBucket filter = new RelationPredicateBucket();
            filter.PredicateExpression.Add(XaFields.HuyenId == 769);
            EntityCollection ecXa = GenericEntityColManagerBase<XaEntityFactory>.SelectAll(0, null, filter);
            Dictionary<int, string> dictXa = new Dictionary<int, string>();
            int tongSoBienNhan, bienNhanHopLy, bienNhanHuy, tongBanVeDKT, soBanVeDat, soBanVeChuaDat, soBanVeDungHan_DKT, soBanVeQuaHan_DKT, tongBanVeChuaKiemTra, soBanVeDungHan_CKT, soBanVeQuaHan_CKT;
            foreach (XaEntity item in ecXa)
            {
                DataRow dr = dt.NewRow();
                dr["STT"] = stt.ToString();
                dr["Phuong"] = item.TenXa;

                #region Hồ sơ đăng ký kiểm tra
                filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(ThongTinHoSoFields.XaId == item.XaId);
                if (startDate != null)
                    filter.PredicateExpression.Add(ThongTinHoSoFields.NgayNop >= startDate);
                if (endDate != null)
                    filter.PredicateExpression.Add(ThongTinHoSoFields.NgayNop <= endDate);
                tongSoBienNhan = GenericEntityColManagerBase<ThongTinHoSoEntityFactory>.GetDbCount(filter);
                filter.PredicateExpression.Add(ThongTinHoSoFields.HoSoKhongHopLy == true);
                bienNhanHuy = GenericEntityColManagerBase<ThongTinHoSoEntityFactory>.GetDbCount(filter);
                bienNhanHopLy = tongSoBienNhan - bienNhanHuy;
                #endregion

                #region Hồ sơ đã kiểm tra
                filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(ThongTinHoSoFields.XaId == item.XaId);
                if (startDate != null)
                    filter.PredicateExpression.Add(ThongTinHoSoFields.NgayNop >= startDate);
                if (endDate != null)
                    filter.PredicateExpression.Add(ThongTinHoSoFields.NgayNop <= endDate);
                filter.PredicateExpression.Add(ThongTinHoSoFields.HoSoDaKiemTra == true);
                tongBanVeDKT = GenericEntityColManagerBase<ThongTinHoSoEntityFactory>.GetDbCount(filter);
                filter.PredicateExpression.Add(ThongTinHoSoFields.HoSoChuaDat == true);
                soBanVeChuaDat = GenericEntityColManagerBase<ThongTinHoSoEntityFactory>.GetDbCount(filter);
                soBanVeDat = tongBanVeDKT - soBanVeChuaDat;

                filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(ThongTinHoSoFields.XaId == item.XaId);
                if (startDate != null)
                    filter.PredicateExpression.Add(ThongTinHoSoFields.NgayNop >= startDate);
                if (endDate != null)
                    filter.PredicateExpression.Add(ThongTinHoSoFields.NgayNop <= endDate);
                filter.PredicateExpression.Add(ThongTinHoSoFields.HoSoDaKiemTra == true);
                filter.PredicateExpression.Add(ThongTinHoSoFields.NgayTraHoSo <= ThongTinHoSoFields.NgayHenTra | ThongTinHoSoFields.NgayHenTra >= dateNow);
                soBanVeDungHan_DKT = GenericEntityColManagerBase<ThongTinHoSoEntityFactory>.GetDbCount(filter);
                soBanVeQuaHan_DKT = tongBanVeDKT - soBanVeDungHan_DKT;
                #endregion

                #region Hồ sơ chưa kiểm tra
                filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(ThongTinHoSoFields.XaId == item.XaId);
                if (startDate != null)
                    filter.PredicateExpression.Add(ThongTinHoSoFields.NgayNop >= startDate);
                if (endDate != null)
                    filter.PredicateExpression.Add(ThongTinHoSoFields.NgayNop <= endDate);
                filter.PredicateExpression.Add(ThongTinHoSoFields.HoSoDaKiemTra == false);
                tongBanVeChuaKiemTra = GenericEntityColManagerBase<ThongTinHoSoEntityFactory>.GetDbCount(filter);
                filter.PredicateExpression.Add(ThongTinHoSoFields.NgayTraHoSo <= ThongTinHoSoFields.NgayHenTra | ThongTinHoSoFields.NgayHenTra >= dateNow);
                soBanVeDungHan_CKT = GenericEntityColManagerBase<ThongTinHoSoEntityFactory>.GetDbCount(filter);
                soBanVeQuaHan_CKT = tongBanVeChuaKiemTra - soBanVeDungHan_CKT;
                #endregion

                dr["TongSoBienNhan"] = tongSoBienNhan;
                dr["BienNhanHopLy"] = bienNhanHopLy;
                dr["BienNhanHuy"] = bienNhanHuy;
                dr["TongBanVeDaKiemTra"] = tongBanVeDKT;
                dr["SoBanVeDat"] = soBanVeDat;
                dr["SoBanVeChuaDat"] = soBanVeChuaDat;
                if (tongBanVeDKT > 0)
                {
                    dr["TyLeBanVeDat"] = Math.Round(soBanVeDat / (double)tongBanVeDKT * 100, 2);
                    dr["TyLeBanVeChuaDat"] = 100 - (double)dr["TyLeBanVeDat"];
                }
                dr["SoBanVeDungHan_DKT"] = soBanVeDungHan_DKT;
                dr["SoBanVeQuaHan_DKT"] = soBanVeQuaHan_DKT;
                dr["TongBanVeChuaKiemTra"] = tongBanVeChuaKiemTra;
                dr["SoBanVeDungHan_CKT"] = soBanVeDungHan_CKT;
                dr["SoBanVeQuaHan_CKT"] = soBanVeQuaHan_CKT;

                stt++;
                dt.Rows.Add(dr);
            }
            #endregion

            return dt;
        }
    }
}
