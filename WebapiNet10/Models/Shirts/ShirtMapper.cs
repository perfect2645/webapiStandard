
using Fawei.Repository.Entities.Shirts;

namespace WebapiNet10.Models.Shirts
{
    public static class ShirtMapper
    {
        public static ShirtDto ToDto(this Shirt shirt)
        {
            return new ShirtDto
            {
                ShirtId = shirt.ShirtId,
                Brand = shirt.Brand,
                Gender = shirt.Gender,
                Size = shirt.Size,
                Color = shirt.Color,
                Price = shirt.Price
            };
        }

        public static ShirtDto ToDto(this CreateShirtDto createShirtDto)
        {
            return new ShirtDto
            {
                Brand = createShirtDto.Brand,
                Gender = createShirtDto.Gender,
                Size = createShirtDto.Size,
                Color = createShirtDto.Color,
                Price = createShirtDto.Price
            };
        }

        public static Shirt ToEntity(this ShirtDto shirtDto)
        {
            return new Shirt
            {
                ShirtId = shirtDto.ShirtId,
                Brand = shirtDto.Brand,
                Gender = shirtDto.Gender,
                Size = shirtDto.Size,
                Color = shirtDto.Color,
                Price = shirtDto.Price
            };
        }

        public static Shirt ToEntity(this CreateShirtDto createShirtDto)
        {
            return new Shirt
            {
                Brand = createShirtDto.Brand,
                Gender = createShirtDto.Gender,
                Size = createShirtDto.Size,
                Color = createShirtDto.Color,
                Price = createShirtDto.Price
            };
        }
    }
}
