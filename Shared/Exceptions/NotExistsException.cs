namespace Backend.Shared.Exceptions
{
    // When the expected resource does not exist.
    public sealed class NotExistsException : Exception
    {
        public NotExistsException(string entity)
            : base($"{entity} does not exist.") { }
    }
}
