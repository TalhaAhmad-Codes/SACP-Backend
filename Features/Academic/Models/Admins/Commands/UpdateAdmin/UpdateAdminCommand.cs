using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Admins.Commands.UpdateAdmin
{
    public sealed class UpdateAdminCommand : BaseDto, IRequest<Unit>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public Guid UserId { get; init; }
        public Guid InstitutionId { get; init; }
    }
}
