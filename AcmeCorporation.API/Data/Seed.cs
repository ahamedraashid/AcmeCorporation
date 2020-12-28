using System.Collections.Generic;
using AcmeCorporation.API.Data.Models;
using AcmeCorporation.API.Shared.Enums;

namespace AcmeCorporation.API.Data
{
    public class Seed
    {
        private readonly ApplicationDbContext _dataContext;
        public Seed(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;

        }

        public void SeedUsers()
        {
            byte[] passwordHash, PasswordSalt;
            CreatePasswordHash("password123", out passwordHash, out PasswordSalt);
            var users = new List<User>()
            {
                new User() {
                    Username = "John Wick",
                    EmailAddress = "johnwick@gmail.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = PasswordSalt,
                    Role = Role.Admin
                },
                new User() {
                    Username = "Peter Park",
                    EmailAddress = "paterpark@gmail.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = PasswordSalt,
                    Role = Role.User
                },
                new User() {
                    Username = "Jason Statham",
                    EmailAddress = "jason@gmail.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = PasswordSalt,
                    Role = Role.User
                }
            };
            _dataContext.Users.AddRange(users);
            _dataContext.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}