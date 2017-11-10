using DAL.ManageDocument.DatabaseSpecific;
using DAL.ManageDocument.EntityClasses;
using DAL.ManageDocument.FactoryClasses;
using DAL.ManageDocument.HelperClasses;
using DocumentManage.Object;
using Newtonsoft.Json;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DocumentManage
{
	public class ManageBase
	{
		private static string _connectionString = "";

		public static string ConnectionString
		{
			get
			{
				return ManageBase._connectionString;
			}
		}

		public static bool IsConnectDatabase(string connectString)
		{
			bool result = true;
			try
			{
				using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(connectString))
				{
					dataAccessAdapterBase.OpenConnection();
					dataAccessAdapterBase.CloseConnection();
					ManageBase._connectionString = connectString;
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public static DataTable ExcuteSelect(string SelectCommand)
		{
			DataTable result;
			try
			{
				SqlConnection sqlConnection = new SqlConnection(ManageBase.ConnectionString);
				sqlConnection.Open();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand(SelectCommand, sqlConnection)
				{
					CommandTimeout = 6000000
				});
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				sqlConnection.Close();
				result = dataTable;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}

		public static long GetSoThuTuHoSo()
		{
			long result = 0L;
			try
			{
				DataTable dataTable = ManageBase.ExcuteSelect("SELECT NEXT VALUE FOR dbo.GetSoThuTuHoSo as number");
				bool flag = dataTable != null && dataTable.Rows.Count > 0;
				if (flag)
				{
					result = (long)dataTable.Rows[0]["number"];
				}
			}
			catch (Exception var_3_47)
			{
			}
			return result;
		}

		public static DateTime GetDateNow()
		{
			DateTime result;
			try
			{
				DataTable dataTable = ManageBase.ExcuteSelect("Select getdate()");
				string s = dataTable.Rows[0][0].ToString();
				result = DateTime.Parse(s);
			}
			catch (Exception)
			{
				result = DateTime.Now;
			}
			return result;
		}

		public static NguoiDungEntity SelectNguoiDungById(int nguoiDungId)
		{
			NguoiDungEntity result = null;
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				NguoiDungEntity nguoiDungEntity = new NguoiDungEntity(nguoiDungId);
				bool flag = dataAccessAdapterBase.FetchEntity(nguoiDungEntity);
				if (flag)
				{
					result = nguoiDungEntity;
				}
			}
			return result;
		}

		public static NguoiDungEntity SelectNguoiDung(string tenDangNhap, string matKhau)
		{
			NguoiDungEntity result = null;
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				EntityCollection entityCollection = new EntityCollection(new NguoiDungEntityFactory());
				dataAccessAdapterBase.FetchEntityCollection(entityCollection, new RelationPredicateBucket
				{
					PredicateExpression = 
					{
						NguoiDungFields.TenDangNhap == tenDangNhap,
						NguoiDungFields.MatKhau == matKhau
					}
				});
				bool flag = entityCollection != null && entityCollection.Count > 0;
				if (flag)
				{
					result = (NguoiDungEntity)entityCollection[0];
				}
			}
			return result;
		}

		public static EntityCollection SelectAllNguoiDung()
		{
			EntityCollection entityCollection;
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				entityCollection = new EntityCollection(new NguoiDungEntityFactory());
				RelationPredicateBucket filterBucket = new RelationPredicateBucket();
				dataAccessAdapterBase.FetchEntityCollection(entityCollection, filterBucket);
			}
			return entityCollection;
		}

		public static bool NguoiDungExist(int nguoiDungId, string tenDangNhap)
		{
			bool result;
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				EntityCollection entityCollection = new EntityCollection(new NguoiDungEntityFactory());
				RelationPredicateBucket relationPredicateBucket = new RelationPredicateBucket();
				relationPredicateBucket.PredicateExpression.Add(NguoiDungFields.TenDangNhap == tenDangNhap);
				bool flag = nguoiDungId > 0;
				if (flag)
				{
					relationPredicateBucket.PredicateExpression.Add(NguoiDungFields.NguoiDungId != nguoiDungId);
				}
				result = (dataAccessAdapterBase.GetDbCount(new NguoiDungEntity().Fields, relationPredicateBucket) > 0);
			}
			return result;
		}

		public static bool SaveNguoiDung(NguoiDungEntity eNguoiDung)
		{
			bool result;
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				result = dataAccessAdapterBase.SaveEntity(eNguoiDung, true);
			}
			return result;
		}

		public static bool DeleteNguoiDung(int nguoiDungId)
		{
			bool result = false;
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				RelationPredicateBucket relationPredicateBucket = new RelationPredicateBucket();
				relationPredicateBucket.PredicateExpression.Add(NguoiDungFields.NguoiDungId == nguoiDungId);
				result = (dataAccessAdapterBase.DeleteEntitiesDirectly(typeof(NguoiDungEntity), relationPredicateBucket) > 0);
			}
			return result;
		}

		public static DataTable SearchNguoiDungRDT(string tenDangNhap, string hoTen)
		{
			DataTable dataTable = new DataTable();
			EntityCollection entityCollection = new EntityCollection(new NguoiDungEntityFactory());
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				RelationPredicateBucket relationPredicateBucket = new RelationPredicateBucket();
				bool flag = !string.IsNullOrEmpty(tenDangNhap);
				if (flag)
				{
					relationPredicateBucket.PredicateExpression.Add(new FieldFullTextSearchPredicate(NguoiDungFields.TenDangNhap, null, FullTextSearchOperator.Contains, ManageBase.GetStringFullTextSearch(tenDangNhap, false)));
				}
				bool flag2 = !string.IsNullOrEmpty(hoTen);
				if (flag2)
				{
					relationPredicateBucket.PredicateExpression.Add(new FieldFullTextSearchPredicate(NguoiDungFields.HoTenNguoiDung, null, FullTextSearchOperator.Contains, ManageBase.GetStringFullTextSearch(hoTen, false)));
				}
				dataAccessAdapterBase.FetchTypedList(entityCollection.EntityFactoryToUse.CreateFields(), dataTable, relationPredicateBucket);
			}
			return dataTable;
		}

		public static DataTable CreateTableNguoiDung()
		{
			DataTable dataTable = new DataTable();
			EntityCollection entityCollection = new EntityCollection(new NguoiDungEntityFactory());
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				RelationPredicateBucket relationPredicateBucket = new RelationPredicateBucket();
				relationPredicateBucket.PredicateExpression.Add(NguoiDungFields.NguoiDungId == -1);
				dataAccessAdapterBase.FetchTypedList(entityCollection.EntityFactoryToUse.CreateFields(), dataTable, relationPredicateBucket);
			}
			return dataTable;
		}

		public static CauHinhEntity SelectCauHinh(string tenCauHinh)
		{
			CauHinhEntity result = null;
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				EntityCollection entityCollection = new EntityCollection(new CauHinhEntityFactory());
				dataAccessAdapterBase.FetchEntityCollection(entityCollection, new RelationPredicateBucket
				{
					PredicateExpression = 
					{
						CauHinhFields.TenCauHinh == tenCauHinh
					}
				});
				bool flag = entityCollection != null && entityCollection.Count > 0;
				if (flag)
				{
					result = (CauHinhEntity)entityCollection[0];
				}
			}
			return result;
		}

		public static CauHinhEntity SaveCauHinh(string tenCauHinh, string giaTri)
		{
			CauHinhEntity cauHinhEntity = ManageBase.SelectCauHinh(tenCauHinh);
			bool flag = cauHinhEntity == null;
			if (flag)
			{
				cauHinhEntity = new CauHinhEntity();
				cauHinhEntity.TenCauHinh = tenCauHinh;
			}
			cauHinhEntity.GiaTri = giaTri;
			cauHinhEntity.NguoiDungId = new int?(GlobalVariable.NguoiDungId);
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				bool flag2 = !dataAccessAdapterBase.SaveEntity(cauHinhEntity, true);
				if (flag2)
				{
					cauHinhEntity = null;
				}
			}
			return cauHinhEntity;
		}

		public static bool SaveCauHinhFTP(FTPDetail ftpDetail)
		{
			ftpDetail.Pass = Util.Encrypt(ftpDetail.Pass);
			return ManageBase.SaveCauHinh("FTPDetail", JsonConvert.SerializeObject(ftpDetail)) != null;
		}

		public static FTPDetail GetFTPDetail()
		{
			CauHinhEntity cauHinhEntity = ManageBase.SelectCauHinh("FTPDetail");
			FTPDetail fTPDetail = null;
			bool flag = cauHinhEntity != null;
			if (flag)
			{
				fTPDetail = JsonConvert.DeserializeObject<FTPDetail>(cauHinhEntity.GiaTri);
			}
			bool flag2 = fTPDetail != null;
			if (flag2)
			{
				fTPDetail.Pass = Util.Decrypt(fTPDetail.Pass);
			}
			return fTPDetail;
		}

		public static EntityCollection SelectXaByHuyenId(int huyenId)
		{
			EntityCollection entityCollection;
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				entityCollection = new EntityCollection(new XaEntityFactory());
				dataAccessAdapterBase.FetchEntityCollection(entityCollection, new RelationPredicateBucket
				{
					PredicateExpression = 
					{
						XaFields.HuyenId == huyenId
					}
				});
			}
			return entityCollection;
		}

		public static XaEntity SelectXaByXaId(int xaId)
		{
			XaEntity result = null;
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				XaEntity xaEntity = new XaEntity(xaId);
				bool flag = dataAccessAdapterBase.FetchEntity(xaEntity);
				if (flag)
				{
					result = xaEntity;
				}
			}
			return result;
		}

		public static EntityCollection SelectAllLoaiGiayTo(byte typeIndex)
		{
			EntityCollection entityCollection;
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				entityCollection = new EntityCollection(new LoaiGiayToEntityFactory());
				dataAccessAdapterBase.FetchEntityCollection(entityCollection, new RelationPredicateBucket
				{
					PredicateExpression = 
					{
						LoaiGiayToFields.TypeIndex == typeIndex
					}
				});
			}
			return entityCollection;
		}

		public static DataTable SelectAllLoaiGiayToRDT(byte typeIndex)
		{
			DataTable dataTable = new DataTable();
			EntityCollection entityCollection = new EntityCollection(new LoaiGiayToEntityFactory());
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				RelationPredicateBucket relationPredicateBucket = new RelationPredicateBucket();
				relationPredicateBucket.PredicateExpression.Add(LoaiGiayToFields.TypeIndex == typeIndex);
				dataAccessAdapterBase.FetchTypedList(entityCollection.EntityFactoryToUse.CreateFields(), dataTable, relationPredicateBucket);
			}
			return dataTable;
		}

		public static DataTable SelectAllLoaiBienDongRDT()
		{
			DataTable dataTable = new DataTable();
			EntityCollection entityCollection = new EntityCollection(new LoaiBienDongEntityFactory());
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				RelationPredicateBucket filterBucket = new RelationPredicateBucket();
				SortExpression sortClauses = new SortExpression(LoaiBienDongFields.TenLoaiBienDong | SortOperator.Ascending);
				dataAccessAdapterBase.FetchTypedList(entityCollection.EntityFactoryToUse.CreateFields(), dataTable, filterBucket, 0, sortClauses, false);
			}
			return dataTable;
		}

        public static DataTable SelectAllCongTyDoVeRDT()
        {
            DataTable dataTable = new DataTable();
            EntityCollection entityCollection = new EntityCollection(new CongTyDoVeEntityFactory());
            using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
            {
                RelationPredicateBucket filterBucket = new RelationPredicateBucket();
                SortExpression sortClauses = new SortExpression(CongTyDoVeFields.TenCongTyDoVe | SortOperator.Ascending);
                dataAccessAdapterBase.FetchTypedList(entityCollection.EntityFactoryToUse.CreateFields(), dataTable, filterBucket, 0, sortClauses, false);
            }
            return dataTable;
        }

        public static EntityCollection SelectAllCongTyDoVe()
        {
            EntityCollection entityCollection;
            using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
            {
                entityCollection = new EntityCollection(new CongTyDoVeEntityFactory());
                RelationPredicateBucket filterBucket = new RelationPredicateBucket();
                dataAccessAdapterBase.FetchEntityCollection(entityCollection, filterBucket);
            }
            return entityCollection;
        }

        public static DataTable SelectAllChuyenVienRDT()
        {
            DataTable dataTable = new DataTable();
            EntityCollection entityCollection = new EntityCollection(new ChuyenVienEntityFactory());
            using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
            {
                RelationPredicateBucket filterBucket = new RelationPredicateBucket();
                SortExpression sortClauses = new SortExpression(ChuyenVienFields.TenChuyenVien | SortOperator.Ascending);
                dataAccessAdapterBase.FetchTypedList(entityCollection.EntityFactoryToUse.CreateFields(), dataTable, filterBucket, 0, sortClauses, false);
            }
            return dataTable;
        }

        public static EntityCollection SelectAllChuyenVien()
        {
            EntityCollection entityCollection;
            using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
            {
                entityCollection = new EntityCollection(new ChuyenVienEntityFactory());
                RelationPredicateBucket filterBucket = new RelationPredicateBucket();
                dataAccessAdapterBase.FetchEntityCollection(entityCollection, filterBucket);
            }
            return entityCollection;
        }

        public static long SaveThongTinHoSo(ThongTinHoSoEntity entity)
		{
			long thongTinHoSoId;
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				dataAccessAdapterBase.SaveEntity(entity, true);
				thongTinHoSoId = entity.ThongTinHoSoId;
			}
			return thongTinHoSoId;
		}

		public static ThongTinHoSoEntity SelectThongTinHoSoById(long thongTinHoSoId)
		{
			ThongTinHoSoEntity result = null;
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				ThongTinHoSoEntity thongTinHoSoEntity = new ThongTinHoSoEntity(thongTinHoSoId);
				bool flag = dataAccessAdapterBase.FetchEntity(thongTinHoSoEntity);
				if (flag)
				{
					result = thongTinHoSoEntity;
				}
			}
			return result;
		}

		public static string GetStringFullTextSearch(string input, bool isContains = false)
		{
			string result;
			if (isContains)
			{
				result = "\"" + input + "*\"";
			}
			else
			{
				result = "\"" + input + "\"";
			}
			return result;
		}

		public static DataTable SearchThongTinHoSoRDT(SearchInput input)
		{
			DataTable dataTable = new DataTable();
			EntityCollection entityCollection = new EntityCollection(new ThongTinHoSoEntityFactory());
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				RelationPredicateBucket relationPredicateBucket = new RelationPredicateBucket();
				relationPredicateBucket.PredicateExpression.Add(ThongTinHoSoFields.XaId == GlobalVariable.XaId);
				relationPredicateBucket.PredicateExpression.Add(ThongTinHoSoFields.HoSoMoiNhat == true);
				bool flag = !string.IsNullOrEmpty(input.SoThua);
				if (flag)
				{
					relationPredicateBucket.PredicateExpression.Add(new FieldFullTextSearchPredicate(ThongTinHoSoFields.SoThuTuThua, null, FullTextSearchOperator.Contains, input.SoThua));
				}
				bool flag2 = !string.IsNullOrEmpty(input.SoTo);
				if (flag2)
				{
					relationPredicateBucket.PredicateExpression.Add(new FieldFullTextSearchPredicate(ThongTinHoSoFields.SoHieuToBanDo, null, FullTextSearchOperator.Contains, input.SoTo));
				}
				bool flag3 = !string.IsNullOrEmpty(input.SoBienNhan);
				if (flag3)
				{
					relationPredicateBucket.PredicateExpression.Add(new FieldFullTextSearchPredicate(ThongTinHoSoFields.SoBienNhan, null, FullTextSearchOperator.Contains, ManageBase.GetStringFullTextSearch(input.SoBienNhan, false)));
				}
				bool flag4 = !string.IsNullOrEmpty(input.SoBanVe);
				if (flag4)
				{
					relationPredicateBucket.PredicateExpression.Add(new FieldFullTextSearchPredicate(ThongTinHoSoFields.SoBanVe, null, FullTextSearchOperator.Contains, ManageBase.GetStringFullTextSearch(input.SoBanVe, false)));
				}
				bool flag5 = !string.IsNullOrEmpty(input.SoSerial);
				if (flag5)
				{
					relationPredicateBucket.PredicateExpression.Add(new FieldFullTextSearchPredicate(ThongTinHoSoFields.SoHieuGiayChungNhan, null, FullTextSearchOperator.Contains, ManageBase.GetStringFullTextSearch(input.SoSerial, false)));
				}
				bool laNguoiNopHoSo = input.LaNguoiNopHoSo;
				if (laNguoiNopHoSo)
				{
					bool flag6 = !string.IsNullOrEmpty(input.HoTen);
					if (flag6)
					{
						relationPredicateBucket.PredicateExpression.Add(new FieldFullTextSearchPredicate(ThongTinHoSoFields.NguoiNopHoSo, null, FullTextSearchOperator.Contains, ManageBase.GetStringFullTextSearch(input.HoTen, false)));
					}
					bool flag7 = !string.IsNullOrEmpty(input.SoGiayTo);
					if (flag7)
					{
						relationPredicateBucket.PredicateExpression.Add(new FieldFullTextSearchPredicate(ThongTinHoSoFields.SoGiayToNguoiNop, null, FullTextSearchOperator.Contains, ManageBase.GetStringFullTextSearch(input.SoGiayTo, false)));
					}
				}
				else
				{
					bool flag8 = !string.IsNullOrEmpty(input.HoTen);
					if (flag8)
					{
						relationPredicateBucket.PredicateExpression.Add(new FieldFullTextSearchPredicate(ThongTinHoSoFields.HoTen, null, FullTextSearchOperator.Contains, ManageBase.GetStringFullTextSearch(input.HoTen, false)));
					}
					bool flag9 = !string.IsNullOrEmpty(input.SoGiayTo);
					if (flag9)
					{
						relationPredicateBucket.PredicateExpression.Add(new FieldFullTextSearchPredicate(ThongTinHoSoFields.SoGiayTo, null, FullTextSearchOperator.Contains, ManageBase.GetStringFullTextSearch(input.SoGiayTo, false)));
					}
				}
				dataAccessAdapterBase.FetchTypedList(entityCollection.EntityFactoryToUse.CreateFields(), dataTable, relationPredicateBucket);
			}
			return dataTable;
		}

		public static EntityCollection SearchThongTinHoSo(SearchInput input)
		{
			EntityCollection entityCollection = new EntityCollection(new ThongTinHoSoEntityFactory());
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				RelationPredicateBucket relationPredicateBucket = new RelationPredicateBucket();
				relationPredicateBucket.PredicateExpression.Add(ThongTinHoSoFields.XaId == GlobalVariable.XaId);
				relationPredicateBucket.PredicateExpression.Add(ThongTinHoSoFields.HoSoMoiNhat == true);
				bool flag = !string.IsNullOrEmpty(input.SoThua);
				if (flag)
				{
					relationPredicateBucket.PredicateExpression.Add(new FieldFullTextSearchPredicate(ThongTinHoSoFields.SoThuTuThua, null, FullTextSearchOperator.Contains, input.SoThua));
				}
				bool flag2 = !string.IsNullOrEmpty(input.SoTo);
				if (flag2)
				{
					relationPredicateBucket.PredicateExpression.Add(new FieldFullTextSearchPredicate(ThongTinHoSoFields.SoHieuToBanDo, null, FullTextSearchOperator.Contains, input.SoTo));
				}
				bool flag3 = !string.IsNullOrEmpty(input.SoBienNhan);
				if (flag3)
				{
					relationPredicateBucket.PredicateExpression.Add(new FieldFullTextSearchPredicate(ThongTinHoSoFields.SoBienNhan, null, FullTextSearchOperator.Contains, ManageBase.GetStringFullTextSearch(input.SoBienNhan, false)));
				}
				bool flag4 = !string.IsNullOrEmpty(input.SoBanVe);
				if (flag4)
				{
					relationPredicateBucket.PredicateExpression.Add(new FieldFullTextSearchPredicate(ThongTinHoSoFields.SoBanVe, null, FullTextSearchOperator.Contains, ManageBase.GetStringFullTextSearch(input.SoBanVe, false)));
				}
				bool flag5 = !string.IsNullOrEmpty(input.SoSerial);
				if (flag5)
				{
					relationPredicateBucket.PredicateExpression.Add(new FieldFullTextSearchPredicate(ThongTinHoSoFields.SoHieuGiayChungNhan, null, FullTextSearchOperator.Contains, ManageBase.GetStringFullTextSearch(input.SoSerial, false)));
				}
				bool laNguoiNopHoSo = input.LaNguoiNopHoSo;
				if (laNguoiNopHoSo)
				{
					bool flag6 = !string.IsNullOrEmpty(input.HoTen);
					if (flag6)
					{
						relationPredicateBucket.PredicateExpression.Add(new FieldFullTextSearchPredicate(ThongTinHoSoFields.NguoiNopHoSo, null, FullTextSearchOperator.Contains, ManageBase.GetStringFullTextSearch(input.HoTen, false)));
					}
					bool flag7 = !string.IsNullOrEmpty(input.SoGiayTo);
					if (flag7)
					{
						relationPredicateBucket.PredicateExpression.Add(new FieldFullTextSearchPredicate(ThongTinHoSoFields.SoGiayToNguoiNop, null, FullTextSearchOperator.Contains, ManageBase.GetStringFullTextSearch(input.SoGiayTo, false)));
					}
				}
				else
				{
					bool flag8 = !string.IsNullOrEmpty(input.HoTen);
					if (flag8)
					{
						relationPredicateBucket.PredicateExpression.Add(new FieldFullTextSearchPredicate(ThongTinHoSoFields.HoTen, null, FullTextSearchOperator.Contains, ManageBase.GetStringFullTextSearch(input.HoTen, false)));
					}
					bool flag9 = !string.IsNullOrEmpty(input.SoGiayTo);
					if (flag9)
					{
						relationPredicateBucket.PredicateExpression.Add(new FieldFullTextSearchPredicate(ThongTinHoSoFields.SoGiayTo, null, FullTextSearchOperator.Contains, ManageBase.GetStringFullTextSearch(input.SoGiayTo, false)));
					}
				}
				dataAccessAdapterBase.FetchEntityCollection(entityCollection, relationPredicateBucket);
			}
			return entityCollection;
		}

		public static bool DeleteThongTinHoSo(long thongTinHoSoId)
		{
			bool result = false;
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				RelationPredicateBucket relationPredicateBucket = new RelationPredicateBucket();
				relationPredicateBucket.PredicateExpression.Add(ThongTinHoSoFields.ThongTinHoSoId == thongTinHoSoId);
				result = (dataAccessAdapterBase.DeleteEntitiesDirectly(typeof(ThongTinHoSoEntity), relationPredicateBucket) > 0);
			}
			return result;
		}

		public static int Update(EntityBase2 entity, IRelationPredicateBucket filter)
		{
			int result = 0;
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				result = dataAccessAdapterBase.UpdateEntitiesDirectly(entity, filter);
			}
			return result;
		}

        public static int SaveEntityCollection(IEntityCollection2 entitiesToSave)
        {
            using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
            {
                return dataAccessAdapterBase.SaveEntityCollection(entitiesToSave, true, false);
            }            
        }

        public static bool Delete(Type type, IRelationPredicateBucket filter)
		{
			bool result = false;
			using (DataAccessAdapterBase dataAccessAdapterBase = new DataAccessAdapter(ManageBase.ConnectionString))
			{
				result = (dataAccessAdapterBase.DeleteEntitiesDirectly(type, filter) > 0);
			}
			return result;
		}
	}
}
