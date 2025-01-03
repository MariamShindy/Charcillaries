namespace Charcillaries.Migration._100;

[Migration(0006)]
public class _0006_FlightTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.Flight)
            .AutoId()
            .WithColumn("flight_number").AsString(10).NotNullable()
            .IntForeignKeyIndexed("flight_route_id", Tables.FlightRoute, false, false)
            .IntForeignKeyIndexed("tour_operator_id", Tables.TourOperator, false, false)
            .WithColumn("departure_date").AsDateTime().NotNullable()
            .WithColumn("arrival_date").AsDateTime().NotNullable()
            .WithColumn("number_of_seats").AsInt32().NotNullable()
            .ObjectStatus();
    }
}