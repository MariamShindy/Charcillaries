namespace Charcillaries.Migration._1000;

[Migration(1010)]
public class _1010_SeedRouteAmenityTable : FluentMigrator.Migration
{
    public override void Up()
    {
        var routeAmenityDictionary = new Dictionary<int, HashSet<int>>();

        var routeId = 0;
        var randomTestRouteAmenity = new Faker<RouteAmenity>()
            .RuleFor(x => x.quantity, f => f.Random.Int(0, 100))
            .RuleFor(x => x.price, f => f.Random.Float(0, 10000))
            .RuleFor(x => x.flight_route_id, _ => routeId / 5 + 1)
            .RuleFor(x => x.amenity_id, _ => routeId / 25 * 5 + 1 + routeId++ % 5)
            .Generate(200);

        foreach (var routeAmenity in randomTestRouteAmenity)
            Insert.IntoTable(Tables.RouteAmenity).Row(routeAmenity);
    }

    public override void Down()
    {
    }

    private record RouteAmenity
    {
        public int quantity { get; set; }
        public float price { get; set; }
        public int flight_route_id { get; set; }
        public int amenity_id { get; set; }
    }
}