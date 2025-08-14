using MyRow = TaskManager.Administration.UserRow;
using MyRequest = TaskManager.Administration.UserListRequest;
using MyResponse = Serenity.Services.ListResponse<TaskManager.Administration.UserRow>;

namespace TaskManager.Administration;

public interface IUserListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class UserListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IUserListHandler
{
    public UserListHandler(IRequestContext context)
         : base(context)
    {
    }
}