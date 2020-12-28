using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
using AcmeCorporation.API.Data.Contracts;
using AcmeCorporation.API.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AcmeCorporation.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AuthService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }
        public User Authenticate(string email, string password)
        {
            if (email == null || password == null)
            {
                throw new Exception();
            }
            var user =  _userRepository.GetAll().FirstOrDefault(x => x.EmailAddress == email);
            if (user == null)
            {
                return null;
            }
            // return null if user not found
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
             var key = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(_configuration.GetSection("AppSettings:Token").Value));   
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.EmailAddress),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),

                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            // user.ClearPassword();
            return user;
        }

        public User Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _userRepository.Add(user);
            _userRepository.SaveChanges();
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }
    }
}