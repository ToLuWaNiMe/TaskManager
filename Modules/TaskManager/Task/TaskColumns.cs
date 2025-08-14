using Serenity.ComponentModel;
using System;
using System.ComponentModel;

namespace TaskManager.TaskManager.Columns;

[ColumnsScript("TaskManager.Task")]
[BasedOnRow(typeof(TaskRow), CheckNames = true)]
public class TaskColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int TaskId { get; set; }
    [EditLink]
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public int Priority { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime InsertDate { get; set; }
}