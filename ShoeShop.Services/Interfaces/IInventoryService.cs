using ShoeShop.Services.DTOs; // FINAL FIX: Kailangan ito para makita ang ShoeDto at CreateShoeDto
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Services.Interfaces
{
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
    }
}