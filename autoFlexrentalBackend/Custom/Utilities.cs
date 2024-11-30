using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using autoFlexrentalBackend.Models;
using Microsoft.IdentityModel.Tokens;

namespace autoFlexrentalBackend.Custom
{
    public class Utilities
    {
        private readonly IConfiguration _configuration;
        public Utilities(IConfiguration configuration) { 
            _configuration = configuration;
        }

        //Build hashPassword
        public string encryptSHA256(string plaintext) {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plaintext));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) { 
                    builder.Append(bytes[i].ToString("x2"));
                }


                return builder.ToString();
            }
        }

        //Build token
        public string generateJWT(User model)
        {
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, model.UserId.ToString()),
                new Claim(ClaimTypes.Email, model.Email!),
                new Claim(ClaimTypes.Role, model.Role!)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var jwtConfig = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }
    }
}
