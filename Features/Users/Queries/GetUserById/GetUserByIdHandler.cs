using Backend.Features.Users.Providers.Interfaces;
using Backend.Features.Users.Responses;
using Backend.Shared.Exceptions;
using Mapster;
using MediatR;

namespace Backend.Features.Users.Queries.GetUserById
{
    public sealed class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponseDto>
    {
        private readonly IUserProvider _userProvider;

        public GetUserByIdHandler(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        public async Task<UserResponseDto> Handle(
            GetUserByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var user = await _userProvider.GetByIdAsync(request.Id, cancellationToken);
            return user.Adapt<UserResponseDto>();
        }
    }
}
