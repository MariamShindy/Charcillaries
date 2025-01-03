namespace Charcillaries.Migration._1000;

[Migration(1011)]
public class _1011_SeedPassengerAmenitySelectionTable : FluentMigrator.Migration
{
    public override void Up()
    {
        int[] generates = [100, 50, 25, 10, 5];

        var randomPassengerAmenitySelection = new List<PassengerAmenitySelection>();
        var iteration = 0;
        foreach (var number in generates)
        {
            var passengerAmenitySelectionId = 0;
            randomPassengerAmenitySelection.AddRange(new Faker<PassengerAmenitySelection>()
                .RuleFor(x => x.quantity, f => f.Random.Int(0, 100))
                .RuleFor(x => x.passenger_id, _ => passengerAmenitySelectionId + 1)
                .RuleFor(x => x.route_amenity_id, _ =>
                        passengerAmenitySelectionId++ % 10 * 5 + 1 + iteration
                // passengerAmenitySelectionId % 5 + passengerAmenitySelectionId++ / 25 * 5 + 1
                )
                .RuleFor(x => x.customization, f => f.Lorem.Sentence())
                .RuleFor(x => x.confirmed, f => 1)
                .Generate(number)
            );
            ++iteration;
        }

        foreach (var passengerAmenitySelection in randomPassengerAmenitySelection)
            Insert.IntoTable(Tables.PassengerAmenitySelection).Row(passengerAmenitySelection);
    }

    public override void Down()
    {
    }

    private record PassengerAmenitySelection
    {
        public int quantity { get; set; }
        public int passenger_id { get; set; }
        public int route_amenity_id { get; set; }
        public string customization { get; set; } = "";
        public int confirmed { get; set; }
    }
}