using Backend.Features.Academic.Models.Institution.Commands.CreateInsitution;
using Backend.Features.Academic.Models.Institution.Responses;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Exceptions;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.Institution.Handlers.Commands
{
    public sealed class CreateInstitutionHandler : IRequestHandler<CreateInstitutionCommand, InstitutionResponse>
    {
        //private readonly ApplicationDbContext _context;
        private readonly IInstitutionProvider _institutionProvider;

        public CreateInstitutionHandler(ApplicationDbContext context, IInstitutionProvider institutionProvider)
        {
            //_context = context;
            _institutionProvider = institutionProvider;
        }

        public async Task<InstitutionResponse> Handle(CreateInstitutionCommand request, CancellationToken cancellationToken)
        {
            var existsByName = await _institutionProvider.ExistsByNameAsync(request.Name.Trim(), cancellationToken);

            if (existsByName)
                throw new InvalidRequestException("Institution is already registered");

            var instutiton = new Institution()
            {
                Name = request.Name.Trim()
            };

            return instutiton.Adapt<InstitutionResponse>();
        }
    }
}
