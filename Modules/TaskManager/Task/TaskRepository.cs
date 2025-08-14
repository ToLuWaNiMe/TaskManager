using TaskManager.TaskManager;

namespace TaskManager.Modules.TaskManager.Task;

public class TaskRepository : BaseRepository
{
    public TaskRepository(IRequestContext context) : base(context) {}
    private static TaskRow.RowFields Fld => TaskRow.Fields;

    public SaveResponse Create(IUnitOfWork uow, SaveRequest<TaskRow> request) =>
        new TaskSaveHandler(Context).Process(uow, request, SaveRequestType.Create);
}
