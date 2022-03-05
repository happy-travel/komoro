using CSharpFunctionalExtensions;
using HappyTravel.Komoro.Common.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.Komoro.Common.Controllers;

public class BaseController : ControllerBase
{
    protected IActionResult NoContentOrBadRequest(Result model)
    {
        var (_, isFailure, error) = model;
        if (isFailure)
            return BadRequest(ProblemDetailsBuilder.Build(error));

        return NoContent();
    }


    protected IActionResult OkOrBadRequest<T>(Result<T> model)
    {
        var (_, isFailure, response, error) = model;
        if (isFailure)
            return BadRequest(ProblemDetailsBuilder.Build(error));

        return Ok(response);
    }
}
