// FILE: ShoeShop.Services\DTOs\ShoeDTOs.cs

namespace ShoeShop.Services.DTOs
{
    public class ShoeDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public decimal RetailPrice { get; set; }
        public bool IsActive { get; set; }
        public List<ShoeColorVariationDto> ColorVariations { get; set; } = new List<ShoeColorVariationDto>();
    }

    public class CreateShoeDto
    {
        public string ModelName { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public decimal RetailPrice { get; set; }
        public List<CreateShoeColorVariationDto> ColorVariations { get; set; } = new List<CreateShoeColorVariationDto>();
    }

    public class ShoeColorVariationDto
    {
        public int Id { get; set; }
        public string Color { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public decimal UnitCost { get; set; }
    }

    public class CreateShoeColorVariationDto
    {
        public string Color { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public decimal UnitCost { get; set; }
    }
}