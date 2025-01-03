namespace Charcillaries.Migration._1000;

[Migration(1003)]
public class _1003_SeedTourOperatorAirlineTable : FluentMigrator.Migration
{
    public override void Up()
    {
        var oneToTen = Enumerable.Range(1, 10).ToArray();
        var f = new Faker();

        var tourOperatorIds = f.Random.Shuffle(oneToTen).ToArray();
        var airlineIds = f.Random.Shuffle(oneToTen).ToArray();

        for (var i = 0; i < 10; i++)
            for (var j = 0; j < 10; j++)
                Insert.IntoTable(Tables.TourOperatorAirline).Row(new TourOperatorAirline
                {
                    tour_operator_id = tourOperatorIds[i],
                    airline_id = airlineIds[j]
                });
    }

    public override void Down()
    {
    }

    private record TourOperatorAirline
    {
        public int tour_operator_id { get; init; }
        public int airline_id { get; init; }
    }
}