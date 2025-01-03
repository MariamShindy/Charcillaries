namespace Charcillaries.Migration._100;

[Migration(0014)]
public class _0014_AmenityFeedbackTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.AmenityFeedback)
            .AutoId()
            .WithColumn("rating").AsInt32().Nullable()
            .WithColumn("date_created").AsDateTime().NotNullable()
            .WithColumn("comment").AsString().Nullable() // convert comment from int to string
            .IntForeignKeyIndexed("passenger_id", Tables.Passenger, false, false)
            .IntForeignKeyIndexed("amenity_id", Tables.Amenity, false, false)
            .ObjectStatus();

        Create.UniqueConstraint("uq_passenger_id_amenity_id")
            .OnTable(Tables.AmenityFeedback)
            .Columns("passenger_id", "amenity_id");
    }
}