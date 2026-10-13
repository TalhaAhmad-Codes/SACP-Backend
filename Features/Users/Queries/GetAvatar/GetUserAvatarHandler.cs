using Backend.Features.Users.Providers.Interfaces;
using Backend.Features.Users.Responses;
using Backend.Shared.Exceptions;
using Mapster;
using MediatR;

namespace Backend.Features.Users.Queries.GetAvatar
{
    public sealed class GetUserAvatarHandler
        : IRequestHandler<GetUserAvatarQuery, UserAvatarResponseDto>
    {
        private readonly IUserProvider _userProvider;

        public GetUserAvatarHandler(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        public async Task<UserAvatarResponseDto> Handle(
            GetUserAvatarQuery request,
            CancellationToken cancellationToken
        )
        {
            var user = await _userProvider.GetByIdAsync(request.Id, cancellationToken);

            if (user.Avatar is null || string.IsNullOrWhiteSpace(user.Avatar.ContentType))
            {
                throw new InvalidRequestException("User has no avatar.");
            }

            return user.Adapt<UserAvatarResponseDto>();
        }
    }
}
