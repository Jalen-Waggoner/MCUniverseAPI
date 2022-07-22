using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCUniverse.Data;
using MCUniverse.Data.Entities;
using MCUniverse.Models.Token;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace MCUniverse.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        public TokenService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<TokenResponse> GetTokenAsync(TokenRequest model) 
        {
            var student = await GetValidUserAsync(model);
            if (student is null)
                return null;

            return await GenerateToken(student);
        }

        private async Task<Student> GetValidUserAsync(TokenRequest model)
        {
            var student = await _context.Students.FirstOrDefaultAsync(student => student.Username.ToLower() == model.Username.ToLower());
            if (student is null)
                return null;

            var passwordHasher = new PasswordHasher<Student>();

            var verifyPasswordResult = passwordHasher.VerifyHashedPassword(student, student.Password, model.Password);
            if (verifyPasswordResult == PasswordVerificationResult.Failed)
                return null;

            return student;

        }

       private async Task<TokenResponse> GenerateToken(Student student)
        { 
            var claim = GetClaims(student);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["jwt:Audience"],
                Subject = new ClaimsIdentity(claim),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(14),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenResponse = new TokenResponse
            {
                Token = tokenHandler.WriteToken(token),
                IssuedAt = token.ValidFrom,
                Expires = token.ValidTo,
            };

            return tokenResponse;
        }
        private Claim[] GetClaims(Student student)
        {
            var fullNameAndDOB = $"{student.FullName} {student.DateOfBirth}";
            var name = !string.IsNullOrWhiteSpace(fullNameAndDOB) ? fullNameAndDOB : student.Username;

            var Claims = new Claim[]
            {
                new Claim("Id", student.Id.ToString()),
                new Claim("Username", student.Username),
                new Claim("Email", student.Email),
                new Claim("Name", name)
            };
            return Claims;
        }
    }
}