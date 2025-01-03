namespace Charcillaries.Migration._100;

[Migration(0004)]
public class _0004_TourOperatorAirlineTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.TourOperatorAirline)
            .IntForeignKeyIndexed("tour_operator_id", Tables.TourOperator, false, true)
            .IntForeignKeyIndexed("airline_id", Tables.Airline, false, true)
            .ObjectStatus();
    }
}