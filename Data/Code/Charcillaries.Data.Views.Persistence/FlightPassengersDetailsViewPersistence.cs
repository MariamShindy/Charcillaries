﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.10.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SD.LLBLGen.Pro.QuerySpec;
using Charcillaries.Data.HelperClasses;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.LinqSupportClasses.DTOProjectionHelpers;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Charcillaries.Data.Views.Persistence
{
	///<summary>class to define custom where/orderby clauses to be used in the linq / query spec query projection</summary>
	public partial class FlightPassengersDetailsViewProjectionParams
	{
		///<summary>class to define custom where/orderby clauses to be used in the linq / query spec query projection</summary>
		public partial class F_FlightRouteProjectionParams_Clauses
		{
			///<summary>class to define custom where/orderby clauses to be used in the linq / query spec query projection</summary>
			public partial class F_F_RouteAmenitiesProjectionParams_Clauses
			{
				/// <summary>QuerySpec specific. Appends a new OrderBy clause for the RouteAmenities embedded set.</summary>
				/// <param name="clauseToAdd">the clause to add</param>
				public void AppendQSOrderBy(ISortClause clauseToAdd) => this.QSOrderByClauses.Add(clauseToAdd);
				/// <summary>Linq specific. Appends a new OrderBy clause for the RouteAmenities embedded set.</summary>
				/// <param name="orderByClause">The order by clause to use</param>
				/// <param name="descending">if true, the order by will be descending, otherwise ascending (default)</param>
				/// <typeparam name="TField">The type of the field to sort by</typeparam>
				public void AppendLinqOrderBy<TField>(System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.RouteAmenityEntity, TField>> orderByClause, bool descending = false) => this.LinqOrderByClauses.Add(new SD.LLBLGen.Pro.ORMSupportClasses.ValuePair<System.Linq.Expressions.Expression, bool>((System.Linq.Expressions.Expression)orderByClause, descending));
				internal List<SD.LLBLGen.Pro.ORMSupportClasses.ValuePair<System.Linq.Expressions.Expression, bool>> LinqOrderByClauses { get; } = new List<SD.LLBLGen.Pro.ORMSupportClasses.ValuePair<System.Linq.Expressions.Expression, bool>>();
				internal List<ISortClause> QSOrderByClauses { get; set; } = new List<ISortClause>();
				/// <summary>Linq specific. Custom where clause to be used for when the RouteAmenities embedded set is fetched</summary>
				public System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.RouteAmenityEntity, bool>> LinqWhereClause { get; set; }
				/// <summary>QuerySpec specific. Custom where clause to be used for when the RouteAmenities embedded set is fetched</summary>
				public IPredicate QSWhereClause { get; set; }
			}

			/// <summary>Projection parameters to configure where / orderby clauses for the nested member 'RouteAmenities'</summary>
			public F_F_RouteAmenitiesProjectionParams_Clauses RouteAmenitiesProjectionParams { get; } = new F_F_RouteAmenitiesProjectionParams_Clauses();
		}

		///<summary>class to define custom where/orderby clauses to be used in the linq / query spec query projection</summary>
		public partial class F_PassengersProjectionParams_Clauses
		{
			///<summary>class to define custom where/orderby clauses to be used in the linq / query spec query projection</summary>
			public partial class F_P_PassengerAmenitySelectionsProjectionParams_Clauses
			{
				/// <summary>QuerySpec specific. Appends a new OrderBy clause for the PassengerAmenitySelections embedded set.</summary>
				/// <param name="clauseToAdd">the clause to add</param>
				public void AppendQSOrderBy(ISortClause clauseToAdd) => this.QSOrderByClauses.Add(clauseToAdd);
				/// <summary>Linq specific. Appends a new OrderBy clause for the PassengerAmenitySelections embedded set.</summary>
				/// <param name="orderByClause">The order by clause to use</param>
				/// <param name="descending">if true, the order by will be descending, otherwise ascending (default)</param>
				/// <typeparam name="TField">The type of the field to sort by</typeparam>
				public void AppendLinqOrderBy<TField>(System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.PassengerAmenitySelectionEntity, TField>> orderByClause, bool descending = false) => this.LinqOrderByClauses.Add(new SD.LLBLGen.Pro.ORMSupportClasses.ValuePair<System.Linq.Expressions.Expression, bool>((System.Linq.Expressions.Expression)orderByClause, descending));
				internal List<SD.LLBLGen.Pro.ORMSupportClasses.ValuePair<System.Linq.Expressions.Expression, bool>> LinqOrderByClauses { get; } = new List<SD.LLBLGen.Pro.ORMSupportClasses.ValuePair<System.Linq.Expressions.Expression, bool>>();
				internal List<ISortClause> QSOrderByClauses { get; set; } = new List<ISortClause>();
				/// <summary>Linq specific. Custom where clause to be used for when the PassengerAmenitySelections embedded set is fetched</summary>
				public System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.PassengerAmenitySelectionEntity, bool>> LinqWhereClause { get; set; }
				/// <summary>QuerySpec specific. Custom where clause to be used for when the PassengerAmenitySelections embedded set is fetched</summary>
				public IPredicate QSWhereClause { get; set; }
			}

			/// <summary>QuerySpec specific. Appends a new OrderBy clause for the Passengers embedded set.</summary>
			/// <param name="clauseToAdd">the clause to add</param>
			public void AppendQSOrderBy(ISortClause clauseToAdd) => this.QSOrderByClauses.Add(clauseToAdd);
			/// <summary>Linq specific. Appends a new OrderBy clause for the Passengers embedded set.</summary>
			/// <param name="orderByClause">The order by clause to use</param>
			/// <param name="descending">if true, the order by will be descending, otherwise ascending (default)</param>
			/// <typeparam name="TField">The type of the field to sort by</typeparam>
			public void AppendLinqOrderBy<TField>(System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.PassengerEntity, TField>> orderByClause, bool descending = false) => this.LinqOrderByClauses.Add(new SD.LLBLGen.Pro.ORMSupportClasses.ValuePair<System.Linq.Expressions.Expression, bool>((System.Linq.Expressions.Expression)orderByClause, descending));
			internal List<SD.LLBLGen.Pro.ORMSupportClasses.ValuePair<System.Linq.Expressions.Expression, bool>> LinqOrderByClauses { get; } = new List<SD.LLBLGen.Pro.ORMSupportClasses.ValuePair<System.Linq.Expressions.Expression, bool>>();
			internal List<ISortClause> QSOrderByClauses { get; set; } = new List<ISortClause>();
			/// <summary>Linq specific. Custom where clause to be used for when the Passengers embedded set is fetched</summary>
			public System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.PassengerEntity, bool>> LinqWhereClause { get; set; }
			/// <summary>QuerySpec specific. Custom where clause to be used for when the Passengers embedded set is fetched</summary>
			public IPredicate QSWhereClause { get; set; }
			/// <summary>Projection parameters to configure where / orderby clauses for the nested member 'PassengerAmenitySelections'</summary>
			public F_P_PassengerAmenitySelectionsProjectionParams_Clauses PassengerAmenitySelectionsProjectionParams { get; } = new F_P_PassengerAmenitySelectionsProjectionParams_Clauses();
		}

		/// <summary>Projection parameters to configure where / orderby clauses for the nested member 'FlightRoute'</summary>
		public F_FlightRouteProjectionParams_Clauses FlightRouteProjectionParams { get; } = new F_FlightRouteProjectionParams_Clauses();
		/// <summary>Projection parameters to configure where / orderby clauses for the nested member 'Passengers'</summary>
		public F_PassengersProjectionParams_Clauses PassengersProjectionParams { get; } = new F_PassengersProjectionParams_Clauses();
	}

	/// <summary>Static class for (extension) methods for fetching and projecting instances of Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView from the entity model.</summary>
	public static partial class FlightPassengersDetailsViewPersistence
	{
		private static readonly System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.FlightEntity, Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView>> _projectorExpression = CreateProjectionFunc();
		private static readonly Func<Charcillaries.Data.EntityClasses.FlightEntity, Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView> _compiledProjector = CreateProjectionFunc().Compile();
		/// <summary>Linq specific partial method for obtaining projection adjustments for the projection method <see cref="ProjectToFlightPassengersDetailsView(System.Linq.IQueryable{Charcillaries.Data.EntityClasses.FlightEntity})"/></summary>
		/// <param name="projectionAdjustments">Set this argument in an implementation of this partial method to a projection lambda similar to the generated projection in <see cref="CreateProjectionFunc"/></param>
		/// <remarks>Linq specific</remarks>
		static partial void GetAdjustmentsForProjectToFlightPassengersDetailsView(ref System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.FlightEntity, Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView>> projectionAdjustments);
		/// <summary>QuerySpec specific partial method for obtaining projection adjustments for the projection method <see cref="ProjectToFlightPassengersDetailsView(EntityQuery{Charcillaries.Data.EntityClasses.FlightEntity}, Charcillaries.Data.FactoryClasses.QueryFactory)"/></summary>
		/// <param name="projectionAdjustments">Set this argument in an implementation of this partial method to a projection lambda similar to the generated projection in <see cref="ProjectToFlightPassengersDetailsView(EntityQuery{Charcillaries.Data.EntityClasses.FlightEntity}, Charcillaries.Data.FactoryClasses.QueryFactory)"/></param>
		/// <remarks>QuerySpec specific</remarks>
		static partial void GetAdjustmentsForProjectToFlightPassengersDetailsViewQs(ref System.Linq.Expressions.Expression<Func<Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView>> projectionAdjustments);
	
		/// <summary>Empty static ctor for triggering initialization of static members in a thread-safe manner</summary>
		static FlightPassengersDetailsViewPersistence() { }
	
		/// <summary>Extension method which produces a projection to Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView which instances are projected from the results of the specified baseQuery, which returns Charcillaries.Data.EntityClasses.FlightEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <returns>IQueryable to retrieve Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView instances</returns>
		public static IQueryable<Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView> ProjectToFlightPassengersDetailsView(this IQueryable<Charcillaries.Data.EntityClasses.FlightEntity> baseQuery) => ProjectToFlightPassengersDetailsView(baseQuery, null);
		/// <summary>Extension method which produces a projection to Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView which instances are projected from the results of the specified baseQuery, which returns Charcillaries.Data.EntityClasses.FlightEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <param name="projectionParams">The optional projection parameters with optional where/orderby clauses for nested sets in the projection</param>
		/// <returns>IQueryable to retrieve Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView instances</returns>
		public static IQueryable<Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView> ProjectToFlightPassengersDetailsView(this IQueryable<Charcillaries.Data.EntityClasses.FlightEntity> baseQuery, FlightPassengersDetailsViewProjectionParams projectionParams)
		{
			if(projectionParams == null)
			{
				return baseQuery.Select(_projectorExpression);
			}
			return baseQuery.Select(CreateProjectionFunc(projectionParams));
		}

		/// <summary>Extension method which produces a projection to Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView which instances are projected from the results of the specified baseQuery using QuerySpec, which returns Charcillaries.Data.EntityClasses.FlightEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <param name="qf">The query factory used to create baseQuery.</param>
		/// <returns>DynamicQuery to retrieve Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView instances</returns>
		public static DynamicQuery<Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView> ProjectToFlightPassengersDetailsView(this EntityQuery<Charcillaries.Data.EntityClasses.FlightEntity> baseQuery, Charcillaries.Data.FactoryClasses.QueryFactory qf) => ProjectToFlightPassengersDetailsView(baseQuery, qf, null);
		/// <summary>Extension method which produces a projection to Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView which instances are projected from the results of the specified baseQuery using QuerySpec, which returns Charcillaries.Data.EntityClasses.FlightEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <param name="qf">The query factory used to create baseQuery.</param>
		/// <param name="projectionParams">The optional projection parameters with optional where/orderby clauses for nested sets in the projection</param>
		/// <returns>DynamicQuery to retrieve Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView instances</returns>
		public static DynamicQuery<Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView> ProjectToFlightPassengersDetailsView(this EntityQuery<Charcillaries.Data.EntityClasses.FlightEntity> baseQuery, Charcillaries.Data.FactoryClasses.QueryFactory qf, FlightPassengersDetailsViewProjectionParams projectionParams=null)
		{
			System.Linq.Expressions.Expression<Func<Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView>> projectionAdjustments = null;
			GetAdjustmentsForProjectToFlightPassengersDetailsViewQs(ref projectionAdjustments);
			return qf.Create()
				.From(baseQuery.Select(Projection.Full).As("__BQ")
					.InnerJoin(qf.FlightRoute.As("__L0_0")).On(FlightFields.FlightRouteId.Source("__BQ").Equal(FlightRouteFields.Id.Source("__L0_0")))
					.InnerJoin(qf.TourOperator.As("__L0_1")).On(FlightFields.TourOperatorId.Source("__BQ").Equal(TourOperatorFields.Id.Source("__L0_1"))))
				.Select(LinqUtils.MergeProjectionAdjustmentsIntoProjection(() => new Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView()
				{
					ArrivalDate = FlightFields.ArrivalDate.Source("__BQ").ToValue<System.DateTime>(),
					DepartureDate = FlightFields.DepartureDate.Source("__BQ").ToValue<System.DateTime>(),
					FlightNumber = FlightFields.FlightNumber.Source("__BQ").ToValue<System.String>(),
					FlightRoute = new Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.FlightRoute()
						{
							ArrivalAirport = FlightRouteFields.ArrivalAirport.Source("__L0_0").ToValue<System.String>(),
							DepartureAirport = FlightRouteFields.DepartureAirport.Source("__L0_0").ToValue<System.String>(),
							RouteAmenities = (List<Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.FlightRouteTypes.RouteAmenity>)qf.FlightRoute.TargetAs("__L1_3")
								.CorrelatedOver(FlightFields.FlightRouteId.Source("__L0_0").Equal(FlightRouteFields.Id.Source("__L1_0")))
								.From(QueryTarget
									.LeftJoin(qf.RouteAmenity.As("__L1_1")).On(RouteAmenityFields.FlightRouteId.Source("__L1_1").Equal(FlightRouteFields.Id.Source("__L1_0")))
									.InnerJoin(qf.Amenity.As("__L1_2")).On(RouteAmenityFields.AmenityId.Source("__L1_1").Equal(AmenityFields.Id.Source("__L1_2")))
									.LeftJoin(qf.RouteAmenity.As("__L1_3")).On(RouteAmenityFields.FlightRouteId.Source("__L1_3").Equal(FlightRouteFields.Id.Source("__L1_3"))))
								.Where(projectionParams==null ? null : GeneralUtils.SetAliasOnPredicate(projectionParams.FlightRouteProjectionParams.RouteAmenitiesProjectionParams.QSWhereClause, "__L1_3"))
								.OrderBy(projectionParams==null ? null : GeneralUtils.SetAliasOnSortClauses(projectionParams.FlightRouteProjectionParams.RouteAmenitiesProjectionParams.QSOrderByClauses, "__L1_3"))
								.Select(() => new Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.FlightRouteTypes.RouteAmenity()
								{
									Amenity = new Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.FlightRouteTypes.RouteAmenityTypes.Amenity()
										{
											Id = AmenityFields.Id.Source("__L1_2").ToValue<System.Int32>(),
											Name = AmenityFields.Name.Source("__L1_2").ToValue<System.String>(),
										},
									Price = RouteAmenityFields.Price.Source("__L1_3").ToValue<System.Single>(),
								}).ToResultset(),
						},
					Passengers = (List<Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.Passenger>)qf.Passenger.TargetAs("__L1_0")
						.CorrelatedOver(FlightFields.Id.Source("__BQ").Equal(PassengerFields.FlightId.Source("__L1_0")))
						.From(QueryTarget
							.InnerJoin(qf.Person.As("__L1_1")).On(PassengerFields.PersonId.Source("__L1_0").Equal(PersonFields.Id.Source("__L1_1"))))
						.Where(projectionParams==null ? null : GeneralUtils.SetAliasOnPredicate(projectionParams.PassengersProjectionParams.QSWhereClause, "__L1_0"))
						.OrderBy(projectionParams==null ? null : GeneralUtils.SetAliasOnSortClauses(projectionParams.PassengersProjectionParams.QSOrderByClauses, "__L1_0"))
						.Select(() => new Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.Passenger()
						{
							Id = PassengerFields.Id.Source("__L1_0").ToValue<System.Int32>(),
							PassengerAmenitySelections = (List<Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.PassengerTypes.PassengerAmenitySelection>)qf.Flight.TargetAs("__L2_0")
								.CorrelatedOver(PassengerFields.Id.Source("__L1_0").Equal(PassengerAmenitySelectionFields.PassengerId.Source("__L2_0")))
								.From(QueryTarget
									.LeftJoin(qf.Passenger.As("__L2_1")).On(PassengerFields.FlightId.Source("__L2_1").Equal(FlightFields.Id.Source("__L2_0")))
									.LeftJoin(qf.PassengerAmenitySelection.As("__L2_2")).On(PassengerAmenitySelectionFields.PassengerId.Source("__L2_2").Equal(PassengerFields.Id.Source("__L2_1")))
									.InnerJoin(qf.RouteAmenity.As("__L2_3")).On(PassengerAmenitySelectionFields.RouteAmenityId.Source("__L2_2").Equal(RouteAmenityFields.Id.Source("__L2_3")))
									.InnerJoin(qf.Amenity.As("__L2_4")).On(RouteAmenityFields.AmenityId.Source("__L2_3").Equal(AmenityFields.Id.Source("__L2_4"))))
								.Where(projectionParams==null ? null : GeneralUtils.SetAliasOnPredicate(projectionParams.PassengersProjectionParams.PassengerAmenitySelectionsProjectionParams.QSWhereClause, "__L2_0"))
								.OrderBy(projectionParams==null ? null : GeneralUtils.SetAliasOnSortClauses(projectionParams.PassengersProjectionParams.PassengerAmenitySelectionsProjectionParams.QSOrderByClauses, "__L2_0"))
								.Select(() => new Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.PassengerTypes.PassengerAmenitySelection()
								{
									Customization = PassengerAmenitySelectionFields.Customization.Source("__L2_0").ToValue<System.String>(),
									RouteAmenity = new Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.PassengerTypes.PassengerAmenitySelectionTypes.RouteAmenity()
										{
											Amenity = new Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.PassengerTypes.PassengerAmenitySelectionTypes.RouteAmenityTypes.Amenity()
												{
													Name = AmenityFields.Name.Source("__L2_4").ToValue<System.String>(),
												},
											AmenityId = RouteAmenityFields.AmenityId.Source("__L2_3").ToValue<System.Int32>(),
										},
								}).ToResultset(),
							PaymentConfirmation = PassengerFields.PaymentConfirmation.Source("__L1_0").ToValue<System.String>(),
							Person = new Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.PassengerTypes.Person()
								{
									Email = PersonFields.Email.Source("__L1_1").ToValue<System.String>(),
									FirstName = PersonFields.FirstName.Source("__L1_1").ToValue<System.String>(),
									LastName = PersonFields.LastName.Source("__L1_1").ToValue<System.String>(),
									PhoneNumber = PersonFields.PhoneNumber.Source("__L1_1").ToValue<System.String>(),
								},
						}).ToResultset(),
					TourOperator = new Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.TourOperator()
						{
							ContactInfo = TourOperatorFields.ContactInfo.Source("__L0_1").ToValue<System.String>(),
							Name = TourOperatorFields.Name.Source("__L0_1").ToValue<System.String>(),
						},
	// __LLBLGENPRO_USER_CODE_REGION_START ProjectionRegionQS_FlightPassengersDetailsView 
	// __LLBLGENPRO_USER_CODE_REGION_END 
				}, projectionAdjustments, false));
		}

		/// <summary>Extension method which produces a projection to Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView which instances are projected from the Charcillaries.Data.EntityClasses.FlightEntity entity instance specified, the root entity of the derived element returned by this method.</summary>
		/// <param name="entity">The entity to project from.</param>
		/// <returns>Charcillaries.Data.EntityClasses.FlightEntity instance created from the specified entity instance</returns>
		public static Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView ProjectToFlightPassengersDetailsView(this Charcillaries.Data.EntityClasses.FlightEntity entity)
		{
			return _compiledProjector(entity);
		}

		private static System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.FlightEntity, Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView>> CreateProjectionFunc(FlightPassengersDetailsViewProjectionParams projectionParams=null)
		{
			System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.FlightEntity, Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView>> mainProjection = p__0 => new Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView()
			{
				ArrivalDate = p__0.ArrivalDate,
				DepartureDate = p__0.DepartureDate,
				FlightNumber = p__0.FlightNumber,
				FlightRoute = new Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.FlightRoute()
				{
					ArrivalAirport = p__0.FlightRoute.ArrivalAirport,
					DepartureAirport = p__0.FlightRoute.DepartureAirport,
					RouteAmenities = p__0.FlightRoute.RouteAmenities.AsQueryable().OptionalWhere(projectionParams.FlightRouteProjectionParams.RouteAmenitiesProjectionParams.LinqWhereClause).OptionalOrderBy(projectionParams.FlightRouteProjectionParams.RouteAmenitiesProjectionParams.LinqOrderByClauses).Select(p__1 => new Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.FlightRouteTypes.RouteAmenity()
					{
						Amenity = new Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.FlightRouteTypes.RouteAmenityTypes.Amenity()
						{
							Id = p__1.Amenity.Id,
							Name = p__1.Amenity.Name,
						},
						Price = p__1.Price,
					}).ToList(),
				},
				Passengers = p__0.Passengers.AsQueryable().OptionalWhere(projectionParams.PassengersProjectionParams.LinqWhereClause).OptionalOrderBy(projectionParams.PassengersProjectionParams.LinqOrderByClauses).Select(p__1 => new Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.Passenger()
				{
					Id = p__1.Id,
					PassengerAmenitySelections = p__1.PassengerAmenitySelections.AsQueryable().OptionalWhere(projectionParams.PassengersProjectionParams.PassengerAmenitySelectionsProjectionParams.LinqWhereClause).OptionalOrderBy(projectionParams.PassengersProjectionParams.PassengerAmenitySelectionsProjectionParams.LinqOrderByClauses).Select(p__2 => new Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.PassengerTypes.PassengerAmenitySelection()
					{
						Customization = p__2.Customization,
						RouteAmenity = new Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.PassengerTypes.PassengerAmenitySelectionTypes.RouteAmenity()
						{
							Amenity = new Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.PassengerTypes.PassengerAmenitySelectionTypes.RouteAmenityTypes.Amenity()
							{
								Name = p__2.RouteAmenity.Amenity.Name,
							},
							AmenityId = p__2.RouteAmenity.AmenityId,
						},
					}).ToList(),
					PaymentConfirmation = p__1.PaymentConfirmation,
					Person = new Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.PassengerTypes.Person()
					{
						Email = p__1.Person.Email,
						FirstName = p__1.Person.FirstName,
						LastName = p__1.Person.LastName,
						PhoneNumber = p__1.Person.PhoneNumber,
					},
				}).ToList(),
				TourOperator = new Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.TourOperator()
				{
					ContactInfo = p__0.TourOperator.ContactInfo,
					Name = p__0.TourOperator.Name,
				},
	// __LLBLGENPRO_USER_CODE_REGION_START ProjectionRegion_FlightPassengersDetailsView 
	// __LLBLGENPRO_USER_CODE_REGION_END 
			};
			System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.FlightEntity, Charcillaries.Data.Views.DtoClasses.FlightPassengersDetailsView>> projectionAdjustments = null;
			GetAdjustmentsForProjectToFlightPassengersDetailsView(ref projectionAdjustments);
			return LinqUtils.MergeProjectionAdjustmentsIntoProjection(mainProjection, projectionAdjustments, true);
		}
	}
}


