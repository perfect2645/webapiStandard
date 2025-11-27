using WebapiNet10.Models.Shirt;

namespace WebapiNet10.Services
{
    public interface IShirtService
    {
        Task<bool> ExistsAsync();
        Task<IEnumerable<ShirtDto>> GetAllShirtsAsync();
        Task<ShirtDto> GetShirtByIdAsync();
        Task<ShirtDto> GetShirtByPropertiesAsync(string brand, string gender, string color, int size);
        Task UpdateShirtAsync(ShirtDto shirtDto);
        Task AddShirtAsync(ShirtDto shirtDto);
    }
}
