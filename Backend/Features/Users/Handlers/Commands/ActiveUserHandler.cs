using Backend.Features.Users.Commands.ActiveUser;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Users.Handlers.Commands
{
    public sealed class ActiveUserHandler : IRequestHandler<ActivateUserCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public ActiveUserHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(
            ActivateUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _context.Users.FindAsync(request.UserId);

            if (user is null)
                return false;

            user.IsActive = true;
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
