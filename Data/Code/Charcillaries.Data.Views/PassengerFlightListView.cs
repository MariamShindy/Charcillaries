﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.10.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Charcillaries.Data.Views.DtoClasses
{ 
	/// <summary> DTO class which is derived from the entity 'Passenger'.</summary>
	[Serializable]
	[DataContract]
	public partial class PassengerFlightListView
	{
		/// <summary>Gets or sets the Flight field. </summary>
		[DataMember]
		public PassengerFlightListViewTypes.Flight Flight { get; set; }
		/// <summary>Gets or sets the Id field. Derived from Entity Model Field 'Passenger.Id'</summary>
		[DataMember]
		public System.Int32 Id { get; set; }
		/// <summary>Gets or sets the ObjectStatus field. Derived from Entity Model Field 'Passenger.ObjectStatus'</summary>
		[DataMember]
		public System.Int32 ObjectStatus { get; set; }
		/// <summary>Gets or sets the PassengerAmenitySelections field. </summary>
		[DataMember]
		public List<PassengerFlightListViewTypes.PassengerAmenitySelection> PassengerAmenitySelections { get; set; }
		/// <summary>Gets or sets the PaymentAmount field. Derived from Entity Model Field 'Passenger.PaymentAmount'</summary>
		[DataMember]
		public Nullable<System.Single> PaymentAmount { get; set; }
		/// <summary>Gets or sets the PaymentConfirmation field. Derived from Entity Model Field 'Passenger.PaymentConfirmation'</summary>
		[DataMember]
		public System.String PaymentConfirmation { get; set; }
		/// <summary>Gets or sets the PaymentConfirmationDate field. Derived from Entity Model Field 'Passenger.PaymentConfirmationDate'</summary>
		[DataMember]
		public Nullable<System.DateTime> PaymentConfirmationDate { get; set; }
		/// <summary>Gets or sets the Person field. </summary>
		[DataMember]
		public PassengerFlightListViewTypes.Person Person { get; set; }
	}

	namespace PassengerFlightListViewTypes
	{
		/// <summary> DTO class which is derived from the entity 'Flight (Flight)'.</summary>
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
			/// <summary> DTO class which is derived from the entity 'FlightRoute (Flight.FlightRoute)'.</summary>
			[Serializable]
			[DataContract]
			public partial class FlightRoute
			{
				/// <summary>Gets or sets the Airline field. </summary>
				[DataMember]
				public FlightRouteTypes.Airline Airline { get; set; }
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
				/// <summary>Gets or sets the RouteAmenities field. </summary>
				[DataMember]
				public List<FlightRouteTypes.RouteAmenity> RouteAmenities { get; set; }
			}

			namespace FlightRouteTypes
			{
				/// <summary> DTO class which is derived from the entity 'Airline (Flight.FlightRoute.Airline)'.</summary>
				[Serializable]
				[DataContract]
				public partial class Airline
				{
					/// <summary>Gets or sets the Name field. Derived from Entity Model Field 'Airline.Name'</summary>
					[DataMember]
					public System.String Name { get; set; }
				}

				/// <summary> DTO class which is derived from the entity 'RouteAmenity (Flight.FlightRoute.RouteAmenities)'.</summary>
				[Serializable]
				[DataContract]
				public partial class RouteAmenity
				{
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
			}
		}

		/// <summary> DTO class which is derived from the entity 'PassengerAmenitySelection (PassengerAmenitySelections)'.</summary>
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
			/// <summary>Gets or sets the RouteAmenity field. </summary>
			[DataMember]
			public PassengerAmenitySelectionTypes.RouteAmenity RouteAmenity { get; set; }
		}

		namespace PassengerAmenitySelectionTypes
		{
			/// <summary> DTO class which is derived from the entity 'RouteAmenity (PassengerAmenitySelections.RouteAmenity)'.</summary>
			[Serializable]
			[DataContract]
			public partial class RouteAmenity
			{
				/// <summary>Gets or sets the Amenity field. </summary>
				[DataMember]
				public RouteAmenityTypes.Amenity Amenity { get; set; }
				/// <summary>Gets or sets the Price field. Derived from Entity Model Field 'RouteAmenity.Price'</summary>
				[DataMember]
				public System.Single Price { get; set; }
			}

			namespace RouteAmenityTypes
			{
				/// <summary> DTO class which is derived from the entity 'Amenity (PassengerAmenitySelections.RouteAmenity.Amenity)'.</summary>
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

		/// <summary> DTO class which is derived from the entity 'Person (Person)'.</summary>
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

}



