﻿using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HappyTravel.Komoro.Api.Infrastructure;

public static class ProblemDetailsBuilder
{
    public static ProblemDetails Build(string details, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new()
        {
            Detail = details,
            Status = (int)statusCode
        };
}
