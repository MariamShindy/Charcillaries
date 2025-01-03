﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.10.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Charcillaries.Data.Views.DtoClasses
{ 
	/// <summary> DTO class which is derived from the entity 'RouteAmenity'.</summary>
	[Serializable]
	[DataContract]
	public partial class RouteAmenityListView
	{
		/// <summary>Gets or sets the Amenity field. </summary>
		[DataMember]
		public RouteAmenityListViewTypes.Amenity Amenity { get; set; }
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

	namespace RouteAmenityListViewTypes
	{
		/// <summary> DTO class which is derived from the entity 'Amenity (Amenity)'.</summary>
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




