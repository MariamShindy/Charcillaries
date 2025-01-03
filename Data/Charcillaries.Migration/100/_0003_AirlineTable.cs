namespace Charcillaries.Migration._100;

[Migration(0003)]
public class _0003_AirlineTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.Airline)
            .AutoId()
            .WithColumn("name").AsString(255).NotNullable()
            .WithColumn("contact_info").AsString(255).NotNullable()
            .WithColumn("email").AsString(255).NotNullable()
            .ObjectStatus();
    }
}