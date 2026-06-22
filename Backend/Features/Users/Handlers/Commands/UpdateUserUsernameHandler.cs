using Backend.Features.Users.Commands.UpdateUser;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Users.Handlers.Commands
{
    public sealed class UpdateUserUsernameHandler : IRequestHandler<UpdateUserUsernameCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public UpdateUserUsernameHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(
            UpdateUserUsernameCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _context.Users.FindAsync(request.Id);

            if (user is null)
                return false;

            user.Username = request.Username;
            _context.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
