// namespace Charcillaries.Migration._1000;
//
// [Migration(1012)]
// public class _1012_SeedAmenityTable : FluentMigrator.Migration
// {
//     private readonly List<Amenity> _amenities =
//     [
//         new Amenity { id = 1, name = "Meal", description = "In-flight meal service", airline_id = 1 },
//         new Amenity { id = 2, name = "Child Care", description = "Child care assistance during flight", airline_id = 1 },
//         new Amenity { id = 3, name = "Wi-Fi", description = "In-flight wireless internet", airline_id = 2 },
//         new Amenity { id = 4, name = "Extra Legroom", description = "Seats with extra legroom", airline_id = 2 },
//         new Amenity { id = 5, name = "In-Flight Entertainment", description = "Movies, music, and games", airline_id = 3 },
//         new Amenity { id = 6, name = "Priority Boarding", description = "Early boarding access", airline_id = 3 },
//         new Amenity { id = 7, name = "Lounge Access", description = "Access to airport lounges", airline_id = 4 },
//         new Amenity { id = 8, name = "Complimentary Drinks", description = "Free beverages during flight", airline_id = 4 },
//         new Amenity { id = 9, name = "USB Charging", description = "USB ports for device charging", airline_id = 5 },
//         new Amenity { id = 10, name = "Blankets and Pillows", description = "Comfort items for passengers", airline_id = 6 },
//         new Amenity { id = 11, name = "Headphones", description = "Noise-cancelling headphones", airline_id = 7 },
//         new Amenity { id = 12, name = "In-Seat Power", description = "Power outlets at every seat", airline_id = 8 },
//         new Amenity { id = 13, name = "Free Checked Bag", description = "One complimentary checked bag", airline_id = 6 },
//         new Amenity { id = 14, name = "Personal TV", description = "Individual television screens", airline_id = 7 },
//         new Amenity { id = 15, name = "Reclining Seats", description = "Seats that recline for comfort", airline_id = 8 },
//         new Amenity { id = 16, name = "Pet Friendly", description = "Accommodations for pets", airline_id = 9 },
//          new Amenity { id = 17, name = "Welcome Drink", description = "Complimentary welcome drink", airline_id = 9 },
//         new Amenity { id = 18, name = "Extra Baggage Allowance", description = "Additional baggage allowance", airline_id = 10 },
//         new Amenity { id = 19, name = "Noise Reduction Earplugs", description = "Earplugs for noise reduction", airline_id = 10 },
//         new Amenity { id = 20, name = "Travel Kit", description = "Comfort travel kit", airline_id = 1 },
//         new Amenity { id = 21, name = "Onboard Library", description = "Access to books and magazines", airline_id = 2 },
//         new Amenity { id = 22, name = "Massage Chairs", description = "In-flight massage chairs", airline_id = 3 },
//         new Amenity { id = 23, name = "Priority Luggage Handling", description = "Fast-tracked luggage handling", airline_id = 4 },
//         new Amenity { id = 24, name = "Hot Towels", description = "Hot towels for refreshment", airline_id = 5 },
//         new Amenity { id = 25, name = "Dedicated Attendant", description = "Personal flight attendant service", airline_id = 6 },
//         new Amenity { id = 26, name = "Extended Recline", description = "Seats with extended recline", airline_id = 7 }
//         ];
//
//     public override void Up()
//     {
//         foreach (var amenity in _amenities)
//             Insert.IntoTable(Tables.Amenity).Row(amenity);
//          Execute.Sql("SELECT setval('amenity_id_seq', 10);");
//     }
//
//     public override void Down()
//     {
//
//     }
//
//     private record Amenity
//     {
//         public int id { get; set; }
//         public string name { get; set; } = "";
//         public string description { get; set; } = "";
//         public int airline_id { get; set; }
//     }
// }