using ProjetNoelAPI.Models;
using System.IdentityModel.Tokens.Jwt;

namespace ProjetNoelAPI.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(User user);

        List<User> GenerateJwtTokenForUser(List<User> users);

        Task<JwtSecurityToken?> ReadJwtToken(string token);
    }
}
