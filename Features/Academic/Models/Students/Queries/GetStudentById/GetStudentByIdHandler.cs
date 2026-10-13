using Backend.Features.Academic.Models.Students.Responses;
using Backend.Features.Academic.Providers.Interfaces;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.Students.Queries.GetStudentById
{
    public sealed class GetStudentByIdHandler
        : IRequestHandler<GetStudentByIdQuery, StudentResponseDto>
    {
        private readonly IStudentProvider _provider;

        public GetStudentByIdHandler(IStudentProvider provider)
        {
            _provider = provider;
        }

        public async Task<StudentResponseDto> Handle(
            GetStudentByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var student = await _provider.GetByIdAsync(request.Id);
            return student.Adapt<StudentResponseDto>();
        }
    }
}
