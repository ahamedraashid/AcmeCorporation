using System.Threading.Tasks;
using AcmeCorporation.API.Data.Models;

namespace AcmeCorporation.API.Services
{
    public interface IAuthService
    {
        User Authenticate(string email, string password);
        User Register(User user, string password);
        // void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

    }
}