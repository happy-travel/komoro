using CSharpFunctionalExtensions;
using FluentValidation;
using HappyTravel.Komoro.Api.Infrastructure;
using HappyTravel.Komoro.Api.Infrastructure.ModelExtensions.Statics;
using HappyTravel.Komoro.Data;
using Microsoft.EntityFrameworkCore;
using ApiModels = HappyTravel.KomoroContracts.Statics;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Services.Statics;

public class MealPlanService : IMealPlanService
{
    public MealPlanService(KomoroContext komoroContext)
    {
        _komoroContext = komoroContext;
    }


    public async Task<List<ApiModels.MealPlan>> Get(CancellationToken cancellationToken)
    {
        return await _komoroContext.MealPlans.Select(mp => mp.ToApiMealPlan())
            .ToListAsync(cancellationToken);
    }


    public async Task<Result> Add(ApiModels.MealPlan apiMealPlan, CancellationToken cancellationToken)
    {
        return await Validate(apiMealPlan)
            .Ensure(() => MealPlanHasNoDuplicates(apiMealPlan), "Adding meal plan has duplicate")
            .Tap(Add);


        async Task<bool> MealPlanHasNoDuplicates(ApiModels.MealPlan mealPlan)
            => !await _komoroContext.MealPlans.Where(mp => mp.Name == mealPlan.Name)
                .AnyAsync(cancellationToken);


        async Task Add()
        {
            var utcNow = DateTimeOffset.UtcNow;
            var mealPlan = new DataModels.MealPlan
            {
                Name = apiMealPlan.Name,
                Created = utcNow,
                Modified = utcNow
            };

            _komoroContext.MealPlans.Add(mealPlan);
            await _komoroContext.SaveChangesAsync(cancellationToken);
        }
    }


    public async Task<Result> Modify(int mealPlanId, ApiModels.MealPlan apiMealPlan, CancellationToken cancellationToken)
    {
        return await Validate(apiMealPlan)
            .Ensure(() => MealPlanHasNoDuplicates(apiMealPlan), "Modifiable meal plan has duplicate")
            .Bind(() => Get(mealPlanId, cancellationToken))
            .Tap(Update);


        async Task<bool> MealPlanHasNoDuplicates(ApiModels.MealPlan mealPlan)
            => !await _komoroContext.MealPlans.Where(mp => mp.Name == mealPlan.Name && mp.Id != mealPlanId)
                .AnyAsync(cancellationToken);


        async Task Update(DataModels.MealPlan mealPlan)
        {
            mealPlan.Name = apiMealPlan.Name;
            mealPlan.Modified = DateTimeOffset.UtcNow;

            _komoroContext.MealPlans.Update(mealPlan);
            await _komoroContext.SaveChangesAsync(cancellationToken);
        }
    }


    public async Task<Result> Remove(int mealPlanId, CancellationToken cancellationToken)
    {
        return await Get(mealPlanId, cancellationToken)
            .Tap(Remove);


        async Task Remove(DataModels.MealPlan mealPlan)
        {
            _komoroContext.MealPlans.Remove(mealPlan);
            await _komoroContext.SaveChangesAsync(cancellationToken);
        }
    }


    private static Result Validate(ApiModels.MealPlan mealPlan)
        => GenericValidator<ApiModels.MealPlan>.Validate(v =>
        {
            v.RuleFor(mp => mp.Name).NotEmpty();
        },
        mealPlan);


    private async Task<Result<DataModels.MealPlan>> Get(int mealPlanId, CancellationToken cancellationToken)
    {
        var mealPlan = await _komoroContext.MealPlans.SingleOrDefaultAsync(mp => mp.Id == mealPlanId, cancellationToken);
        
        return mealPlan is not null
            ? mealPlan
            : Result.Failure<DataModels.MealPlan>($"Meal plan with id {mealPlanId} not found");
    }


    private readonly KomoroContext _komoroContext;
}
