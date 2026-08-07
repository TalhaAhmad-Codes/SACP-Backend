namespace Backend.Shared.Common
{
    // ? This class represents the result of an operation that can either succeed with a value of type T or fail with an error.
    public class Result<T> : Result
        where T : class
    {
        public T? Value { get; }

        private Result(T value)
            : base(true, null)
        {
            Value = value;
        }

        private Result(Error error)
            : base(false, error) { }

        // * Factory method for creating a success result with a value.
        public static Result<T> Success(T value) => new(value);

        // * Factory method for creating a failure result with an error.
        public static new Result<T> Failure(Error error) => new(error);
    }
}
