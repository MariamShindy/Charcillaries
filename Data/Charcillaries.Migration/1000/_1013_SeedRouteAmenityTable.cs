// namespace Charcillaries.Migration._1000;
//
// [Migration(1013)]
// public class _1013_SeedRouteAmenityTable : FluentMigrator.Migration
// {
//     private readonly List<RouteAmenity> _routeAmenities =
//     [
//
//         new RouteAmenity { id = 1, quantity = 10, price = 21.0f, flight_route_id = 3, amenity_id = 7 },
//         new RouteAmenity { id = 2, quantity = 10, price = 9.0f, flight_route_id = 3, amenity_id = 8 },
//         new RouteAmenity { id = 3, quantity = 10, price = 11.0f, flight_route_id = 3, amenity_id = 23 },
//         new RouteAmenity { id = 4, quantity = 10, price = 20.0f, flight_route_id = 4, amenity_id = 1 },
//         new RouteAmenity { id = 5, quantity = 10, price = 40.0f, flight_route_id = 4, amenity_id = 2 },
//         new RouteAmenity { id = 6, quantity = 10, price = 50.0f, flight_route_id = 4, amenity_id = 20 },
//         new RouteAmenity { id = 7, quantity = 10, price = 10.0f, flight_route_id = 5, amenity_id = 5 },
//         new RouteAmenity { id = 8, quantity = 10, price = 30.0f, flight_route_id = 5, amenity_id = 6 },
//         new RouteAmenity { id = 9, quantity = 10, price = 40.0f, flight_route_id = 5, amenity_id = 22 },
//         new RouteAmenity { id = 10, quantity = 10, price = 10.0f, flight_route_id = 6, amenity_id = 10 },
//         new RouteAmenity { id = 11, quantity = 10, price = 10.0f, flight_route_id = 6, amenity_id = 13},
//         new RouteAmenity { id = 12, quantity = 10, price = 40.0f, flight_route_id = 6, amenity_id = 25 },
//         new RouteAmenity { id = 13, quantity = 10, price = 10.0f, flight_route_id = 7, amenity_id = 11 },
//         new RouteAmenity { id = 14, quantity = 10, price = 10.0f, flight_route_id = 7, amenity_id = 14},
//         new RouteAmenity { id = 15, quantity = 10, price = 40.0f, flight_route_id = 7, amenity_id = 26 },
//         new RouteAmenity { id = 16, quantity = 10, price = 33.0f, flight_route_id = 9, amenity_id = 12 },
//         new RouteAmenity { id = 17, quantity = 10, price = 33.0f, flight_route_id = 10, amenity_id = 16 },
//         new RouteAmenity { id = 18, quantity = 10, price = 40.0f, flight_route_id = 10, amenity_id = 17 }
//         ];
//
//     public override void Up()
//     {
//         foreach (var routeAmenity in _routeAmenities)
//             Insert.IntoTable(Tables.RouteAmenity).Row(routeAmenity);
//        Execute.Sql("SELECT setval('route_amenity_id_seq', 10);");
//     }
//
//     public override void Down()
//     {
//
//     }
//
//     private record RouteAmenity
//     {
//         public int id { get; set; }
//         public int quantity { get; set; }
//         public float price { get; set; }
//         public int flight_route_id { get; set; }
//         public int amenity_id { get; set; }
//     }
// }