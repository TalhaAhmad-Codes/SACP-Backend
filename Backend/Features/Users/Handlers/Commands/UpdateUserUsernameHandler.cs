using Backend.Features.Users.Commands.UpdateUser;
using Backend.Features.Users.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Users.Handlers.Commands
{
    public sealed class UpdateUserUsernameHandler : IRequestHandler<UpdateUserUsernameCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserProvider _userProvider;

        public UpdateUserUsernameHandler(ApplicationDbContext context, IUserProvider userProvider)
        {
            _context = context;
            _userProvider = userProvider;
        }

        public async Task<Unit> Handle(UpdateUserUsernameCommand request, CancellationToken cancellationToken)
        {
            var user = await _userProvider.GetByIdAsync(request.Id);

            user.Username = request.Username;
            _context.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
