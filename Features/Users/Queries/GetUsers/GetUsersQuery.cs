using Backend.Features.Users.Models.Enums;
using Backend.Features.Users.Responses;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Users.Queries.GetUsers
{
    public sealed class GetUsersQuery : BasePagedQuery, IRequest<PagedResultDto<UserResponseDto>>
    {
        public string? Username { get; init; } = null;
        public UserRole? Role { get; init; } = null;
        public bool? IsActive { get; init; } = null;
    }
}
