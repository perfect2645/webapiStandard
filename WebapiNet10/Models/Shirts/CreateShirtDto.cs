using System.ComponentModel.DataAnnotations;
using WebapiNet10.Models.Shirts.Validations;

namespace WebapiNet10.Models.Shirts
{
    public class CreateShirtDto
    {
        [Required(ErrorMessage = "Shirt Brand is required")]
        public required string Brand { get; set; }
        [Required(ErrorMessage = "Gender for shirts is required")]
        public required string Gender { get; set; }
        [Required(ErrorMessage = "Shrit color is required")]
        public required string Color { get; set; }
        [CorrectSizing]
        public int Size { get; set; }
        public double Price { get; set; }
    }
}
