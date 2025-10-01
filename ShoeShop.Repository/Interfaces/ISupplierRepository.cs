// FILE: ShoeShop.Repository\Interfaces\ISupplierRepository.cs

using ShoeShop.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Repository.Interfaces
{
    public interface ISupplierRepository
    {
        // Ang mga methods na ito ay tumutugma sa iyong SupplierRepository.cs implementation
        Task<Supplier> AddSupplierAsync(Supplier supplier);
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
        Task<Supplier?> GetSupplierByIdAsync(int supplierId);
        Task UpdateSupplierAsync(Supplier supplier);
        // Tiyakin na Public ang interface
    }
}