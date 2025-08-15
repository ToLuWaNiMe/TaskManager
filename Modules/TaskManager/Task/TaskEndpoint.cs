using Serenity.Reporting;
using System.Globalization;
using TaskManager.Modules.TaskManager.Task;
using MyRow = TaskManager.TaskManager.TaskRow;

namespace TaskManager.TaskManager.Endpoints;

[Route("Services/TaskManager/Task/[action]")]
[ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
public class TaskEndpoint : ServiceEndpoint
{
    private readonly ISqlConnections connections;

    public TaskEndpoint(ISqlConnections connections)
    {
        this.connections = connections;
    }

    public IEnumerable<TaskSummaryResult> Generate(IUnitOfWork uow, TaskSummaryRequest request)
    {
        var sql = @"SELECT 
                            Priority = CASE Priority 
                                WHEN 1 THEN 'Low' 
                                WHEN 2 THEN 'Medium' 
                                WHEN 3 THEN 'High' END,
                            Count = COUNT(*),
                            Completed = SUM(CASE WHEN IsCompleted = 1 THEN 1 ELSE 0 END)
                        FROM Tasks
                        WHERE DueDate BETWEEN @start AND @end
                        GROUP BY Priority";

        return Dapper.SqlMapper.Query<TaskSummaryResult>(uow.Connection, sql, new
        {
            start = request.StartDate ?? DateTime.MinValue,
            end = request.EndDate ?? DateTime.MaxValue
        });
    }

    [HttpPost, AuthorizeCreate(typeof(MyRow))]
    public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] ITaskSaveHandler handler)
    {
        return handler.Create(uow, request);
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] ITaskSaveHandler handler)
    {
        return handler.Update(uow, request);
    }
 
    [HttpPost, AuthorizeDelete(typeof(MyRow))]
    public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
        [FromServices] ITaskDeleteHandler handler)
    {
        return handler.Delete(uow, request);
    }

    [HttpPost]
    public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
        [FromServices] ITaskRetrieveHandler handler)
    {
        return handler.Retrieve(connection, request);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
        [FromServices] ITaskListHandler handler)
    {
        return handler.List(connection, request);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
        [FromServices] ITaskListHandler handler,
        [FromServices] IExcelExporter exporter)
    {
        var data = List(connection, request, handler).Entities;
        var bytes = exporter.Export(data, typeof(Columns.TaskColumns), request.ExportColumns);
        return ExcelContentResult.Create(bytes, "TaskList_" +
            DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
    }
}