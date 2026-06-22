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

        public GetUserByIdHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserResponse> Handle(
            GetUserByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var user = await _context.Users.FindAsync(request.UserId);

            if (user is null)
            {
                throw new DomainException("User not found");
            }

            // return new(user.Id, user.Username, user.Email, user.Role, user.IsActive);
            return user.Adapt<UserResponse>();
        }
    }
}
