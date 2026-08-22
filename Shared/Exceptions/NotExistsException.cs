namespace Backend.Shared.Exceptions
{
    // ? When the expected resource does not exist.
    public sealed class NotExistsException : Exception
    {
        public NotExistsException() : base() { }
        public NotExistsException(string message) : base(message) { }
    }
}
