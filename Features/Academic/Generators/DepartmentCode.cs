using Backend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Academic.Generators
{
    public static class DepartmentCode
    {
        public static async Task<string> GenerateAsync(
            string name,
            ApplicationDbContext context,
            CancellationToken cancellationToken = default
        ) // BUG: It can break uniqueness if department name is updated or deleted. I'll fix it later... 😊
        {
            // Get count of first 3 characters of the supplied name
            var count = await context
                .Departments.AsNoTracking()
                .CountAsync(
                    d => EF.Functions.ILike(d.Name, $"{name.Substring(0, 3)}%"),
                    cancellationToken
                );

            // Generate department code -> DEPxx
            var code = $"{name[..3].ToUpper()}{count + 1:D2}";

            return code;
        }
    }
}
