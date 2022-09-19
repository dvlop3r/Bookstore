namespace Bookstore.Application.Interfaces;

public interface IJwtTokenGenerator
{
    string generateToken(User user);
}