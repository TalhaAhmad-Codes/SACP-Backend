using Backend.Features.Academic.Models.Departments;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using MediatR;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Backend.Features.Academic.Models.Degrees.Commands.UpdateDegree
{
    public sealed class UpdateDegreeHandler : IRequestHandler<UpdateDegreeCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IDegreeProvider _provider;

        public UpdateDegreeHandler(ApplicationDbContext context, IDegreeProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        public async Task<Unit> Handle(
            UpdateDegreeCommand request,
            CancellationToken cancellationToken
        )
        {
            var degree = await _provider.GetByIdAsync(request.Id);

            degree.Title = request.Title;
            degree.Code = request.Code;
            degree.DepartmentId = request.DepartmentId;
            degree.MarkUpdated();

            _context.Degrees.Update(degree);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
