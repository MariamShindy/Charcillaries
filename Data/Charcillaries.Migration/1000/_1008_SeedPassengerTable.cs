namespace Charcillaries.Migration._1000;

[Migration(1008)]
public class _1008_SeedPassengerTable : FluentMigrator.Migration
{
    public override void Up()
    {
        var passengerId = 0;

        var randomPassengers = new Faker<Passenger>()
            // .RuleFor(x => x.payment_confirmation, f => f.Random.AlphaNumeric(9))
            // .RuleFor(x => x.payment_confirmation_date, f => f.Date.Past())
            // .RuleFor(x => x.payment_amount, f => f.Random.Float(0, 3000))
            .RuleFor(x => x.person_id, _ => passengerId / 20 + 2)
            .RuleFor(x => x.flight_id, (_, x) => passengerId++ % 20 + 1)
            .Generate(100);

        foreach (var passenger in randomPassengers)
            Insert.IntoTable(Tables.Passenger).Row(passenger);
    }

    public override void Down()
    {
    }

    private record Passenger
    {
        public string payment_confirmation { get; set; } = "";
        public DateTime? payment_confirmation_date { get; set; }
        public float? payment_amount { get; set; }
        public int person_id { get; set; }
        public int flight_id { get; set; }
    }
}