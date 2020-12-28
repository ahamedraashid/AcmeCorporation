using System.Threading.Tasks;
using AcmeCorporation.API.Data.Models;

namespace AcmeCorporation.API.Data.Contracts
{
    public interface IUserRepository : IEntityRepository<User>
    {
        bool UserExist(string email);
        User GetUserByEmailAddress(string emailAddress);
    }
}