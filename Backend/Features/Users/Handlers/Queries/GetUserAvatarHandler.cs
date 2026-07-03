using Backend.Features.Users.Providers.Interfaces;
using Backend.Features.Users.Queries.GetAvatar;
using Backend.Features.Users.Responses;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Exceptions;
using Mapster;
using MediatR;

namespace Backend.Features.Users.Handlers.Queries
{
    public sealed class GetUserAvatarHandler : IRequestHandler<GetUserAvatarQuery, UserAvatarResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserProvider _userProvider;

        public GetUserAvatarHandler(ApplicationDbContext context, IUserProvider userProvider)
        {
            _context = context;
            _userProvider = userProvider;
        }

        public async Task<UserAvatarResponse> Handle(GetUserAvatarQuery request, CancellationToken cancellationToken)
        {
            var user = await _userProvider.GetByIdAsync(request.UserId, cancellationToken);

            if (user is null)
            {
                throw new NotExistsException();
            }

            if (user.Avatar is null || string.IsNullOrWhiteSpace(user.Avatar.ContentType))
            {
                throw new InvalidRequestException("User has no avatar.");
            }

            return user.Adapt<UserAvatarResponse>();
        }
    }
}
