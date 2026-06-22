using Backend.Features.Users.Commands.CreateUser;
using Backend.Features.Users.Models;
using Backend.Infrastructure.Identity;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Users.Handlers.Commands
{
    public sealed class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly ApplicationDbContext _context;

        public CreateUserHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<bool> ExistsByEmail(string email, CancellationToken cancellationToken) =>
            await _context.Users.AnyAsync(u => u.Email == email, cancellationToken);

        public async Task<Guid> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var existsByEmail = await ExistsByEmail(request.Email, cancellationToken);

            if (existsByEmail)
            {
                throw new DomainException("User with this email is already registered");
            }

            var user = new User()
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = PasswordHasher.Hash(request.Password),
                Role = request.Role,
            };

            await _context.AddAsync(user);
            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
