using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace TaskManager.TaskManager.Pages;

[PageAuthorize(typeof(TaskRow))]
public class TaskPage : Controller
{
    [Route("TaskManager/Task")]
    public ActionResult Index()
    {
        return this.GridPage<TaskRow>("@/TaskManager/Task/TaskPage");
    }
}