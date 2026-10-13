namespace Backend.Shared.Common.Utilities
{
    public static class MinValue
    {
        // User
        public static int Password => 8;
        public static int Username => 3;

        // Degree
        public static int DegreeTitle => 15;
        public static int DegreeCode => 2;

        // Course
        public static int CourseTitle => 3;
        public static int CourseCode => 2;

        // Session
        public static int SessionName => 5;

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
        public static int PersonFullName => 101;
        public static int InstitutionName => 200;
        public static int DepartmentName => 100;
        public static int Description => 150;

        // User
        public static int Password => 255;
        public static int Username => 50;
        public static int Email => 255;
        public static int RefreshToken => 512;

        // Degree
        public static int DegreeTitle => 75;
        public static int DegreeCode => 6;

        // Course
        public static int CourseTitle => 120;
        public static int CourseCode => 10;

        // Session
        public static int SessionName => 25;

        // Pagination
        public static int PageSize => 25;
    }
}
