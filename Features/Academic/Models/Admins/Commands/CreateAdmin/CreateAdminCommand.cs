using Backend.Features.Academic.Models.Admins.Responses;
using MediatR;

namespace Backend.Features.Academic.Models.Admins.Commands.CreateAdmin
{
    public sealed class CreateAdminCommand : IRequest<AdminResponseDto>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public Guid UserId { get; init; }
        public Guid InstitutionId { get; init; }
    }
}
