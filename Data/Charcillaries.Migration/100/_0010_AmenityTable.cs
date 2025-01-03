namespace Charcillaries.Migration._100;

[Migration(0010)]
public class _0010_AmenityTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.Amenity)
            .AutoId()
            .WithColumn("name").AsString(255).NotNullable()
            .WithColumn("description").AsString(255).NotNullable()
            .WithColumn("icon").AsGuid().Nullable()
            .IntForeignKeyIndexed("airline_id", Tables.Airline, false, false)
            .ObjectStatus();
    }
}