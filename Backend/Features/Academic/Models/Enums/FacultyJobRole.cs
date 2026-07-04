namespace Backend.Features.Academic.Models.Enums
{
    public enum FacultyJobRole
    {
        // * Teaching Staff
        Lecturer = 1,
        AssistantProfessor,
        Professor,

        // * Department Administration
        HeadOfDepartment,

        // * Institution Administration
        Registrar,
        ControllerOfExaminations,
        Principal,
        VicePrincipal,
        ViceChancellor,
        Chancellor,

        // * Support and Student Affairs
        LabInstructor,

        // * Others
        // Librarian,
        // Counselor,
        Other,
    }
}
