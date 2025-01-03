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

	/// <summary>Static class for (extension) methods for fetching and projecting instances of Charcillaries.Data.Views.DtoClasses.UserView from the entity model.</summary>
	public static partial class UserViewPersistence
	{
		private static readonly System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.UserEntity, Charcillaries.Data.Views.DtoClasses.UserView>> _projectorExpression = CreateProjectionFunc();
		private static readonly Func<Charcillaries.Data.EntityClasses.UserEntity, Charcillaries.Data.Views.DtoClasses.UserView> _compiledProjector = CreateProjectionFunc().Compile();
		/// <summary>Linq specific partial method for obtaining projection adjustments for the projection method <see cref="ProjectToUserView(System.Linq.IQueryable{Charcillaries.Data.EntityClasses.UserEntity})"/></summary>
		/// <param name="projectionAdjustments">Set this argument in an implementation of this partial method to a projection lambda similar to the generated projection in <see cref="CreateProjectionFunc"/></param>
		/// <remarks>Linq specific</remarks>
		static partial void GetAdjustmentsForProjectToUserView(ref System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.UserEntity, Charcillaries.Data.Views.DtoClasses.UserView>> projectionAdjustments);
		/// <summary>QuerySpec specific partial method for obtaining projection adjustments for the projection method <see cref="ProjectToUserView(EntityQuery{Charcillaries.Data.EntityClasses.UserEntity}, Charcillaries.Data.FactoryClasses.QueryFactory)"/></summary>
		/// <param name="projectionAdjustments">Set this argument in an implementation of this partial method to a projection lambda similar to the generated projection in <see cref="ProjectToUserView(EntityQuery{Charcillaries.Data.EntityClasses.UserEntity}, Charcillaries.Data.FactoryClasses.QueryFactory)"/></param>
		/// <remarks>QuerySpec specific</remarks>
		static partial void GetAdjustmentsForProjectToUserViewQs(ref System.Linq.Expressions.Expression<Func<Charcillaries.Data.Views.DtoClasses.UserView>> projectionAdjustments);
	
		/// <summary>Empty static ctor for triggering initialization of static members in a thread-safe manner</summary>
		static UserViewPersistence() { }
	
		/// <summary>Extension method which produces a projection to Charcillaries.Data.Views.DtoClasses.UserView which instances are projected from the results of the specified baseQuery, which returns Charcillaries.Data.EntityClasses.UserEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <returns>IQueryable to retrieve Charcillaries.Data.Views.DtoClasses.UserView instances</returns>
		public static IQueryable<Charcillaries.Data.Views.DtoClasses.UserView> ProjectToUserView(this IQueryable<Charcillaries.Data.EntityClasses.UserEntity> baseQuery)
		{
			return baseQuery.Select(_projectorExpression);
		}

		/// <summary>Extension method which produces a projection to Charcillaries.Data.Views.DtoClasses.UserView which instances are projected from the results of the specified baseQuery using QuerySpec, which returns Charcillaries.Data.EntityClasses.UserEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <param name="qf">The query factory used to create baseQuery.</param>
		/// <returns>DynamicQuery to retrieve Charcillaries.Data.Views.DtoClasses.UserView instances</returns>
		public static DynamicQuery<Charcillaries.Data.Views.DtoClasses.UserView> ProjectToUserView(this EntityQuery<Charcillaries.Data.EntityClasses.UserEntity> baseQuery, Charcillaries.Data.FactoryClasses.QueryFactory qf)
		{
			System.Linq.Expressions.Expression<Func<Charcillaries.Data.Views.DtoClasses.UserView>> projectionAdjustments = null;
			GetAdjustmentsForProjectToUserViewQs(ref projectionAdjustments);
			return qf.Create()
				.From(baseQuery.Select(Projection.Full).As("__BQ")
					.InnerJoin(qf.Person.As("__L0_0")).On(UserFields.PersonId.Source("__BQ").Equal(PersonFields.Id.Source("__L0_0")))
					.InnerJoin(qf.Role.As("__L0_1")).On(UserFields.RoleId.Source("__BQ").Equal(RoleFields.Id.Source("__L0_1"))))
				.Select(LinqUtils.MergeProjectionAdjustmentsIntoProjection(() => new Charcillaries.Data.Views.DtoClasses.UserView()
				{
					AirlineId = UserFields.AirlineId.Source("__BQ").ToValue<Nullable<System.Int32>>(),
					Password = UserFields.Password.Source("__BQ").ToValue<System.String>(),
					Person = new Charcillaries.Data.Views.DtoClasses.UserViewTypes.Person()
						{
							Email = PersonFields.Email.Source("__L0_0").ToValue<System.String>(),
						},
					PersonId = UserFields.PersonId.Source("__BQ").ToValue<System.Int32>(),
					ResetToken = UserFields.ResetToken.Source("__BQ").ToValue<System.String>(),
					ResetTokenExpiration = UserFields.ResetTokenExpiration.Source("__BQ").ToValue<Nullable<System.DateTime>>(),
					Role = new Charcillaries.Data.Views.DtoClasses.UserViewTypes.Role()
						{
							Name = RoleFields.Name.Source("__L0_1").ToValue<System.String>(),
						},
					TourOperatorId = UserFields.TourOperatorId.Source("__BQ").ToValue<Nullable<System.Int32>>(),
	// __LLBLGENPRO_USER_CODE_REGION_START ProjectionRegionQS_UserView 
	// __LLBLGENPRO_USER_CODE_REGION_END 
				}, projectionAdjustments, false));
		}

		/// <summary>Extension method which produces a projection to Charcillaries.Data.Views.DtoClasses.UserView which instances are projected from the Charcillaries.Data.EntityClasses.UserEntity entity instance specified, the root entity of the derived element returned by this method.</summary>
		/// <param name="entity">The entity to project from.</param>
		/// <returns>Charcillaries.Data.EntityClasses.UserEntity instance created from the specified entity instance</returns>
		public static Charcillaries.Data.Views.DtoClasses.UserView ProjectToUserView(this Charcillaries.Data.EntityClasses.UserEntity entity)
		{
			return _compiledProjector(entity);
		}

		private static System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.UserEntity, Charcillaries.Data.Views.DtoClasses.UserView>> CreateProjectionFunc()
		{
			System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.UserEntity, Charcillaries.Data.Views.DtoClasses.UserView>> mainProjection = p__0 => new Charcillaries.Data.Views.DtoClasses.UserView()
			{
				AirlineId = p__0.AirlineId,
				Password = p__0.Password,
				Person = new Charcillaries.Data.Views.DtoClasses.UserViewTypes.Person()
				{
					Email = p__0.Person.Email,
				},
				PersonId = p__0.PersonId,
				ResetToken = p__0.ResetToken,
				ResetTokenExpiration = p__0.ResetTokenExpiration,
				Role = new Charcillaries.Data.Views.DtoClasses.UserViewTypes.Role()
				{
					Name = p__0.Role.Name,
				},
				TourOperatorId = p__0.TourOperatorId,
	// __LLBLGENPRO_USER_CODE_REGION_START ProjectionRegion_UserView 
	// __LLBLGENPRO_USER_CODE_REGION_END 
			};
			System.Linq.Expressions.Expression<Func<Charcillaries.Data.EntityClasses.UserEntity, Charcillaries.Data.Views.DtoClasses.UserView>> projectionAdjustments = null;
			GetAdjustmentsForProjectToUserView(ref projectionAdjustments);
			return LinqUtils.MergeProjectionAdjustmentsIntoProjection(mainProjection, projectionAdjustments, true);
		}
	}
}


