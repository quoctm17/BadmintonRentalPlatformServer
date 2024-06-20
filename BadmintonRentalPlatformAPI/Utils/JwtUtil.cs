using BusinessObjects;
using BusinessObjects.Commons;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BadmintonRentalPlatformAPI.Utils
{
    public class JwtUtil
    {
        public static string GenerateJwtToken(UserEntity user, Tuple<string, Guid> guidClaim)
        {
            JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();
            SymmetricSecurityKey secrectKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConfig.JwtSetting.SecretKey));
            var credentials = new SigningCredentials(secrectKey, SecurityAlgorithms.HmacSha256Signature);
            string issuer = AppConfig.JwtSetting.IssuerSigningKey!;
            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                //new Claim(ClaimTypes.Role, user.Role.RoleName),
            };
            if (guidClaim != null) claims.Add(new Claim(guidClaim.Item1, guidClaim.Item2.ToString()));
            /*var expires = user.Role.RoleName.Equals(RoleEnum.User.GetDescriptionFromEnum())
                ? DateTime.Now.AddDays(1)
                : DateTime.Now.AddDays(30);*/
            var expires = DateTime.Now.AddDays(1);
            var token = new JwtSecurityToken(issuer, null, claims, notBefore: DateTime.Now, expires, credentials);
            return jwtHandler.WriteToken(token);
        }
    }
}
