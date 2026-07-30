namespace Timely.Domain.Error
{
    public sealed class ValidationResultError : FluentResults.Error
    {
        public string Title { get; }
        public ErrorType Type { get; }
        public string Detail { get; }
        public string Code { get; }
        public IReadOnlyCollection<ValidationError> Errors { get; }

        private ValidationResultError(
            string title,
            ErrorType type,
            string detail,
            string code,
            IReadOnlyCollection<ValidationError> errors) : base(detail)
        {
            Title = title;
            Type = type;
            Detail = detail;
            Code = code;
            Errors = errors;
        }

        public static ValidationResultError Create(
            string detail,
            IReadOnlyCollection<ValidationError> errors,
            string title = "Validierung fehlgeschlagen",
            string code = "General.Validation")
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(detail);
            ArgumentException.ThrowIfNullOrWhiteSpace(title);
            ArgumentException.ThrowIfNullOrWhiteSpace(code);
            ArgumentNullException.ThrowIfNull(errors);

            if (errors.Count == 0)
                throw new ArgumentException("Mindestens ein Validierungsfehler muss angegeben werden.", nameof(errors));

            var copiedErrors = Array.AsReadOnly(errors.ToArray());

            return new ValidationResultError(
                title,
                ErrorType.Validation,
                detail,
                code,
                copiedErrors);
        }
    }
}
