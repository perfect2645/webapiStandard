using Fawei.Repository.Core;
using Microsoft.EntityFrameworkCore;

namespace Fawei.Repository.Entities.Shirts
{
    public class ShirtRepository : RepositoryBase<Shirt>
    {
        public ShirtRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
