using MyRow = TaskManager.Administration.LanguageRow;
using MyRequest = Serenity.Services.SaveRequest<TaskManager.Administration.LanguageRow>;
using MyResponse = Serenity.Services.SaveResponse;


namespace TaskManager.Administration;

public interface ILanguageSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }
public class LanguageSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ILanguageSaveHandler
{
    public LanguageSaveHandler(IRequestContext context)
         : base(context)
    {
    }
}