using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Timely.Domain.Error;

namespace Timely.Api.Error;

public static class ValidationResultErrorExtensions
{
    extension(ValidationResultError error)
    {
        public ObjectResult ToProblem()
        {
            ArgumentNullException.ThrowIfNull(error);
            
            int status = error.Type switch
            {
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                _ => throw new UnreachableException($"Unbekannter {nameof(ErrorType)}: {error.Type}")
            };

            var errors = error.Errors
                .GroupBy(error => error.Field)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(error => error.Message).ToArray());

            ValidationProblemDetails problemDetails = new(errors)
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
