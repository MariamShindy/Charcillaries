﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.10.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using Charcillaries.Data.EntityClasses;
using Charcillaries.Data.HelperClasses;
using Charcillaries.Data.RelationClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Charcillaries.Data.FactoryClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>general base class for the generated factories</summary>
	[Serializable]
	public partial class EntityFactoryBase2<TEntity> : EntityFactoryCore2
		where TEntity : EntityBase2, IEntity2
	{
		private readonly bool _isInHierarchy;

		/// <summary>CTor</summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <param name="isInHierarchy">If true, the entity of this factory is in an inheritance hierarchy, false otherwise</param>
		public EntityFactoryBase2(string entityName, Charcillaries.Data.EntityType typeOfEntity, bool isInHierarchy) : base(entityName, (int)typeOfEntity)
		{
			_isInHierarchy = isInHierarchy;
		}
		
		/// <inheritdoc/>
		public override IEntityFields2 CreateFields() { return ModelInfoProviderSingleton.GetInstance().GetEntityFields(this.ForEntityName); }
		
		/// <inheritdoc/>
		public override IEntity2 CreateEntityFromEntityTypeValue(int entityTypeValue) {	return GeneralEntityFactory.Create((Charcillaries.Data.EntityType)entityTypeValue); }

		/// <inheritdoc/>
		public override IRelationCollection CreateHierarchyRelations(string objectAlias) { return ModelInfoProviderSingleton.GetInstance().GetHierarchyRelations(this.ForEntityName, objectAlias); }

		/// <inheritdoc/>
		public override IEntityFactory2 GetEntityFactory(object[] fieldValues, Dictionary<string, int> entityFieldStartIndexesPerEntity) 
		{
			return (IEntityFactory2)ModelInfoProviderSingleton.GetInstance().GetEntityFactory(this.ForEntityName, fieldValues, entityFieldStartIndexesPerEntity) ?? this;
		}
		
		/// <inheritdoc/>
		public override IPredicateExpression GetEntityTypeFilter(bool negate, string objectAlias) {	return ModelInfoProviderSingleton.GetInstance().GetEntityTypeFilter(this.ForEntityName, objectAlias, negate);	}
						
		/// <inheritdoc/>
		public override IEntityCollection2 CreateEntityCollection()	{ return new EntityCollection<TEntity>(this); }
		
		/// <inheritdoc/>
		public override IEntityFields2 CreateHierarchyFields() 
		{
			return _isInHierarchy ? new EntityFields2(ModelInfoProviderSingleton.GetInstance().GetHierarchyFields(this.ForEntityName), ModelInfoProviderSingleton.GetInstance(), null) : base.CreateHierarchyFields();
		}
		
		/// <inheritdoc/>
		protected override Type ForEntityType { get { return typeof(TEntity); } }
	}

	/// <summary>Factory to create new, empty AirlineEntity objects.</summary>
	[Serializable]
	public partial class AirlineEntityFactory : EntityFactoryBase2<AirlineEntity> 
	{
		/// <summary>CTor</summary>
		public AirlineEntityFactory() : base("AirlineEntity", Charcillaries.Data.EntityType.AirlineEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new AirlineEntity(fields); }
	}

	/// <summary>Factory to create new, empty AmenityEntity objects.</summary>
	[Serializable]
	public partial class AmenityEntityFactory : EntityFactoryBase2<AmenityEntity> 
	{
		/// <summary>CTor</summary>
		public AmenityEntityFactory() : base("AmenityEntity", Charcillaries.Data.EntityType.AmenityEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new AmenityEntity(fields); }
	}

	/// <summary>Factory to create new, empty AmenityFeedbackEntity objects.</summary>
	[Serializable]
	public partial class AmenityFeedbackEntityFactory : EntityFactoryBase2<AmenityFeedbackEntity> 
	{
		/// <summary>CTor</summary>
		public AmenityFeedbackEntityFactory() : base("AmenityFeedbackEntity", Charcillaries.Data.EntityType.AmenityFeedbackEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new AmenityFeedbackEntity(fields); }
	}

	/// <summary>Factory to create new, empty FlightEntity objects.</summary>
	[Serializable]
	public partial class FlightEntityFactory : EntityFactoryBase2<FlightEntity> 
	{
		/// <summary>CTor</summary>
		public FlightEntityFactory() : base("FlightEntity", Charcillaries.Data.EntityType.FlightEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new FlightEntity(fields); }
	}

	/// <summary>Factory to create new, empty FlightRouteEntity objects.</summary>
	[Serializable]
	public partial class FlightRouteEntityFactory : EntityFactoryBase2<FlightRouteEntity> 
	{
		/// <summary>CTor</summary>
		public FlightRouteEntityFactory() : base("FlightRouteEntity", Charcillaries.Data.EntityType.FlightRouteEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new FlightRouteEntity(fields); }
	}

	/// <summary>Factory to create new, empty PassengerEntity objects.</summary>
	[Serializable]
	public partial class PassengerEntityFactory : EntityFactoryBase2<PassengerEntity> 
	{
		/// <summary>CTor</summary>
		public PassengerEntityFactory() : base("PassengerEntity", Charcillaries.Data.EntityType.PassengerEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new PassengerEntity(fields); }
	}

	/// <summary>Factory to create new, empty PassengerAmenitySelectionEntity objects.</summary>
	[Serializable]
	public partial class PassengerAmenitySelectionEntityFactory : EntityFactoryBase2<PassengerAmenitySelectionEntity> 
	{
		/// <summary>CTor</summary>
		public PassengerAmenitySelectionEntityFactory() : base("PassengerAmenitySelectionEntity", Charcillaries.Data.EntityType.PassengerAmenitySelectionEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new PassengerAmenitySelectionEntity(fields); }
	}

	/// <summary>Factory to create new, empty PersonEntity objects.</summary>
	[Serializable]
	public partial class PersonEntityFactory : EntityFactoryBase2<PersonEntity> 
	{
		/// <summary>CTor</summary>
		public PersonEntityFactory() : base("PersonEntity", Charcillaries.Data.EntityType.PersonEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new PersonEntity(fields); }
	}

	/// <summary>Factory to create new, empty RoleEntity objects.</summary>
	[Serializable]
	public partial class RoleEntityFactory : EntityFactoryBase2<RoleEntity> 
	{
		/// <summary>CTor</summary>
		public RoleEntityFactory() : base("RoleEntity", Charcillaries.Data.EntityType.RoleEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new RoleEntity(fields); }
	}

	/// <summary>Factory to create new, empty RouteAmenityEntity objects.</summary>
	[Serializable]
	public partial class RouteAmenityEntityFactory : EntityFactoryBase2<RouteAmenityEntity> 
	{
		/// <summary>CTor</summary>
		public RouteAmenityEntityFactory() : base("RouteAmenityEntity", Charcillaries.Data.EntityType.RouteAmenityEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new RouteAmenityEntity(fields); }
	}

	/// <summary>Factory to create new, empty RouteFlightFeedbackEntity objects.</summary>
	[Serializable]
	public partial class RouteFlightFeedbackEntityFactory : EntityFactoryBase2<RouteFlightFeedbackEntity> 
	{
		/// <summary>CTor</summary>
		public RouteFlightFeedbackEntityFactory() : base("RouteFlightFeedbackEntity", Charcillaries.Data.EntityType.RouteFlightFeedbackEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new RouteFlightFeedbackEntity(fields); }
	}

	/// <summary>Factory to create new, empty TourOperatorEntity objects.</summary>
	[Serializable]
	public partial class TourOperatorEntityFactory : EntityFactoryBase2<TourOperatorEntity> 
	{
		/// <summary>CTor</summary>
		public TourOperatorEntityFactory() : base("TourOperatorEntity", Charcillaries.Data.EntityType.TourOperatorEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new TourOperatorEntity(fields); }
	}

	/// <summary>Factory to create new, empty TourOperatorAirlineEntity objects.</summary>
	[Serializable]
	public partial class TourOperatorAirlineEntityFactory : EntityFactoryBase2<TourOperatorAirlineEntity> 
	{
		/// <summary>CTor</summary>
		public TourOperatorAirlineEntityFactory() : base("TourOperatorAirlineEntity", Charcillaries.Data.EntityType.TourOperatorAirlineEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new TourOperatorAirlineEntity(fields); }
	}

	/// <summary>Factory to create new, empty UserEntity objects.</summary>
	[Serializable]
	public partial class UserEntityFactory : EntityFactoryBase2<UserEntity> 
	{
		/// <summary>CTor</summary>
		public UserEntityFactory() : base("UserEntity", Charcillaries.Data.EntityType.UserEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new UserEntity(fields); }
	}

	/// <summary>Factory to create new, empty Entity objects based on the entity type specified. Uses  entity specific factory objects</summary>
	[Serializable]
	public partial class GeneralEntityFactory
	{
		/// <summary>Creates a new, empty Entity object of the type specified</summary>
		/// <param name="entityTypeToCreate">The entity type to create.</param>
		/// <returns>A new, empty Entity object.</returns>
		public static IEntity2 Create(Charcillaries.Data.EntityType entityTypeToCreate)
		{
			var factoryToUse = EntityFactoryFactory.GetFactory(entityTypeToCreate);
			IEntity2 toReturn = null;
			if(factoryToUse != null)
			{
				toReturn = factoryToUse.Create();
			}
			return toReturn;
		}		
	}
		
	/// <summary>Class which is used to obtain the entity factory based on the .NET type of the entity. </summary>
	[Serializable]
	public static class EntityFactoryFactory
	{
		private static Dictionary<Type, IEntityFactory2> _factoryPerType = new Dictionary<Type, IEntityFactory2>();

		/// <summary>Initializes the <see cref="EntityFactoryFactory"/> class.</summary>
		static EntityFactoryFactory()
		{
			foreach(int entityTypeValue in Enum.GetValues(typeof(Charcillaries.Data.EntityType)))
			{
				var factory = GetFactory((Charcillaries.Data.EntityType)entityTypeValue);
				_factoryPerType.Add(factory.ForEntityType ?? factory.Create().GetType(), factory);
			}
		}

		/// <summary>Gets the factory of the entity with the .NET type specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(Type typeOfEntity) { return _factoryPerType.GetValue(typeOfEntity); }

		/// <summary>Gets the factory of the entity with the Charcillaries.Data.EntityType specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(Charcillaries.Data.EntityType typeOfEntity)
		{
			switch(typeOfEntity)
			{
				case Charcillaries.Data.EntityType.AirlineEntity:
					return new AirlineEntityFactory();
				case Charcillaries.Data.EntityType.AmenityEntity:
					return new AmenityEntityFactory();
				case Charcillaries.Data.EntityType.AmenityFeedbackEntity:
					return new AmenityFeedbackEntityFactory();
				case Charcillaries.Data.EntityType.FlightEntity:
					return new FlightEntityFactory();
				case Charcillaries.Data.EntityType.FlightRouteEntity:
					return new FlightRouteEntityFactory();
				case Charcillaries.Data.EntityType.PassengerEntity:
					return new PassengerEntityFactory();
				case Charcillaries.Data.EntityType.PassengerAmenitySelectionEntity:
					return new PassengerAmenitySelectionEntityFactory();
				case Charcillaries.Data.EntityType.PersonEntity:
					return new PersonEntityFactory();
				case Charcillaries.Data.EntityType.RoleEntity:
					return new RoleEntityFactory();
				case Charcillaries.Data.EntityType.RouteAmenityEntity:
					return new RouteAmenityEntityFactory();
				case Charcillaries.Data.EntityType.RouteFlightFeedbackEntity:
					return new RouteFlightFeedbackEntityFactory();
				case Charcillaries.Data.EntityType.TourOperatorEntity:
					return new TourOperatorEntityFactory();
				case Charcillaries.Data.EntityType.TourOperatorAirlineEntity:
					return new TourOperatorAirlineEntityFactory();
				case Charcillaries.Data.EntityType.UserEntity:
					return new UserEntityFactory();
				default:
					return null;
			}
		}
	}
		
	/// <summary>Element creator for creating project elements from somewhere else, like inside Linq providers.</summary>
	public class ElementCreator : ElementCreatorBase, IElementCreator2
	{
		/// <summary>Gets the factory of the Entity type with the Charcillaries.Data.EntityType value passed in</summary>
		/// <param name="entityTypeValue">The entity type value.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory2 GetFactory(int entityTypeValue) { return (IEntityFactory2)this.GetFactoryImpl(entityTypeValue); }
		
		/// <summary>Gets the factory of the Entity type with the .NET type passed in</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory2 GetFactory(Type typeOfEntity) { return (IEntityFactory2)this.GetFactoryImpl(typeOfEntity); }

		/// <summary>Creates a new resultset fields object with the number of field slots reserved as specified</summary>
		/// <param name="numberOfFields">The number of fields.</param>
		/// <returns>ready to use resultsetfields object</returns>
		public IEntityFields2 CreateResultsetFields(int numberOfFields) { return new ResultsetFields(numberOfFields); }
		
		/// <inheritdoc/>
		public override IInheritanceInfoProvider ObtainInheritanceInfoProviderInstance() { return ModelInfoProviderSingleton.GetInstance(); }

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand) { return new DynamicRelation(leftOperand); }

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, DerivedTableDefinition rightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, rightOperand, onClause);
		}

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(IEntityFieldCore leftOperand, JoinHint joinType, DerivedTableDefinition rightOperand, string aliasLeftOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, rightOperand, aliasLeftOperand, onClause);
		}

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, string rightOperandEntityName, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, (Charcillaries.Data.EntityType)Enum.Parse(typeof(Charcillaries.Data.EntityType), rightOperandEntityName, false), aliasRightOperand, onClause);
		}

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(string leftOperandEntityName, JoinHint joinType, string rightOperandEntityName, string aliasLeftOperand, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation((Charcillaries.Data.EntityType)Enum.Parse(typeof(Charcillaries.Data.EntityType), leftOperandEntityName, false), joinType, (Charcillaries.Data.EntityType)Enum.Parse(typeof(Charcillaries.Data.EntityType), rightOperandEntityName, false), aliasLeftOperand, aliasRightOperand, onClause);
		}
		
		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(IEntityFieldCore leftOperand, JoinHint joinType, string rightOperandEntityName, string aliasLeftOperand, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, (Charcillaries.Data.EntityType)Enum.Parse(typeof(Charcillaries.Data.EntityType), rightOperandEntityName, false), aliasLeftOperand, aliasRightOperand, onClause);
		}
		
		/// <inheritdoc/>
		protected override IEntityFactoryCore GetFactoryImpl(int entityTypeValue) { return EntityFactoryFactory.GetFactory((Charcillaries.Data.EntityType)entityTypeValue); }

		/// <inheritdoc/>
		protected override IEntityFactoryCore GetFactoryImpl(Type typeOfEntity) { return EntityFactoryFactory.GetFactory(typeOfEntity);	}

	}
}
