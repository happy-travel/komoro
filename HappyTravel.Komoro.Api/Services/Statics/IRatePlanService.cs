namespace HappyTravel.Komoro.Api.Services.Statics;

public interface IRatePlanService
{
    public List<string> Get();
    bool IsExist(string ratePlanCode);
}
