using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Timely.Domain.Error;

namespace Timely.Api.Error;

public static class ResultErrorExtensions
{
    extension(ResultError error)
    {
        public ObjectResult ToProblem()
        {
            ArgumentNullException.ThrowIfNull(error);

            int status = error.Type switch
            {
                ErrorType.Failure => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                ErrorType.Forbidden => StatusCodes.Status403Forbidden,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Unexpected => StatusCodes.Status500InternalServerError,

                _ => throw new UnreachableException($"Unbekannter {nameof(ErrorType)}: {error.Type}")
            };

            ProblemDetails problemDetails = new()
            {
                Title = error.Title,
                Status = status,
                Detail = error.Detail,
            };

            problemDetails.Extensions.Add("code", error.Code);

            return new ObjectResult(problemDetails) 
            { 
                StatusCode = status
            };
        }
    }
}
