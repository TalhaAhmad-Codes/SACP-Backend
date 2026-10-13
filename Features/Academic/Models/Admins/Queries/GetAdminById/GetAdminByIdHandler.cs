using Backend.Features.Academic.Models.Admins.Responses;
using Backend.Features.Academic.Providers.Interfaces;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.Admins.Queries.GetAdminById
{
    public sealed class GetAdminByIdHandler : IRequestHandler<GetAdminByIdQuery, AdminResponseDto>
    {
        private readonly IAdminProvider _provider;

        public GetAdminByIdHandler(IAdminProvider provider)
        {
            _provider = provider;
        }

        public async Task<AdminResponseDto> Handle(
            GetAdminByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var admin = await _provider.GetByIdAsync(request.Id);
            return admin.Adapt<AdminResponseDto>();
        }
    }
}
