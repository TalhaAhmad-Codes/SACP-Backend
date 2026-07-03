using Backend.Features.Users.Commands.DeleteUser;
using Backend.Features.Users.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Users.Handlers.Commands
{
    public sealed class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserProvider _userProvider;

        public DeleteUserHandler(ApplicationDbContext context, IUserProvider userProvider)
        {
            _context = context;
            _userProvider = userProvider;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userProvider.GetByIdAsync(request.UserId);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
