namespace Charcillaries.Migration._1000;

[Migration(1016)]
public class _1016_SeedAmenityFeedbackTable : FluentMigrator.Migration
{
    public override void Up()
    {
        int[] generates = [25, 20];
        var randomRouteAmenityFeedback = new List<RouteAmenityFeedback>();

        foreach (var number in generates)
        {
            var routeAmenityFeedbackId = 0;
            randomRouteAmenityFeedback.AddRange(new Faker<RouteAmenityFeedback>()
                .RuleFor(x => x.rating, f => f.Random.Int(1, 5))
                .RuleFor(x => x.comment, f => f.Rant.Review())
                .RuleFor(x => x.date_created, f => f.Date.Past(2))
                .RuleFor(x => x.passenger_id, _ => routeAmenityFeedbackId / 5 + (number == 25 ? 1 : 6))
                .RuleFor(x => x.amenity_id, _ =>
                        routeAmenityFeedbackId++ % 5 + (number == 25 ? 1 : 6)
                // routeAmenityFeedbackId % 5 + routeAmenityFeedbackId++ / 25 * 5 + 1)
                )
                .Generate(number));
        }

        foreach (var routeAmenityFeedback in randomRouteAmenityFeedback)
            Insert.IntoTable(Tables.AmenityFeedback).Row(routeAmenityFeedback);
    }

    public override void Down()
    {
    }

    private record RouteAmenityFeedback
    {
        public int rating { get; set; }
        public DateTime date_created { get; set; }
        public string comment { get; set; } = "";
        public int passenger_id { get; set; }
        public int amenity_id { get; set; }
    }
}