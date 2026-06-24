using Backend.Features.Academic.Models;
using Backend.Features.Users.Models.Enums;
using Backend.Features.Users.Models.ValueObjects;
using Backend.Shared.Common;

namespace Backend.Features.Users.Models
{
    public sealed class User : BaseEntity
    {
        public Avatar Avatar { get; set; } = new();
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public UserRole Role { get; set; }
        public bool IsActive { get; set; }

        // * Relations
        public ICollection<RefreshToken> RefreshTokens { get; set; }
        public Admin Admin { get; set; }
        public FacultyMember FacultyMember { get; set; }
        public Student Student { get; set; }
    }
}
