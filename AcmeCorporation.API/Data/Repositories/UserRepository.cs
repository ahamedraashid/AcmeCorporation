using System.Linq;
using System.Threading.Tasks;
using AcmeCorporation.API.Data.Contracts;
using AcmeCorporation.API.Data.Models;

namespace AcmeCorporation.API.Data.Repositories
{
    public class UserRepository : EntityRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public User GetUserByEmailAddress(string emailAddress)
        {
            return dbSet.FirstOrDefault(u => u.EmailAddress == emailAddress);
        }

        public bool UserExist(string email)
        {
            if (dbSet.Any(u => u.EmailAddress == email)) {
                return true;  
            }

            return false;
        }
    }
}