using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Timely.Domain.Error;

namespace Timely.Api.Error
{
    public static class ResultExtensions
    {
        extension(Result result)
        {
            public ObjectResult ToProblem()
            {
                ArgumentNullException.ThrowIfNull(result);

                if (result.IsSuccess) 
                    throw new InvalidOperationException($"{nameof(ToProblem)} darf nicht für ein IsSucess Result aufgerufen werden.");

                IError error = result.Errors.OfType<IError>().FirstOrDefault()
                    ?? throw new ArgumentException($"{nameof(result)} muss mindestens einen Fehlertyp {nameof(IError)} enthalten.");

                return error switch
                {
                    ResultError resultError => resultError.ToProblem(),
                    ValidationResultError validationResultError => validationResultError.ToProblem(),
                    _ => throw new InvalidOperationException($"Der Fehlertyp {error.GetType().Name} wird nicht unterstützt.")
                };
            }
        }
    }
}
