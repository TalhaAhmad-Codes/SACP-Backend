using Backend.Shared.Common.Entities;

namespace Backend.Features.Users.Models
{
    public sealed class RefreshToken : BaseEntity
    {
        public Guid UserId { get; set; }

        public string Token { get; set; } = null!;

        public DateTime ExpiresAt { get; set; }

        public bool IsRevoked { get; set; }

        public User User { get; set; } = null!;

        // * Derived properties
        public bool IsExpired => DateTime.UtcNow >= ExpiresAt;

        public bool IsActive => !IsRevoked && !IsExpired;
    }
}
