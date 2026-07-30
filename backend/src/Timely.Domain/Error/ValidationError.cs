namespace Timely.Domain.Error
{
    public sealed record ValidationError
    {
        public string Field { get; }
        public string Message { get; }

        private ValidationError(string field, string message)
        {
            Field = field;
            Message = message;
        }

        public static ValidationError Create(string field, string message)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(field);
            ArgumentException.ThrowIfNullOrWhiteSpace(message);

            return new ValidationError(field, message);
        }
    }
}
