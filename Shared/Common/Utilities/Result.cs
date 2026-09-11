namespace Backend.Shared.Common.Utilities
{
    // It's base class for Result<T> and Result, so it can be used for both success and failure cases.
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;

        public Error? Error { get; }

        protected Result(bool isSuccess, Error? error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        // Factory methods for creating success and failure results.
        public static Result Success() => new(true, null);

        // Factory method for creating a failure result with an error.
        public static Result Failure(Error error) => new(false, error);
    }
}
