namespace Charcillaries.Migration._100;

[Migration(0007)]
public class _0007_RoleTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.Role)
            .AutoId()
            .WithColumn("name").AsString(200).NotNullable()
            .ObjectStatus();
    }
}