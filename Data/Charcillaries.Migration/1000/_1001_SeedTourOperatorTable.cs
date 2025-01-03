namespace Charcillaries.Migration._1000;

[Migration(1001)]
public class _1001_SeedTourOperatorTable : FluentMigrator.Migration
{
    public override void Up()
    {
        var randomTourOperator = new Faker<TourOperator>()
            .RuleFor(x => x.name, f => f.Company.CompanyName())
            .RuleFor(x => x.contact_info, f => f.PickRandom(
                f.Phone.PhoneNumber("+20 11########"),
                f.Phone.PhoneNumber("+20 10########"),
                f.Phone.PhoneNumber("+20 12########"),
                f.Phone.PhoneNumber("+20 15########")
            ))
            .Generate(10);

        foreach (var tourOperator in randomTourOperator)
            Insert.IntoTable(Tables.TourOperator).Row(tourOperator);
    }

    public override void Down()
    {
    }

    private record TourOperator
    {
        public string name { get; set; } = "";
        public string contact_info { get; set; } = "";
    }
}