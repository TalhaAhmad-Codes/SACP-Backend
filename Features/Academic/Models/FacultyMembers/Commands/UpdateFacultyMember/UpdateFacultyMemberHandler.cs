using Backend.Features.Academic.Generators;
using Backend.Features.Academic.Models.Departments;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Features.Users.Models;
using Backend.Infrastructure.Persistence;
using MediatR;
using StackExchange.Redis;

namespace Backend.Features.Academic.Models.FacultyMembers.Commands.UpdateFacultyMember
{
    public sealed class UpdateFacultyMemberHandler
        : IRequestHandler<UpdateFacultyMemberCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IFacultyMemberProvider _provider;

        public UpdateFacultyMemberHandler(
            ApplicationDbContext context,
            IFacultyMemberProvider provider
        )
        {
            _context = context;
            _provider = provider;
        }

        public async Task<Unit> Handle(
            UpdateFacultyMemberCommand request,
            CancellationToken cancellationToken
        )
        {
            var faculty = await _provider.GetByIdAsync(request.Id, cancellationToken);

            if (
                faculty.DepartmentId != request.DepartmentId
                || faculty.DateOfJoining != request.DateOfJoining
            )
            {
                var accessCode = await AccessCode.Generate(
                    _context,
                    request.DateOfJoining,
                    request.DepartmentId
                );

                faculty.AccessCode = accessCode.ToString();
            }

            faculty.FirstName = request.FirstName;
            faculty.LastName = request.LastName;
            faculty.Role = request.Role;
            faculty.DateOfJoining = request.DateOfJoining;
            faculty.UserId = request.UserId;
            faculty.DepartmentId = request.DepartmentId;
            faculty.MarkUpdated();

            _context.FacultyMembers.Update(faculty);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
