using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Academic.Models.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IDepartmentProvider _departmentProvider;

        public DeleteDepartmentHandler(
            ApplicationDbContext context,
            IDepartmentProvider departmentProvider
        )
        {
            _context = context;
            _departmentProvider = departmentProvider;
        }

        public async Task<Unit> Handle(
            DeleteDepartmentCommand request,
            CancellationToken cancellationToken
        )
        {
            // Get the department
            var department = await _departmentProvider.GetByIdAsync(request.Id, cancellationToken);

            // Remove the department
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
