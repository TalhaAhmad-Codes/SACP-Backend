using Backend.Features.Academic.Models.Sessions.Responses;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Sessions.Queries.GetSessions
{
    public sealed class GetSessionsQuery
        : BasePagedQuery,
            IRequest<PagedResultDto<SessionResponseDto>>
    {
        public string? Name { get; init; }
        public DateOnly? FromDate { get; init; }
        public DateOnly? ToDate { get; init; }
        public bool? IsExpired { get; init; }
    }
}
