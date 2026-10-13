using Backend.Features.Academic.Generators;
using Backend.Features.Academic.Models.FacultyMembers.Responses;
using Backend.Infrastructure.Persistence;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.FacultyMembers.Commands.CreateFacultyMember
{
    public sealed class CreateFacultyMemberHandler
        : IRequestHandler<CreateFacultyMemberCommand, FacultyMemberResponseDto>
    {
        private readonly ApplicationDbContext _context;

        public CreateFacultyMemberHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FacultyMemberResponseDto> Handle(
            CreateFacultyMemberCommand request,
            CancellationToken cancellationToken
        )
        {
            var accessCode = await AccessCode.Generate(
                _context,
                request.DateOfJoining,
                request.DepartmentId
            );

            FacultyMember faculty = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Role = request.Role,
                AccessCode = accessCode.ToString(),
                DateOfJoining = request.DateOfJoining,
                UserId = request.UserId,
                DepartmentId = request.DepartmentId,
            };

            await _context.FacultyMembers.AddAsync(faculty, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return faculty.Adapt<FacultyMemberResponseDto>();
        }
    }
}
