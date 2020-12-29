using System.Collections.Generic;
using System.Threading.Tasks;
using AcmeCorporation.API.Data.Models;

namespace AcmeCorporation.API.Data.Contracts
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        Task<IEnumerable<Product>> GetActiveProducts();
    }
}