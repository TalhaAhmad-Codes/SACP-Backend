using Backend.Features.Users.Models;
using Backend.Features.Users.Providers.Interfaces;
using Backend.Features.Users.Responses;
using Backend.Infrastructure.Identity;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Exceptions;
using Mapster;
using MediatR;

namespace Backend.Features.Users.Commands.CreateUser
{
    public sealed class CreateUserHandler : IRequestHandler<CreateUserCommand, UserResponseDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserProvider _userProvider;

        public CreateUserHandler(ApplicationDbContext context, IUserProvider userProvider)
        {
            _context = context;
            _userProvider = userProvider;
        }

        public async Task<UserResponseDto> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var existsByEmail = await _userProvider.ExistsByEmailAsync(
                request.Email,
                cancellationToken
            );

            if (existsByEmail)
            {
                throw new InvalidRequestException("User is already registered");
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

            return user.Adapt<UserResponseDto>();
        }
    }
}
