using Backend.Features.Users.Providers.Interfaces;
using Backend.Features.Users.Queries.GetUserById;
using Backend.Features.Users.Responses;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Exceptions;
using Mapster;
using MediatR;

namespace Backend.Features.Users.Handlers.Queries
{
    public sealed class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserProvider _userProvider;

        public GetUserByIdHandler(ApplicationDbContext context, IUserProvider userProvider)
        {
            _context = context;
            _userProvider = userProvider;
        }

        public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userProvider.GetByIdAsync(request.UserId, cancellationToken);

            return user.Adapt<UserResponse>();
        }
    }
}
