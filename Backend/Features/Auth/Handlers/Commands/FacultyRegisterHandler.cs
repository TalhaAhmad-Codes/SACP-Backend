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
    public class FacultyRegisterHandler : IRequestHandler<FacultyRegisterCommand, Guid>
    {
        private readonly ApplicationDbContext _context;

        public FacultyRegisterHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<bool> UserExistsByEmailAsync(
            string email,
            CancellationToken cancellationToken
        ) => await _context.Users.AnyAsync(u => u.Email == email, cancellationToken);

        private async Task<FacultyMember?> GetFacultyByEmailAsync(
            string email,
            CancellationToken cancellationToken
        ) =>
            await _context.FacultyMembers.FirstOrDefaultAsync(
                fm => fm.Email == email,
                cancellationToken
            );

        public async Task<Guid> Handle(
            FacultyRegisterCommand request,
            CancellationToken cancellationToken
        )
        {
            // * Check access code
            var faculty = await GetFacultyByEmailAsync(request.Email.Trim(), cancellationToken);

            if (faculty is null)
                throw new NotExistsException(
                    "There's no record of a faculty member having this email"
                );

            if (faculty.AccessCode != request.AccessCode.Trim())
                throw new NotExistsException("The given access code is invalid");

            // * Create User Profile
            var isUserRegistered = await UserExistsByEmailAsync(
                request.Email.Trim(),
                cancellationToken
            );

            if (isUserRegistered)
                throw new NotExistsException("User with the given email is already registered");

            if (request.Password != request.ConfirmPassword)
                throw new NotExistsException("Password doesn't match");

            var user = new User()
            {
                Username = request.Username.Trim(),
                Email = request.Email.Trim(),
                PasswordHash = PasswordHasher.Hash(request.Password),
                Role = UserRole.FacultyMember,
            };

            // * Attach faculty member profile with user profile
            faculty.User = user;

            // * Add data and commit transaction
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
