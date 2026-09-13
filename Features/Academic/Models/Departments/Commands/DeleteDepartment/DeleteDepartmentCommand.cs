using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Departments.Commands.DeleteDepartment
{
    public sealed class DeleteDepartmentCommand : BaseDto, IRequest<Unit> { }
}
