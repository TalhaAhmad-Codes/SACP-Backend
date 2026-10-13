using Backend.Features.Academic.Models.Degrees.Responses;
using Backend.Infrastructure.Persistence;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.Degrees.Commands.CreateDegree
{
    public sealed class CreateDegreeHandler
        : IRequestHandler<CreateDegreeCommand, DegreeResponseDto>
    {
        private readonly ApplicationDbContext _context;

        public CreateDegreeHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DegreeResponseDto> Handle(
            CreateDegreeCommand request,
            CancellationToken cancellationToken
        )
        {
            Degree degree = new()
            {
                Title = request.Title,
                Code = request.Code,
                DepartmentId = request.DepartmentId,
            };

            await _context.Degrees.AddAsync(degree);
            await _context.SaveChangesAsync(cancellationToken);

            return degree.Adapt<DegreeResponseDto>();
        }
    }
}
