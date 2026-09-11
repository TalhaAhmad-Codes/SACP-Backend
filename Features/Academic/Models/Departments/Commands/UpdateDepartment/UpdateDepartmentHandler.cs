using Backend.Features.Academic.Generators;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Academic.Models.Departments.Commands.UpdateDepartment
{
    public sealed class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IDepartmentProvider _departmentProvider;

        public UpdateDepartmentHandler(
            ApplicationDbContext context,
            IDepartmentProvider departmentProvider
        )
        {
            _context = context;
            _departmentProvider = departmentProvider;
        }

        public async Task<Unit> Handle(
            UpdateDepartmentCommand request,
            CancellationToken cancellationToken
        )
        {
            // Get the department
            var department = await _departmentProvider.GetByIdAsync(request.Id, cancellationToken);

            // Check if department exists by given name
            var existsByName = await _departmentProvider.ExistsByNameAsync(
                request.Name,
                cancellationToken
            );

            if (existsByName)
            {
                throw new InvalidDataException(
                    $"Department with name '{request.Name}' already exists."
                );
            }

            // Get department code
            var code = department.Code;

            // Check department name and generate new code if the first three letters are not same
            if (!department.Name[..3].Equals(request.Name[..3], StringComparison.OrdinalIgnoreCase))
            {
                code = await DepartmentCode.GenerateAsync(
                    request.Name,
                    _context,
                    cancellationToken
                );
            }

            // Update the department
            department.Name = request.Name;
            department.Description = request.Description;
            department.Code = code;
            department.MarkUpdated();

            // Save changes
            _context.Departments.Update(department);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
