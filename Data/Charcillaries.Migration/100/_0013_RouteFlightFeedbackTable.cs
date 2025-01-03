namespace Charcillaries.Migration._100;

[Migration(0013)]
public class _0013_RouteFlightFeedbackTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.RouteFlightFeedback)
            .AutoId()
            .WithColumn("rating").AsInt32().Nullable()
            .WithColumn("date_created").AsDateTime().NotNullable()
            .WithColumn("comment").AsString().Nullable() // convert comment from int to string
            .IntForeignKeyIndexed("passenger_id", Tables.Passenger, false, false).Unique("passenger_id_feedback")
            .IntForeignKeyIndexed("flight_id", Tables.Flight, false, false)
            .ObjectStatus();
    }
}