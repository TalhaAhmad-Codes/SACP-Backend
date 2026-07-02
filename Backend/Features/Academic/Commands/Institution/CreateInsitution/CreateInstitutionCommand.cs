using Backend.Features.Academic.Responses;
using MediatR;

namespace Backend.Features.Academic.Commands.Institution.CreateInsitution;

public sealed record CreateInstitutionCommand(
    string Name
) : IRequest<InstitutionResponse>;
