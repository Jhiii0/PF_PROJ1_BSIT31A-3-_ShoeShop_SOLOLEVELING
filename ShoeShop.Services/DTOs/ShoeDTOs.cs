<<<<<<< HEAD
﻿namespace ShoeShop.Services.DTOs
=======
<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;

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

=======
<<<<<<< HEAD
﻿namespace ShoeShop.Services.DTOs
=======
﻿// FILE: ShoeShop.Services\DTOs\ShoeDTOs.cs

namespace ShoeShop.Services.DTOs
>>>>>>> origin/memberC
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
{
    public class ShoeDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
        public double RetailPrice { get; set; }
        public bool IsActive { get; set; }

        // ✅ Dapat ito ay ColorVariationDto
        public List<ColorVariationDto> ColorVariations { get; set; } = new();
    }
}
<<<<<<< HEAD
=======
=======
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
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a

    public class ShoeColorVariationDto
    {
        public int Id { get; set; }
<<<<<<< HEAD
        public int ShoeId { get; set; }
        public string ColorName { get; set; }
        public string HexCode { get; set; }
        public int StockQuantity { get; set; }
        public int ReorderLevel { get; set; }
        public bool IsLowStock => StockQuantity <= ReorderLevel;
    }
}
=======
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
>>>>>>> origin/memberC
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
