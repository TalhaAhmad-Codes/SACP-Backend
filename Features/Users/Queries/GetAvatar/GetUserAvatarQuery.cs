using Backend.Features.Users.Responses;
using MediatR;

namespace Backend.Features.Users.Queries.GetAvatar
{
    public sealed record GetUserAvatarQuery(Guid UserId) : IRequest<UserAvatarResponse>;
}
