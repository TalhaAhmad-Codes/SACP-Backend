namespace Backend.Shared.Common.Utilities
{
    public static class MinValue
    {
        // User
        public static int Password => 8;
        public static int Username => 3;

        // Course
        public static int CourseTitle => 3;
        public static int CourseCode => 2;

        // General
        public static int PersonName => 3;
        public static int DepartmentName => 3;
        public static int Description => 5;

        // Pagination
        public static int PageNumber => 1;
        public static int PageSize => 5;
    }

    public static class MaxValue
    {
        // General
        public static int PersonName => 50;
        public static int PersonFullName => 100;
        public static int InstitutionName => 200;
        public static int DepartmentName => 100;
        public static int Description => 150;

        // User
        public static int Password => 255;
        public static int Username => 50;
        public static int Email => 255;
        public static int RefreshToken => 512;

        // Course
        public static int CourseTitle => 120;
        public static int CourseCode => 10;

        // Pagination
        public static int PageSize => 25;
    }
}
