using Fawei.Repository.Core;
using Microsoft.EntityFrameworkCore;
using Utils.Ioc;

namespace Fawei.Repository.Entities.Shirts
{
    [Register(ServiceType = typeof(IShirtRepository))]
    public class ShirtRepository : RepositoryBase<Shirt>, IShirtRepository
    {
        public ShirtRepository(DbContext dbContext) : base(dbContext)
        {
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
