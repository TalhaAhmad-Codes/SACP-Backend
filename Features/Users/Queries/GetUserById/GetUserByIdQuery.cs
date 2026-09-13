using Backend.Features.Users.Responses;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Users.Queries.GetUserById
{
    public sealed class GetUserByIdQuery : BaseDto, IRequest<UserResponse> { }
}
