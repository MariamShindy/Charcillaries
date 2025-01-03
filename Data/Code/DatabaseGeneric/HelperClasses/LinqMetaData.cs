﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.10.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Linq;
using System.Collections.Generic;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Charcillaries.Data.EntityClasses;
using Charcillaries.Data.FactoryClasses;

namespace Charcillaries.Data.Linq
{
	/// <summary>Meta-data class for the construction of Linq queries which are to be executed using LLBLGen Pro code.</summary>
	public partial class LinqMetaData: ILinqMetaData
	{
		/// <summary>CTor. Using this ctor will leave the IDataAccessAdapter object to use empty. To be able to execute the query, an IDataAccessAdapter instance
		/// is required, and has to be set on the LLBLGenProProvider2 object in the query to execute. </summary>
		public LinqMetaData() : this(null, null) { }
		
		/// <summary>CTor which accepts an IDataAccessAdapter implementing object, which will be used to execute queries created with this metadata class.</summary>
		/// <param name="adapterToUse">the IDataAccessAdapter to use in queries created with this meta data</param>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data till they go out of scope.</remarks>
		public LinqMetaData(IDataAccessAdapter adapterToUse) : this (adapterToUse, null) { }

		/// <summary>CTor which accepts an IDataAccessAdapter implementing object, which will be used to execute queries created with this metadata class.</summary>
		/// <param name="adapterToUse">the IDataAccessAdapter to use in queries created with this meta data</param>
		/// <param name="customFunctionMappings">The custom function mappings to use. These take higher precedence than the ones in the DQE to use.</param>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data till they go out of scope.</remarks>
		public LinqMetaData(IDataAccessAdapter adapterToUse, FunctionMappingStore customFunctionMappings)
		{
			this.AdapterToUse = adapterToUse;
			this.CustomFunctionMappings = customFunctionMappings;
		}
	
		/// <summary>returns the datasource to use in a Linq query for the entity type specified</summary>
		/// <param name="typeOfEntity">the type of the entity to get the datasource for</param>
		/// <returns>the requested datasource</returns>
		public IDataSource GetQueryableForEntity(int typeOfEntity)
		{
			switch((Charcillaries.Data.EntityType)typeOfEntity)
			{
				case Charcillaries.Data.EntityType.AirlineEntity:
					return this.Airline;
				case Charcillaries.Data.EntityType.AmenityEntity:
					return this.Amenity;
				case Charcillaries.Data.EntityType.AmenityFeedbackEntity:
					return this.AmenityFeedback;
				case Charcillaries.Data.EntityType.FlightEntity:
					return this.Flight;
				case Charcillaries.Data.EntityType.FlightRouteEntity:
					return this.FlightRoute;
				case Charcillaries.Data.EntityType.PassengerEntity:
					return this.Passenger;
				case Charcillaries.Data.EntityType.PassengerAmenitySelectionEntity:
					return this.PassengerAmenitySelection;
				case Charcillaries.Data.EntityType.PersonEntity:
					return this.Person;
				case Charcillaries.Data.EntityType.RoleEntity:
					return this.Role;
				case Charcillaries.Data.EntityType.RouteAmenityEntity:
					return this.RouteAmenity;
				case Charcillaries.Data.EntityType.RouteFlightFeedbackEntity:
					return this.RouteFlightFeedback;
				case Charcillaries.Data.EntityType.TourOperatorEntity:
					return this.TourOperator;
				case Charcillaries.Data.EntityType.TourOperatorAirlineEntity:
					return this.TourOperatorAirline;
				case Charcillaries.Data.EntityType.UserEntity:
					return this.User;
				default:
					return null;
			}
		}

		/// <summary>returns the datasource to use in a Linq query which wraps the specified SQL query and projects it to instances of type T</summary>
		/// <param name="sqlQuery">The SQL query to execute. Has to follow one of the parameter specification patterns for Plain SQL queries in the LLBLGen Pro Runtime Framework</param>
		/// <param name="parameterValues">The object which will provide the parameter values for the SQL query specified. Has to follow one of the parameter specification patterns for Plain SQL queries in the LLBLGen Pro Runtime Framework</param>
		/// <typeparam name="T">The type of the instances to project the rows into, returned by the SQL query specified</typeparam>
		/// <returns>the requested datasource</returns>
		[InMemoryCandidate]
		public DataSource2<T> FromSql<T>(string sqlQuery, object parameterValues)
			where T : class
		{
			return new DataSource2<T>(this.AdapterToUse, new ElementCreator(), this.CustomFunctionMappings, this.ContextToUse).SetWrappedPlainSQLQuerySpecification(sqlQuery, parameterValues);
		}

		/// <summary>returns the datasource to use in a Linq query for the entity type specified</summary>
		/// <typeparam name="TEntity">the type of the entity to get the datasource for</typeparam>
		/// <returns>the requested datasource</returns>
		public DataSource2<TEntity> GetQueryableForEntity<TEntity>()
				where TEntity : class
		{
			return new DataSource2<TEntity>(this.AdapterToUse, new ElementCreator(), this.CustomFunctionMappings, this.ContextToUse);
		}

		/// <summary>returns the datasource to use in a Linq query when targeting AirlineEntity instances in the database.</summary>
		public DataSource2<AirlineEntity> Airline {	get { return new DataSource2<AirlineEntity>(this.AdapterToUse, new ElementCreator(), this.CustomFunctionMappings, this.ContextToUse); } }
		
		/// <summary>returns the datasource to use in a Linq query when targeting AmenityEntity instances in the database.</summary>
		public DataSource2<AmenityEntity> Amenity {	get { return new DataSource2<AmenityEntity>(this.AdapterToUse, new ElementCreator(), this.CustomFunctionMappings, this.ContextToUse); } }
		
		/// <summary>returns the datasource to use in a Linq query when targeting AmenityFeedbackEntity instances in the database.</summary>
		public DataSource2<AmenityFeedbackEntity> AmenityFeedback {	get { return new DataSource2<AmenityFeedbackEntity>(this.AdapterToUse, new ElementCreator(), this.CustomFunctionMappings, this.ContextToUse); } }
		
		/// <summary>returns the datasource to use in a Linq query when targeting FlightEntity instances in the database.</summary>
		public DataSource2<FlightEntity> Flight {	get { return new DataSource2<FlightEntity>(this.AdapterToUse, new ElementCreator(), this.CustomFunctionMappings, this.ContextToUse); } }
		
		/// <summary>returns the datasource to use in a Linq query when targeting FlightRouteEntity instances in the database.</summary>
		public DataSource2<FlightRouteEntity> FlightRoute {	get { return new DataSource2<FlightRouteEntity>(this.AdapterToUse, new ElementCreator(), this.CustomFunctionMappings, this.ContextToUse); } }
		
		/// <summary>returns the datasource to use in a Linq query when targeting PassengerEntity instances in the database.</summary>
		public DataSource2<PassengerEntity> Passenger {	get { return new DataSource2<PassengerEntity>(this.AdapterToUse, new ElementCreator(), this.CustomFunctionMappings, this.ContextToUse); } }
		
		/// <summary>returns the datasource to use in a Linq query when targeting PassengerAmenitySelectionEntity instances in the database.</summary>
		public DataSource2<PassengerAmenitySelectionEntity> PassengerAmenitySelection {	get { return new DataSource2<PassengerAmenitySelectionEntity>(this.AdapterToUse, new ElementCreator(), this.CustomFunctionMappings, this.ContextToUse); } }
		
		/// <summary>returns the datasource to use in a Linq query when targeting PersonEntity instances in the database.</summary>
		public DataSource2<PersonEntity> Person {	get { return new DataSource2<PersonEntity>(this.AdapterToUse, new ElementCreator(), this.CustomFunctionMappings, this.ContextToUse); } }
		
		/// <summary>returns the datasource to use in a Linq query when targeting RoleEntity instances in the database.</summary>
		public DataSource2<RoleEntity> Role {	get { return new DataSource2<RoleEntity>(this.AdapterToUse, new ElementCreator(), this.CustomFunctionMappings, this.ContextToUse); } }
		
		/// <summary>returns the datasource to use in a Linq query when targeting RouteAmenityEntity instances in the database.</summary>
		public DataSource2<RouteAmenityEntity> RouteAmenity {	get { return new DataSource2<RouteAmenityEntity>(this.AdapterToUse, new ElementCreator(), this.CustomFunctionMappings, this.ContextToUse); } }
		
		/// <summary>returns the datasource to use in a Linq query when targeting RouteFlightFeedbackEntity instances in the database.</summary>
		public DataSource2<RouteFlightFeedbackEntity> RouteFlightFeedback {	get { return new DataSource2<RouteFlightFeedbackEntity>(this.AdapterToUse, new ElementCreator(), this.CustomFunctionMappings, this.ContextToUse); } }
		
		/// <summary>returns the datasource to use in a Linq query when targeting TourOperatorEntity instances in the database.</summary>
		public DataSource2<TourOperatorEntity> TourOperator {	get { return new DataSource2<TourOperatorEntity>(this.AdapterToUse, new ElementCreator(), this.CustomFunctionMappings, this.ContextToUse); } }
		
		/// <summary>returns the datasource to use in a Linq query when targeting TourOperatorAirlineEntity instances in the database.</summary>
		public DataSource2<TourOperatorAirlineEntity> TourOperatorAirline {	get { return new DataSource2<TourOperatorAirlineEntity>(this.AdapterToUse, new ElementCreator(), this.CustomFunctionMappings, this.ContextToUse); } }
		
		/// <summary>returns the datasource to use in a Linq query when targeting UserEntity instances in the database.</summary>
		public DataSource2<UserEntity> User {	get { return new DataSource2<UserEntity>(this.AdapterToUse, new ElementCreator(), this.CustomFunctionMappings, this.ContextToUse); } }
		


		/// <summary> Gets / sets the IDataAccessAdapter to use for the queries created with this meta data object.</summary>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public IDataAccessAdapter AdapterToUse { get; set; }
		
		/// <summary>Gets or sets the custom function mappings to use. These take higher precedence than the ones in the DQE to use</summary>
		public FunctionMappingStore CustomFunctionMappings { get; set; }
		
		/// <summary>Gets or sets the Context instance to use for entity fetches.</summary>
		public Context ContextToUse { get; set; }
	}
}