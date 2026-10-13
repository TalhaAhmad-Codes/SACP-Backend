using Backend.Features.Academic.Models.Sessions.Responses;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Common.Utilities;
using Backend.Shared.Exceptions;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.Sessions.Commands.CreateSession
{
    public sealed class CreateSessionHandler
        : IRequestHandler<CreateSessionCommand, SessionResponseDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly ISessionProvider _provider;

        public CreateSessionHandler(ApplicationDbContext context, ISessionProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        public async Task<SessionResponseDto> Handle(
            CreateSessionCommand request,
            CancellationToken cancellationToken
        )
        {
            var existsByName = await _provider.ExistsByNameAsync(request.Name, cancellationToken);

            if (existsByName)
                throw new InvalidRequestException(Message.AlreadyExists("Name"));

            Session session = new()
            {
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
            };

            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync(cancellationToken);

            return session.Adapt<SessionResponseDto>();
        }
    }
}
