namespace HappyTravel.Komoro.Api.Services.Statics;

public interface IRatePlanService
{
    List<string> Get();
    bool IsExist(string ratePlanCode);
}
