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
	/// <summary>Entity class which represents the entity 'User'.<br/><br/></summary>
	[Serializable]
	public partial class UserEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		private AirlineEntity _airline;
		private PersonEntity _person;
		private RoleEntity _role;
		private TourOperatorEntity _tourOperator;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static UserEntityStaticMetaData _staticMetaData = new UserEntityStaticMetaData();
		private static UserRelations _relationsFactory = new UserRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Airline</summary>
			public static readonly string Airline = "Airline";
			/// <summary>Member name Person</summary>
			public static readonly string Person = "Person";
			/// <summary>Member name Role</summary>
			public static readonly string Role = "Role";
			/// <summary>Member name TourOperator</summary>
			public static readonly string TourOperator = "TourOperator";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class UserEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public UserEntityStaticMetaData()
			{
				SetEntityCoreInfo("UserEntity", InheritanceHierarchyType.None, false, (int)Charcillaries.Data.EntityType.UserEntity, typeof(UserEntity), typeof(UserEntityFactory), false);
				AddNavigatorMetaData<UserEntity, AirlineEntity>("Airline", "Users", (a, b) => a._airline = b, a => a._airline, (a, b) => a.Airline = b, Charcillaries.Data.RelationClasses.StaticUserRelations.AirlineEntityUsingAirlineIdStatic, ()=>new UserRelations().AirlineEntityUsingAirlineId, null, new int[] { (int)UserFieldIndex.AirlineId }, null, true, (int)Charcillaries.Data.EntityType.AirlineEntity);
				AddNavigatorMetaData<UserEntity, PersonEntity>("Person", "Users", (a, b) => a._person = b, a => a._person, (a, b) => a.Person = b, Charcillaries.Data.RelationClasses.StaticUserRelations.PersonEntityUsingPersonIdStatic, ()=>new UserRelations().PersonEntityUsingPersonId, null, new int[] { (int)UserFieldIndex.PersonId }, null, true, (int)Charcillaries.Data.EntityType.PersonEntity);
				AddNavigatorMetaData<UserEntity, RoleEntity>("Role", "Users", (a, b) => a._role = b, a => a._role, (a, b) => a.Role = b, Charcillaries.Data.RelationClasses.StaticUserRelations.RoleEntityUsingRoleIdStatic, ()=>new UserRelations().RoleEntityUsingRoleId, null, new int[] { (int)UserFieldIndex.RoleId }, null, true, (int)Charcillaries.Data.EntityType.RoleEntity);
				AddNavigatorMetaData<UserEntity, TourOperatorEntity>("TourOperator", "Users", (a, b) => a._tourOperator = b, a => a._tourOperator, (a, b) => a.TourOperator = b, Charcillaries.Data.RelationClasses.StaticUserRelations.TourOperatorEntityUsingTourOperatorIdStatic, ()=>new UserRelations().TourOperatorEntityUsingTourOperatorId, null, new int[] { (int)UserFieldIndex.TourOperatorId }, null, true, (int)Charcillaries.Data.EntityType.TourOperatorEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static UserEntity()
		{
		}

		/// <summary> CTor</summary>
		public UserEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public UserEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this UserEntity</param>
		public UserEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for User which data should be fetched into this User object</param>
		public UserEntity(System.Int32 id) : this(id, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for User which data should be fetched into this User object</param>
		/// <param name="validator">The custom validator object for this UserEntity</param>
		public UserEntity(System.Int32 id, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.Id = id;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected UserEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Airline' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAirline() { return CreateRelationInfoForNavigator("Airline"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Person' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPerson() { return CreateRelationInfoForNavigator("Person"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Role' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRole() { return CreateRelationInfoForNavigator("Role"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'TourOperator' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTourOperator() { return CreateRelationInfoForNavigator("TourOperator"); }
		
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
		/// <param name="validator">The validator object for this UserEntity</param>
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
		public static UserRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Airline' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAirline { get { return _staticMetaData.GetPrefetchPathElement("Airline", CommonEntityBase.CreateEntityCollection<AirlineEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Person' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPerson { get { return _staticMetaData.GetPrefetchPathElement("Person", CommonEntityBase.CreateEntityCollection<PersonEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRole { get { return _staticMetaData.GetPrefetchPathElement("Role", CommonEntityBase.CreateEntityCollection<RoleEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TourOperator' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTourOperator { get { return _staticMetaData.GetPrefetchPathElement("TourOperator", CommonEntityBase.CreateEntityCollection<TourOperatorEntity>()); } }

		/// <summary>The AirlineId property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "user"."airline_id".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> AirlineId
		{
			get { return (Nullable<System.Int32>)GetValue((int)UserFieldIndex.AirlineId, false); }
			set	{ SetValue((int)UserFieldIndex.AirlineId, value); }
		}

		/// <summary>The Id property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "user"."id".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Id
		{
			get { return (System.Int32)GetValue((int)UserFieldIndex.Id, true); }
			set { SetValue((int)UserFieldIndex.Id, value); }		}

		/// <summary>The ObjectStatus property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "user"."object_status".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ObjectStatus
		{
			get { return (System.Int32)GetValue((int)UserFieldIndex.ObjectStatus, true); }
			set	{ SetValue((int)UserFieldIndex.ObjectStatus, value); }
		}

		/// <summary>The Password property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "user"."password".<br/>Table field type characteristics (type, precision, scale, length): Varchar, 0, 0, 200.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Password
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Password, true); }
			set	{ SetValue((int)UserFieldIndex.Password, value); }
		}

		/// <summary>The PersonId property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "user"."person_id".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 PersonId
		{
			get { return (System.Int32)GetValue((int)UserFieldIndex.PersonId, true); }
			set	{ SetValue((int)UserFieldIndex.PersonId, value); }
		}

		/// <summary>The ResetToken property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "user"."reset_token".<br/>Table field type characteristics (type, precision, scale, length): Varchar, 0, 0, 256.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ResetToken
		{
			get { return (System.String)GetValue((int)UserFieldIndex.ResetToken, true); }
			set	{ SetValue((int)UserFieldIndex.ResetToken, value); }
		}

		/// <summary>The ResetTokenExpiration property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "user"."reset_token_expiration".<br/>Table field type characteristics (type, precision, scale, length): Timestamp, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ResetTokenExpiration
		{
			get { return (Nullable<System.DateTime>)GetValue((int)UserFieldIndex.ResetTokenExpiration, false); }
			set	{ SetValue((int)UserFieldIndex.ResetTokenExpiration, value); }
		}

		/// <summary>The RoleId property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "user"."role_id".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 RoleId
		{
			get { return (System.Int32)GetValue((int)UserFieldIndex.RoleId, true); }
			set	{ SetValue((int)UserFieldIndex.RoleId, value); }
		}

		/// <summary>The TourOperatorId property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "user"."tour_operator_id".<br/>Table field type characteristics (type, precision, scale, length): Integer, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> TourOperatorId
		{
			get { return (Nullable<System.Int32>)GetValue((int)UserFieldIndex.TourOperatorId, false); }
			set	{ SetValue((int)UserFieldIndex.TourOperatorId, value); }
		}

		/// <summary>Gets / sets related entity of type 'AirlineEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual AirlineEntity Airline
		{
			get { return _airline; }
			set { SetSingleRelatedEntityNavigator(value, "Airline"); }
		}

		/// <summary>Gets / sets related entity of type 'PersonEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual PersonEntity Person
		{
			get { return _person; }
			set { SetSingleRelatedEntityNavigator(value, "Person"); }
		}

		/// <summary>Gets / sets related entity of type 'RoleEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual RoleEntity Role
		{
			get { return _role; }
			set { SetSingleRelatedEntityNavigator(value, "Role"); }
		}

		/// <summary>Gets / sets related entity of type 'TourOperatorEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual TourOperatorEntity TourOperator
		{
			get { return _tourOperator; }
			set { SetSingleRelatedEntityNavigator(value, "TourOperator"); }
		}

		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END

	}
}

namespace Charcillaries.Data
{
	public enum UserFieldIndex
	{
		///<summary>AirlineId. </summary>
		AirlineId,
		///<summary>Id. </summary>
		Id,
		///<summary>ObjectStatus. </summary>
		ObjectStatus,
		///<summary>Password. </summary>
		Password,
		///<summary>PersonId. </summary>
		PersonId,
		///<summary>ResetToken. </summary>
		ResetToken,
		///<summary>ResetTokenExpiration. </summary>
		ResetTokenExpiration,
		///<summary>RoleId. </summary>
		RoleId,
		///<summary>TourOperatorId. </summary>
		TourOperatorId,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace Charcillaries.Data.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: User. </summary>
	public partial class UserRelations: RelationFactory
	{

		/// <summary>Returns a new IEntityRelation object, between UserEntity and AirlineEntity over the m:1 relation they have, using the relation between the fields: User.AirlineId - Airline.Id</summary>
		public virtual IEntityRelation AirlineEntityUsingAirlineId
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "Airline", false, new[] { AirlineFields.Id, UserFields.AirlineId }); }
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and PersonEntity over the m:1 relation they have, using the relation between the fields: User.PersonId - Person.Id</summary>
		public virtual IEntityRelation PersonEntityUsingPersonId
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "Person", false, new[] { PersonFields.Id, UserFields.PersonId }); }
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and RoleEntity over the m:1 relation they have, using the relation between the fields: User.RoleId - Role.Id</summary>
		public virtual IEntityRelation RoleEntityUsingRoleId
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "Role", false, new[] { RoleFields.Id, UserFields.RoleId }); }
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and TourOperatorEntity over the m:1 relation they have, using the relation between the fields: User.TourOperatorId - TourOperator.Id</summary>
		public virtual IEntityRelation TourOperatorEntityUsingTourOperatorId
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "TourOperator", false, new[] { TourOperatorFields.Id, UserFields.TourOperatorId }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticUserRelations
	{
		internal static readonly IEntityRelation AirlineEntityUsingAirlineIdStatic = new UserRelations().AirlineEntityUsingAirlineId;
		internal static readonly IEntityRelation PersonEntityUsingPersonIdStatic = new UserRelations().PersonEntityUsingPersonId;
		internal static readonly IEntityRelation RoleEntityUsingRoleIdStatic = new UserRelations().RoleEntityUsingRoleId;
		internal static readonly IEntityRelation TourOperatorEntityUsingTourOperatorIdStatic = new UserRelations().TourOperatorEntityUsingTourOperatorId;

		/// <summary>CTor</summary>
		static StaticUserRelations() { }
	}
}
