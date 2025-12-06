using System.ComponentModel.DataAnnotations;

namespace WebapiNet10.Models.Shirts
{
    public class ShirtDto
    {
        public int ShirtId { get; set; }
        [Required(ErrorMessage ="Shirt Brand is required")]
        public required string Brand { get; set; }
        [Required(ErrorMessage = "Gender for shirts is required")]
        public required string Gender { get; set; }
        [Required(ErrorMessage = "Shrit color is required")]
        public required string Color { get; set; }
        public int Size { get; set; }
        public double Price { get; set; }
    }
}
