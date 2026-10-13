using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Academic.Models.Admins.Commands.DeleteAdmin
{
    public sealed class DeleteAdminHandler : IRequestHandler<DeleteAdminCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IAdminProvider _provider;

        public DeleteAdminHandler(ApplicationDbContext context, IAdminProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        public async Task<Unit> Handle(
            DeleteAdminCommand request,
            CancellationToken cancellationToken
        )
        {
            var admin = await _provider.GetByIdAsync(request.Id);

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
