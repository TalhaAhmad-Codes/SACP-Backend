using Backend.Features.Academic.Models.Sessions.Responses;
using Backend.Features.Academic.Providers.Interfaces;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.Sessions.Queries.GetSessionById
{
    public sealed class GetSessionByIdHandler
        : IRequestHandler<GetSessionByIdQuery, SessionResponseDto>
    {
        private readonly ISessionProvider _provider;

        public GetSessionByIdHandler(ISessionProvider provider)
        {
            _provider = provider;
        }

        public async Task<SessionResponseDto> Handle(
            GetSessionByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var session = await _provider.GetByIdAsync(request.Id, cancellationToken);
            return session.Adapt<SessionResponseDto>();
        }
    }
}
