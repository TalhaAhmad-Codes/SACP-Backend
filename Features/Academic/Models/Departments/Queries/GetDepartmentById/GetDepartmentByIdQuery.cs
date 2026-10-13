using Backend.Features.Academic.Models.Departments.Responses;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Departments.Queries.GetDepartmentById
{
    public sealed class GetDepartmentByIdQuery : BaseDto, IRequest<DepartmentResponseDto> { }
}
