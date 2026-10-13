using Backend.Features.Academic.Models.Institutions.Responses;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Shared.Exceptions;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.Institutions.Queries.GetInstitutionById
{
    public sealed class GetInstitutionByIdHandler
        : IRequestHandler<GetInstitutionByIdQuery, InstitutionResponseDto>
    {
        private readonly IInstitutionProvider _institutionProvider;

        public GetInstitutionByIdHandler(IInstitutionProvider provider)
        {
            _institutionProvider = provider;
        }

        public async Task<InstitutionResponseDto> Handle(
            GetInstitutionByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            // Get institution
            var institution = await _institutionProvider.GetByIdAsync(
                request.Id,
                cancellationToken
            );

            // Return the institution
            return institution.Adapt<InstitutionResponseDto>();
        }
    }
}
