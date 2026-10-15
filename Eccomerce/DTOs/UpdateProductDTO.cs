namespace Eccomerce.DTOs
{
    public class UpdateProductDTO
    {
        public string ProductName { get; set; }
        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }
    }
}
