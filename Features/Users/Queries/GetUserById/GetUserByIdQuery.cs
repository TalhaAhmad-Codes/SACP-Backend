using Backend.Features.Users.Responses;
using MediatR;

namespace Backend.Features.Users.Queries.GetUserById
{
    public sealed record GetUserByIdQuery(Guid UserId) : IRequest<UserResponse>;
}
