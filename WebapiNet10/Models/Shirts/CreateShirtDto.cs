namespace WebapiNet10.Models.Shirts
{
    public class CreateShirtDto
    {
        public required string Brand { get; set; }
        public required string Gender { get; set; }
        public required string Color { get; set; }
        public int Size { get; set; }
        public double Price { get; set; }
    }
}
