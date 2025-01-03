namespace Charcillaries.Migration._100;

[Migration(0012)]
public class _0012_PassengerAmenitySelectionTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.PassengerAmenitySelection)
            .AutoId()
            .WithColumn("quantity").AsInt32().Nullable().WithDefaultValue(0)
            .WithColumn("customization").AsString().Nullable()
            .WithColumn("confirmed").AsInt32().Nullable().WithDefaultValue(0)
            .IntForeignKeyIndexed("passenger_id", Tables.Passenger, false, false)
            .IntForeignKeyIndexed("route_amenity_id", Tables.RouteAmenity, false, false)
            .ObjectStatus();
    }
}