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
	/// <summary>Implements the relations factory for the entity: CongTyDoVe. </summary>
	public partial class CongTyDoVeRelations
	{
		/// <summary>CTor</summary>
		public CongTyDoVeRelations()
		{
		}

		/// <summary>Gets all relations of the CongTyDoVeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}
		#endregion

		#region Included Code

		#endregion
	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCongTyDoVeRelations
	{

		/// <summary>CTor</summary>
		static StaticCongTyDoVeRelations()
		{
		}
	}
}
