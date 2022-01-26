using CSharpFunctionalExtensions;
using FluentValidation;
using HappyTravel.Komoro.Api.Infrastructure;
using HappyTravel.Komoro.Api.Infrastructure.ModelExtensions;
using HappyTravel.Komoro.Data;
using Microsoft.EntityFrameworkCore;
using ApiModels = HappyTravel.Komoro.Api.Models;
using DataModels = HappyTravel.Komoro.Data.Models.Statics;

namespace HappyTravel.Komoro.Api.Services;

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
            .Tap(Add);


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
            .Bind(() => Get(mealPlanId, cancellationToken))
            .Tap(Update);


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
            v.RuleFor(r => r.Name).NotEmpty();
        },
        mealPlan);


    private async Task<Result<DataModels.MealPlan>> Get(int mealPlanId, CancellationToken cancellationToken)
    {
        var mealPlan = await _komoroContext.MealPlans.SingleOrDefaultAsync(r => r.Id == mealPlanId, cancellationToken);
        
        return mealPlan is not null
            ? mealPlan
            : Result.Failure<DataModels.MealPlan>($"Meal plan with id {mealPlanId} not found");
    }


    private readonly KomoroContext _komoroContext;
}
