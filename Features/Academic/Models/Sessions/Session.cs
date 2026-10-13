using Backend.Shared.Common.Entities;

namespace Backend.Features.Academic.Models.Sessions
{
    public sealed class Session : BaseEntity
    {
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public bool IsExpired => EndDate <= DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
