using Fawei.Repository.Entities.Shirts;
using System.Linq.Expressions;
using Utils.Ioc;
using WebapiNet10.Models.Shirts;

namespace WebapiNet10.Services.Shirts
{
    [Register(ServiceType = typeof(IShirtService))]
    public class ShirtService : IShirtService
    {
        private readonly IShirtRepository _shirtRepository;

        public ShirtService(IShirtRepository shirtRepository) 
        {
            _shirtRepository = shirtRepository;
        }

        public async Task<bool> ExistsAsync(int shirtId)
        {
            Expression<Func<Shirt, bool>> predicate = shirt => shirt.ShirtId == shirtId;
            return await _shirtRepository.ExistAsync(predicate);
        }

        public async Task<IReadOnlyList<ShirtDto>> GetAllShirtsAsync()
        {
            var shirts = await _shirtRepository.GetAllAsync();
            return shirts.Select(s => s.ToDto()).ToList();
        }

        public async Task<ShirtDto?> GetShirtByIdAsync(int shirtId)
        {
            var shirt = await _shirtRepository.GetByIdAsync(shirtId);
            return shirt?.ToDto();
        }

        public async Task<ShirtDto?> GetShirtByPropertiesAsync(string brand, string gender, string color, int size)
        {
            var shirt = await _shirtRepository.GetByPropertiesAsync(brand, gender, color, size);
            return shirt?.ToDto();
        }

        public async Task UpdateShirtAsync(ShirtDto shirtDto)
        {
            await _shirtRepository.UpdateAsync(shirtDto.ToEntity());
            await _shirtRepository.SaveChangeAsync();
        }

        public async Task<ShirtDto> AddShirtAsync(CreateShirtDto createShirtDto)
        {
            var addedShirt = await _shirtRepository.AddAsync(createShirtDto.ToEntity());
            return addedShirt.ToDto();
        }

        public async Task<ShirtDto?> DeleteShirtAsync(int shirtId)
        {
            var shirt = await _shirtRepository.DeleteAsync(shirtId);
            return shirt?.ToDto();
        }
    }
}
