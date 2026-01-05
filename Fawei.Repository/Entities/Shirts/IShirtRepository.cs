
using NetUtils.Repository;

namespace Fawei.Repository.Entities.Shirts
{
    public interface IShirtRepository : IRepository<Shirt, int>
    {
        Task<Shirt?> GetByPropertiesAsync(string brand, string gender, string color, int size);
    }
}
