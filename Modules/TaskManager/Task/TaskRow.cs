using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;

namespace TaskManager.TaskManager;

[ConnectionKey("Default"), Module("TaskManager"), TableName("Tasks")]
[DisplayName("Tasks"), InstanceName("Task")]
[ReadPermission("Administration:General")]
[ModifyPermission("Administration:General")]
[ServiceLookupPermission("Administration:General")]
public sealed class TaskRow : Row<TaskRow.RowFields>, IIdRow, INameRow
{
    [DisplayName("Task Id"), Identity, IdProperty]
    public int? TaskId { get => fields.TaskId[this]; set => fields.TaskId[this] = value; }

    [DisplayName("Title"), Size(100), NotNull, QuickSearch, NameProperty]
    public string Title { get => fields.Title[this]; set => fields.Title[this] = value; }

    [DisplayName("Description"), Size(500)]
    public string Description { get => fields.Description[this]; set => fields.Description[this] = value; }

    [DisplayName("Due Date"), NotNull]
    public DateTime? DueDate { get => fields.DueDate[this]; set => fields.DueDate[this] = value; }

    [DisplayName("Priority"), DefaultValue(1)]
    public TaskPriority? Priority { get => (TaskPriority?)fields.Priority[this]; set => fields.Priority[this] = (int?)value; }

    [DisplayName("Is Completed"), NotNull]
    public bool? IsCompleted { get => fields.IsCompleted[this]; set => fields.IsCompleted[this] = value; }

    [DisplayName("Insert Date")]
    public DateTime? InsertDate { get => fields.InsertDate[this]; set => fields.InsertDate[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field TaskId;
        public StringField Title;
        public StringField Description;
        public DateTimeField DueDate;
        public Int32Field Priority;
        public BooleanField IsCompleted;
        public DateTimeField InsertDate;

    }

}

public enum TaskPriority
{
    Low = 1,
    Medium = 2,
    High = 3
}