using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace HappyTravel.Komoro.Api.Infrastructure.FunctionalExtensions;

public static class ResultTransactionExtensions
{
    public static async Task<Result> BindWithTransaction<T>(
        this Task<Result<T>> target,
        DbContext context,
        Func<T, Task<Result>> f)
    {
        var (_, isFailure, result, error) = await target;
        if (isFailure)
            return Result.Failure(error);

        return await WithTransactionScope(context, () => f(result));
    }


    private static Task<TResult> WithTransactionScope<TResult>(DbContext context, Func<Task<TResult>> operation)
        where TResult : CSharpFunctionalExtensions.IResult
    {
        var strategy = context.Database.CreateExecutionStrategy();
        return strategy.ExecuteAsync((object)null!,
            async (dbContext, state, cancellationToken) =>
            {
                    // Nested transaction support. We can commit only on a top-level
                    var transaction = dbContext.Database.CurrentTransaction is null
                    ? await dbContext.Database.BeginTransactionAsync(cancellationToken)
                    : null;
                try
                {
                    var result = await operation();
                    if (result.IsSuccess)
                        transaction?.Commit();

                    return result;
                }
                finally
                {
                    transaction?.Dispose();
                }
            },
            // This delegate is not used in NpgSql.
            null);
    }
}
