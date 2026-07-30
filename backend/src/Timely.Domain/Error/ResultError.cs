namespace Timely.Domain.Error
{
    public sealed class ResultError : FluentResults.Error
    {
        public string Title { get; }
        public ErrorType Type { get; }
        public string Detail { get; }
        public string Code { get; }

        private ResultError(
            string title,
            ErrorType type,
            string detail,
            string code) : base(detail)
        {
            Title = title;
            Type = type;
            Detail = detail;
            Code = code;
        }

        public static ResultError Failure(
            string detail,
            string title = "Anfrage fehlgeschlagen",
            string code = "General.Failure")
            => Create(title, ErrorType.Failure, detail, code);

        public static ResultError NotFound(
            string detail,
            string title = "Ressource nicht gefunden",
            string code = "General.NotFound")
            => Create(title, ErrorType.NotFound, detail, code);

        public static ResultError Unauthorized(
            string detail,
            string title = "Nicht authentifiziert",
            string code = "General.Unauthorized")
            => Create(title, ErrorType.Unauthorized, detail, code);

        public static ResultError Forbidden(
            string detail,
            string title = "Keine Berechtigung",
            string code = "General.Forbidden")
            => Create(title, ErrorType.Forbidden, detail, code);

        public static ResultError Conflict(
            string detail,
            string title = "Konflikt",
            string code = "General.Conflict")
            => Create(title, ErrorType.Conflict, detail, code);

        public static ResultError Unexpected(
            string detail,
            string title = "Unerwarteter Fehler",
            string code = "General.Unexpected")
            => Create(title, ErrorType.Unexpected, detail, code);

        private static ResultError Create(
            string title,
            ErrorType type,
            string detail,
            string code)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(detail);
            ArgumentException.ThrowIfNullOrWhiteSpace(title);
            ArgumentException.ThrowIfNullOrWhiteSpace(code);

            return new ResultError(title, type, detail, code);
        }
    }
}
