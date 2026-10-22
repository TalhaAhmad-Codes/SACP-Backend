using Backend.Features.Academic.Providers;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Features.Users.Providers;
using Backend.Features.Users.Providers.Interfaces;

namespace Backend.Shared.Extensions;

public static class ProviderExtensions
{
    public static IServiceCollection AddProviders(this IServiceCollection services)
    {
        /* <----- Users -----> */
        services.AddScoped<IUserProvider, UserProvider>();

        /* <----- Academic Data -----> */
        services.AddScoped<IInstitutionProvider, InstitutionProvider>();
        services.AddScoped<IDepartmentProvider, DepartmentProvider>();
        services.AddScoped<IAdminProvider, AdminProvider>();
        services.AddScoped<IFacultyMemberProvider, FacultyMemberProvider>();
        services.AddScoped<IStudentProvider, StudentProvider>();
        services.AddScoped<IDegreeProvider, DegreeProvider>();
        services.AddScoped<ISessionProvider, SessionProvider>();
        services.AddScoped<ICourseProvider, CourseProvider>();
        services.AddScoped<ICourseEnrollmentProvider, CourseEnrollmentProvider>();
        /*services.AddScoped<ICourseAssignmentProvider, CourseAssignmentProvider>();
        services.AddScoped<IExamProvider, ExamProvider>();
        services.AddScoped<IExamResultProvider, ExamResultProvider>();
        services.AddScoped<ILectureProvider, LectureProvider>();*/

        return services;
    }
}
