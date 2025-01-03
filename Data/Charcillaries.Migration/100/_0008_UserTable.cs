namespace Charcillaries.Migration._100;

[Migration(0008)]
public class _0008_UserTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.User)
            .AutoId()
            .WithColumn("password").AsString(200).NotNullable()
            .WithColumn("reset_token").AsString(256).Nullable()
            .WithColumn("reset_token_expiration").AsDateTime().Nullable()
            .IntForeignKeyIndexed("person_id", Tables.Person, false, false)
            .IntForeignKeyIndexed("role_id", Tables.Role, false, false)
            .IntForeignKeyIndexed("airline_id", Tables.Airline, true, false)
            .IntForeignKeyIndexed("tour_operator_id", Tables.TourOperator, true, false)
            .ObjectStatus();
    }
}