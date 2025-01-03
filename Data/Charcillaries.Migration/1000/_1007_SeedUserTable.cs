using Microsoft.AspNetCore.Identity;

namespace Charcillaries.Migration._1000;

[Migration(1007)]
public class _1007_SeedUserTable : FluentMigrator.Migration
{
    public override void Up()
    {
        var hasher = new PasswordHasher<string>();
        var userId = 1;
        var randomUsers = new Faker<User>()
            .RuleFor(x => x.person_id, _ => userId)
            .Rules((f, x) =>
            {
                x.role_id = userId++ switch
                {
                    1 => 1,
                    <= 11 => 2,
                    <= 21 => 3,
                    _ => 4
                };

                switch (x.role_id)
                {
                    case 4:
                        x.airline_id = userId - 22;
                        x.tour_operator_id = null;
                        x.password = hasher.HashPassword(string.Empty, "airline");
                        break;

                    case 3:
                        x.tour_operator_id = userId - 12;
                        x.airline_id = null;
                        x.password = hasher.HashPassword(string.Empty, "tourOperator");
                        break;

                    case 2:
                        x.airline_id = null;
                        x.tour_operator_id = null;
                        x.password = hasher.HashPassword(string.Empty, "passenger");
                        break;

                    default:
                        x.airline_id = null;
                        x.tour_operator_id = null;
                        x.password = hasher.HashPassword(string.Empty, "admin");
                        break;
                }
            })
            .Generate(31);

        foreach (var user in randomUsers)
            Insert.IntoTable(Tables.User).Row(user);
        //Adding RealEmail to test forgot password
        var user1 = new User
        {
            person_id = 32,
            airline_id = null,
            tour_operator_id = null,
            password = hasher.HashPassword(string.Empty, "mariam"),
            role_id = 2
        };
        userId++;
        var user2 = new User
        {
            person_id = 33,
            airline_id = null,
            tour_operator_id = null,
            password = hasher.HashPassword(string.Empty, "jana"),
            role_id = 2
        };
        Insert.IntoTable(Tables.User).Row(user1);
        Insert.IntoTable(Tables.User).Row(user2);
    }

    public override void Down()
    {
    }

    private record User
    {
        public string password { get; set; } = "";
        public int person_id { get; set; }
        public int role_id { get; set; }
        public int? airline_id { get; set; }
        public int? tour_operator_id { get; set; }
    }
}