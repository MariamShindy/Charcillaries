﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.10.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Charcillaries.Data.Views.DtoClasses
{ 
	/// <summary> DTO class which is derived from the entity 'PassengerAmenitySelection'.</summary>
	[Serializable]
	[DataContract]
	public partial class PassengerAmenityListView
	{
		/// <summary>Gets or sets the AmenityId field. Derived from Entity Model Field 'PassengerAmenitySelection.RouteAmenityId (FK)'</summary>
		[DataMember]
		public System.Int32 AmenityId { get; set; }
		/// <summary>Gets or sets the Confirmed field. Derived from Entity Model Field 'PassengerAmenitySelection.Confirmed'</summary>
		[DataMember]
		public Nullable<System.Int32> Confirmed { get; set; }
		/// <summary>Gets or sets the Id field. Derived from Entity Model Field 'PassengerAmenitySelection.Id'</summary>
		[DataMember]
		public System.Int32 Id { get; set; }
		/// <summary>Gets or sets the ObjectStatus field. Derived from Entity Model Field 'PassengerAmenitySelection.ObjectStatus'</summary>
		[DataMember]
		public System.Int32 ObjectStatus { get; set; }
		/// <summary>Gets or sets the Passenger field. </summary>
		[DataMember]
		public PassengerAmenityListViewTypes.Passenger Passenger { get; set; }
		/// <summary>Gets or sets the PassengerId field. Derived from Entity Model Field 'PassengerAmenitySelection.PassengerId (FK)'</summary>
		[DataMember]
		public System.Int32 PassengerId { get; set; }
		/// <summary>Gets or sets the Quantity field. Derived from Entity Model Field 'PassengerAmenitySelection.Quantity'</summary>
		[DataMember]
		public Nullable<System.Int32> Quantity { get; set; }
		/// <summary>Gets or sets the RouteAmenity field. </summary>
		[DataMember]
		public PassengerAmenityListViewTypes.RouteAmenity RouteAmenity { get; set; }
	}

	namespace PassengerAmenityListViewTypes
	{
		/// <summary> DTO class which is derived from the entity 'Passenger (Passenger)'.</summary>
		[Serializable]
		[DataContract]
		public partial class Passenger
		{
			/// <summary>Gets or sets the Flight field. </summary>
			[DataMember]
			public PassengerTypes.Flight Flight { get; set; }
			/// <summary>Gets or sets the PassengerAmenitySelections field. </summary>
			[DataMember]
			public List<PassengerTypes.PassengerAmenitySelection> PassengerAmenitySelections { get; set; }
			/// <summary>Gets or sets the Person field. </summary>
			[DataMember]
			public PassengerTypes.Person Person { get; set; }
		}

		namespace PassengerTypes
		{
			/// <summary> DTO class which is derived from the entity 'Flight (Passenger.Flight)'.</summary>
			[Serializable]
			[DataContract]
			public partial class Flight
			{
				/// <summary>Gets or sets the ArrivalDate field. Derived from Entity Model Field 'Flight.ArrivalDate'</summary>
				[DataMember]
				public System.DateTime ArrivalDate { get; set; }
				/// <summary>Gets or sets the DepartureDate field. Derived from Entity Model Field 'Flight.DepartureDate'</summary>
				[DataMember]
				public System.DateTime DepartureDate { get; set; }
				/// <summary>Gets or sets the FlightNumber field. Derived from Entity Model Field 'Flight.FlightNumber'</summary>
				[DataMember]
				public System.String FlightNumber { get; set; }
				/// <summary>Gets or sets the FlightRoute field. </summary>
				[DataMember]
				public FlightTypes.FlightRoute FlightRoute { get; set; }
				/// <summary>Gets or sets the FlightRouteId field. Derived from Entity Model Field 'Flight.FlightRouteId (FK)'</summary>
				[DataMember]
				public System.Int32 FlightRouteId { get; set; }
				/// <summary>Gets or sets the Id field. Derived from Entity Model Field 'Flight.Id'</summary>
				[DataMember]
				public System.Int32 Id { get; set; }
				/// <summary>Gets or sets the NumberOfSeats field. Derived from Entity Model Field 'Flight.NumberOfSeats'</summary>
				[DataMember]
				public System.Int32 NumberOfSeats { get; set; }
				/// <summary>Gets or sets the ObjectStatus field. Derived from Entity Model Field 'Flight.ObjectStatus'</summary>
				[DataMember]
				public System.Int32 ObjectStatus { get; set; }
				/// <summary>Gets or sets the TourOperatorId field. Derived from Entity Model Field 'Flight.TourOperatorId (FK)'</summary>
				[DataMember]
				public System.Int32 TourOperatorId { get; set; }
			}

			namespace FlightTypes
			{
				/// <summary> DTO class which is derived from the entity 'FlightRoute (Passenger.Flight.FlightRoute)'.</summary>
				[Serializable]
				[DataContract]
				public partial class FlightRoute
				{
					/// <summary>Gets or sets the AirlineId field. Derived from Entity Model Field 'FlightRoute.AirlineId (FK)'</summary>
					[DataMember]
					public System.Int32 AirlineId { get; set; }
					/// <summary>Gets or sets the ArrivalAirport field. Derived from Entity Model Field 'FlightRoute.ArrivalAirport'</summary>
					[DataMember]
					public System.String ArrivalAirport { get; set; }
					/// <summary>Gets or sets the DepartureAirport field. Derived from Entity Model Field 'FlightRoute.DepartureAirport'</summary>
					[DataMember]
					public System.String DepartureAirport { get; set; }
					/// <summary>Gets or sets the Id field. Derived from Entity Model Field 'FlightRoute.Id'</summary>
					[DataMember]
					public System.Int32 Id { get; set; }
					/// <summary>Gets or sets the ObjectStatus field. Derived from Entity Model Field 'FlightRoute.ObjectStatus'</summary>
					[DataMember]
					public System.Int32 ObjectStatus { get; set; }
				}
			}

			/// <summary> DTO class which is derived from the entity 'PassengerAmenitySelection (Passenger.PassengerAmenitySelections)'.</summary>
			[Serializable]
			[DataContract]
			public partial class PassengerAmenitySelection
			{
				/// <summary>Gets or sets the AmenityId field. Derived from Entity Model Field 'PassengerAmenitySelection.RouteAmenityId (FK)'</summary>
				[DataMember]
				public System.Int32 AmenityId { get; set; }
				/// <summary>Gets or sets the Confirmed field. Derived from Entity Model Field 'PassengerAmenitySelection.Confirmed'</summary>
				[DataMember]
				public Nullable<System.Int32> Confirmed { get; set; }
				/// <summary>Gets or sets the Customization field. Derived from Entity Model Field 'PassengerAmenitySelection.Customization'</summary>
				[DataMember]
				public System.String Customization { get; set; }
				/// <summary>Gets or sets the Id field. Derived from Entity Model Field 'PassengerAmenitySelection.Id'</summary>
				[DataMember]
				public System.Int32 Id { get; set; }
				/// <summary>Gets or sets the ObjectStatus field. Derived from Entity Model Field 'PassengerAmenitySelection.ObjectStatus'</summary>
				[DataMember]
				public System.Int32 ObjectStatus { get; set; }
				/// <summary>Gets or sets the PassengerId field. Derived from Entity Model Field 'PassengerAmenitySelection.PassengerId (FK)'</summary>
				[DataMember]
				public System.Int32 PassengerId { get; set; }
				/// <summary>Gets or sets the Quantity field. Derived from Entity Model Field 'PassengerAmenitySelection.Quantity'</summary>
				[DataMember]
				public Nullable<System.Int32> Quantity { get; set; }
			}

			/// <summary> DTO class which is derived from the entity 'Person (Passenger.Person)'.</summary>
			[Serializable]
			[DataContract]
			public partial class Person
			{
				/// <summary>Gets or sets the Email field. Derived from Entity Model Field 'Person.Email'</summary>
				[DataMember]
				public System.String Email { get; set; }
				/// <summary>Gets or sets the FirstName field. Derived from Entity Model Field 'Person.FirstName'</summary>
				[DataMember]
				public System.String FirstName { get; set; }
				/// <summary>Gets or sets the Id field. Derived from Entity Model Field 'Person.Id'</summary>
				[DataMember]
				public System.Int32 Id { get; set; }
				/// <summary>Gets or sets the LastName field. Derived from Entity Model Field 'Person.LastName'</summary>
				[DataMember]
				public System.String LastName { get; set; }
				/// <summary>Gets or sets the ObjectStatus field. Derived from Entity Model Field 'Person.ObjectStatus'</summary>
				[DataMember]
				public System.Int32 ObjectStatus { get; set; }
				/// <summary>Gets or sets the PassportNumber field. Derived from Entity Model Field 'Person.PassportNumber'</summary>
				[DataMember]
				public System.String PassportNumber { get; set; }
				/// <summary>Gets or sets the PhoneNumber field. Derived from Entity Model Field 'Person.PhoneNumber'</summary>
				[DataMember]
				public System.String PhoneNumber { get; set; }
			}
		}

		/// <summary> DTO class which is derived from the entity 'RouteAmenity (RouteAmenity)'.</summary>
		[Serializable]
		[DataContract]
		public partial class RouteAmenity
		{
			/// <summary>Gets or sets the Amenity field. </summary>
			[DataMember]
			public RouteAmenityTypes.Amenity Amenity { get; set; }
			/// <summary>Gets or sets the AmenityId field. Derived from Entity Model Field 'RouteAmenity.AmenityId (FK)'</summary>
			[DataMember]
			public System.Int32 AmenityId { get; set; }
			/// <summary>Gets or sets the FlightRouteId field. Derived from Entity Model Field 'RouteAmenity.FlightRouteId (FK)'</summary>
			[DataMember]
			public System.Int32 FlightRouteId { get; set; }
			/// <summary>Gets or sets the Id field. Derived from Entity Model Field 'RouteAmenity.Id'</summary>
			[DataMember]
			public System.Int32 Id { get; set; }
			/// <summary>Gets or sets the ObjectStatus field. Derived from Entity Model Field 'RouteAmenity.ObjectStatus'</summary>
			[DataMember]
			public System.Int32 ObjectStatus { get; set; }
			/// <summary>Gets or sets the Price field. Derived from Entity Model Field 'RouteAmenity.Price'</summary>
			[DataMember]
			public System.Single Price { get; set; }
			/// <summary>Gets or sets the Quantity field. Derived from Entity Model Field 'RouteAmenity.Quantity'</summary>
			[DataMember]
			public Nullable<System.Int32> Quantity { get; set; }
		}

		namespace RouteAmenityTypes
		{
			/// <summary> DTO class which is derived from the entity 'Amenity (RouteAmenity.Amenity)'.</summary>
			[Serializable]
			[DataContract]
			public partial class Amenity
			{
				/// <summary>Gets or sets the Name field. Derived from Entity Model Field 'Amenity.Name'</summary>
				[DataMember]
				public System.String Name { get; set; }
			}
		}
	}

}



