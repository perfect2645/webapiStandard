using Fawei.Repository.Core;

namespace Fawei.Repository.Entities.Shirts
{
    public interface IShirtRepository : IRepository<Shirt>
    {
        Task<Shirt?> GetByPropertiesAsync(string brand, string gender, string color, int size);
    }
}
