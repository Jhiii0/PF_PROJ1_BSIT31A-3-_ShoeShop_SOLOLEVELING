<<<<<<< HEAD
﻿using ShoeShop.Services.DTOs;
=======
<<<<<<< HEAD
﻿using ShoeShop.Services.DTOs;
=======
<<<<<<< HEAD
﻿using ShoeShop.Services.DTOs;
=======
﻿using ShoeShop.Services.DTOs; // FINAL FIX: Kailangan ito para makita ang ShoeDto at CreateShoeDto
>>>>>>> origin/memberC
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Services.Interfaces
{
<<<<<<< HEAD
=======
<<<<<<< HEAD
    public interface IInventoryService
    {
=======
<<<<<<< HEAD
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
    public interface IInventoryService
    {
        Task<ShoeDto> CreateShoeAsync(CreateShoeDto dto);
        Task<IEnumerable<ShoeDto>> GetAllShoesAsync();
        Task<ShoeDto?> GetShoeByIdAsync(int id);
        Task UpdateShoeAsync(int id, CreateShoeDto dto);
        Task DeleteShoeAsync(int id);
        Task<int> GetStockQuantityAsync(int shoeId);
        Task<bool> AdjustStockAsync(int shoeId, int quantityChange, string reason, string user);

        Task<ColorVariationDto> AddColorVariationAsync(int shoeId, CreateColorVariationDto dto);
        Task<IEnumerable<ColorVariationDto>> GetColorVariationsByShoeIdAsync(int shoeId);
        Task<ColorVariationDto?> GetColorVariationByIdAsync(int variationId);
        Task<ColorVariationDto> UpdateColorVariationAsync(int variationId, CreateColorVariationDto dto);
        Task DeleteColorVariationAsync(int variationId);

        // BAGONG METHOD para sa ReportsController
        Task<IEnumerable<StockPullOutDto>> GetAllPullOutHistoryAsync();
<<<<<<< HEAD
=======
=======
    // FINAL FIX: Tiyakin na public ang interface
    public interface IInventoryService
    {
        // Ang mga DTOs na ito ay makikita na dahil sa using statement
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
        Task<ShoeDto> CreateShoeAsync(CreateShoeDto shoeDto);
        Task<IEnumerable<ShoeDto>> GetAllShoesAsync();
        Task<ShoeDto?> GetShoeByIdAsync(int id);
        Task UpdateShoeAsync(int id, CreateShoeDto updatedShoeDto);
        Task DeleteShoeAsync(int id);

<<<<<<< HEAD
        // Naka-fix na ang return type at arguments (Para sa CS0738 error)
        Task<bool> AdjustStockAsync(int colorVariationId, int quantityChange, string reason, string user);

        // Naka-fix na ang missing method (Para sa CS1061 error sa PullOutService)
        Task<int> GetStockQuantityAsync(int colorVariationId);
=======
        // Stock adjustment methods
        Task<bool> AdjustStockAsync(int colorVariationId, int quantityChange, string reason, string user);
        Task<int> GetStockQuantityAsync(int colorVariationId);
>>>>>>> origin/memberC
>>>>>>> b30b4460a836dea4b1bca5ee8bbf6eb0894b246a
>>>>>>> bcac366a079e9ad835d6feb753f8e19dcc833bc7
    }
}