namespace HappyTravel.Komoro.Api.Services.Statics;

public interface IRatePlanService
{
    Task<bool> IsExist(string ratePlanCode);
}
