using Microsoft.EntityFrameworkCore;
using NetUtils.Repository;
using Utils.Ioc;

namespace Fawei.Repository.Entities.Shirts
{
    [Register(ServiceType = typeof(IShirtRepository), Lifetime = Lifetime.Scoped)]
    public class ShirtRepository : RepositoryBase<Shirt, int>, IShirtRepository
    {
        private readonly ShirtsDbContext _dbContext;
        public ShirtRepository(ShirtsDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Shirt?> GetByPropertiesAsync(string brand, string gender, string color, int size)
        {
            var targetShirt = DbSet.FirstOrDefaultAsync(s =>
                s.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase)
                && s.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase)
                && s.Color.Equals(color, StringComparison.OrdinalIgnoreCase)
                && s.Size == size);

            return targetShirt;
        }
    }
}
