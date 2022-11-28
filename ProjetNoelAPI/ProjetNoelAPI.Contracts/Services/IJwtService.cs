using ProjetNoelAPI.Models;
using System.IdentityModel.Tokens.Jwt;

namespace ProjetNoelAPI.Contracts.Services
{
    public interface IJwtService
    {
        string GenerateJwtToken(User user);

        List<User> GenerateJwtTokenForUser(List<User> users);

        JwtSecurityToken? ReadJwtToken(string token);
    }
}
