using Backend.Features.Users.Models.Enums;
using Backend.Shared.Common.DTOs;

namespace Backend.Features.Users.Responses
{
    public sealed class UserResponse : BaseResponseDto
    {
        public string Username { get; init; }
        public string Email { get; init; }
        public UserRole Role { get; init; }
        public bool IsActive { get; init; }
    }
}
