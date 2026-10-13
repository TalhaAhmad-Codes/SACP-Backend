using Backend.Features.Users.Responses;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Users.Queries.GetAvatar
{
    public sealed class GetUserAvatarQuery : BaseDto, IRequest<UserAvatarResponseDto> { }
}
