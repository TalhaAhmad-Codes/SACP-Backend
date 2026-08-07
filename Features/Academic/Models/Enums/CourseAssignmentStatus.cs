namespace Backend.Features.Academic.Models.Enums
{
    public enum CourseAssignmentStatus
    {
        Pending = 1, // * Assigned but not yet confirmed/started
        Active, // * Currently teaching the course
        Completed, // * Course finished successfully
        Cancelled, // * Assignment withdrawn or reassigned
    }
}
