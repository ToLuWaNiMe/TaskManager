using FluentMigrator;

namespace TaskManager.Migrations.DefaultDB
{
    [Migration(20241208001)]
    public class DefaultDB_20241208_001_Tasks : Migration
    {
        public override void Up()
        {
            Create.Table("Tasks")
                .WithColumn("TaskId").AsInt32().Identity().PrimaryKey()
                .WithColumn("Title").AsString(100).NotNullable()
                .WithColumn("Description").AsString(500).Nullable()
                .WithColumn("DueDate").AsDateTime().NotNullable()
                .WithColumn("TaskPriority").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("IsCompleted").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("InsertDate").AsDateTime().WithDefaultValue(SystemMethods.CurrentDateTime);
        }

        public override void Down()
        {
            Delete.Table("Tasks");
        }
    }
}