namespace Charcillaries.Migration._1000;

[Migration(1005)]
public class _1005_SeedFlightTable : FluentMigrator.Migration
{
    public override void Up()
    {
        var flightId = 0;
        var randomFlights = new Faker<Flight>()
            .RuleFor(x => x.flight_number, f => f.Random.Replace("??####"))
            .RuleFor(x => x.flight_route_id, _ => flightId % 10 + 1)
            .RuleFor(x => x.tour_operator_id, _ => flightId++ % 10 + 1)
            .Rules((f, x) =>
            {
                x.departure_date = f.PickRandom(f.Date.Future(), f.Date.Past());
                x.arrival_date = x.departure_date.AddHours(f.Random.Int(1, 10));
            })
            .RuleFor(x => x.number_of_seats, f => f.Random.Int(100, 300))
            .Generate(20);

        foreach (var flight in randomFlights)
            Insert.IntoTable(Tables.Flight).Row(flight);
    }

    public override void Down()
    {
    }

    private record Flight
    {
        public string flight_number { get; set; } = String.Empty;
        public int flight_route_id { get; set; }
        public int tour_operator_id { get; init; }
        public DateTime departure_date { get; set; }
        public DateTime arrival_date { get; set; }
        public int number_of_seats { get; set; }
    }
}