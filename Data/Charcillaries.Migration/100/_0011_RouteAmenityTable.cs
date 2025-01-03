namespace Charcillaries.Migration._100;

[Migration(0011)]
public class _0011_RouteAmenityTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.RouteAmenity)
            .AutoId()
            .WithColumn("quantity").AsInt32().Nullable()
            .WithColumn("price").AsFloat().NotNullable()
            .IntForeignKeyIndexed("flight_route_id", Tables.FlightRoute, false, false)
            .IntForeignKeyIndexed("amenity_id", Tables.Amenity, false, false)
            .ObjectStatus();
        Create.UniqueConstraint("uq_flight_route_id_amenity_id")
          .OnTable(Tables.RouteAmenity)
          .Columns("flight_route_id", "amenity_id");
    }
}