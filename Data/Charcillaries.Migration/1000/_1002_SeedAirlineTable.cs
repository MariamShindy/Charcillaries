using System.Net.Http.Json;

namespace Charcillaries.Migration._1000;

[Migration(1002)]
public class _1002_SeedAirlineTable : FluentMigrator.Migration
{
    private static async Task<List<AirlineResponse>?> GetAirlineNames()
    {
        var client = new HttpClient();
        var airlineCodesJson =
            await client.GetFromJsonAsync<List<AirlineResponse>>("https://api.travelpayouts.com/data/en/airlines.json");

        return airlineCodesJson;
    }

    public override void Up()
    {
        var airlinesCodes = GetAirlineNames().Result;

        var randomAirlines = new Faker<Airline>()
            .RuleFor(x => x.name, f => f.PickRandom(airlinesCodes).Name)
            .RuleFor(x => x.contact_info, f => f.Phone.PhoneNumber())
            .RuleFor(x => x.email, f => f.Internet.Email())
            .RuleFor(x => x.contact_info, f => f.PickRandom(
                f.Phone.PhoneNumber("+20 11########"),
                f.Phone.PhoneNumber("+20 10########"),
                f.Phone.PhoneNumber("+20 12########"),
                f.Phone.PhoneNumber("+20 15########")
            )).Generate(10);

        foreach (var airline in randomAirlines)
            Insert.IntoTable(Tables.Airline).Row(airline);
    }

    public override void Down()
    {
    }

    private record Airline
    {
        public string name { get; set; } = "";
        public string contact_info { get; set; } = "";
        public string email { get; set; } = "";
    }

    private record AirlineResponse(
        string Name
    );
}