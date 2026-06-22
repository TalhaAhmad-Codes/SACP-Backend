using Backend.Features.Users.Commands.DeactiveUser;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Users.Handlers.Commands
{
    public class DeactivateUserHandler : IRequestHandler<DeactivateUserCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public DeactivateUserHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(
            DeactivateUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _context.Users.FindAsync(request.UserId);

            if (user is null)
                return false;

            user.IsActive = false;
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
