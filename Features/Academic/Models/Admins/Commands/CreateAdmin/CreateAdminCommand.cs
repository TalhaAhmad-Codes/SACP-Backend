using Backend.Features.Academic.Models.Admins.Responses;
using MediatR;

namespace Backend.Features.Academic.Models.Admins.Commands.CreateAdmin
{
    public sealed class CreateAdminCommand : IRequest<AdminResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid UserId { get; set; }
    }
}
