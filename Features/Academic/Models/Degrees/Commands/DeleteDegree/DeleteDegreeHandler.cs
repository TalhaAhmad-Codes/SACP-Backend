using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Academic.Models.Degrees.Commands.DeleteDegree
{
    public sealed class DeleteDegreeHandler : IRequestHandler<DeleteDegreeCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IDegreeProvider _provider;

        public DeleteDegreeHandler(ApplicationDbContext context, IDegreeProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        public async Task<Unit> Handle(
            DeleteDegreeCommand request,
            CancellationToken cancellationToken
        )
        {
            var degree = await _provider.GetByIdAsync(request.Id);

            _context.Degrees.Remove(degree);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
