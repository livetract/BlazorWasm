using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using JwtAuth.Dtos;
using JwtAuth.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace JwtAuth.Services
{
    public class GeneralService : IGeneralService
    {
        private JwtSettings JwtSettings { get; set; }
        private KeySettings KeySettings { get; set; }
        
        public GeneralService(IConfiguration configuration)
        {
            JwtSettings = new JwtSettings();
            KeySettings = new KeySettings();
            
            configuration.Bind("JwtSettings", JwtSettings);
            configuration.Bind("KeySettings", KeySettings);
        }
        
        public string BuildToken(JwtDto model)
        {
            Claim[] claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, model.UserName), 
                new Claim(JwtRegisteredClaimNames.Jti, model.Id.ToString()), 
            };
            
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.SecretKey));
            
            var creds = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken(
                issuer:JwtSettings.Issuer,
                audience:JwtSettings.Audience,
                claims:claims,
                expires:DateTime.Now.AddMinutes(JwtSettings.ExpiressTime),
                signingCredentials:creds);
            
            var resultToken = new JwtSecurityTokenHandler().WriteToken(token);
            return resultToken;
        }

        public string EncryptPassword(string password)
        {
            
            var bytes = Encoding.UTF8.GetBytes($"{KeySettings.Signatory}+{password}+{KeySettings.Postmark}");
            var hash = SHA256.Create().ComputeHash(bytes);
            var sb = new StringBuilder();
            foreach (var c in hash)
            {
                sb.Append(c.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}