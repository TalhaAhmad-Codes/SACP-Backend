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

        public static string ZeroOrLess(string property) =>
            $"{property} can't be zero or negative.";

        public static string ProperRangeExclusive(string name) =>
            $"\"Min {name}\" must be less than \"Max {name}\"";

        public static string ProperRangeExclusive(string prop1, string prop2) =>
            $"{prop1} must be less than {prop2}";

        public static string ProperRangeInclusive(string name) =>
            $"\"Min {name}\" must be less than or equal to \"Max {name}\"";

        public static string ProperRangeInclusive(string prop1, string prop2) =>
            $"{prop1} must be less than or equal to {prop2}";

        public static string InvalidMinValue(string property, int minValue) =>
            $"{property} must be greater than or equal to {minValue}.";

        public static string InvalidMaxValue(string property, int maxValue) =>
            $"{property} must be less than or equal to {maxValue}.";

        public static string InvalidEnum(string name, Array values) =>
            $"{name} is invalid. Valid values are: {string.Join(", ", values)}.";

        public static string NotEmpty(string property) => $"{property} must not be empty.";

        public static string AlreadyExists(string property) => $"{property} already exists.";

        public static string Updated(string property) =>
            $"{property} has been updated successfully.";

        public static string Removed(string property) =>
            $"{property} has been removed successfully.";

        public static string MustPastDate(string property) =>
            $"{property} can only be set to past.";

        public static string MustPastDate(string property, string corresponding) =>
            $"{property} can only be set to past corresponding to {corresponding}.";

        public static string MustPastOrPresentDate(string property) =>
            $"{property} can only be set to today or past.";

        public static string MustPresentOrFutureDate(string property) =>
            $"{property} can only be set to today or future.";

        public static string InvalidPattern(string property) =>
            $"{property} is not in a valid format.";

        public static string InvalidEnum(string property) =>
            $"Selected choice is invalid for {property}.";
    }
}
