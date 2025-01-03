﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.10.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Charcillaries.Data.HelperClasses;
using Charcillaries.Data.FactoryClasses;
using Charcillaries.Data.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Charcillaries.Data.EntityClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	/// <summary>Entity class which represents the entity 'PassengerAmenitySelection'.<br/><br/></summary>
	[Serializable]
	public partial class PassengerAmenitySelectionEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		private PassengerEntity _passenger;
		private RouteAmenityEntity _routeAmenity;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static PassengerAmenitySelectionEntityStaticMetaData _staticMetaData = new PassengerAmenitySelectionEntityStaticMetaData();
		private static PassengerAmenitySelectionRelations _relationsFactory = new PassengerAmenitySelectionRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Passenger</summary>
			public static readonly string Passenger = "Passenger";
			/// <summary>Member name RouteAmenity</summary>
			public static readonly string RouteAmenity = "RouteAmenity";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class PassengerAmenitySelectionEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public PassengerAmenitySelectionEntityStaticMetaData()
			{
				SetEntityCoreInfo("PassengerAmenitySelectionEntity", InheritanceHierarchyType.None, false, (int)Charcillaries.Data.EntityType.PassengerAmenitySelectionEntity, typeof(PassengerAmenitySelectionEntity), typeof(PassengerAmenitySelectionEntityFactory), false);
				AddNavigatorMetaData<PassengerAmenitySelectionEntity, PassengerEntity>("Passenger", "PassengerAmenitySelections", (a, b) => a._passenger = b, a => a._passenger, (a, b) => a.Passenger = b, Charcillaries.Data.RelationClasses.StaticPassengerAmenitySelectionRelations.PassengerEntityUsingPassengerIdStatic, ()=>new PassengerAmenitySelectionRelations().PassengerEntityUsingPassengerId, null, new int[] { (int)PassengerAmenitySelectionFieldIndex.PassengerId }, null, true, (int)Charcillaries.Data.EntityType.PassengerEntity);
				AddNavigatorMetaData<PassengerAmenitySelectionEntity, RouteAmenityEntity>("RouteAmenity", "PassengerAmenitySelections", (a, b) => a._routeAmenity = b, a => a._routeAmenity, (a, b) => a.RouteAmenity = b, Charcillaries.Data.RelationClasses.StaticPassengerAmenitySelectionRelations.RouteAmenityEntityUsingRouteAmenityIdStatic, ()=>new PassengerAmenitySelectionRelations().RouteAmenityEntityUsingRouteAmenityId, null, new int[] { (int)PassengerAmenitySelectionFieldIndex.RouteAmenityId }, null, true, (int)Charcillaries.Data.EntityType.RouteAmenityEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static PassengerAmenitySelectionEntity()
		{
		}

		/// <summary> CTor</summary>
		public PassengerAmenitySelectionEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PassengerAmenitySelectionEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PassengerAmenitySelectionEntity</param>
		public PassengerAmenitySelectionEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for PassengerAmenitySelection which data should be fetched into this PassengerAmenitySelection object</param>
		public PassengerAmenitySelectionEntity(System.Int32 id) : this(id, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for PassengerAmenitySelection which data should be fetched into this PassengerAmenitySelection object</param>
		/// <param name="validator">The custom validator object for this PassengerAmenitySelectionEntity</param>
		public PassengerAmenitySelectionEntity(System.Int32 id, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.Id = id;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected PassengerAmenitySelectionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Passenger' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPassenger() { return CreateRelationInfoForNavigator("Passenger"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'RouteAmenity' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRouteAmenity() { return CreateRelationInfoForNavigator("RouteAmenity"); }
		
		/// <inheritdoc/>
		protected override EntityStaticMetaDataBase GetEntityStaticMetaData() {	return _staticMetaData; }

		/// <summary>Initializes the class members</summary>
		private void InitClassMembers()
		{
			PerformDependencyInjection();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}

		/// <summary>Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this PassengerAmenitySelectionEntity</param>
		/// <param name="fields">Fields of this entity</param>
		private void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			this.Fields = fields ?? CreateFields();
			this.Validator = validator;
			InitClassMembers();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary>The relations object holding all relations of this entity with other entity classes.</summary>
		public static PassengerAmenitySelectionRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Passenger' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPassenger { get { return _staticMetaData.GetPrefetchPathElement("Passenger", CommonEntityBase.CreateEntityCollection<PassengerEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RouteAmenity' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRouteAmenity { get { return _staticMetaData.GetPrefetchPathElement("RouteAmenity", CommonEntityBase.CreateEntityCollection<RouteAmenityEntity>()); } }

		/// <summary>The Confirmed property of the Entity PassengerAmenitySelection<br/><br/></summary>
		/// <remarks>Mapped on  table field: "passenger_amenity_selection"."confirmed".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> Confirmed
		{
			get { return (Nullable<System.Int32>)GetValue((int)PassengerAmenitySelectionFieldIndex.Confirmed, false); }
			set	{ SetValue((int)PassengerAmenitySelectionFieldIndex.Confirmed, value); }
		}

		/// <summary>The Customization property of the Entity PassengerAmenitySelection<br/><br/></summary>
		/// <remarks>Mapped on  table field: "passenger_amenity_selection"."customization".<br/>Table field type characteristics (type, precision, scale, length): Text, 0, 0, 1073741824.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Customization
		{
			get { return (System.String)GetValue((int)PassengerAmenitySelectionFieldIndex.Customization, true); }
			set	{ SetValue((int)PassengerAmenitySelectionFieldIndex.Customization, value); }
		}

		/// <summary>The Id property of the Entity PassengerAmenitySelection<br/><br/></summary>
		/// <remarks>Mapped on  table field: "passenger_amenity_selection"."id".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Id
		{
			get { return (System.Int32)GetValue((int)PassengerAmenitySelectionFieldIndex.Id, true); }
			set { SetValue((int)PassengerAmenitySelectionFieldIndex.Id, value); }		}

		/// <summary>The ObjectStatus property of the Entity PassengerAmenitySelection<br/><br/></summary>
		/// <remarks>Mapped on  table field: "passenger_amenity_selection"."object_status".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ObjectStatus
		{
			get { return (System.Int32)GetValue((int)PassengerAmenitySelectionFieldIndex.ObjectStatus, true); }
			set	{ SetValue((int)PassengerAmenitySelectionFieldIndex.ObjectStatus, value); }
		}

		/// <summary>The PassengerId property of the Entity PassengerAmenitySelection<br/><br/></summary>
		/// <remarks>Mapped on  table field: "passenger_amenity_selection"."passenger_id".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 PassengerId
		{
			get { return (System.Int32)GetValue((int)PassengerAmenitySelectionFieldIndex.PassengerId, true); }
			set	{ SetValue((int)PassengerAmenitySelectionFieldIndex.PassengerId, value); }
		}

		/// <summary>The Quantity property of the Entity PassengerAmenitySelection<br/><br/></summary>
		/// <remarks>Mapped on  table field: "passenger_amenity_selection"."quantity".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> Quantity
		{
			get { return (Nullable<System.Int32>)GetValue((int)PassengerAmenitySelectionFieldIndex.Quantity, false); }
			set	{ SetValue((int)PassengerAmenitySelectionFieldIndex.Quantity, value); }
		}

		/// <summary>The RouteAmenityId property of the Entity PassengerAmenitySelection<br/><br/></summary>
		/// <remarks>Mapped on  table field: "passenger_amenity_selection"."route_amenity_id".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 RouteAmenityId
		{
			get { return (System.Int32)GetValue((int)PassengerAmenitySelectionFieldIndex.RouteAmenityId, true); }
			set	{ SetValue((int)PassengerAmenitySelectionFieldIndex.RouteAmenityId, value); }
		}

		/// <summary>Gets / sets related entity of type 'PassengerEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual PassengerEntity Passenger
		{
			get { return _passenger; }
			set { SetSingleRelatedEntityNavigator(value, "Passenger"); }
		}

		/// <summary>Gets / sets related entity of type 'RouteAmenityEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual RouteAmenityEntity RouteAmenity
		{
			get { return _routeAmenity; }
			set { SetSingleRelatedEntityNavigator(value, "RouteAmenity"); }
		}

		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END

	}
}

namespace Charcillaries.Data
{
	public enum PassengerAmenitySelectionFieldIndex
	{
		///<summary>Confirmed. </summary>
		Confirmed,
		///<summary>Customization. </summary>
		Customization,
		///<summary>Id. </summary>
		Id,
		///<summary>ObjectStatus. </summary>
		ObjectStatus,
		///<summary>PassengerId. </summary>
		PassengerId,
		///<summary>Quantity. </summary>
		Quantity,
		///<summary>RouteAmenityId. </summary>
		RouteAmenityId,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace Charcillaries.Data.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: PassengerAmenitySelection. </summary>
	public partial class PassengerAmenitySelectionRelations: RelationFactory
	{

		/// <summary>Returns a new IEntityRelation object, between PassengerAmenitySelectionEntity and PassengerEntity over the m:1 relation they have, using the relation between the fields: PassengerAmenitySelection.PassengerId - Passenger.Id</summary>
		public virtual IEntityRelation PassengerEntityUsingPassengerId
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "Passenger", false, new[] { PassengerFields.Id, PassengerAmenitySelectionFields.PassengerId }); }
		}

		/// <summary>Returns a new IEntityRelation object, between PassengerAmenitySelectionEntity and RouteAmenityEntity over the m:1 relation they have, using the relation between the fields: PassengerAmenitySelection.RouteAmenityId - RouteAmenity.Id</summary>
		public virtual IEntityRelation RouteAmenityEntityUsingRouteAmenityId
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "RouteAmenity", false, new[] { RouteAmenityFields.Id, PassengerAmenitySelectionFields.RouteAmenityId }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticPassengerAmenitySelectionRelations
	{
		internal static readonly IEntityRelation PassengerEntityUsingPassengerIdStatic = new PassengerAmenitySelectionRelations().PassengerEntityUsingPassengerId;
		internal static readonly IEntityRelation RouteAmenityEntityUsingRouteAmenityIdStatic = new PassengerAmenitySelectionRelations().RouteAmenityEntityUsingRouteAmenityId;

		/// <summary>CTor</summary>
		static StaticPassengerAmenitySelectionRelations() { }
	}
}
