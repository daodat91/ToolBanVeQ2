﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.3.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using DAL.ManageDocument;
using DAL.ManageDocument.FactoryClasses;
using DAL.ManageDocument.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace DAL.ManageDocument.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: Xa. </summary>
	public partial class XaRelations
	{
		/// <summary>CTor</summary>
		public XaRelations()
		{
		}

		/// <summary>Gets all relations of the XaEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ThongTinHoSoEntityUsingXaId);
			toReturn.Add(this.HuyenEntityUsingHuyenId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between XaEntity and ThongTinHoSoEntity over the 1:n relation they have, using the relation between the fields:
		/// Xa.XaId - ThongTinHoSo.XaId
		/// </summary>
		public virtual IEntityRelation ThongTinHoSoEntityUsingXaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ThongTinHoSos" , true);
				relation.AddEntityFieldPair(XaFields.XaId, ThongTinHoSoFields.XaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("XaEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ThongTinHoSoEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between XaEntity and HuyenEntity over the m:1 relation they have, using the relation between the fields:
		/// Xa.HuyenId - Huyen.HuyenId
		/// </summary>
		public virtual IEntityRelation HuyenEntityUsingHuyenId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Huyen", false);
				relation.AddEntityFieldPair(HuyenFields.HuyenId, XaFields.HuyenId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HuyenEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("XaEntity", true);
				return relation;
			}
		}
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}
		#endregion

		#region Included Code

		#endregion
	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticXaRelations
	{
		internal static readonly IEntityRelation ThongTinHoSoEntityUsingXaIdStatic = new XaRelations().ThongTinHoSoEntityUsingXaId;
		internal static readonly IEntityRelation HuyenEntityUsingHuyenIdStatic = new XaRelations().HuyenEntityUsingHuyenId;

		/// <summary>CTor</summary>
		static StaticXaRelations()
		{
		}
	}
}
