﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.10.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Charcillaries.Data.Views.DtoClasses
{ 
	/// <summary> DTO class which is derived from the entity 'Amenity'.</summary>
	[Serializable]
	[DataContract]
	public partial class AmenitiesListView
	{
		/// <summary>Gets or sets the AmenityFeedbacks field. </summary>
		[DataMember]
		public List<AmenitiesListViewTypes.AmenityFeedback> AmenityFeedbacks { get; set; }
		/// <summary>Gets or sets the Id field. Derived from Entity Model Field 'Amenity.Id'</summary>
		[DataMember]
		public System.Int32 Id { get; set; }
		/// <summary>Gets or sets the Name field. Derived from Entity Model Field 'Amenity.Name'</summary>
		[DataMember]
		public System.String Name { get; set; }
		/// <summary>Gets or sets the ObjectStatus field. Derived from Entity Model Field 'Amenity.ObjectStatus'</summary>
		[DataMember]
		public System.Int32 ObjectStatus { get; set; }
		/// <summary>Gets or sets the RouteAmenities field. </summary>
		[DataMember]
		public List<AmenitiesListViewTypes.RouteAmenity> RouteAmenities { get; set; }
	}

	namespace AmenitiesListViewTypes
	{
		/// <summary> DTO class which is derived from the entity 'AmenityFeedback (AmenityFeedbacks)'.</summary>
		[Serializable]
		[DataContract]
		public partial class AmenityFeedback
		{
			/// <summary>Gets or sets the Comment field. Derived from Entity Model Field 'AmenityFeedback.Comment'</summary>
			[DataMember]
			public System.String Comment { get; set; }
			/// <summary>Gets or sets the DateCreated field. Derived from Entity Model Field 'AmenityFeedback.DateCreated'</summary>
			[DataMember]
			public System.DateTime DateCreated { get; set; }
			/// <summary>Gets or sets the Id field. Derived from Entity Model Field 'AmenityFeedback.Id'</summary>
			[DataMember]
			public System.Int32 Id { get; set; }
			/// <summary>Gets or sets the ObjectStatus field. Derived from Entity Model Field 'AmenityFeedback.ObjectStatus'</summary>
			[DataMember]
			public System.Int32 ObjectStatus { get; set; }
			/// <summary>Gets or sets the PassengerId field. Derived from Entity Model Field 'AmenityFeedback.PassengerId (FK)'</summary>
			[DataMember]
			public System.Int32 PassengerId { get; set; }
			/// <summary>Gets or sets the Rating field. Derived from Entity Model Field 'AmenityFeedback.Rating'</summary>
			[DataMember]
			public Nullable<System.Int32> Rating { get; set; }
		}

		/// <summary> DTO class which is derived from the entity 'RouteAmenity (RouteAmenities)'.</summary>
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
			/// <summary>Gets or sets the PassengerAmenitySelections field. </summary>
			[DataMember]
			public List<RouteAmenityTypes.PassengerAmenitySelection> PassengerAmenitySelections { get; set; }
			/// <summary>Gets or sets the Price field. Derived from Entity Model Field 'RouteAmenity.Price'</summary>
			[DataMember]
			public System.Single Price { get; set; }
			/// <summary>Gets or sets the Quantity field. Derived from Entity Model Field 'RouteAmenity.Quantity'</summary>
			[DataMember]
			public Nullable<System.Int32> Quantity { get; set; }
		}

		namespace RouteAmenityTypes
		{
			/// <summary> DTO class which is derived from the entity 'PassengerAmenitySelection (RouteAmenities.PassengerAmenitySelections)'.</summary>
			[Serializable]
			[DataContract]
			public partial class PassengerAmenitySelection
			{
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
				/// <summary>Gets or sets the RouteAmenityId field. Derived from Entity Model Field 'PassengerAmenitySelection.RouteAmenityId (FK)'</summary>
				[DataMember]
				public System.Int32 RouteAmenityId { get; set; }
			}

			namespace PassengerAmenitySelectionTypes
			{
				/// <summary> DTO class which is derived from the entity 'RouteAmenity (RouteAmenities.PassengerAmenitySelections.RouteAmenity)'.</summary>
				[Serializable]
				[DataContract]
				public partial class RouteAmenity
				{
					/// <summary>Gets or sets the AmenityId field. Derived from Entity Model Field 'RouteAmenity.AmenityId (FK)'</summary>
					[DataMember]
					public System.Int32 AmenityId { get; set; }
				}
			}
		}
	}

}



