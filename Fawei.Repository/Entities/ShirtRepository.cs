using Fawei.Repository.Core;
using Microsoft.EntityFrameworkCore;

namespace Fawei.Repository.shirt
{
    public class ShirtRepository : RepositoryBase<Shirt>
    {
        public ShirtRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
