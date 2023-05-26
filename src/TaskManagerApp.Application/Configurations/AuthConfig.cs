using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TaskManagerApp.Application.Utils;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Configurations
{
    internal static class AuthConfig
    {
        private static SymmetricSecurityKey SecurityKey { get; set; } =
            new(RandomNumberGenerator.GetBytes(128));

        public static void AddJWTAuth(
            this IServiceCollection services,
            IConfiguration configuration,
            bool isEnv = false
        )
        {
            SetCredentials(configuration, isEnv);

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        IssuerSigningKey = SecurityKey
                    };
                });
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        }

        public static string CreateToken(User user)
        {
            var claims = new ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("UserId", user.Id.ToString()),
                }
            );
            List<Role> roles =
                user.UserRoles?.Select(ur => ur.Role ?? new Role())?.ToList() ?? new List<Role>();

            foreach (var roleName in roles.Select(r => r.Name))
            {
                claims.AddClaim(new Claim(ClaimTypes.Role, roleName));
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(
                    SecurityKey,
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private static void SetCredentials(IConfiguration configuration, bool isEnv)
        {
            var key = isEnv
                ? EnvUtils.GetEnv("JWT_SECRET")
                : configuration.GetValue<string>("Jwt:Secret");

            if (string.IsNullOrEmpty(key))
            {
                var env = isEnv ? "env" : "appsettings";
                throw new Exception($"JWT Secret from `{env}` is not set");
            }
            var keyBytes = Encoding.UTF8.GetBytes(key);
            SecurityKey = new(keyBytes);
        }
    }
}
