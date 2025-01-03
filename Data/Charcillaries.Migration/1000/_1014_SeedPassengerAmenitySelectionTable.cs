// namespace Charcillaries.Migration._1000;
//
// [Migration(1014)]
// public class _1014_SeedPassengerAmenitySelectionTable : FluentMigrator.Migration
// {
//     private readonly List<PassengerAmenitySelection> _passengerAmenities =
//     [
//        new PassengerAmenitySelection { id = 1, quantity = 1, passenger_id = 4, amenity_id = 7, customization = "Please ensure that the airport lounge has sufficient seating capacity and high-speed Wi-Fi access. We would also appreciate if complimentary snacks and beverages are available at all times." },
//        new PassengerAmenitySelection { id = 2, quantity = 1, passenger_id = 4, amenity_id = 8, customization = "Please include options for sparkling water and freshly brewed coffee." },
//         new PassengerAmenitySelection { id = 3, quantity = 1, passenger_id = 4, amenity_id = 23, customization = "Ensure that luggage is among the first to be delivered at the baggage claim. Also, please affix a ‘Priority’ label to the luggage for quick identification." },
//         new PassengerAmenitySelection { id = 4, quantity = 1, passenger_id = 10, amenity_id = 5, customization = "Please provide high-quality, noise-cancelling headphones that are compatible with the in-flight entertainment system. Extra ear cushions would be appreciated." },
//         new PassengerAmenitySelection { id = 5, quantity = 1, passenger_id = 10, amenity_id = 6, customization = "Ensure that the personal TV screens are in good working condition, with a wide variety of movies, TV shows, and games available. Please also provide instructions for using the entertainment system." },
//
//     ];
//
//     public override void Up()
//     {
//         foreach (var passengerAmenitySelection in _passengerAmenities)
//             Insert.IntoTable(Tables.PassengerAmenitySelection).Row(passengerAmenitySelection);
//        Execute.Sql("SELECT setval('passenger_amenity_selection_id_seq', 10);");
//     }
//
//     public override void Down()
//     {
//
//     }
//
//
//     private record PassengerAmenitySelection
//     {
//         public int id { get; set; }
//         public int quantity { get; set; }
//         public int passenger_id { get; set; }
//         public int amenity_id { get; set; }
//         public string customization { get; set; } = "";
//     }
// }