namespace Backend.Shared.Common.FixedValue
{
    public static class MinValue
    {
        // User
        public static int Password => 8;
        public static int Username => 3;

        // Pagination
        public static int PageNumber => 1;
        public static int PageSize => 10;
    }

    public static class MaxValue
    {
        // User
        public static int Password => 255;
        public static int Username => 100;
        public static int Email => 255;
        public static int Token => 512;
    }
}
