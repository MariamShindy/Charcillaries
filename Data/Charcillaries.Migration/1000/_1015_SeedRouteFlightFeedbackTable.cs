namespace Charcillaries.Migration._1000;

[Migration(1015)]
public class _1015_SeedRouteFlightFeedbackTable : FluentMigrator.Migration
{
    public override void Up()
    {
        var routeFlightFeedbackId = 0;
        var randomRouteFlightFeedback = new Faker<RouteFlightFeedback>()
            .RuleFor(x => x.rating, f => f.Random.Int(1, 5))
            .RuleFor(x => x.comment, f => f.Rant.Review())
            .RuleFor(x => x.date_created, f => f.Date.Past(2))
            .RuleFor(x => x.passenger_id, _ => routeFlightFeedbackId + 1)
            .RuleFor(x => x.flight_id, _ => routeFlightFeedbackId++ % 20 + 1)
            .Generate(50);

        foreach (var routeFlightFeedback in randomRouteFlightFeedback)
            Insert.IntoTable(Tables.RouteFlightFeedback).Row(routeFlightFeedback);
    }

    public override void Down()
    {
    }

    private record RouteFlightFeedback
    {
        public int rating { get; set; }
        public DateTime date_created { get; set; }
        public string comment { get; set; } = "";
        public int passenger_id { get; set; }
        public int flight_id { get; set; }
    }
}