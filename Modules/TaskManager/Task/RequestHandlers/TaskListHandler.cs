using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<TaskManager.TaskManager.TaskRow>;
using MyRow = TaskManager.TaskManager.TaskRow;

namespace TaskManager.TaskManager;

public interface ITaskListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class TaskListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ITaskListHandler
{
    public TaskListHandler(IRequestContext context)
            : base(context)
    {
    }
}