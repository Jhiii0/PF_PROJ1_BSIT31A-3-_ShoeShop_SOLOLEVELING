using ShoeShop.Repository.Entities;
using System.Collections.Generic; 
using System.Threading.Tasks;

namespace ShoeShop.Repository.Interfaces
{
    public interface IShoeRepository
    {
        Task<Shoe?> GetShoeByIdAsync(int id); 
        Task<IEnumerable<Shoe>> GetAllShoesAsync();
        Task<Shoe> AddShoeAsync(Shoe shoe);
        Task UpdateShoeAsync(Shoe shoe);
        Task DeleteShoeAsync(int id);

        Task<Shoe?> GetShoeByColorVariationIdAsync(int colorVariationId);
    }
}