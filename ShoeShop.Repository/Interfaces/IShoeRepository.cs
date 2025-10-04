<<<<<<< HEAD:ShoeShop.Repository/Data/Interfaces/IShoeRepository.cs
﻿using System.Collections.Generic;
using System.Threading.Tasks;
// Tiyakin na tama ang 'using' directive na ito para sa 'Shoe' entity mo.
using ShoeShop.Repository.Entities;
=======
﻿using ShoeShop.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
>>>>>>> origin/memberC:ShoeShop.Repository/Interfaces/IShoeRepository.cs

namespace ShoeShop.Repository.Interfaces
{
    // Ito ang KONTATA na kailangan mong sundin.
    public interface IShoeRepository
    {
<<<<<<< HEAD:ShoeShop.Repository/Data/Interfaces/IShoeRepository.cs
        // 1. SAVE CHANGES (Ito ang fix para sa CS0738)
        // Kailangang mag-return ng Task<int>
        Task<int> SaveChangesAsync();

        // 2. GET ALL (Ito ang fix para sa CS0535)
        // Ang InventoryService mo ay gumagamit ng GetAllWithVariationsAsync
        Task<IEnumerable<Shoe>> GetAllWithVariationsAsync();

        // 3. GET BY ID (Ito ang fix para sa CS0535)
        // Ang InventoryService mo ay gumagamit ng GetByIdWithVariationsAsync(int id)
        Task<Shoe?> GetByIdWithVariationsAsync(int id);

        // 4. DELETE (Ito ang fix para sa CS0535)
        // Ang InventoryService mo ay gumagamit ng DeleteAsync(Shoe shoe)
        Task DeleteAsync(Shoe shoe);

        // --- Iba pang Methods na Ginagamit ng InventoryService at ShoeRepository ---

        // AddAsync (Simple Add method)
        Task AddAsync(Shoe entity);

        // UpdateAsync (Simple Update method)
        Task UpdateAsync(Shoe shoe);

        // GetShoeByColorVariationIdAsync (Base sa iyong orihinal na snippet)
=======
        Task<Shoe> AddShoeAsync(Shoe shoe);
        Task<IEnumerable<Shoe>> GetAllShoesAsync();
        Task<Shoe?> GetShoeByIdAsync(int id);
        Task UpdateShoeAsync(Shoe shoe);
        Task DeleteShoeAsync(int id);

>>>>>>> origin/memberC:ShoeShop.Repository/Interfaces/IShoeRepository.cs
        Task<Shoe?> GetShoeByColorVariationIdAsync(int colorVariationId);
    }
}