namespace Backend.Shared.Common
{
    public static class Message
    {
        public static string InvalidMaxLength(string property, int value)
            => $"{property} must not exceed {value} characters.";

        public static string InvalidMinLength(string property, int value)
            => $"{property} must be at least {value} characters long.";

        public static string NotEmpty(string property)
            => $"{property} must not be empty.";

        public static string InvalidPattern(string property)
            => $"{property} is not in a valid format.";
    }
}
