﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.10.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Charcillaries.Data.Views.DtoClasses
{ 
	/// <summary> DTO class which is derived from the entity 'User'.</summary>
	[Serializable]
	[DataContract]
	public partial class UserView
	{
		/// <summary>Gets or sets the AirlineId field. Derived from Entity Model Field 'User.AirlineId (FK)'</summary>
		[DataMember]
		public Nullable<System.Int32> AirlineId { get; set; }
		/// <summary>Gets or sets the Password field. Derived from Entity Model Field 'User.Password'</summary>
		[DataMember]
		public System.String Password { get; set; }
		/// <summary>Gets or sets the Person field. </summary>
		[DataMember]
		public UserViewTypes.Person Person { get; set; }
		/// <summary>Gets or sets the PersonId field. Derived from Entity Model Field 'User.PersonId (FK)'</summary>
		[DataMember]
		public System.Int32 PersonId { get; set; }
		/// <summary>Gets or sets the ResetToken field. Derived from Entity Model Field 'User.ResetToken'</summary>
		[DataMember]
		public System.String ResetToken { get; set; }
		/// <summary>Gets or sets the ResetTokenExpiration field. Derived from Entity Model Field 'User.ResetTokenExpiration'</summary>
		[DataMember]
		public Nullable<System.DateTime> ResetTokenExpiration { get; set; }
		/// <summary>Gets or sets the Role field. </summary>
		[DataMember]
		public UserViewTypes.Role Role { get; set; }
		/// <summary>Gets or sets the TourOperatorId field. Derived from Entity Model Field 'User.TourOperatorId (FK)'</summary>
		[DataMember]
		public Nullable<System.Int32> TourOperatorId { get; set; }
	}

	namespace UserViewTypes
	{
		/// <summary> DTO class which is derived from the entity 'Person (Person)'.</summary>
		[Serializable]
		[DataContract]
		public partial class Person
		{
			/// <summary>Gets or sets the Email field. Derived from Entity Model Field 'Person.Email'</summary>
			[DataMember]
			public System.String Email { get; set; }
		}

		/// <summary> DTO class which is derived from the entity 'Role (Role)'.</summary>
		[Serializable]
		[DataContract]
		public partial class Role
		{
			/// <summary>Gets or sets the Name field. Derived from Entity Model Field 'Role.Name'</summary>
			[DataMember]
			public System.String Name { get; set; }
		}
	}

}




