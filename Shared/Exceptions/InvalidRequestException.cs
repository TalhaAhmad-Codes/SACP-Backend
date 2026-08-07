namespace Backend.Shared.Exceptions
{
    // ? When the request can't be processed due to invalid data or operation.
    public sealed class InvalidRequestException : Exception
    {
        public InvalidRequestException(string message) : base(message) { }
    }
}
