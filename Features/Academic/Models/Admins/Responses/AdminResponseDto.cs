using Backend.Shared.Common.DTOs;

namespace Backend.Features.Academic.Models.Admins.Responses
{
    public sealed class AdminResponseDto : BaseInstitutionDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid UserId { get; set; }
    }
}
