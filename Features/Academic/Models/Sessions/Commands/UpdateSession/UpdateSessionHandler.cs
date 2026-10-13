using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Common.Utilities;
using Backend.Shared.Exceptions;
using MediatR;

namespace Backend.Features.Academic.Models.Sessions.Commands.UpdateSession
{
    public sealed class UpdateSessionHandler : IRequestHandler<UpdateSessionCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly ISessionProvider _provider;

        public UpdateSessionHandler(ApplicationDbContext context, ISessionProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        public async Task<Unit> Handle(
            UpdateSessionCommand request,
            CancellationToken cancellationToken
        )
        {
            var existsByName = await _provider.ExistsByNameAsync(request.Name, cancellationToken);

            if (existsByName)
                throw new InvalidRequestException(Message.AlreadyExists("Name"));

            var session = await _provider.GetByIdAsync(request.Id, cancellationToken);

            session.Name = request.Name;
            session.StartDate = request.StartDate;
            session.EndDate = request.EndDate;
            session.MarkUpdated();

            _context.Sessions.Update(session);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
