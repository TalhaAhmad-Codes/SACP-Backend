using Backend.Features.Academic.Models.Institutions.Queries.GetInstitutionById;
using Backend.Shared.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Shared.Controllers
{
    [ApiController]
    // [Route("api/[controller]")]
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
