﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.3.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Linq;
using System.Collections.Generic;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

using DAL.ManageDocument;
using DAL.ManageDocument.EntityClasses;
using DAL.ManageDocument.FactoryClasses;
using DAL.ManageDocument.HelperClasses;
using DAL.ManageDocument.RelationClasses;

namespace DAL.ManageDocument.Linq
{
	/// <summary>Meta-data class for the construction of Linq queries which are to be executed using LLBLGen Pro code.</summary>
	public partial class LinqMetaData: ILinqMetaData
	{
		#region Class Member Declarations
		private IDataAccessAdapter _adapterToUse;
		private FunctionMappingStore _customFunctionMappings;
		private Context _contextToUse;
		#endregion
		
		/// <summary>CTor. Using this ctor will leave the IDataAccessAdapter object to use empty. To be able to execute the query, an IDataAccessAdapter instance
		/// is required, and has to be set on the LLBLGenProProvider2 object in the query to execute. </summary>
		public LinqMetaData() : this(null, null)
		{
		}
		
		/// <summary>CTor which accepts an IDataAccessAdapter implementing object, which will be used to execute queries created with this metadata class.</summary>
		/// <param name="adapterToUse">the IDataAccessAdapter to use in queries created with this meta data</param>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(IDataAccessAdapter adapterToUse) : this (adapterToUse, null)
		{
		}

		/// <summary>CTor which accepts an IDataAccessAdapter implementing object, which will be used to execute queries created with this metadata class.</summary>
		/// <param name="adapterToUse">the IDataAccessAdapter to use in queries created with this meta data</param>
		/// <param name="customFunctionMappings">The custom function mappings to use. These take higher precedence than the ones in the DQE to use.</param>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(IDataAccessAdapter adapterToUse, FunctionMappingStore customFunctionMappings)
		{
			_adapterToUse = adapterToUse;
			_customFunctionMappings = customFunctionMappings;
		}
	
		/// <summary>returns the datasource to use in a Linq query for the entity type specified</summary>
		/// <param name="typeOfEntity">the type of the entity to get the datasource for</param>
		/// <returns>the requested datasource</returns>
		public IDataSource GetQueryableForEntity(int typeOfEntity)
		{
			IDataSource toReturn = null;
			switch((DAL.ManageDocument.EntityType)typeOfEntity)
			{
				case DAL.ManageDocument.EntityType.CauHinhEntity:
					toReturn = this.CauHinh;
					break;
				case DAL.ManageDocument.EntityType.ChuyenVienEntity:
					toReturn = this.ChuyenVien;
					break;
				case DAL.ManageDocument.EntityType.CongTyDoVeEntity:
					toReturn = this.CongTyDoVe;
					break;
				case DAL.ManageDocument.EntityType.HuyenEntity:
					toReturn = this.Huyen;
					break;
				case DAL.ManageDocument.EntityType.LoaiBienDongEntity:
					toReturn = this.LoaiBienDong;
					break;
				case DAL.ManageDocument.EntityType.LoaiGiayToEntity:
					toReturn = this.LoaiGiayTo;
					break;
				case DAL.ManageDocument.EntityType.NguoiDungEntity:
					toReturn = this.NguoiDung;
					break;
				case DAL.ManageDocument.EntityType.ThongTinHoSoEntity:
					toReturn = this.ThongTinHoSo;
					break;
				case DAL.ManageDocument.EntityType.TinhEntity:
					toReturn = this.Tinh;
					break;
				case DAL.ManageDocument.EntityType.XaEntity:
					toReturn = this.Xa;
					break;
				default:
					toReturn = null;
					break;
			}
			return toReturn;
		}

		/// <summary>returns the datasource to use in a Linq query for the entity type specified</summary>
		/// <typeparam name="TEntity">the type of the entity to get the datasource for</typeparam>
		/// <returns>the requested datasource</returns>
		public DataSource2<TEntity> GetQueryableForEntity<TEntity>()
				where TEntity : class
		{
			return new DataSource2<TEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse);
		}

		/// <summary>returns the datasource to use in a Linq query when targeting CauHinhEntity instances in the database.</summary>
		public DataSource2<CauHinhEntity> CauHinh
		{
			get { return new DataSource2<CauHinhEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ChuyenVienEntity instances in the database.</summary>
		public DataSource2<ChuyenVienEntity> ChuyenVien
		{
			get { return new DataSource2<ChuyenVienEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting CongTyDoVeEntity instances in the database.</summary>
		public DataSource2<CongTyDoVeEntity> CongTyDoVe
		{
			get { return new DataSource2<CongTyDoVeEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HuyenEntity instances in the database.</summary>
		public DataSource2<HuyenEntity> Huyen
		{
			get { return new DataSource2<HuyenEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting LoaiBienDongEntity instances in the database.</summary>
		public DataSource2<LoaiBienDongEntity> LoaiBienDong
		{
			get { return new DataSource2<LoaiBienDongEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting LoaiGiayToEntity instances in the database.</summary>
		public DataSource2<LoaiGiayToEntity> LoaiGiayTo
		{
			get { return new DataSource2<LoaiGiayToEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting NguoiDungEntity instances in the database.</summary>
		public DataSource2<NguoiDungEntity> NguoiDung
		{
			get { return new DataSource2<NguoiDungEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ThongTinHoSoEntity instances in the database.</summary>
		public DataSource2<ThongTinHoSoEntity> ThongTinHoSo
		{
			get { return new DataSource2<ThongTinHoSoEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TinhEntity instances in the database.</summary>
		public DataSource2<TinhEntity> Tinh
		{
			get { return new DataSource2<TinhEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting XaEntity instances in the database.</summary>
		public DataSource2<XaEntity> Xa
		{
			get { return new DataSource2<XaEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		

		#region Class Property Declarations
		/// <summary> Gets / sets the IDataAccessAdapter to use for the queries created with this meta data object.</summary>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public IDataAccessAdapter AdapterToUse
		{
			get { return _adapterToUse;}
			set { _adapterToUse = value;}
		}

		/// <summary>Gets or sets the custom function mappings to use. These take higher precedence than the ones in the DQE to use</summary>
		public FunctionMappingStore CustomFunctionMappings
		{
			get { return _customFunctionMappings; }
			set { _customFunctionMappings = value; }
		}
		
		/// <summary>Gets or sets the Context instance to use for entity fetches.</summary>
		public Context ContextToUse
		{
			get { return _contextToUse;}
			set { _contextToUse = value;}
		}
		#endregion
	}
}