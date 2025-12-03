using Fawei.Repository.Core;

namespace Fawei.Repository.Entities.Shirts
{
    internal interface IShirtRepository : IRepository<Shirt>
    {
        Task<Shirt?> GetByPropertiesAsync(string brand, string gender, string color, int size);
    }
}
