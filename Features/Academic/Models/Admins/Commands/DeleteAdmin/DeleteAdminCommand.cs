using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Admins.Commands.DeleteAdmin
{
    public sealed class DeleteAdminCommand : BaseDto, IRequest<Unit> { }
}
