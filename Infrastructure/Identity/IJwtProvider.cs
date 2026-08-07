using Backend.Features.Users.Models;

namespace Backend.Infrastructure.Identity
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}

/*
Include Claims:

sub
email
role
userId
*/
