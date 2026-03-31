using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using KTBioAPI.Models;

namespace KTBioAPI.Helpers
{
    public class JwtHelper
    {
        private readonly IConfiguration _configuration;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Generate both an access token (short-lived) and a refresh token (long-lived).
        /// </summary>
        public (string accessToken, string refreshToken) GenerateTokenPair(Utilisateur user)
        {
            var accessToken  = BuildToken(user, isRefresh: false);
            var refreshToken = BuildToken(user, isRefresh: true);
            return (accessToken, refreshToken);
        }

        /// <summary>
        /// Legacy helper kept for backward-compatibility — returns only the access token.
        /// </summary>
        public string GenerateToken(Utilisateur user) => GenerateTokenPair(user).accessToken;

        /// <summary>
        /// Validate a refresh token. Returns the ClaimsPrincipal on success, null on failure.
        /// </summary>
        public ClaimsPrincipal? ValidateRefreshToken(string token)
        {
            try
            {
                var secretKey = RequireSecretKey();
                var handler   = new JwtSecurityTokenHandler();

                var parameters = new TokenValidationParameters
                {
                    ValidateIssuer           = true,
                    ValidateAudience         = true,
                    ValidateLifetime         = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer              = _configuration["JwtSettings:Issuer"],
                    ValidAudience            = _configuration["JwtSettings:Audience"],
                    IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ClockSkew                = TimeSpan.Zero
                };

                var principal = handler.ValidateToken(token, parameters, out var validated);

                // Must be tagged as a refresh token
                var tokenType = principal.FindFirst("token_type")?.Value;
                if (tokenType != "refresh") return null;

                return principal;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Validate an access token. Returns the ClaimsPrincipal on success, null on failure.
        /// </summary>
        public ClaimsPrincipal? ValidateToken(string token)
        {
            try
            {
                var secretKey = RequireSecretKey();
                var handler   = new JwtSecurityTokenHandler();

                var parameters = new TokenValidationParameters
                {
                    ValidateIssuer           = true,
                    ValidateAudience         = true,
                    ValidateLifetime         = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer              = _configuration["JwtSettings:Issuer"],
                    ValidAudience            = _configuration["JwtSettings:Audience"],
                    IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ClockSkew                = TimeSpan.Zero
                };

                return handler.ValidateToken(token, parameters, out _);
            }
            catch
            {
                return null;
            }
        }

        // ── Private helpers ───────────────────────────────────────────────────

        private string BuildToken(Utilisateur user, bool isRefresh)
        {
            var secretKey   = RequireSecretKey();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub,  user.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                new(ClaimTypes.NameIdentifier,    user.Id.ToString()),
                new(ClaimTypes.Name,              user.Username),
                new(ClaimTypes.Role,              user.Role),
                new(ClaimTypes.GivenName,         user.FullName),
                new(ClaimTypes.Email,             user.Email ?? ""),
                new(JwtRegisteredClaimNames.Jti,  Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Iat,  DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                new("token_type",                 isRefresh ? "refresh" : "access")
            };

            DateTime expires;
            if (isRefresh)
            {
                var days = _configuration.GetValue<int>("JwtSettings:RefreshTokenExpirationDays", 7);
                expires = DateTime.UtcNow.AddDays(days);
            }
            else
            {
                var minutes = _configuration.GetValue<int>("JwtSettings:ExpirationMinutes", 60);
                expires = DateTime.UtcNow.AddMinutes(minutes);
            }

            var token = new JwtSecurityToken(
                issuer:             _configuration["JwtSettings:Issuer"],
                audience:           _configuration["JwtSettings:Audience"],
                claims:             claims,
                expires:            expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string RequireSecretKey()
        {
            var key = _configuration["JwtSettings:SecretKey"];
            if (string.IsNullOrEmpty(key))
                throw new InvalidOperationException("JWT SecretKey not configured");
            return key;
        }
    }
}
