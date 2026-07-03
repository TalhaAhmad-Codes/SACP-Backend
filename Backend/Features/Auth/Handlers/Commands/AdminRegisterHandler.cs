using Backend.Features.Academic.Models;
using Backend.Features.Auth.Commands.Register;
using Backend.Features.Users.Models;
using Backend.Features.Users.Models.Enums;
using Backend.Infrastructure.Identity;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Auth.Handlers.Commands
{
    public sealed class AdminRegisterHandler : IRequestHandler<AdminRegisterCommand, Guid>
    {
        private readonly ApplicationDbContext _context;

        public AdminRegisterHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<bool> ExistsByEmailAsync(
            string email,
            CancellationToken cancellationToken
        ) => await _context.Users.AnyAsync(u => u.Email == email.Trim(), cancellationToken);

        private async Task<bool> DoesInstitutionExistAsync(
            string institutionName,
            CancellationToken cancellationToken
        ) =>
            await _context.Institutions.AnyAsync(
                i => i.Name.ToLower() == institutionName.ToLower(),
                cancellationToken
            );

        public async Task<Guid> Handle(
            AdminRegisterCommand request,
            CancellationToken cancellationToken
        )
        {
            // * Create User Profile
            var isRegistered = await ExistsByEmailAsync(request.Email, cancellationToken);

            if (isRegistered)
                throw new NotExistsException("User with the given email is already registered");

            if (request.Password != request.ConfirmPassword)
                throw new NotExistsException("Password doesn't match");

            var user = new User()
            {
                Username = request.Username.Trim(),
                Email = request.Email.Trim(),
                PasswordHash = PasswordHasher.Hash(request.Password),
                Role = UserRole.Admin,
            };

            // * Create Institution
            var doesInstitutionExist = await DoesInstitutionExistAsync(
                request.InstitutionName.Trim(),
                cancellationToken
            );

            if (doesInstitutionExist)
                throw new NotExistsException("Institution with this name is already registered");

            var institution = new Institution() { Name = request.InstitutionName.Trim() };

            // * Create Admin profile
            var admin = new Admin()
            {
                Name = new()
                {
                    FirstName = request.FirstName.Trim(),
                    LastName = request.LastName.Trim(),
                },
                User = user,
                Institution = institution,
            };

            // * Add data and commit transaction
            await _context.Users.AddAsync(user);
            await _context.Institutions.AddAsync(institution);
            await _context.Admins.AddAsync(admin);

            await _context.SaveChangesAsync(cancellationToken);

            // * Return the id of user
            return user.Id;
        }
    }
}
