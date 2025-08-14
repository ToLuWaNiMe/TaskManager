using Serenity.ComponentModel;
using System;

namespace TaskManager.TaskManager.Forms;

[FormScript("TaskManager.Task")]
[BasedOnRow(typeof(TaskRow), CheckNames = true)]
public class TaskForm
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public int Priority { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime InsertDate { get; set; }
}