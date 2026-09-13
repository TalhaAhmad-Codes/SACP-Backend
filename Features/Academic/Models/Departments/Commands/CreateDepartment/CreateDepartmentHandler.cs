using Backend.Features.Academic.Generators;
using Backend.Features.Academic.Models.Departments.Responses;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Exceptions;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.Departments.Commands.CreateDepartment
{
    public sealed class CreateDepartmentHandler
        : IRequestHandler<CreateDepartmentCommand, DepartmentResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IDepartmentProvider _departmentProvider;

        public CreateDepartmentHandler(
            ApplicationDbContext context,
            IDepartmentProvider departmentProvider
        )
        {
            _context = context;
            _departmentProvider = departmentProvider;
        }

        public async Task<DepartmentResponse> Handle(
            CreateDepartmentCommand request,
            CancellationToken cancellationToken
        )
        {
            // Check if the department already exists
            var existsByName = await _departmentProvider.ExistsByNameAsync(
                request.Name,
                cancellationToken
            );

            if (existsByName)
            {
                throw new InvalidRequestException(
                    $"A department with the name '{request.Name}' already exists."
                );
            }

            // Create the new department and its code
            var deptCode = await DepartmentCode.GenerateAsync(
                request.Name,
                _context,
                cancellationToken
            );

            var department = new Department
            {
                Name = request.Name,
                Description = request.Description,
                Code = deptCode,
                InstitutionId = request.InstitutionId,
            };

            // Add the department to the database
            _context.Departments.Add(department);
            await _context.SaveChangesAsync(cancellationToken);

            // Return the created department as a response
            return department.Adapt<DepartmentResponse>();
        }
    }
}
