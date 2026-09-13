namespace Backend.Shared.Common.Utilities
{
    public static class Message
    {
        public static string InvalidMaxLength(string property, int value) =>
            $"{property} must not exceed {value} characters.";

        public static string InvalidMinLength(string property, int value) =>
            $"{property} must be at least {value} characters long.";

        public static string InvalidRange(string property, int minValue, int maxValue) =>
            $"{property} must be between {minValue} and {maxValue}.";

        public static string InvalidMinValue(string property, int minValue) =>
            $"{property} must be greater than or equal to {minValue}.";

        public static string InvalidMaxValue(string property, int maxValue) =>
            $"{property} must be less than or equal to {maxValue}.";

        public static string NotEmpty(string property) => $"{property} must not be empty.";

        public static string InvalidPattern(string property) =>
            $"{property} is not in a valid format.";

        public static string InvalidEnum(string property) =>
            $"Selected choice is invalid for {property}.";
    }
}
