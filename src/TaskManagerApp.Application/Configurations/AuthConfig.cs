using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Configurations
{
    internal static class AuthConfig
    {
        private static SymmetricSecurityKey SecurityKey { get; set; } =
            new(RandomNumberGenerator.GetBytes(128));

        public static void AddJWTAuth(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            SetCredentials(configuration);

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
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim("UserId", user.Id.ToString()),
                        // TODO add user roles logic
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(
                    SecurityKey,
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private static void SetCredentials(IConfiguration configuration)
        {
            var keyBytes = Encoding.UTF8.GetBytes(configuration.GetValue<string>("Jwt:Secret"));
            SecurityKey = new(keyBytes);
        }
    }
}
