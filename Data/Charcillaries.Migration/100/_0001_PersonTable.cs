namespace Charcillaries.Migration._100;

[Migration(0001)]
public class _0001_PersonTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.Person)
            .AutoId()
            .WithColumn("first_name").AsString(50).NotNullable()
            .WithColumn("last_name").AsString(50).NotNullable()
            .WithColumn("email").AsString(255).NotNullable()
            .WithColumn("phone_number").AsString(30).Nullable()
            .WithColumn("passport_number").AsString(50).Nullable()
            .ObjectStatus();
    }
}