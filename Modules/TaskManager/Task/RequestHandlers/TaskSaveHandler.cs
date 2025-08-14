using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<TaskManager.TaskManager.TaskRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = TaskManager.TaskManager.TaskRow;

namespace TaskManager.TaskManager;

public interface ITaskSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class TaskSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ITaskSaveHandler
{
    public TaskSaveHandler(IRequestContext context) : base(context) {}

    protected override void ValidateRequest()
    {
        base.ValidateRequest();

        if (Row.DueDate < DateTime.Today)
            throw new ValidationError("DueDateError",
                "Due date cannot be in the past!");
        if(Row.Priority == TaskPriority.High &&
            Row.DueDate > DateTime.Today.AddDays(3))
        {
            throw new ValidationError("HighPriorityRule",
                "High Priority tasks must be due within 3 days!");
        }
    }

    protected override void BeforeSave()
    {
        base.BeforeSave();
        Row.InsertDate = DateTime.Now;
    }
}