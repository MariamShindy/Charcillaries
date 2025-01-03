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
	/// <summary>Entity class which represents the entity 'AmenityFeedback'.<br/><br/></summary>
	[Serializable]
	public partial class AmenityFeedbackEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		private AmenityEntity _amenity;
		private PassengerEntity _passenger;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static AmenityFeedbackEntityStaticMetaData _staticMetaData = new AmenityFeedbackEntityStaticMetaData();
		private static AmenityFeedbackRelations _relationsFactory = new AmenityFeedbackRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Amenity</summary>
			public static readonly string Amenity = "Amenity";
			/// <summary>Member name Passenger</summary>
			public static readonly string Passenger = "Passenger";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class AmenityFeedbackEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public AmenityFeedbackEntityStaticMetaData()
			{
				SetEntityCoreInfo("AmenityFeedbackEntity", InheritanceHierarchyType.None, false, (int)Charcillaries.Data.EntityType.AmenityFeedbackEntity, typeof(AmenityFeedbackEntity), typeof(AmenityFeedbackEntityFactory), false);
				AddNavigatorMetaData<AmenityFeedbackEntity, AmenityEntity>("Amenity", "AmenityFeedbacks", (a, b) => a._amenity = b, a => a._amenity, (a, b) => a.Amenity = b, Charcillaries.Data.RelationClasses.StaticAmenityFeedbackRelations.AmenityEntityUsingAmenityIdStatic, ()=>new AmenityFeedbackRelations().AmenityEntityUsingAmenityId, null, new int[] { (int)AmenityFeedbackFieldIndex.AmenityId }, null, true, (int)Charcillaries.Data.EntityType.AmenityEntity);
				AddNavigatorMetaData<AmenityFeedbackEntity, PassengerEntity>("Passenger", "AmenityFeedbacks", (a, b) => a._passenger = b, a => a._passenger, (a, b) => a.Passenger = b, Charcillaries.Data.RelationClasses.StaticAmenityFeedbackRelations.PassengerEntityUsingPassengerIdStatic, ()=>new AmenityFeedbackRelations().PassengerEntityUsingPassengerId, null, new int[] { (int)AmenityFeedbackFieldIndex.PassengerId }, null, true, (int)Charcillaries.Data.EntityType.PassengerEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static AmenityFeedbackEntity()
		{
		}

		/// <summary> CTor</summary>
		public AmenityFeedbackEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AmenityFeedbackEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AmenityFeedbackEntity</param>
		public AmenityFeedbackEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for AmenityFeedback which data should be fetched into this AmenityFeedback object</param>
		public AmenityFeedbackEntity(System.Int32 id) : this(id, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for AmenityFeedback which data should be fetched into this AmenityFeedback object</param>
		/// <param name="validator">The custom validator object for this AmenityFeedbackEntity</param>
		public AmenityFeedbackEntity(System.Int32 id, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.Id = id;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected AmenityFeedbackEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Method which will construct a filter (predicate expression) for the unique constraint defined on the fields: AmenityId , PassengerId .</summary>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public IPredicateExpression ConstructFilterForUCAmenityIdPassengerId()
		{
			var filter = new PredicateExpression();
			filter.Add(Charcillaries.Data.HelperClasses.AmenityFeedbackFields.AmenityId == this.Fields.GetCurrentValue((int)AmenityFeedbackFieldIndex.AmenityId));
			filter.Add(Charcillaries.Data.HelperClasses.AmenityFeedbackFields.PassengerId == this.Fields.GetCurrentValue((int)AmenityFeedbackFieldIndex.PassengerId));
 			return filter;
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Amenity' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAmenity() { return CreateRelationInfoForNavigator("Amenity"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Passenger' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPassenger() { return CreateRelationInfoForNavigator("Passenger"); }
		
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
		/// <param name="validator">The validator object for this AmenityFeedbackEntity</param>
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
		public static AmenityFeedbackRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Amenity' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAmenity { get { return _staticMetaData.GetPrefetchPathElement("Amenity", CommonEntityBase.CreateEntityCollection<AmenityEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Passenger' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPassenger { get { return _staticMetaData.GetPrefetchPathElement("Passenger", CommonEntityBase.CreateEntityCollection<PassengerEntity>()); } }

		/// <summary>The AmenityId property of the Entity AmenityFeedback<br/><br/></summary>
		/// <remarks>Mapped on  table field: "amenity_feedback"."amenity_id".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 AmenityId
		{
			get { return (System.Int32)GetValue((int)AmenityFeedbackFieldIndex.AmenityId, true); }
			set	{ SetValue((int)AmenityFeedbackFieldIndex.AmenityId, value); }
		}

		/// <summary>The Comment property of the Entity AmenityFeedback<br/><br/></summary>
		/// <remarks>Mapped on  table field: "amenity_feedback"."comment".<br/>Table field type characteristics (type, precision, scale, length): Text, 0, 0, 1073741824.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Comment
		{
			get { return (System.String)GetValue((int)AmenityFeedbackFieldIndex.Comment, true); }
			set	{ SetValue((int)AmenityFeedbackFieldIndex.Comment, value); }
		}

		/// <summary>The DateCreated property of the Entity AmenityFeedback<br/><br/></summary>
		/// <remarks>Mapped on  table field: "amenity_feedback"."date_created".<br/>Table field type characteristics (type, precision, scale, length): Timestamp, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)AmenityFeedbackFieldIndex.DateCreated, true); }
			set	{ SetValue((int)AmenityFeedbackFieldIndex.DateCreated, value); }
		}

		/// <summary>The Id property of the Entity AmenityFeedback<br/><br/></summary>
		/// <remarks>Mapped on  table field: "amenity_feedback"."id".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Id
		{
			get { return (System.Int32)GetValue((int)AmenityFeedbackFieldIndex.Id, true); }
			set { SetValue((int)AmenityFeedbackFieldIndex.Id, value); }		}

		/// <summary>The ObjectStatus property of the Entity AmenityFeedback<br/><br/></summary>
		/// <remarks>Mapped on  table field: "amenity_feedback"."object_status".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ObjectStatus
		{
			get { return (System.Int32)GetValue((int)AmenityFeedbackFieldIndex.ObjectStatus, true); }
			set	{ SetValue((int)AmenityFeedbackFieldIndex.ObjectStatus, value); }
		}

		/// <summary>The PassengerId property of the Entity AmenityFeedback<br/><br/></summary>
		/// <remarks>Mapped on  table field: "amenity_feedback"."passenger_id".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 PassengerId
		{
			get { return (System.Int32)GetValue((int)AmenityFeedbackFieldIndex.PassengerId, true); }
			set	{ SetValue((int)AmenityFeedbackFieldIndex.PassengerId, value); }
		}

		/// <summary>The Rating property of the Entity AmenityFeedback<br/><br/></summary>
		/// <remarks>Mapped on  table field: "amenity_feedback"."rating".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> Rating
		{
			get { return (Nullable<System.Int32>)GetValue((int)AmenityFeedbackFieldIndex.Rating, false); }
			set	{ SetValue((int)AmenityFeedbackFieldIndex.Rating, value); }
		}

		/// <summary>Gets / sets related entity of type 'AmenityEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual AmenityEntity Amenity
		{
			get { return _amenity; }
			set { SetSingleRelatedEntityNavigator(value, "Amenity"); }
		}

		/// <summary>Gets / sets related entity of type 'PassengerEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual PassengerEntity Passenger
		{
			get { return _passenger; }
			set { SetSingleRelatedEntityNavigator(value, "Passenger"); }
		}

		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END

	}
}

namespace Charcillaries.Data
{
	public enum AmenityFeedbackFieldIndex
	{
		///<summary>AmenityId. </summary>
		AmenityId,
		///<summary>Comment. </summary>
		Comment,
		///<summary>DateCreated. </summary>
		DateCreated,
		///<summary>Id. </summary>
		Id,
		///<summary>ObjectStatus. </summary>
		ObjectStatus,
		///<summary>PassengerId. </summary>
		PassengerId,
		///<summary>Rating. </summary>
		Rating,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace Charcillaries.Data.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: AmenityFeedback. </summary>
	public partial class AmenityFeedbackRelations: RelationFactory
	{

		/// <summary>Returns a new IEntityRelation object, between AmenityFeedbackEntity and AmenityEntity over the m:1 relation they have, using the relation between the fields: AmenityFeedback.AmenityId - Amenity.Id</summary>
		public virtual IEntityRelation AmenityEntityUsingAmenityId
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "Amenity", false, new[] { AmenityFields.Id, AmenityFeedbackFields.AmenityId }); }
		}

		/// <summary>Returns a new IEntityRelation object, between AmenityFeedbackEntity and PassengerEntity over the m:1 relation they have, using the relation between the fields: AmenityFeedback.PassengerId - Passenger.Id</summary>
		public virtual IEntityRelation PassengerEntityUsingPassengerId
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "Passenger", false, new[] { PassengerFields.Id, AmenityFeedbackFields.PassengerId }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticAmenityFeedbackRelations
	{
		internal static readonly IEntityRelation AmenityEntityUsingAmenityIdStatic = new AmenityFeedbackRelations().AmenityEntityUsingAmenityId;
		internal static readonly IEntityRelation PassengerEntityUsingPassengerIdStatic = new AmenityFeedbackRelations().PassengerEntityUsingPassengerId;

		/// <summary>CTor</summary>
		static StaticAmenityFeedbackRelations() { }
	}
}
