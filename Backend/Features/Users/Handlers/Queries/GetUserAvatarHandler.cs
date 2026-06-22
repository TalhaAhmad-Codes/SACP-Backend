using Backend.Features.Users.Queries.GetAvatar;
using Backend.Features.Users.Responses;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Exceptions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Users.Handlers.Queries
{
    public sealed class GetUserAvatarHandler
        : IRequestHandler<GetUserAvatarQuery, UserAvatarResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetUserAvatarHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserAvatarResponse> Handle(
            GetUserAvatarQuery request,
            CancellationToken cancellationToken
        )
        {
            var user = await _context
                .Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (user is null)
            {
                throw new DomainException("User not found.");
            }

            if (user.Avatar is null || string.IsNullOrWhiteSpace(user.Avatar.ContentType))
            {
                throw new DomainException("User has no avatar.");
            }

            return user.Adapt<UserAvatarResponse>();
        }
    }
}
