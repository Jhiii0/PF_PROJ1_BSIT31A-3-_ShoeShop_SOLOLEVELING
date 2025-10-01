using System.ComponentModel.DataAnnotations;

namespace ShoeShop.Services.DTOs
{

    public class CreateShoeDto
    {
        [Required(ErrorMessage = "The shoe name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The name length must be between 3 and 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Brand is required.")]
        [StringLength(50, MinimumLength = 2)]
        public string Brand { get; set; }

        [Range(0.01, 10000.00, ErrorMessage = "The Cost must be a positive number.")]
        public decimal Cost { get; set; }

        [Range(0.01, 10000.00, ErrorMessage = "The Price must be a positive number.")]
        public decimal Price { get; set; }

        public string? Description { get; set; }
        public string? ImageUrl { get; set; }


        public List<CreateShoeColorVariationDto> ColorVariations { get; set; } = new List<CreateShoeColorVariationDto>();
    }


    public class CreateShoeColorVariationDto
    {
        [Required(ErrorMessage = "The Color Name is required.")]
        [StringLength(50)]
        public string ColorName { get; set; }

        [RegularExpression(@"^#?([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$", ErrorMessage = "Invalid Hex Code format.")]
        public string HexCode { get; set; }

        [Range(0, 10000, ErrorMessage = "Initial Stock cannot be negative.")]
        public int StockQuantity { get; set; }
    }


    public class ShoeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<ShoeColorVariationDto> ColorVariations { get; set; } = new List<ShoeColorVariationDto>();
        public decimal TotalStock => ColorVariations.Sum(v => v.StockQuantity);
    }


    public class ShoeColorVariationDto
    {
        public int Id { get; set; }
        public int ShoeId { get; set; }
        public string ColorName { get; set; }
        public string HexCode { get; set; }
        public int StockQuantity { get; set; }
        public int ReorderLevel { get; set; }
        public bool IsLowStock => StockQuantity <= ReorderLevel;
    }
}
