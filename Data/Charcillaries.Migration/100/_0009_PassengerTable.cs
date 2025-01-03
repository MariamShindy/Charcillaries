namespace Charcillaries.Migration._100;

[Migration(0009)]
public class _0009_PassengerTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.Passenger)
            .AutoId()
            .WithColumn("payment_confirmation").AsString(255).Nullable()
            .WithColumn("payment_confirmation_date").AsDateTime().Nullable()
            .WithColumn("payment_amount").AsFloat().Nullable()
            .IntForeignKeyIndexed("person_id", Tables.Person, false, false)
            .IntForeignKeyIndexed("flight_id", Tables.Flight, false, false)
            .ObjectStatus();
    }
}