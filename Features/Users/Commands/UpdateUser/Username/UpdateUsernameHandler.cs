using Backend.Features.Users.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Users.Commands.UpdateUser.Username
{
    public sealed class UpdateUsernameHandler : IRequestHandler<UpdateUsernameCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserProvider _userProvider;

        public UpdateUsernameHandler(ApplicationDbContext context, IUserProvider userProvider)
        {
            _context = context;
            _userProvider = userProvider;
        }

        public async Task<Unit> Handle(
            UpdateUsernameCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _userProvider.GetByIdAsync(request.Id);

            user.Username = request.Username;
            user.MarkUpdated();

            _context.Update(user);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
