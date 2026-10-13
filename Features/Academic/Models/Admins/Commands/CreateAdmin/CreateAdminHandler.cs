using Backend.Features.Academic.Models.Admins.Responses;
using Backend.Infrastructure.Persistence;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.Admins.Commands.CreateAdmin
{
    public sealed class CreateAdminHandler : IRequestHandler<CreateAdminCommand, AdminResponseDto>
    {
        private readonly ApplicationDbContext _context;

        public CreateAdminHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdminResponseDto> Handle(
            CreateAdminCommand request,
            CancellationToken cancellationToken
        )
        {
            Admin admin = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserId = request.UserId,
                InstitutionId = request.InstitutionId,
            };

            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync(cancellationToken);

            return admin.Adapt<AdminResponseDto>();
        }
    }
}
