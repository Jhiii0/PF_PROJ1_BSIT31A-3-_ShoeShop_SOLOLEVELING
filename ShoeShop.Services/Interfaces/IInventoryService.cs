using ShoeShop.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Services.Interfaces
{
    public interface IInventoryService
    {
        Task<ShoeDto> CreateShoeAsync(CreateShoeDto shoeDto);
        Task<IEnumerable<ShoeDto>> GetAllShoesAsync();
        Task<ShoeDto?> GetShoeByIdAsync(int id);
        Task UpdateShoeAsync(int id, CreateShoeDto updatedShoeDto);
        Task DeleteShoeAsync(int id);

        // Naka-fix na ang return type at arguments (Para sa CS0738 error)
        Task<bool> AdjustStockAsync(int colorVariationId, int quantityChange, string reason, string user);

        // Naka-fix na ang missing method (Para sa CS1061 error sa PullOutService)
        Task<int> GetStockQuantityAsync(int colorVariationId);
    }
}