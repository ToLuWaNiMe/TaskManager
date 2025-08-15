namespace TaskManager.Modules.TaskManager.Task;

public class TaskSummaryRequest : ServiceRequest
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
