using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<TaskManager.TaskManager.TaskRow>;
using MyRow = TaskManager.TaskManager.TaskRow;

namespace TaskManager.TaskManager;

public interface ITaskRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class TaskRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ITaskRetrieveHandler
{
    public TaskRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}