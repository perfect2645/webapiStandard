using WebapiNet10.Models.Shirts;

namespace WebapiNet10.Services.Shirts
{
    public interface IShirtService
    {
        Task<bool> ExistsAsync(int shirtId);
        Task<IEnumerable<ShirtDto>> GetAllShirtsAsync();
        Task<ShirtDto?> GetShirtByIdAsync(int shirtId);
        Task<ShirtDto?> GetShirtByPropertiesAsync(string brand, string gender, string color, int size);
        Task UpdateShirtAsync(ShirtDto shirtDto);
        Task<ShirtDto> AddShirtAsync(CreateShirtDto createShirtDto);
        Task<ShirtDto?> DeleteShirtAsync(int shirtId);
    }
}
