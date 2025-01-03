namespace Charcillaries.Migration._1000;

[Migration(1000)]
public class _1000_SeedPersonTable : FluentMigrator.Migration
{
    public override void Up()
    {
        var personId = 1;
        var passengerCount = 1;
        var airlineCount = 1;
        var tourOperatorCount = 1;
        var randomPerson = new Faker<Person>()
            .RuleFor(x => x.first_name, f => f.Name.FirstName())
            .RuleFor(x => x.last_name, f => f.Name.LastName())
            .Rules((_, x) =>
            {
                x.email = personId++ switch
                {
                    1 => "admin@gmail.com",
                    <= 11 => $"passenger{passengerCount++}@gmail.com",
                    <= 21 => $"tourOperator{tourOperatorCount++}@gmail.com",
                    _ => $"airline{airlineCount++}@gmail.com"
                };
            })
            .RuleFor(x => x.phone_number, f => f.PickRandom(
                f.Phone.PhoneNumber("+20 11########"),
                f.Phone.PhoneNumber("+20 10########"),
                f.Phone.PhoneNumber("+20 12########"),
                f.Phone.PhoneNumber("+20 15########")
            ))
            .RuleFor(x => x.passport_number, f => f.PickRandom(
                f.Random.Replace("??#######"),
                f.Random.Replace("?########"),
                f.Random.ReplaceNumbers("#########")
            ))
            .Generate(31);

        foreach (var person in randomPerson)
            Insert.IntoTable(Tables.Person).Row(person);
        //Adding RealEmail to test forgot password
        var person1 = new Person
        {
            first_name = "Mariam",
            last_name = "Shindy",
            email = "mariam.shendy411@gmail.com",
            phone_number = "20 01014147350",
            passport_number = ""
        };
        personId++;
        var person2 = new Person
        {
            first_name = "Jana",
            last_name = "Ashraf",
            email = "janaashraff1234@gmail.com",
            phone_number = "20 01145256841",
            passport_number = ""
        };
        Insert.IntoTable(Tables.Person).Row(person1);
        Insert.IntoTable(Tables.Person).Row(person2);
    }

    public override void Down()
    {
    }

    private record Person
    {
        public string first_name { get; set; } = "";
        public string last_name { get; set; } = "";
        public string email { get; set; } = "";
        public string phone_number { get; set; } = "";
        public string passport_number { get; set; } = "";
    }
}