using Backend.Features.Academic.Models.FacultyMembers.Responses;
using Backend.Features.Academic.Providers.Interfaces;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.FacultyMembers.Queries.GetFacultyMemberById
{
    public sealed class GetFacultyMemberByIdHandler
        : IRequestHandler<GetFacultyMemberByIdQuery, FacultyMemberResponseDto>
    {
        private readonly IFacultyMemberProvider _provider;

        public GetFacultyMemberByIdHandler(IFacultyMemberProvider provider) => _provider = provider;

        public async Task<FacultyMemberResponseDto> Handle(
            GetFacultyMemberByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var faculty = await _provider.GetByIdAsync(request.Id);
            return faculty.Adapt<FacultyMemberResponseDto>();
        }
    }
}
