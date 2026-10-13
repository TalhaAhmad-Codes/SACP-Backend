using Backend.Features.Academic.Models.Admins.Responses;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Admins.Queries.GetAdminById
{
    public sealed class GetAdminByIdQuery : BaseDto, IRequest<AdminResponseDto> { }
}
