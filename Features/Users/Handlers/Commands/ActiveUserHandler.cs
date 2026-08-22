using Backend.Features.Users.Commands.ActiveUser;
using Backend.Features.Users.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Users.Handlers.Commands
{
    public sealed class ActiveUserHandler : IRequestHandler<ActivateUserCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserProvider _userProvider;

        public ActiveUserHandler(ApplicationDbContext context, IUserProvider userProvider)
        {
            _context = context;
            _userProvider = userProvider;
        }

        public async Task<Unit> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userProvider.GetByIdAsync(request.Id, cancellationToken);

            user.IsActive = true;
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
