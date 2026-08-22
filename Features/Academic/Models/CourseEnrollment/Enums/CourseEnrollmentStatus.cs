namespace Backend.Features.Academic.Models.CourseEnrollment.Enums
{
    public enum CourseEnrollmentStatus
    {
        Pending = 1, // * Enrollment requested / awaiting approval
        Enrolled, // * Successfully enrolled
        Dropped, // * Student withdrew from the course
        Completed, // * Course successfully finished
    }
}
