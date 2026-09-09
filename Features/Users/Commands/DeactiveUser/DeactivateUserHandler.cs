using Backend.Features.Users.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Users.Commands.DeactiveUser
{
    public class DeactivateUserHandler : IRequestHandler<DeactivateUserCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserProvider _userProvider;

        public DeactivateUserHandler(ApplicationDbContext context, IUserProvider userProvider)
        {
            _context = context;
            _userProvider = userProvider;
        }

        public async Task<Unit> Handle(
            DeactivateUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _userProvider.GetByIdAsync(request.Id);

            user.IsActive = false;
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
