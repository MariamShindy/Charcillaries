namespace Charcillaries.Migration._100;

[Migration(0002)]
public class _0002_TourOperatorTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table(Tables.TourOperator)
            .AutoId()
            .WithColumn("name").AsString(255).NotNullable()
            .WithColumn("contact_info").AsString(255).NotNullable()
            .ObjectStatus();
    }
}