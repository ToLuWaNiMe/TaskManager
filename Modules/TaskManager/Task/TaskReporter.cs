namespace TaskManager.Modules.TaskManager.Task;

public class TaskSummaryResult
{
    public string Priority { get; set; }
    public int Count { get; set; }
    public int Completed { get; set; }
}

public class TaskReporter
{
    public IEnumerable<TaskSummaryResult> Execute(IUnitOfWork uow, TaskSummaryRequest request)
    {
        var sql = @"SELECT 
                        Priority = CASE Priority WHEN 1 THEN 'Low' WHEN 2 THEN 'Medium' WHEN 3 THEN 'High' END,
                        Count = COUNT(*),
                        Completed = SUM(CASE WHEN IsCompleted = 1 THEN 1 ELSE 0 END)
                    FROM Tasks
                    WHERE DueDate BETWEEN @start AND @end
                    GROUP BY Priority";

        var result = Dapper.SqlMapper.Query<TaskSummaryResult>(uow.Connection, sql, new
        {
            start = request.StartDate ?? DateTime.MinValue,
            end = request.EndDate ?? DateTime.MaxValue
        });

        return result;
    }
}
