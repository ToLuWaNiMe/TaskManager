using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<TaskManager.TaskManager.TaskRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = TaskManager.TaskManager.TaskRow;

namespace TaskManager.TaskManager;

public interface ITaskSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class TaskSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ITaskSaveHandler
{
    public TaskSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}