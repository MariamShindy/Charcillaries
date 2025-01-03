namespace Charcillaries.Migration._100;

[Migration(0005)]
public class _0005_FlightRouteTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.FlightRoute)
            .AutoId()
            .IntForeignKeyIndexed("airline_id", Tables.Airline, false, false)
            .WithColumn("departure_airport").AsString(3).NotNullable()
            .WithColumn("arrival_airport").AsString(3).NotNullable()
            .ObjectStatus();
        Create.UniqueConstraint("uq_depatrure_airport_arrival_airport")
          .OnTable(Tables.FlightRoute)
          .Columns("departure_airport", "arrival_airport", "airline_id");
    }
}