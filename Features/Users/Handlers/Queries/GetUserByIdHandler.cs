using Backend.Features.Users.Providers.Interfaces;
using Backend.Features.Users.Queries.GetUserById;
using Backend.Features.Users.Responses;
using Backend.Shared.Exceptions;
using Mapster;
using MediatR;

namespace Backend.Features.Users.Handlers.Queries
{
    public sealed class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly IUserProvider _userProvider;

        public GetUserByIdHandler(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        public async Task<UserResponse> Handle(
            GetUserByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var user = await _userProvider.GetByIdAsync(request.Id, cancellationToken);

            if (user is null)
            {
                throw new NotExistsException();
            }

            return user.Adapt<UserResponse>();
        }
    }
}
