using ShoeShop.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Repository.Data.Interfaces
{
    public interface IShoeRepository
    {
        Task<IEnumerable<Shoe>> GetAllAsync();
        Task<IEnumerable<Shoe>> GetAllShoesAsync();
        Task<IEnumerable<Shoe>> GetAllWithVariationsAsync();
        Task<Shoe?> GetByIdAsync(int id);
        Task<Shoe?> GetByIdWithVariationsAsync(int id);

        // This is the new method definition that fixes the error
        Task<ShoeColorVariation?> GetColorVariationByIdAsync(int id);

        Task AddAsync(Shoe shoe);
        Task UpdateAsync(Shoe shoe);
        Task DeleteAsync(Shoe shoe);
        Task SaveChangesAsync();
    }
}