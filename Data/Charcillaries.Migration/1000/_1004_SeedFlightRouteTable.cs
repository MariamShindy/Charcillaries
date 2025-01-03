using System.Net.Http.Json;

namespace Charcillaries.Migration._1000;

[Migration(1004)]
public class _1004_SeedFlightRouteTable : FluentMigrator.Migration
{
    private static async Task<List<Airports>?> GetAirportCodes()
    {
        var client = new HttpClient();
        var airportCodesJson =
            await client.GetFromJsonAsync<List<Airports>>("https://api.travelpayouts.com/data/en/airports.json");

        return airportCodesJson;
    }

    public override void Up()
    {
        var airportCodes = GetAirportCodes().Result;

        var flightRouteId = 0;
        var randomFlightRoutes = new Faker<FlightRoute>()
            .RuleFor(x => x.airline_id, _ => flightRouteId++ / 5 + 1)
            .Rules((f, x) =>
            {
                x.departure_airport = f.PickRandom(airportCodes).Code;
                do
                {
                    x.arrival_airport = f.PickRandom(airportCodes).Code;
                } while (x.departure_airport == x.arrival_airport);
            })
            .Generate(50);

        foreach (var flightRoute in randomFlightRoutes)
            Insert.IntoTable(Tables.FlightRoute).Row(flightRoute);
    }

    public override void Down()
    {
    }

    private record FlightRoute
    {
        public int airline_id { get; set; }
        public string departure_airport { get; set; } = "";
        public string arrival_airport { get; set; } = "";
    }

    private record Airports(
        string Code
    );
}