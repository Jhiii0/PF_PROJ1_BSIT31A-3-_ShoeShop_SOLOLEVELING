using System.Collections.Generic;
using System.Threading.Tasks;
// Tiyakin na tama ang 'using' directive na ito para sa 'Shoe' entity mo.
using ShoeShop.Repository.Entities;
using System.Collections.Generic; 
using System.Threading.Tasks;

namespace ShoeShop.Repository.Interfaces
{
    // Ito ang KONTATA na kailangan mong sundin.
    public interface IShoeRepository
    {
        Task<Shoe> GetShoeByIdAsync(int id);
        Task<IEnumerable<Shoe>> GetAllShoesAsync();
        Task<Shoe> AddShoeAsync(Shoe shoe);
        Task UpdateShoeAsync(Shoe shoe);
        Task DeleteShoeAsync(int id);
    }
}