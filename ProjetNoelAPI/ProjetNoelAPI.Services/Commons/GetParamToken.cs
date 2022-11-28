using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNoelAPI.Services.Commons
{
    public class GetParamToken
    {
        public static string GetClaimInToken(string? token, string? typeClaim)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken jsonToken = handler.ReadToken(token);
            JwtSecurityToken? tokenS = jsonToken as JwtSecurityToken;
            string result = tokenS.Claims.First(claim => claim.Type == typeClaim).Value;

            return result;
        }
    }
}
