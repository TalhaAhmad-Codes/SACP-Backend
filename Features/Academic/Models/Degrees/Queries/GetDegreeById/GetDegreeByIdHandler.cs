using Backend.Features.Academic.Models.Degrees.Responses;
using Backend.Features.Academic.Providers.Interfaces;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.Degrees.Queries.GetDegreeById
{
    public sealed class GetDegreeByIdHandler
        : IRequestHandler<GetDegreeByIdQuery, DegreeResponseDto>
    {
        private readonly IDegreeProvider _provider;

        public GetDegreeByIdHandler(IDegreeProvider provider)
        {
            _provider = provider;
        }

        public async Task<DegreeResponseDto> Handle(
            GetDegreeByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var degree = await _provider.GetByIdAsync(request.Id);
            return degree.Adapt<DegreeResponseDto>();
        }
    }
}
