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

	/// <summary>Static class for (extension) methods for fetching and projecting instances of Charcillaries.Data.Views.DtoClasses.RouteAmenityListView from the entity model.</summary>
	public static partial class RouteAmenityListViewPersistence
	{
		private static readonly System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.RouteAmenityEntity, Charcillaries.Data.Views.DtoClasses.RouteAmenityListView>> _projectorExpression = CreateProjectionFunc();
		private static readonly Func<Charcillaries.Data.EntityClasses.RouteAmenityEntity, Charcillaries.Data.Views.DtoClasses.RouteAmenityListView> _compiledProjector = CreateProjectionFunc().Compile();
		/// <summary>Linq specific partial method for obtaining projection adjustments for the projection method <see cref="ProjectToRouteAmenityListView(System.Linq.IQueryable{Charcillaries.Data.EntityClasses.RouteAmenityEntity})"/></summary>
		/// <param name="projectionAdjustments">Set this argument in an implementation of this partial method to a projection lambda similar to the generated projection in <see cref="CreateProjectionFunc"/></param>
		/// <remarks>Linq specific</remarks>
		static partial void GetAdjustmentsForProjectToRouteAmenityListView(ref System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.RouteAmenityEntity, Charcillaries.Data.Views.DtoClasses.RouteAmenityListView>> projectionAdjustments);
		/// <summary>QuerySpec specific partial method for obtaining projection adjustments for the projection method <see cref="ProjectToRouteAmenityListView(EntityQuery{Charcillaries.Data.EntityClasses.RouteAmenityEntity}, Charcillaries.Data.FactoryClasses.QueryFactory)"/></summary>
		/// <param name="projectionAdjustments">Set this argument in an implementation of this partial method to a projection lambda similar to the generated projection in <see cref="ProjectToRouteAmenityListView(EntityQuery{Charcillaries.Data.EntityClasses.RouteAmenityEntity}, Charcillaries.Data.FactoryClasses.QueryFactory)"/></param>
		/// <remarks>QuerySpec specific</remarks>
		static partial void GetAdjustmentsForProjectToRouteAmenityListViewQs(ref System.Linq.Expressions.Expression<Func<Charcillaries.Data.Views.DtoClasses.RouteAmenityListView>> projectionAdjustments);
	
		/// <summary>Empty static ctor for triggering initialization of static members in a thread-safe manner</summary>
		static RouteAmenityListViewPersistence() { }
	
		/// <summary>Extension method which produces a projection to Charcillaries.Data.Views.DtoClasses.RouteAmenityListView which instances are projected from the results of the specified baseQuery, which returns Charcillaries.Data.EntityClasses.RouteAmenityEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <returns>IQueryable to retrieve Charcillaries.Data.Views.DtoClasses.RouteAmenityListView instances</returns>
		public static IQueryable<Charcillaries.Data.Views.DtoClasses.RouteAmenityListView> ProjectToRouteAmenityListView(this IQueryable<Charcillaries.Data.EntityClasses.RouteAmenityEntity> baseQuery)
		{
			return baseQuery.Select(_projectorExpression);
		}

		/// <summary>Extension method which produces a projection to Charcillaries.Data.Views.DtoClasses.RouteAmenityListView which instances are projected from the results of the specified baseQuery using QuerySpec, which returns Charcillaries.Data.EntityClasses.RouteAmenityEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <param name="qf">The query factory used to create baseQuery.</param>
		/// <returns>DynamicQuery to retrieve Charcillaries.Data.Views.DtoClasses.RouteAmenityListView instances</returns>
		public static DynamicQuery<Charcillaries.Data.Views.DtoClasses.RouteAmenityListView> ProjectToRouteAmenityListView(this EntityQuery<Charcillaries.Data.EntityClasses.RouteAmenityEntity> baseQuery, Charcillaries.Data.FactoryClasses.QueryFactory qf)
		{
			System.Linq.Expressions.Expression<Func<Charcillaries.Data.Views.DtoClasses.RouteAmenityListView>> projectionAdjustments = null;
			GetAdjustmentsForProjectToRouteAmenityListViewQs(ref projectionAdjustments);
			return qf.Create()
				.From(baseQuery.Select(Projection.Full).As("__BQ")
					.InnerJoin(qf.Amenity.As("__L0_0")).On(RouteAmenityFields.AmenityId.Source("__BQ").Equal(AmenityFields.Id.Source("__L0_0"))))
				.Select(LinqUtils.MergeProjectionAdjustmentsIntoProjection(() => new Charcillaries.Data.Views.DtoClasses.RouteAmenityListView()
				{
					Amenity = new Charcillaries.Data.Views.DtoClasses.RouteAmenityListViewTypes.Amenity()
						{
							Name = AmenityFields.Name.Source("__L0_0").ToValue<System.String>(),
						},
					AmenityId = RouteAmenityFields.AmenityId.Source("__BQ").ToValue<System.Int32>(),
					FlightRouteId = RouteAmenityFields.FlightRouteId.Source("__BQ").ToValue<System.Int32>(),
					Id = RouteAmenityFields.Id.Source("__BQ").ToValue<System.Int32>(),
					ObjectStatus = RouteAmenityFields.ObjectStatus.Source("__BQ").ToValue<System.Int32>(),
					Price = RouteAmenityFields.Price.Source("__BQ").ToValue<System.Single>(),
					Quantity = RouteAmenityFields.Quantity.Source("__BQ").ToValue<Nullable<System.Int32>>(),
	// __LLBLGENPRO_USER_CODE_REGION_START ProjectionRegionQS_RouteAmenityListView 
	// __LLBLGENPRO_USER_CODE_REGION_END 
				}, projectionAdjustments, false));
		}

		/// <summary>Extension method which produces a projection to Charcillaries.Data.Views.DtoClasses.RouteAmenityListView which instances are projected from the Charcillaries.Data.EntityClasses.RouteAmenityEntity entity instance specified, the root entity of the derived element returned by this method.</summary>
		/// <param name="entity">The entity to project from.</param>
		/// <returns>Charcillaries.Data.EntityClasses.RouteAmenityEntity instance created from the specified entity instance</returns>
		public static Charcillaries.Data.Views.DtoClasses.RouteAmenityListView ProjectToRouteAmenityListView(this Charcillaries.Data.EntityClasses.RouteAmenityEntity entity)
		{
			return _compiledProjector(entity);
		}

		private static System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.RouteAmenityEntity, Charcillaries.Data.Views.DtoClasses.RouteAmenityListView>> CreateProjectionFunc()
		{
			System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.RouteAmenityEntity, Charcillaries.Data.Views.DtoClasses.RouteAmenityListView>> mainProjection = p__0 => new Charcillaries.Data.Views.DtoClasses.RouteAmenityListView()
			{
				Amenity = new Charcillaries.Data.Views.DtoClasses.RouteAmenityListViewTypes.Amenity()
				{
					Name = p__0.Amenity.Name,
				},
				AmenityId = p__0.AmenityId,
				FlightRouteId = p__0.FlightRouteId,
				Id = p__0.Id,
				ObjectStatus = p__0.ObjectStatus,
				Price = p__0.Price,
				Quantity = p__0.Quantity,
	// __LLBLGENPRO_USER_CODE_REGION_START ProjectionRegion_RouteAmenityListView 
	// __LLBLGENPRO_USER_CODE_REGION_END 
			};
			System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.RouteAmenityEntity, Charcillaries.Data.Views.DtoClasses.RouteAmenityListView>> projectionAdjustments = null;
			GetAdjustmentsForProjectToRouteAmenityListView(ref projectionAdjustments);
			return LinqUtils.MergeProjectionAdjustmentsIntoProjection(mainProjection, projectionAdjustments, true);
		}
	}
}


