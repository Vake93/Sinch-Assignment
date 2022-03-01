using Microsoft.AspNetCore.Mvc;
using PolishNotation.API.Models;
using PolishNotation.API.Services.Cache;
using PolishNotation.API.Services.Evaluators;

namespace PolishNotation.API;

public static class Endpoints
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder builder)
    {
        builder
            .MapPost("/api/v1/npn", Evaluate)
            .Produces<EvalutateResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest);

        return builder;
    }

    internal static IResult Evaluate(
        [FromBody] EvalutateRequest request,
        [FromServices] IExpressionCache cache)
    {
        if (string.IsNullOrEmpty(request.Expression))
        {
            return Results.BadRequest(new ProblemDetails
            {
                Title = "Expression required",
                Detail = "A valid polish notation expression is required",
            });
        }

        if (!cache.TryGetValue(request.Expression, out var result))
        {
            result = PolishNotationEvaluator.Evaluate(request.Expression);
            cache.Set(request.Expression, result);
        }

        if (result.HasValue)
        {
            return Results.Ok(new EvalutateResponse
            {
                Result = result.Value,
            });
        }

        return Results.BadRequest(new ProblemDetails
        {
            Title = "Invalid Expression",
            Detail = "Input is not a valid polish notation expression",
        });
    }
}
