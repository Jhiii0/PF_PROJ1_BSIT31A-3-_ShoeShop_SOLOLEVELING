<<<<<<< HEAD
﻿using ShoeShop.Services.DTOs;
=======
﻿using ShoeShop.Services.DTOs; // FINAL FIX: Kailangan ito para makita ang ShoeDto at CreateShoeDto
>>>>>>> origin/memberC
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Services.Interfaces
{
<<<<<<< HEAD
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
=======
    // FINAL FIX: Tiyakin na public ang interface
    public interface IInventoryService
    {
        // Ang mga DTOs na ito ay makikita na dahil sa using statement
        Task<ShoeDto> CreateShoeAsync(CreateShoeDto shoeDto);
        Task<IEnumerable<ShoeDto>> GetAllShoesAsync();
        Task<ShoeDto?> GetShoeByIdAsync(int id);
        Task UpdateShoeAsync(int id, CreateShoeDto updatedShoeDto);
        Task DeleteShoeAsync(int id);

        // Stock adjustment methods
        Task<bool> AdjustStockAsync(int colorVariationId, int quantityChange, string reason, string user);
        Task<int> GetStockQuantityAsync(int colorVariationId);
>>>>>>> origin/memberC
    }
}