using Backend.Features.Academic.Providers;
using Backend.Features.Academic.Providers.Interfaces;

namespace Backend.Shared.Extensions;

public static class ProviderExtensions
{
    public static IServiceCollection AddProviders(
        this IServiceCollection services)
    {
        // * Academic Data
        services.AddScoped<IInstitutionProvider, InstitutionProvider>();
        services.AddScoped<IAdminProvider, AdminProvider>();
        services.AddScoped<IFacultyMemberProvider, FacultyMemberProvider>();
        services.AddScoped<IStudentProvider, StudentProvider>();
        services.AddScoped<IDepartmentProvider, DepartmentProvider>();
        services.AddScoped<ICourseProvider, CourseProvider>();
        services.AddScoped<ICourseAssignmentProvider, CourseAssignmentProvider>();
        services.AddScoped<IExamProvider, ExamProvider>();
        services.AddScoped<IExamResultProvider, ExamResultProvider>();
        services.AddScoped<ILectureProvider, LectureProvider>();

        return services;
    }
}
