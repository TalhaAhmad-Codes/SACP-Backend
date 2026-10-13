using Backend.Features.Academic.Models.Institutions;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Features.Users.Models;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Academic.Models.Admins.Commands.UpdateAdmin
{
    public sealed class UpdateAdminHandler : IRequestHandler<UpdateAdminCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IAdminProvider _provider;

        public UpdateAdminHandler(ApplicationDbContext context, IAdminProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        public async Task<Unit> Handle(
            UpdateAdminCommand request,
            CancellationToken cancellationToken
        )
        {
            var admin = await _provider.GetByIdAsync(request.Id);

            admin.FirstName = request.FirstName;
            admin.LastName = request.LastName;
            admin.UserId = request.UserId;
            admin.InstitutionId = request.InstitutionId;
            admin.MarkUpdated();

            _context.Admins.Update(admin);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
