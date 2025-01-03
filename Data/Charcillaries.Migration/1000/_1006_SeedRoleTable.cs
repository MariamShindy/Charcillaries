namespace Charcillaries.Migration._1000;

[Migration(1006)]
public class _1006_SeedRoleTable : FluentMigrator.Migration
{
    private readonly List<Role> _roles =
    [
        new Role(1, "Admin"),
        new Role(2, "Passenger"),
        new Role(3, "Tour Operator"),
        new Role(4, "Airline")
    ];

    public override void Up()
    {
        foreach (var role in _roles)
            Insert.IntoTable(Tables.Role).Row(role);
    }

    public override void Down()
    {
    }

    private record Role(int id, string name);
}