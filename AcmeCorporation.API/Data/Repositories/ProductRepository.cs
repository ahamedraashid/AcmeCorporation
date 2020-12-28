using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeCorporation.API.Data.Contracts;
using AcmeCorporation.API.Data.Models;
using AcmeCorporation.API.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorporation.API.Data.Repositories
{
    public class ProductRepository : EntityRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public override IQueryable<Product> GetAll()
        {
            return dbSet.Include(t => t.Transactions).Where(p => p.IsDeleted == false);
        }

        public override Task<Product> Get(int id)
        {
            return dbSet.Include(t => t.Transactions).Include(s => s.Photos).SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<Product>> GetActiveProducts()
        {
            return await dbSet.Include(t => t.Transactions).Include(s => s.Photos)
                            .Where(p => p.Status == ProductStatus.Active || p.Status == ProductStatus.Inactive).ToListAsync();
        }

        public override void Delete(int id)
        {
            // var entity = await Get(id);
            var product = dbSet.Find(id);
            product.IsDeleted = true;
        }
    }
}