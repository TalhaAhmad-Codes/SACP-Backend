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
    public sealed class StudentHandler : IRequestHandler<StudentRegisterCommand, Guid>
    {
        private readonly ApplicationDbContext _context;

        public StudentHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<Student?> GetStudentByEmailAsync(
            string email,
            CancellationToken cancellationToken
        ) => await _context.Students.FirstOrDefaultAsync(s => s.Email == email, cancellationToken);

        private async Task<bool> UserExistsByEmailAsync(
            string email,
            CancellationToken cancellationToken
        ) => await _context.Users.AnyAsync(u => u.Email == email, cancellationToken);

        public async Task<Guid> Handle(
            StudentRegisterCommand request,
            CancellationToken cancellationToken
        )
        {
            // * Check registration number
            var student = await GetStudentByEmailAsync(request.Email.Trim(), cancellationToken);

            if (student is null)
                throw new NotExistsException("There's no record of a student having this email");

            if (student.RegistrationNumber != request.RegistrationNumber.Trim())
                throw new NotExistsException("The given registration number is invalid");

            // * Create user profile
            var isRegistered = await UserExistsByEmailAsync(
                request.Email.Trim(),
                cancellationToken
            );

            if (isRegistered)
                throw new NotExistsException("User is already registered");

            if (request.Password != request.ConfirmPassword)
                throw new NotExistsException("Password didn't match");

            var user = new User()
            {
                Username = request.Username.Trim(),
                Email = request.Email.Trim(),
                PasswordHash = PasswordHasher.Hash(request.Password),
                Role = UserRole.Student,
            };

            student.User = user;

            // * Add data and commit transaction
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
