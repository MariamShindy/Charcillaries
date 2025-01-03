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

	/// <summary>Static class for (extension) methods for fetching and projecting instances of Charcillaries.Data.Views.DtoClasses.AirlineListView from the entity model.</summary>
	public static partial class AirlineListViewPersistence
	{
		private static readonly System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.AirlineEntity, Charcillaries.Data.Views.DtoClasses.AirlineListView>> _projectorExpression = CreateProjectionFunc();
		private static readonly Func<Charcillaries.Data.EntityClasses.AirlineEntity, Charcillaries.Data.Views.DtoClasses.AirlineListView> _compiledProjector = CreateProjectionFunc().Compile();
		/// <summary>Linq specific partial method for obtaining projection adjustments for the projection method <see cref="ProjectToAirlineListView(System.Linq.IQueryable{Charcillaries.Data.EntityClasses.AirlineEntity})"/></summary>
		/// <param name="projectionAdjustments">Set this argument in an implementation of this partial method to a projection lambda similar to the generated projection in <see cref="CreateProjectionFunc"/></param>
		/// <remarks>Linq specific</remarks>
		static partial void GetAdjustmentsForProjectToAirlineListView(ref System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.AirlineEntity, Charcillaries.Data.Views.DtoClasses.AirlineListView>> projectionAdjustments);
		/// <summary>QuerySpec specific partial method for obtaining projection adjustments for the projection method <see cref="ProjectToAirlineListView(EntityQuery{Charcillaries.Data.EntityClasses.AirlineEntity}, Charcillaries.Data.FactoryClasses.QueryFactory)"/></summary>
		/// <param name="projectionAdjustments">Set this argument in an implementation of this partial method to a projection lambda similar to the generated projection in <see cref="ProjectToAirlineListView(EntityQuery{Charcillaries.Data.EntityClasses.AirlineEntity}, Charcillaries.Data.FactoryClasses.QueryFactory)"/></param>
		/// <remarks>QuerySpec specific</remarks>
		static partial void GetAdjustmentsForProjectToAirlineListViewQs(ref System.Linq.Expressions.Expression<Func<Charcillaries.Data.Views.DtoClasses.AirlineListView>> projectionAdjustments);
	
		/// <summary>Empty static ctor for triggering initialization of static members in a thread-safe manner</summary>
		static AirlineListViewPersistence() { }
	
		/// <summary>Extension method which produces a projection to Charcillaries.Data.Views.DtoClasses.AirlineListView which instances are projected from the results of the specified baseQuery, which returns Charcillaries.Data.EntityClasses.AirlineEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <returns>IQueryable to retrieve Charcillaries.Data.Views.DtoClasses.AirlineListView instances</returns>
		public static IQueryable<Charcillaries.Data.Views.DtoClasses.AirlineListView> ProjectToAirlineListView(this IQueryable<Charcillaries.Data.EntityClasses.AirlineEntity> baseQuery)
		{
			return baseQuery.Select(_projectorExpression);
		}

		/// <summary>Extension method which produces a projection to Charcillaries.Data.Views.DtoClasses.AirlineListView which instances are projected from the results of the specified baseQuery using QuerySpec, which returns Charcillaries.Data.EntityClasses.AirlineEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <param name="qf">The query factory used to create baseQuery.</param>
		/// <returns>DynamicQuery to retrieve Charcillaries.Data.Views.DtoClasses.AirlineListView instances</returns>
		public static DynamicQuery<Charcillaries.Data.Views.DtoClasses.AirlineListView> ProjectToAirlineListView(this EntityQuery<Charcillaries.Data.EntityClasses.AirlineEntity> baseQuery, Charcillaries.Data.FactoryClasses.QueryFactory qf)
		{
			System.Linq.Expressions.Expression<Func<Charcillaries.Data.Views.DtoClasses.AirlineListView>> projectionAdjustments = null;
			GetAdjustmentsForProjectToAirlineListViewQs(ref projectionAdjustments);
			return qf.Create()
				.From(baseQuery.Select(Projection.Full).As("__BQ"))
				.Select(LinqUtils.MergeProjectionAdjustmentsIntoProjection(() => new Charcillaries.Data.Views.DtoClasses.AirlineListView()
				{
					ContactInfo = AirlineFields.ContactInfo.Source("__BQ").ToValue<System.String>(),
					Email = AirlineFields.Email.Source("__BQ").ToValue<System.String>(),
					Id = AirlineFields.Id.Source("__BQ").ToValue<System.Int32>(),
					Name = AirlineFields.Name.Source("__BQ").ToValue<System.String>(),
	// __LLBLGENPRO_USER_CODE_REGION_START ProjectionRegionQS_AirlineListView 
	// __LLBLGENPRO_USER_CODE_REGION_END 
				}, projectionAdjustments, false));
		}

		/// <summary>Extension method which produces a projection to Charcillaries.Data.Views.DtoClasses.AirlineListView which instances are projected from the Charcillaries.Data.EntityClasses.AirlineEntity entity instance specified, the root entity of the derived element returned by this method.</summary>
		/// <param name="entity">The entity to project from.</param>
		/// <returns>Charcillaries.Data.EntityClasses.AirlineEntity instance created from the specified entity instance</returns>
		public static Charcillaries.Data.Views.DtoClasses.AirlineListView ProjectToAirlineListView(this Charcillaries.Data.EntityClasses.AirlineEntity entity)
		{
			return _compiledProjector(entity);
		}

		private static System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.AirlineEntity, Charcillaries.Data.Views.DtoClasses.AirlineListView>> CreateProjectionFunc()
		{
			System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.AirlineEntity, Charcillaries.Data.Views.DtoClasses.AirlineListView>> mainProjection = p__0 => new Charcillaries.Data.Views.DtoClasses.AirlineListView()
			{
				ContactInfo = p__0.ContactInfo,
				Email = p__0.Email,
				Id = p__0.Id,
				Name = p__0.Name,
	// __LLBLGENPRO_USER_CODE_REGION_START ProjectionRegion_AirlineListView 
	// __LLBLGENPRO_USER_CODE_REGION_END 
			};
			System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.AirlineEntity, Charcillaries.Data.Views.DtoClasses.AirlineListView>> projectionAdjustments = null;
			GetAdjustmentsForProjectToAirlineListView(ref projectionAdjustments);
			return LinqUtils.MergeProjectionAdjustmentsIntoProjection(mainProjection, projectionAdjustments, true);
		}
	}
}


