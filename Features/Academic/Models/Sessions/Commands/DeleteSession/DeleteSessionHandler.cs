using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Academic.Models.Sessions.Commands.DeleteSession
{
    public sealed class DeleteSessionHandler : IRequestHandler<DeleteSessionCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly ISessionProvider _provider;

        public DeleteSessionHandler(ApplicationDbContext context, ISessionProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        public async Task<Unit> Handle(
            DeleteSessionCommand request,
            CancellationToken cancellationToken
        )
        {
            var session = await _provider.GetByIdAsync(request.Id, cancellationToken);

            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
