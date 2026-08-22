using Backend.Features.Auth.Commands.Login;
using Backend.Features.Users.Models;
using Backend.Infrastructure.Identity;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Auth.Handlers.Commands
{
    public sealed class UserLoginHandler : IRequestHandler<UserLoginCommand, Guid>
    {
        private readonly ApplicationDbContext _context;

        public UserLoginHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<User?> GetByEmailAsync(
            string email,
            CancellationToken cancellationToken
        ) => await _context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

        public async Task<Guid> Handle(
            UserLoginCommand request,
            CancellationToken cancellationToken
        )
        {
            var user =
                await GetByEmailAsync(request.Email, cancellationToken)
                ?? throw new NotExistsException("Email is not registered");

            if (!PasswordHasher.Verify(request.Password, user.PasswordHash))
                throw new NotExistsException("Incorrect password");

            return user.Id;
        }
    }
}
